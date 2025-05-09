using Domain.Entities;

namespace Infrastructure.Repositories.AcademicBuildingRepository
{
    public interface IAcademicBuildingRepository
    {
        public Task<AcademicBuilding?> ReadById(int id);
        public Task<IEnumerable<AcademicBuilding>> ReadAll();
        public Task<int> Create(AcademicBuilding academicBuilding);
        public Task<bool> Update(AcademicBuilding academicBuilding);
        public Task<bool> Delete(int id);
    }
}
