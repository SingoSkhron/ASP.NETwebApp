﻿using Application.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private ILessonRepository lessonRepository;
        public LessonService(ILessonRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }
        public Task Add(LessonDTO quiz)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LessonDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LessonDTO quiz)
        {
            throw new NotImplementedException();
        }
    }
}
