using Application.DTOs;
using Application.Requests;

namespace Application.Services
{
    public interface IAuditoriumService
    {
        public Task<AuditoriumDto?> GetById(int id);
        public Task<IEnumerable<AuditoriumDto>> GetAll();
        public Task<int> Add(CreateAuditoriumRequest request);
        public Task Update(UpdateAuditoriumRequest request);
        public Task Delete(int id);
    }
}
