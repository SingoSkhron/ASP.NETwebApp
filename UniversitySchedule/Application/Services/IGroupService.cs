using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IGroupService
    {
        public Task<GroupDto?> GetById(int id);
        public Task<List<GroupDto>> GetAll();
        public Task Add(GroupDto group);
        public Task<bool> Update(GroupDto group);
        public Task<bool> Delete(int id);
    }
}
