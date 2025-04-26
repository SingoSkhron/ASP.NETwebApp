using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface ILessonRepository
    {
        public Task<Lesson?> ReadById(int id);
        public Task<IEnumerable<Lesson>> ReadAll();
        public Task<int> Create(Lesson lesson);
        public Task<bool> Update(Lesson lesson);
        public Task<bool> Delete(int id);
    }
}
