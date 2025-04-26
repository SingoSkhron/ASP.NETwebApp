using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ScheduleItemsService : IScheduleItemsService
    {
        private readonly IScheduleItemsRepository _scheduleItemsRepository;
        public ScheduleItemsService(IScheduleItemsRepository scheduleItemsRepository)
        {
            _scheduleItemsRepository = scheduleItemsRepository;
        }
        public Task<int> Add(ScheduleItemsDto scheduleItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScheduleItemsDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleItemsDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ScheduleItemsDto scheduleItem)
        {
            throw new NotImplementedException();
        }
    }
}
