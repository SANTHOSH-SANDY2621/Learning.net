using Learning.NetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.NetCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employees1> Employee { get; set; }
    }
}
