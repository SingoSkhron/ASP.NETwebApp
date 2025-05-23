using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.AcademicBuildingRepository;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AcademicBuildingService : IAcademicBuildingService
    {
        private readonly IAcademicBuildingRepository _academicBuildingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AcademicBuildingService> _logger;

        public AcademicBuildingService(IAcademicBuildingRepository academicBuildingRepository, IMapper mapper, ILogger<AcademicBuildingService> logger)
        {
            _academicBuildingRepository = academicBuildingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Add(CreateAcademicBuildingRequest request)
        {
            var academicBuilding = new AcademicBuilding()
            {
                Address = request.Address,
                Name = request.Name
            };
            var res = await _academicBuildingRepository.Create(academicBuilding);
            _logger.LogInformation(@"AcademicBuilding with ID = {0} was created.", res);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _academicBuildingRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("AcademicBuilding for deletion not found");
            }
            _logger.LogInformation(@"AcademicBuilding with ID = {0} was deleted.", id);
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
            _logger.LogInformation(@"AcademicBuilding with ID = {0} was updated.", academicBuilding.Id);
        }
    }
}
