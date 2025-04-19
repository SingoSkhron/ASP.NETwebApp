using Application.DTOs;

namespace Application.Services
{
    public interface IGroupService
    {
        public Task<GroupDto?> GetById(int id);
        public Task<IEnumerable<GroupDto>> GetAll();
        public Task<int> Add(GroupDto group);
        public Task<bool> Update(GroupDto group);
        public Task<bool> Delete(int id);
    }
}
