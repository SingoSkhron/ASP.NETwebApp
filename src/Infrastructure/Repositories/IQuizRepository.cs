using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IQuizRepository
    {
        public Task<Quiz?> ReadById(int id);
        public Task<List<Quiz>> ReadAll();
        public Task Create(Quiz quiz);
        public Task<bool> Update(Quiz quiz);
        public Task<bool> Delete(int id);
    }
}
