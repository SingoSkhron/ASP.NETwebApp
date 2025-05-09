using Domain.Enums;
using FluentMigrator;

namespace Infrastructure.DataBase.Migrations
{
    [Migration(202505091315)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("academicbuilding")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("address").AsString(250).NotNullable()
                .WithColumn("name").AsString(100).NotNullable();

            Create.Table("auditorium")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("floor_number").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("building_id").AsInt32().ForeignKey("academicbuilding", "id").NotNullable();

            Create.Table("group")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("group_name").AsString(50).NotNullable()
                .WithColumn("education_level").AsString(50).WithDefaultValue("Baccalaureate")
                .WithColumn("education_form").AsString(50).WithDefaultValue("FullTime")
                .WithColumn("admission_year").AsInt32().NotNullable();

            Create.Table("scheduleitems")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("order_number").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("day_of_the_week").AsInt32().NotNullable()
                .WithColumn("start_time").AsTime().NotNullable()
                .WithColumn("end_time").AsTime().NotNullable()
                .WithColumn("building_id").AsInt32().ForeignKey("academicbuilding", "id").NotNullable();

            Create.Table("user")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("type").AsString().NotNullable().WithDefaultValue("Student")
                .WithColumn("first_name").AsString(100).NotNullable()
                .WithColumn("last_name").AsString(100).NotNullable()
                .WithColumn("admission_year").AsInt32().Nullable()
                .WithColumn("group_id").AsInt32().ForeignKey("group", "id").Nullable();

            Create.Table("lesson")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("lesson_type").AsString().NotNullable().WithDefaultValue("Lecture")
                .WithColumn("auditorium_id").AsInt32().ForeignKey("auditorium", "id").NotNullable()
                .WithColumn("building_id").AsInt32().ForeignKey("academicbuilding", "id").NotNullable()
                .WithColumn("professor_id").AsInt32().ForeignKey("user", "id").NotNullable()
                .WithColumn("group_id").AsInt32().ForeignKey("group", "id").NotNullable()
                .WithColumn("schedule_item_id").AsInt32().ForeignKey("scheduleitems", "id").NotNullable();

            Insert.IntoTable("academicbuilding")
                .Row(new
                {
                    address = "г. Ярославль, ул. Союзная, д. 144",
                    name = "Корпус 7"
                });
            Insert.IntoTable("auditorium")
                .Row(new
                {
                    name = "432 лаборатория технической защиты информации",
                    floor_number = 4,
                    building_id = 1
                });
            Insert.IntoTable("group")
                .Row(new
                {
                    group_name = "КБ-41СО",
                    education_level = EducationLevelEnum.Specialty.ToString(),
                    education_form = EducationFormEnum.FullTime.ToString(),
                    admission_year = 2020
                });
            Insert.IntoTable("scheduleitems")
                .Row(new
                {
                    order_number = 1,
                    day_of_the_week = 1,
                    start_time = new TimeSpan(9, 0, 0),
                    end_time = new TimeSpan(10, 30, 0),
                    building_id = 1
                });
            Insert.IntoTable("user")
                .Row(new
                {
                    type = UserTypeEnum.Student.ToString(),
                    first_name = "Johnny",
                    last_name = "Dodepp",
                    admission_year = 2020,
                    group_id = 1
                });
            Insert.IntoTable("lesson")
                .Row(new
                {
                    name = "Математический анализ",
                    lesson_type = LessonTypeEnum.Lecture.ToString(),
                    auditorium_id = 1,
                    building_id = 1,
                    professor_id = 1,
                    group_id = 1,
                    schedule_item_id = 1
                });
        }
        public override void Down()
        {
            Delete.Table("lesson");
            Delete.Table("user");
            Delete.Table("scheduleitems");
            Delete.Table("group");
            Delete.Table("auditorium");
            Delete.Table("academicbuilding");
        }
    }
}
