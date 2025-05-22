using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.AuditoriumRepository;

namespace Application.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly IAuditoriumRepository _auditoriumRepository;
        private readonly IMapper _mapper;

        public AuditoriumService(IAuditoriumRepository auditoriumRepository, IMapper mapper)
        {
            _auditoriumRepository = auditoriumRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(CreateAuditoriumRequest request)
        {
            var auditorium = new Auditorium()
            {
                Name = request.Name,
                FloorNumber = request.FloorNumber,
                BuildingId = request.BuildingId
            };
            return await _auditoriumRepository.Create(auditorium);
        }

        public async Task Delete(int id)
        {
            var res = await _auditoriumRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("Auditorium for deletion not found");
            }
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
        }
    }
}
