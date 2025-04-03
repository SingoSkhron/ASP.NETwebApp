using Application.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }
        public Task Add(GroupDTO quiz)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GroupDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GroupDTO quiz)
        {
            throw new NotImplementedException();
        }
    }
}
