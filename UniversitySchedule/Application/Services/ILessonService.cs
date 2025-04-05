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
        public Task<LessonDto?> GetById(int id);
        public Task<List<LessonDto>> GetAll();
        public Task Add(LessonDto lesson);
        public Task<bool> Update(LessonDto lesson);
        public Task<bool> Delete(int id);
    }
}
