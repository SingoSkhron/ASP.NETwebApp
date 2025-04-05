using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private List<Lesson> lessons = new List<Lesson>();
        public LessonRepository()
        {
            PopulateTestData();
        }
        public Task Create(Lesson lesson)
        {
            lessons.Add(lesson);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!lessons.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            lessons.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<Lesson>> ReadAll()
        {
            return Task.FromResult(lessons);
        }

        public Task<Lesson?> ReadById(int id)
        {
            var lesson = lessons.Find(x => x.Id == id);
            return Task.FromResult(lesson);
        }

        public Task<bool> Update(Lesson lesson)
        {
            var lessonToUpdate = lessons.Find(x => x.Id == lesson.Id);
            if (lessonToUpdate == null)
            {
                return Task.FromResult(false);
            }
            lessonToUpdate.OrderNumber = lesson.OrderNumber;
            lessonToUpdate.Name = lesson.Name;
            lessonToUpdate.LessonType = lesson.LessonType;
            lessonToUpdate.DayOfTheWeek = lesson.DayOfTheWeek;
            lessonToUpdate.StartTime = lesson.StartTime;
            lessonToUpdate.EndTime = lesson.EndTime;
            lessonToUpdate.AuditoriumId = lesson.AuditoriumId;
            lessonToUpdate.ProfessorId = lesson.ProfessorId;
            lessonToUpdate.GroupId = lesson.GroupId;
            lessonToUpdate.BuildingId = lesson.BuildingId;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            lessons = new List<Lesson>();
            for (int i = 0; i < 5; i++)
            {
                var lesson = new Lesson();
                lesson.Id = i + 1;
                lesson.OrderNumber = i + 1;
                lesson.Name = "Математический анализ";
                lesson.LessonType = "Лекция";
                lesson.DayOfTheWeek = "пн";
                lesson.StartTime = new TimeOnly(9, 0);
                lesson.EndTime = new TimeOnly(10, 35);
                lesson.AuditoriumId = i + 1;
                lesson.ProfessorId = i + 1;
                lesson.GroupId = i + 1;
                lesson.BuildingId = i + 1;
                lessons.Add(lesson);
            }
        }
    }
}
