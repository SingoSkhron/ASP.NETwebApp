using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.ScheduleItemsRepository;

namespace Application.Services
{
    public class ScheduleItemsService : IScheduleItemsService
    {
        private readonly IScheduleItemsRepository _scheduleItemsRepository;
        private readonly IMapper _mapper;

        public ScheduleItemsService(IScheduleItemsRepository scheduleItemsRepository, IMapper mapper)
        {
            _scheduleItemsRepository = scheduleItemsRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(ScheduleItemsDto scheduleItem)
        {
            var mappedScheduleItem = _mapper.Map<ScheduleItems>(scheduleItem);
            if (mappedScheduleItem != null)
            {
                var mappedScheduleItemsId = await _scheduleItemsRepository.Create(mappedScheduleItem);
                return mappedScheduleItemsId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _scheduleItemsRepository.Delete(id);
        }

        public async Task<IEnumerable<ScheduleItemsDto>> GetAll()
        {
            var scheduleItems = await _scheduleItemsRepository.ReadAll();
            var mappedScheduleItems = scheduleItems.Select(u => _mapper.Map<ScheduleItemsDto>(u));
            return mappedScheduleItems;
        }

        public async Task<ScheduleItemsDto?> GetById(int id)
        {
            var scheduleItem = await _scheduleItemsRepository.ReadById(id);
            var mappedScheduleItem = _mapper.Map<ScheduleItemsDto>(scheduleItem);
            return mappedScheduleItem;
        }

        public async Task<bool> Update(ScheduleItemsDto scheduleItem)
        {
            if (scheduleItem == null)
            {
                return false;
            }
            var mappedScheduleItems = _mapper.Map<ScheduleItems>(scheduleItem);
            var existingScheduleItems = await _scheduleItemsRepository.ReadById(scheduleItem.Id);
            if (existingScheduleItems == null)
            {
                return false;
            }
            return await _scheduleItemsRepository.Update(mappedScheduleItems);
        }
    }
}
