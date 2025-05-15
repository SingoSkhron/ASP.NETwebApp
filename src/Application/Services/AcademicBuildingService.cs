using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
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

        public async Task<int> Add(CreateAcademicBuildingRequest request)
        {
            var academicBuilding = new AcademicBuilding()
            {
                Address = request.Address,
                Name = request.Name
            };
            return await _academicBuildingRepository.Create(academicBuilding);
        }

        public async Task Delete(int id)
        {
            var res = await _academicBuildingRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("AcademicBuilding for deletion not found");
            }
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
            if (academicBuilding == null)
            {
                throw new NotFoundApplicationException("AcademicBuilding not found.");
            }
            var mappedAcademicBuilding = _mapper.Map<AcademicBuildingDto>(academicBuilding);
            return mappedAcademicBuilding;
        }

        public async Task Update(UpdateAcademicBuildingRequest request)
        {
            var academicBuilding = new AcademicBuilding()
            {
                Id = request.Id,
                Address = request.Address,
                Name = request.Name
            };
            var res = await _academicBuildingRepository.Update(academicBuilding);
            if (res == false)
            {
                throw new EntityUpdateException("AcademicBuilding wasn't updated.");
            }
        }
    }
}
