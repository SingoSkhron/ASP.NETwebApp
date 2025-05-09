using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(LessonDto lesson)
        {
            var mappedLesson = _mapper.Map<Lesson>(lesson);
            if (mappedLesson != null)
            {
                var mappedLessonId = await _lessonRepository.Create(mappedLesson);
                return mappedLessonId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _lessonRepository.Delete(id);
        }

        public async Task<IEnumerable<LessonDto>> GetAll()
        {
            var lessons = await _lessonRepository.ReadAll();
            var mappedLessons = lessons.Select(u => _mapper.Map<LessonDto>(u));
            return mappedLessons;
        }

        public async Task<LessonDto?> GetById(int id)
        {
            var lesson = await _lessonRepository.ReadById(id);
            var mappedLesson = _mapper.Map<LessonDto>(lesson);
            return mappedLesson;
        }

        public async Task<bool> Update(LessonDto lesson)
        {
            if (lesson == null)
            {
                return false;
            }
            var mappedLesson = _mapper.Map<Lesson>(lesson);
            var existingLesson = await _lessonRepository.ReadById(lesson.Id);
            if (existingLesson == null)
            {
                return false;
            }
            return await _lessonRepository.Update(mappedLesson);
        }
    }
}
