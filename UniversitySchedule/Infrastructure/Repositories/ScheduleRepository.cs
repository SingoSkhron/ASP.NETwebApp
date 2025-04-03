using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private List<Schedule> schedules = new List<Schedule>();
        public ScheduleRepository()
        {
            PopulateTestData();
        }
        public Task Create(Schedule schedule)
        {
            schedules.Add(schedule);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!schedules.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            schedules.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<Schedule>> ReadAll()
        {
            return Task.FromResult(schedules);
        }

        public Task<Schedule?> ReadById(int id)
        {
            var schedule = schedules.Find(x => x.Id == id);
            return Task.FromResult(schedule);
        }

        public Task<bool> Update(Schedule schedule)
        {
            var scheduleToUpdate = schedules.Find(x => x.Id == schedule.Id);
            if (scheduleToUpdate == null)
            {
                return Task.FromResult(false);
            }
            scheduleToUpdate.Type = schedule.Type;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            schedules = new List<Schedule>();
            for (int i = 0; i < 5; i++)
            {
                var group = new Schedule();
                group.Id = i + 1;
                group.Type = $"Для Студента";
            }
        }
    }
}
