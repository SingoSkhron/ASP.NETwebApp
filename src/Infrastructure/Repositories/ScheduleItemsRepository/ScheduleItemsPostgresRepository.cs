using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.ScheduleItemsRepository
{
    public class ScheduleItemsPostgresRepository : IScheduleItemsRepository
    {
        private readonly NpgsqlConnection _connection;

        public ScheduleItemsPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(ScheduleItems scheduleItem)
        {
            var scheduleItemId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO schedule_item (order_number, day_of_the_week, start_time, end_time, building_id) 
                VALUES (@OrderNumber, @DayOfTheWeek, @StartTime, @EndTime, @BuildingId)
                RETURNING id", new { scheduleItem.OrderNumber, scheduleItem.DayOfTheWeek, scheduleItem.StartTime, scheduleItem.EndTime, scheduleItem.BuildingId });

            return scheduleItemId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM schedule_item WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<ScheduleItems>> ReadAll()
        {
            var scheduleItems = await _connection.QueryAsync<ScheduleItems>(
                @"SELECT id, order_number, day_of_the_week, start_time, end_time, building_id FROM schedule_item");

            return scheduleItems.ToList();
        }

        public async Task<ScheduleItems?> ReadById(int id)
        {
            var scheduleItem = await _connection.QueryFirstOrDefaultAsync<ScheduleItems>(
                @"SELECT order_number, day_of_the_week, start_time, end_time, building_id FROM schedule_item WHERE id = @Id", new { Id = id });

            return scheduleItem;
        }

        public async Task<bool> Update(ScheduleItems scheduleItem)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE schedule_item
                SET order_number = @OrderNumber, day_of_the_week = @DayOfTheWeek, start_time = @StartTime, end_time = @EndTime, building_id = @BuildingId
                WHERE id = @Id", scheduleItem);

            return affectedRows > 0;
        }
    }
}
