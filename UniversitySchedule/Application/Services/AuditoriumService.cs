using Application.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private IAuditoriumRepository auditoriumRepository;
        public AuditoriumService(IAuditoriumRepository auditoriumRepository)
        {
            this.auditoriumRepository = auditoriumRepository;
        }
        public Task Add(AuditoriumDto auditorium)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuditoriumDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuditoriumDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AuditoriumDto auditorium)
        {
            throw new NotImplementedException();
        }
    }
}
