using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IScheduleService
    {
        public Task<ScheduleDTO?> GetById(int id);
        public Task<List<ScheduleDTO>> GetAll();
        public Task Add(ScheduleDTO quiz);
        public Task<bool> Update(ScheduleDTO quiz);
        public Task<bool> Delete(int id);
    }
}
