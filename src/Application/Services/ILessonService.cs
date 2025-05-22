using Application.DTOs;
using Application.Requests;

namespace Application.Services
{
    public interface ILessonService
    {
        public Task<LessonDto?> GetById(int id);
        public Task<IEnumerable<LessonDto>> GetAll();
        public Task<int> Add(CreateLessonRequest request);
        public Task Update(UpdateLessonRequest request);
        public Task Delete(int id);
    }
}
