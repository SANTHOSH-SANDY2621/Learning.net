using FluentMigrator;

namespace Learning.NetCore.Migrations
{
    [Migration(0001)]
    public class CreateTableEmployee : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Employee")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}
