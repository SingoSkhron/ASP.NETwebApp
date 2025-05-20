using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.UserRepository
{
    public class UserPostgresRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection;

        public UserPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(User user)
        {
            var userId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO users (type, first_name, last_name, admission_year, group_id) VALUES (@Type, @FirstName, @LastName, @AdmissionYear, @GroupId)
                RETURNING id", new { user.Type, user.FirstName, user.LastName, user.AdmissionYear, user.GroupId });

            return userId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM users WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<User>> ReadAll()
        {
            var users = await _connection.QueryAsync<User>(
                @"SELECT id, type, first_name, last_name, admission_year, group_id FROM users");

            return users.ToList();
        }

        public async Task<User?> ReadById(int id)
        {
            var user = await _connection.QueryFirstOrDefaultAsync<User>(
                @"SELECT type, first_name, last_name, admission_year, group_id FROM users WHERE id = @Id", new { Id = id });

            return user;
        }

        public async Task<bool> Update(User user)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE users
                SET type = @Type, first_name = @FirstName, last_name = @LastName, admission_year = @AdmissionYear, group_id = @GroupId
                WHERE id = @Id", user);

            return affectedRows > 0;
        }
    }
}
