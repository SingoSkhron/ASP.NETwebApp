using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.ScheduleItemsRepository;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ScheduleItemsService : IScheduleItemsService
    {
        private readonly IScheduleItemsRepository _scheduleItemsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ScheduleItemsService> _logger;

        public ScheduleItemsService(IScheduleItemsRepository scheduleItemsRepository, IMapper mapper, ILogger<ScheduleItemsService> logger)
        {
            _scheduleItemsRepository = scheduleItemsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Add(CreateScheduleItemRequest request)
        {
            var scheduleItems = new ScheduleItems()
            {
                OrderNumber = request.OrderNumber,
                DayOfTheWeek = request.DayOfTheWeek,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                BuildingId = request.BuildingId
            };
            var res = await _scheduleItemsRepository.Create(scheduleItems);
            _logger.LogInformation(@"ScheduleItem with ID = {0} was created.", res);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _scheduleItemsRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("ScheduleItem for deletion not found");
            }
            _logger.LogInformation(@"ScheduleItem with ID = {0} was deleted.", id);
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
            if (scheduleItem == null)
            {
                throw new NotFoundApplicationException("ScheduleItem not found.");
            }
            var mappedScheduleItem = _mapper.Map<ScheduleItemsDto>(scheduleItem);
            return mappedScheduleItem;
        }

        public async Task Update(UpdateScheduleItemRequest request)
        {
            var scheduleItem = new ScheduleItems()
            {
                Id = request.Id,
                OrderNumber = request.OrderNumber,
                DayOfTheWeek = request.DayOfTheWeek,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                BuildingId = request.BuildingId
            };
            var res = await _scheduleItemsRepository.Update(scheduleItem);
            if (res == false)
            {
                throw new EntityUpdateException("ScheduleItem wasn't updated.");
            }
            _logger.LogInformation(@"ScheduleItem with ID = {0} was updated.", scheduleItem.Id);
        }
    }
}
