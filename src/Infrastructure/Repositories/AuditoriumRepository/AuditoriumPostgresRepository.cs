using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.AuditoriumRepository
{
    public class AuditoriumPostgresRepository : IAuditoriumRepository
    {
        private readonly NpgsqlConnection _connection;

        public AuditoriumPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(Auditorium auditorium)
        {
            var auditoriumId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO auditorium (name, floor_number, building_id) VALUES (@Name, @FloorNumber, @BuildingId)
                RETURNING id", new { auditorium.Name, auditorium.FloorNumber, auditorium.BuildingId });

            return auditoriumId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM auditorium WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<Auditorium>> ReadAll()
        {
            var auditoriums = await _connection.QueryAsync<Auditorium>(
                @"SELECT id, name, floor_number, building_id FROM auditorium");

            return auditoriums.ToList();
        }

        public async Task<Auditorium?> ReadById(int id)
        {
            var auditorium = await _connection.QueryFirstOrDefaultAsync<Auditorium>(
                @"SELECT name, floor_number, building_id FROM auditorium WHERE id = @Id", new { Id = id });

            return auditorium;
        }

        public async Task<bool> Update(Auditorium auditorium)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE auditorium
                SET name = @Name, floor_number = @FloorNumber, building_id = @BuildingId
                WHERE id = @Id", auditorium);

            return affectedRows > 0;
        }
    }
}
