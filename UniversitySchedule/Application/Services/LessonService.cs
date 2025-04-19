using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public Task<int> Add(LessonDto lesson)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LessonDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LessonDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LessonDto lesson)
        {
            throw new NotImplementedException();
        }
    }
}
