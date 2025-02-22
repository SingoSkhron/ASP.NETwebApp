using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services
{
    public interface IQuizService
    {
        public Task<QuizDto?> GetById(int id);
        public Task<List<QuizDto>> GetAll();
        public Task Add(QuizDto quiz);
        public Task<bool> Update(QuizDto quiz);
        public Task<bool> Delete(int id);
    }
}
