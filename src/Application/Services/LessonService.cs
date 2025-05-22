using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.LessonRepository;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LessonService> _logger;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper, ILogger<LessonService> logger)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Add(CreateLessonRequest request)
        {
            var lesson = new Lesson()
            {
                Name = request.Name,
                LessonType = request.LessonType,
                AuditoriumId = request.AuditoriumId,
                BuildingId = request.BuildingId,
                ProfessorId = request.ProfessorId,
                GroupId = request.GroupId,
                ScheduleItemId = request.ScheduleItemId
            };
            var res = await _lessonRepository.Create(lesson);
            _logger.LogInformation(@"Lesson with ID = {0} was created.", res);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _lessonRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("Lesson for deletion not found");
            }
            _logger.LogInformation(@"Lesson with ID = {0} was deleted.", id);
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
            if (lesson == null)
            {
                throw new NotFoundApplicationException("Lesson not found.");
            }
            var mappedLesson = _mapper.Map<LessonDto>(lesson);
            return mappedLesson;
        }

        public async Task Update(UpdateLessonRequest request)
        {
            var lesson = new Lesson()
            {
                Id = request.Id,
                Name = request.Name,
                LessonType = request.LessonType,
                AuditoriumId = request.AuditoriumId,
                BuildingId = request.BuildingId,
                ProfessorId = request.ProfessorId,
                GroupId = request.GroupId,
                ScheduleItemId = request.ScheduleItemId
            };
            var res = await _lessonRepository.Update(lesson);
            if (res == false)
            {
                throw new EntityUpdateException("Lesson wasn't updated.");
            }
            _logger.LogInformation(@"Lesson with ID = {0} was updated.", lesson.Id);
        }
    }
}
