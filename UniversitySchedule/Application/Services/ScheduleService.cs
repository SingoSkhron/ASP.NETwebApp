using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }
        public Task Add(ScheduleDTO quiz)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ScheduleDTO quiz)
        {
            throw new NotImplementedException();
        }
    }
}
