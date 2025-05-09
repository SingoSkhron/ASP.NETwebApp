using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.Migrations
{
    [Migration(202505091315)]
    public class InitialMigration : Migration
    {
        public override void Up() //накат миграции в бд
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("first_name").AsString(100).NotNullable()
                .WithColumn("last_name").AsString(100).NotNullable();
            Create.Table("quizzes")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("quiz_name").AsString(100).NotNullable()
                .WithColumn("description").AsString(255).Nullable()
                .WithColumn("author_id").AsInt32().NotNullable().ForeignKey("users", "id");
            Insert.IntoTable("users")
                .Row(new { first_name = "Test", last_name = "User" });
            Insert.IntoTable("quizzes")
                .Row(new { quiz_name = "Test", description = "Description", author_id = 1 });
        }
        public override void Down() //откат миграции в бд
        {
            Delete.Table("users");
            Delete.Table("quizzes");
        }
    }
}
