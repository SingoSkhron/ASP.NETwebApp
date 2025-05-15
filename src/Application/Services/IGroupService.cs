using Application.DTOs;
using Application.Requests;

namespace Application.Services
{
    public interface IGroupService
    {
        public Task<GroupDto?> GetById(int id);
        public Task<IEnumerable<GroupDto>> GetAll();
        public Task<int> Add(CreateGroupRequest request);
        public Task Update(UpdateGroupRequest request);
        public Task Delete(int id);
    }
}
