using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            lessonToUpdate.NumberInOrder = lesson.NumberInOrder;
            lessonToUpdate.Auditorium = lesson.Auditorium;
            lessonToUpdate.AcademicBuilding = lesson.AcademicBuilding;
            lessonToUpdate.Discipline = lesson.Discipline;
            lessonToUpdate.TypeOfLesson = lesson.TypeOfLesson;
            lessonToUpdate.DayOfTheWeek = lesson.DayOfTheWeek;
            lessonToUpdate.ProfessorId = lesson.ProfessorId;
            lessonToUpdate.ScheduleId = lesson.ScheduleId;
            lessonToUpdate.GroupId = lesson.GroupId;
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
                lesson.NumberInOrder = i + 1;
                lesson.Auditorium = 311 + i;
                lesson.AcademicBuilding = 7;
                lesson.Discipline = "Математический анализ";
                lesson.TypeOfLesson = "Лекция";
                lesson.DayOfTheWeek = "пн";
                lesson.ProfessorId = i + 1;
                lesson.ScheduleId = i + 1;
                lesson.GroupId = i + 1;
            }
        }
    }
}
