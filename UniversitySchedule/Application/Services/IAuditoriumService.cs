using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuditoriumService
    {
        public Task<AuditoriumDto?> GetById(int id);
        public Task<List<AuditoriumDto>> GetAll();
        public Task Add(AuditoriumDto auditorium);
        public Task<bool> Update(AuditoriumDto auditorium);
        public Task<bool> Delete(int id);
    }
}
