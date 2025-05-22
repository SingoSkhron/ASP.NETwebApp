using Application.DTOs;
using Application.Requests;

namespace Application.Services
{
    public interface IAcademicBuildingService
    {
        public Task<AcademicBuildingDto?> GetById(int id);
        public Task<IEnumerable<AcademicBuildingDto>> GetAll();
        public Task<int> Add(CreateAcademicBuildingRequest request);
        public Task Update(UpdateAcademicBuildingRequest request);
        public Task Delete(int id);
    }
}
