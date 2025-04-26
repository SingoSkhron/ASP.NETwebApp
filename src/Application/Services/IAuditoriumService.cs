using Application.DTOs;

namespace Application.Services
{
    public interface IAuditoriumService
    {
        public Task<AuditoriumDto?> GetById(int id);
        public Task<IEnumerable<AuditoriumDto>> GetAll();
        public Task<int> Add(AuditoriumDto auditorium);
        public Task<bool> Update(AuditoriumDto auditorium);
        public Task<bool> Delete(int id);
    }
}
