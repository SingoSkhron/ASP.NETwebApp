using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private List<Quiz> quizzes = new List<Quiz>();
        public QuizRepository() {
            PopulateTestData();
        }

        public Task Create(Quiz quiz)
        {
            quizzes.Add(quiz);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!quizzes.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            quizzes.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<Quiz>> ReadAll()
        {
            return Task.FromResult(quizzes);
        }

        public Task<Quiz> ReadById(int id)
        {
            var quiz = quizzes.Find(x => x.Id == id);
            return Task.FromResult(quiz);
        }

        public Task<bool> Update(Quiz quiz)
        {
            var quizToUpdate = quizzes.Find(x => x.Id == quiz.Id);
            if (quizToUpdate == null)
            {
                return Task.FromResult(false);
            }
            quizToUpdate.AuthorId = quiz.AuthorId;
            quizToUpdate.Author = quiz.Author;
            quizToUpdate.QuizName = quiz.QuizName;
            quizToUpdate.Description = quiz.Description;
            quizToUpdate.Questions = quiz.Questions;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            quizzes = new List<Quiz>();
            for (int i = 0; i < 5; i++)
            {
                var author = new User() { Id = 1, 
                    FirstName = faker.Person.FirstName, 
                    LastName = faker.Person.LastName, 
                    Email = faker.Person.Email
                };
                var quiz = new Quiz();
                quiz.Id = i + 1;
                quiz.QuizName = faker.Company.CompanyName();
                quiz.Author = author;
                quiz.AuthorId = author.Id;
                quiz.Questions = new List<QuizQuestion>();
            }
        }
    }
}
