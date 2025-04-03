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
        public Task<GroupDTO?> GetById(int id);
        public Task<List<GroupDTO>> GetAll();
        public Task Add(GroupDTO quiz);
        public Task<bool> Update(GroupDTO quiz);
        public Task<bool> Delete(int id);
    }
}
