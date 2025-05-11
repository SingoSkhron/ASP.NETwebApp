using Domain.Entities;

namespace Infrastructure.Repositories.ScheduleItemsRepository
{
    public interface IScheduleItemsRepository
    {
        public Task<ScheduleItems?> ReadById(int id);
        public Task<IEnumerable<ScheduleItems>> ReadAll();
        public Task<int> Create(ScheduleItems scheduleItem);
        public Task<bool> Update(ScheduleItems scheduleItem);
        public Task<bool> Delete(int id);
    }
}
