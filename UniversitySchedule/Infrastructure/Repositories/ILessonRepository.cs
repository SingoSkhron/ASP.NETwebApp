using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ILessonRepository
    {
        public Task<Lesson?> ReadById(int id);
        public Task<List<Lesson>> ReadAll();
        public Task Create(Lesson lesson);
        public Task<bool> Update(Lesson lesson);
        public Task<bool> Delete(int id);
    }
}
