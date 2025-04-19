using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AcademicBuildingService : IAcademicBuildingService
    {
        private readonly IAcademicBuildingRepository _academicBuildingRepository;
        public AcademicBuildingService(IAcademicBuildingRepository academicBuildingRepository)
        {
            _academicBuildingRepository = academicBuildingRepository;
        }
        public Task<int> Add(AcademicBuildingDto academicBuilding)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AcademicBuildingDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AcademicBuildingDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AcademicBuildingDto academicBuilding)
        {
            throw new NotImplementedException();
        }
    }
}
