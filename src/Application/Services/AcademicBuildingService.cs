using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.AcademicBuildingRepository;

namespace Application.Services
{
    public class AcademicBuildingService : IAcademicBuildingService
    {
        private readonly IAcademicBuildingRepository _academicBuildingRepository;
        private readonly IMapper _mapper;

        public AcademicBuildingService(IAcademicBuildingRepository academicBuildingRepository, IMapper mapper)
        {
            _academicBuildingRepository = academicBuildingRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(AcademicBuildingDto academicBuilding)
        {
            var mappedAcademicBuilding = _mapper.Map<AcademicBuilding>(academicBuilding);
            if (mappedAcademicBuilding != null)
            {
                var mappedAcademicBuildingId = await _academicBuildingRepository.Create(mappedAcademicBuilding);
                return mappedAcademicBuildingId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _academicBuildingRepository.Delete(id);
        }

        public async Task<IEnumerable<AcademicBuildingDto>> GetAll()
        {
            var academicBuildings = await _academicBuildingRepository.ReadAll();
            var mappedAcademicBuildings = academicBuildings.Select(u => _mapper.Map<AcademicBuildingDto>(u));
            return mappedAcademicBuildings;
        }

        public async Task<AcademicBuildingDto?> GetById(int id)
        {
            var academicBuilding = await _academicBuildingRepository.ReadById(id);
            var mappedAcademicBuilding = _mapper.Map<AcademicBuildingDto>(academicBuilding);
            return mappedAcademicBuilding;
        }

        public async Task<bool> Update(AcademicBuildingDto academicBuilding)
        {
            if (academicBuilding == null)
            {
                return false;
            }
            var mappedAcademicBuilding = _mapper.Map<AcademicBuilding>(academicBuilding);
            var existingAcademicBuilding = await _academicBuildingRepository.ReadById(academicBuilding.Id);
            if (existingAcademicBuilding == null)
            {
                return false;
            }
            return await _academicBuildingRepository.Update(mappedAcademicBuilding);
        }
    }
}
