using System.Reflection;
using FluentMigrator.Runner;
using Learning.NetCore;
using Learning.NetCore.BLogic;
using Learning.NetCore.BLogic.IBLogic;
using Learning.NetCore.Repo;
using Learning.NetCore.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("mssql")));


builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer() 
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("mssql"))
        .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

//repo registration
builder.Services.AddTransient<IEmployeeLogic, EmployeeLogic>();
builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();    
    runner.MigrateUp();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
