using Bogus;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IEnumerable<Lesson> lessons = new List<Lesson>();
        public LessonRepository()
        {
            lessons = new List<Lesson>();
            PopulateTestData();
        }
        public Task<int> Create(Lesson lesson)
        {
            lesson.Id = GetId();
            lessons.ToList().Add(lesson);
            return Task.FromResult(lesson.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!lessons.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            lessons.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Lesson>> ReadAll()
        {
            return Task.FromResult(lessons);
        }

        public Task<Lesson?> ReadById(int id)
        {
            var lesson = lessons.ToList().Find(x => x.Id == id);
            return Task.FromResult(lesson);
        }

        public Task<bool> Update(Lesson lesson)
        {
            var lessonToUpdate = lessons.ToList().Find(x => x.Id == lesson.Id);
            if (lessonToUpdate == null)
            {
                return Task.FromResult(false);
            }
            lessonToUpdate.Name = lesson.Name;
            lessonToUpdate.LessonType = lesson.LessonType;
            lessonToUpdate.AuditoriumId = lesson.AuditoriumId;
            lessonToUpdate.ProfessorId = lesson.ProfessorId;
            lessonToUpdate.GroupId = lesson.GroupId;
            lessonToUpdate.BuildingId = lesson.BuildingId;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            for (int i = 0; i < 5; i++)
            {
                var lesson = new Lesson();
                lesson.Id = i + 1;
                lesson.Name = "Математический анализ";
                lesson.LessonType = LessonTypeEnum.Lecture;
                lesson.AuditoriumId = i + 1;
                lesson.ProfessorId = i + 1;
                lesson.GroupId = i + 1;
                lesson.BuildingId = i + 1;
                lessons.ToList().Add(lesson);
            }
        }
        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (lessons.ToList().Find(x => x.Id == id) == null)
                {
                    return id;
                }
                else
                {
                    id++;
                }
            }
        }
    }
}
