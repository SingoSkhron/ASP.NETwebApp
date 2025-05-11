using Domain.Entities;

namespace Infrastructure.Repositories.ScheduleItemsRepository
{
    public class ScheduleItemsInMemoryRepository : IScheduleItemsRepository
    {
        private readonly List<ScheduleItems> scheduleItems = new List<ScheduleItems>();

        public ScheduleItemsInMemoryRepository()
        {
            scheduleItems = new List<ScheduleItems>();
            PopulateTestData();
        }

        public Task<int> Create(ScheduleItems scheduleItem)
        {
            scheduleItem.Id = GetId();
            scheduleItems.ToList().Add(scheduleItem);
            return Task.FromResult(scheduleItem.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!scheduleItems.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            scheduleItems.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<ScheduleItems>> ReadAll()
        {
            return Task.FromResult<IEnumerable<ScheduleItems>>(scheduleItems);
        }

        public Task<ScheduleItems?> ReadById(int id)
        {
            var scheduleItem = scheduleItems.ToList().Find(x => x.Id == id);
            return Task.FromResult(scheduleItem);
        }

        public Task<bool> Update(ScheduleItems scheduleItem)
        {
            var itemToUpdate = scheduleItems.ToList().Find(x => x.Id == scheduleItem.Id);
            if (itemToUpdate == null)
            {
                return Task.FromResult(false);
            }
            itemToUpdate.OrderNumber = scheduleItem.OrderNumber;
            itemToUpdate.DayOfTheWeek = scheduleItem.DayOfTheWeek;
            itemToUpdate.StartTime = scheduleItem.StartTime;
            itemToUpdate.EndTime = scheduleItem.EndTime;
            itemToUpdate.BuildingId = scheduleItem.BuildingId;
            return Task.FromResult(true);
        }

        private void PopulateTestData()
        {
            for (int i = 0; i < 5; i++)
            {
                var scheduleItem = new ScheduleItems();
                scheduleItem.Id = i + 1;
                scheduleItem.OrderNumber = i + 1;
                scheduleItem.DayOfTheWeek = i + 1;
                scheduleItem.StartTime = new TimeOnly(9 + i, 0 + i * 30);
                scheduleItem.EndTime = new TimeOnly(10 + i, 30 + i * 30);
                scheduleItem.BuildingId = i + 1;
                scheduleItems.Add(scheduleItem);
            }
        }

        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (scheduleItems.ToList().Find(x => x.Id == id) == null)
                {
                    return id;
                }
                else
                {
                    id++;
                }
            }
        }
    }
}
