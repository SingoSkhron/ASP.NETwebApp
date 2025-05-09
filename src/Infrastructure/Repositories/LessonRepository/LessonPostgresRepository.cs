using Bogus;
using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.LessonRepository
{
    public class LessonPostgresRepository : ILessonRepository
    {
        private readonly NpgsqlConnection _connection;

        public LessonPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(Lesson lesson)
        {
            var lessonId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO lesson (name, lesson_type, auditorium_id, building_id, professor_id, group_id, schedule_item_id) 
                VALUES (@Name, @LessonType, @AuditoriumId, @BuildingId, @ProfessorId, @GroupId, @ScheduleItemId)
                RETURNING id", new { lesson.Name, lesson.LessonType, lesson.AuditoriumId, lesson.BuildingId, lesson.ProfessorId, lesson.GroupId, lesson.ScheduleItemId });

            return lessonId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM lesson WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<Lesson>> ReadAll()
        {
            var lessons = await _connection.QueryAsync<Lesson>(
                @"SELECT id, name, lesson_type, auditorium_id, building_id, professor_id, group_id, schedule_item_id FROM lesson");

            return lessons.ToList();
        }

        public async Task<Lesson?> ReadById(int id)
        {
            var lesson = await _connection.QueryFirstOrDefaultAsync<Lesson>(
                @"SELECT name, lesson_type, auditorium_id, building_id, professor_id, group_id, schedule_item_id FROM lesson WHERE id = @Id", new { Id = id });

            return lesson;
        }

        public async Task<bool> Update(Lesson lesson)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE lesson
                SET name = @Name, lesson_type = @LessonType, auditorium_id = @AuditoriumId, building_id = @BuildingId, 
                professor_id = @ProfessorId, group_id = @GroupId, schedule_item_id = @ScheduleItemId
                WHERE id = @Id", lesson);

            return affectedRows > 0;
        }
    }
}
