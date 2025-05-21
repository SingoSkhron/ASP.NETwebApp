using Domain.Enums;
using FluentMigrator;

namespace Infrastructure.DataBase.Migrations
{
    [Migration(202505091315)]
    public class InitialMigration : Migration
    {

        public override void Up()
        {
            Create.Table("academic_buildings")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("address").AsString(250).NotNullable()
                .WithColumn("name").AsString(100).NotNullable();

            Create.Table("auditoriums")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("floor_number").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("building_id").AsInt32().ForeignKey("academic_buildings", "id").NotNullable();

            Create.Table("groups")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("group_name").AsString(50).NotNullable()
                .WithColumn("education_level").AsString(50)
                .WithColumn("education_form").AsString(50)
                .WithColumn("admission_year").AsInt32().NotNullable();

            Create.Table("schedule_items")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("order_number").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("day_of_the_week").AsInt32().NotNullable()
                .WithColumn("start_time").AsCustom("Time").NotNullable()
                .WithColumn("end_time").AsCustom("Time").NotNullable()
                .WithColumn("building_id").AsInt32().ForeignKey("academic_buildings", "id").NotNullable();

            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("type").AsString().NotNullable().WithDefaultValue("Student")
                .WithColumn("first_name").AsString(100).NotNullable()
                .WithColumn("last_name").AsString(100).NotNullable()
                .WithColumn("admission_year").AsInt32().Nullable()
                .WithColumn("group_id").AsInt32().ForeignKey("groups", "id").Nullable();

            Create.Table("lessons")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("lesson_type").AsString().NotNullable().WithDefaultValue("Lecture")
                .WithColumn("auditorium_id").AsInt32().ForeignKey("auditoriums", "id").NotNullable()
                .WithColumn("building_id").AsInt32().ForeignKey("academic_buildings", "id").NotNullable()
                .WithColumn("professor_id").AsInt32().ForeignKey("users", "id").NotNullable()
                .WithColumn("group_id").AsInt32().ForeignKey("groups", "id").NotNullable()
                .WithColumn("schedule_item_id").AsInt32().ForeignKey("schedule_items", "id").NotNullable();

            Insert.IntoTable("academic_buildings")
                .Row(new
                {
                    address = "г. Ярославль, ул. Союзная, д. 144",
                    name = "Корпус 7"
                });
            Insert.IntoTable("auditoriums")
                .Row(new
                {
                    name = "432 лаборатория технической защиты информации",
                    floor_number = 4,
                    building_id = 1
                });
            Insert.IntoTable("groups")
                .Row(new
                {
                    group_name = "КБ-41СО",
                    education_level = EducationLevelEnum.Specialty.ToString(),
                    education_form = EducationFormEnum.FullTime.ToString(),
                    admission_year = 2020
                });
            Insert.IntoTable("schedule_items")
                .Row(new
                {
                    order_number = 1,
                    day_of_the_week = 1,
                    start_time = new TimeSpan(9, 0, 0),
                    end_time = new TimeSpan(10, 30, 0),
                    building_id = 1
                });
            Insert.IntoTable("users")
                .Row(new
                {
                    type = UserTypeEnum.Student.ToString(),
                    first_name = "Johnny",
                    last_name = "Dodepp",
                    admission_year = 2020,
                    group_id = 1
                });
            Insert.IntoTable("lessons")
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
            Delete.Table("lessons");
            Delete.Table("users");
            Delete.Table("schedule_items");
            Delete.Table("groups");
            Delete.Table("auditoriums");
            Delete.Table("academic_buildings");
        }
    }
}
