using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Repositories.GroupRepository
{
    public class GroupPostgresRepository : IGroupRepository
    {
        private readonly NpgsqlConnection _connection;

        public GroupPostgresRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(Group group)
        {
            var groupId = await _connection.QuerySingleAsync<int>(
                @"INSERT INTO groups (group_name, education_level, education_form, admission_year) 
                VALUES (@GroupName, @EducationLevel, @EducationForm, @AdmissionYear)
                RETURNING id", new { group.GroupName, group.EducationLevel, group.EducationForm, group.AdmissionYear });

            return groupId;
        }

        public async Task<bool> Delete(int id)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"DELETE FROM groups WHERE id = @Id", new { Id = id });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<Group>> ReadAll()
        {
            var groups = await _connection.QueryAsync<Group>(
                @"SELECT id, group_name, education_level, education_form, admission_year FROM groups");

            return groups.ToList();
        }

        public async Task<Group?> ReadById(int id)
        {
            var group = await _connection.QueryFirstOrDefaultAsync<Group>(
                @"SELECT group_name, education_level, education_form, admission_year FROM groups WHERE id = @Id", new { Id = id });

            return group;
        }

        public async Task<bool> Update(Group group)
        {
            var affectedRows = await _connection.ExecuteAsync(
                @"UPDATE groups
                SET group_name = @GroupName, education_level = @EducationLevel, education_form = @EducationForm, admission_year = @AdmissionYear
                WHERE id = @Id", group);

            return affectedRows > 0;
        }
    }
}
