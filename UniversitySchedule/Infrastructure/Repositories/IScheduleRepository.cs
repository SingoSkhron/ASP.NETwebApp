using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IScheduleRepository
    {
        public Task<Schedule?> ReadById(int id);
        public Task<List<Schedule>> ReadAll();
        public Task Create(Schedule schedule);
        public Task<bool> Update(Schedule schedule);
        public Task<bool> Delete(int id);
    }
}
