using Application.DTOs;
using Application.Requests;

namespace Application.Services
{
    public interface IScheduleItemsService
    {
        public Task<ScheduleItemsDto?> GetById(int id);
        public Task<IEnumerable<ScheduleItemsDto>> GetAll();
        public Task<int> Add(CreateScheduleItemRequest request);
        public Task Update(UpdateScheduleItemRequest request);
        public Task Delete(int id);
    }
}
