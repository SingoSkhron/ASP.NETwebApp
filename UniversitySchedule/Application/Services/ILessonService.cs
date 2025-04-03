using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILessonService
    {
        public Task<LessonDTO?> GetById(int id);
        public Task<List<LessonDTO>> GetAll();
        public Task Add(LessonDTO quiz);
        public Task<bool> Update(LessonDTO quiz);
        public Task<bool> Delete(int id);
    }
}
