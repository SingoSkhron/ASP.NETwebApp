using Application.DTOs;

namespace Application.Services
{
    public interface IScheduleItemsService
    {
        public Task<ScheduleItemsDto?> GetById(int id);
        public Task<IEnumerable<ScheduleItemsDto>> GetAll();
        public Task<int> Add(ScheduleItemsDto scheduleItem);
        public Task<bool> Update(ScheduleItemsDto scheduleItem);
        public Task<bool> Delete(int id);
    }
}
