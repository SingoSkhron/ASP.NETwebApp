using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private IAuditoriumRepository _auditoriumRepository;
        public AuditoriumService(IAuditoriumRepository auditoriumRepository)
        {
            _auditoriumRepository = auditoriumRepository;
        }
        public Task<int> Add(AuditoriumDto auditorium)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuditoriumDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuditoriumDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AuditoriumDto auditorium)
        {
            throw new NotImplementedException();
        }
    }
}
