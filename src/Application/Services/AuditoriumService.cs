using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

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

        public async Task<int> Add(AuditoriumDto auditorium)
        {
            var mappedAuditorium = _mapper.Map<Auditorium>(auditorium);
            if (mappedAuditorium != null)
            {
                var mappedAuditoriumId = await _auditoriumRepository.Create(mappedAuditorium);
                return mappedAuditoriumId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _auditoriumRepository.Delete(id);
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
            var mappedAuditorium = _mapper.Map<AuditoriumDto>(auditorium);
            return mappedAuditorium;
        }

        public async Task<bool> Update(AuditoriumDto auditorium)
        {
            if (auditorium == null)
            {
                return false;
            }
            var mappedAuditorium = _mapper.Map<Auditorium>(auditorium);
            var existingAuditorium = await _auditoriumRepository.ReadById(auditorium.Id);
            if (existingAuditorium == null)
            {
                return false;
            }
            return await _auditoriumRepository.Update(mappedAuditorium);
        }
    }
}
