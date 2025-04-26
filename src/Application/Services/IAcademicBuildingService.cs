using Application.DTOs;

namespace Application.Services
{
    public interface IAcademicBuildingService
    {
        public Task<AcademicBuildingDto?> GetById(int id);
        public Task<IEnumerable<AcademicBuildingDto>> GetAll();
        public Task<int> Add(AcademicBuildingDto academicBuilding);
        public Task<bool> Update(AcademicBuildingDto academicBuilding);
        public Task<bool> Delete(int id);
    }
}
