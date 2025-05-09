using Domain.Entities;

namespace Infrastructure.Repositories.GroupRepository
{
    public interface IGroupRepository
    {
        public Task<Group?> ReadById(int id);
        public Task<IEnumerable<Group>> ReadAll();
        public Task<int> Create(Group group);
        public Task<bool> Update(Group group);
        public Task<bool> Delete(int id);
    }
}
