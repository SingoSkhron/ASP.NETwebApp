using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IGroupRepository
    {
        public Task<Group?> ReadById(int id);
        public Task<List<Group>> ReadAll();
        public Task Create(Group group);
        public Task<bool> Update(Group group);
        public Task<bool> Delete(int id);
    }
}
