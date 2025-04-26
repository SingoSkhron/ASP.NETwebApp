using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public Task<int> Add(GroupDto group)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GroupDto group)
        {
            throw new NotImplementedException();
        }
    }
}
