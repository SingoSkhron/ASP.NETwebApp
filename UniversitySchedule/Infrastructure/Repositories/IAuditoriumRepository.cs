using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IAuditoriumRepository
    {
        public Task<Auditorium?> ReadById(int id);
        public Task<IEnumerable<Auditorium>> ReadAll();
        public Task<int> Create(Auditorium auditorium);
        public Task<bool> Update(Auditorium auditorium);
        public Task<bool> Delete(int id);
    }
}
