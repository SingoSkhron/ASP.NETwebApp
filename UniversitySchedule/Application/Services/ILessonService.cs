using Application.DTOs;

namespace Application.Services
{
    public interface ILessonService
    {
        public Task<LessonDto?> GetById(int id);
        public Task<IEnumerable<LessonDto>> GetAll();
        public Task<int> Add(LessonDto lesson);
        public Task<bool> Update(LessonDto lesson);
        public Task<bool> Delete(int id);
    }
}
