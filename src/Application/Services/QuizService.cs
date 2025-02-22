using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class QuizService : IQuizService
    {
        private IQuizRepository quizRepository;
        public QuizService(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }
        public Task Add(QuizDto quiz)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuizDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<QuizDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(QuizDto quiz)
        {
            throw new NotImplementedException();
        }
    }
}
