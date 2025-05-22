using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.AuditoriumRepository;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly IAuditoriumRepository _auditoriumRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuditoriumService> _logger;

        public AuditoriumService(IAuditoriumRepository auditoriumRepository, IMapper mapper, ILogger<AuditoriumService> logger)
        {
            _auditoriumRepository = auditoriumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Add(CreateAuditoriumRequest request)
        {
            var auditorium = new Auditorium()
            {
                Name = request.Name,
                FloorNumber = request.FloorNumber,
                BuildingId = request.BuildingId
            };
            var res = await _auditoriumRepository.Create(auditorium);
            _logger.LogInformation(@"Auditorium with ID = {0} was created.", res);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _auditoriumRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("Auditorium for deletion not found");
            }
            _logger.LogInformation(@"Auditorium with ID = {0} was deleted.", id);
        }

        public async Task<IEnumerable<AuditoriumDto>> GetAll()
        {
            var auditoriums = await _auditoriumRepository.ReadAll();
            var mappedAuditoriums = auditoriums.Select(u => _mapper.Map<AuditoriumDto>(u));
            return mappedAuditoriums;
        }

        public async Task<AuditoriumDto?> GetById(int id)
        {
            var auditorium = await _auditoriumRepository.ReadById(id);
            if (auditorium == null)
            {
                throw new NotFoundApplicationException("Auditorium not found.");
            }
            var mappedAuditorium = _mapper.Map<AuditoriumDto>(auditorium);
            return mappedAuditorium;
        }

        public async Task Update(UpdateAuditoriumRequest request)
        {
            var auditorium = new Auditorium()
            {
                Id = request.Id,
                Name = request.Name,
                FloorNumber = request.FloorNumber,
                BuildingId = request.BuildingId
            };
            var res = await _auditoriumRepository.Update(auditorium);
            if (res == false)
            {
                throw new EntityUpdateException("Auditorium wasn't updated.");
            }
            _logger.LogInformation(@"Auditorium with ID = {0} was updated.", auditorium.Id);
        }
    }
}
