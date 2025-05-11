using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.AcademicBuildingRepository
{
    public class AcademicBuildingPostgresRepository : IAcademicBuildingRepository
    {
        private readonly NpgsqlConnection _connection;

        public AcademicBuildingPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(AcademicBuilding academicBuilding)
        {
            var academicBuildingId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO academic_building (address, name) VALUES (@Address, @Name)
                RETURNING id", new { academicBuilding.Address, academicBuilding.Name });

            return academicBuildingId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM academic_building WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<AcademicBuilding>> ReadAll()
        {
            var academicBuildings = await _connection.QueryAsync<AcademicBuilding>(
                @"SELECT id, address, name FROM academic_building");

            return academicBuildings.ToList();
        }

        public async Task<AcademicBuilding?> ReadById(int id)
        {
            var academicBuilding = await _connection.QueryFirstOrDefaultAsync<AcademicBuilding>(
                @"SELECT address, name FROM academic_building WHERE id = @Id", new { Id = id });

            return academicBuilding;
        }

        public async Task<bool> Update(AcademicBuilding academicBuilding)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE academic_building
                SET address = @Address, name = @Name
                WHERE id = @Id", academicBuilding);

            return affectedRows > 0;
        }
    }
}
