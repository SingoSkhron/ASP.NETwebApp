using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAuditoriumRepository
    {
        public Task<Auditorium?> ReadById(int id);
        public Task<List<Auditorium>> ReadAll();
        public Task Create(Auditorium auditorium);
        public Task<bool> Update(Auditorium auditorium);
        public Task<bool> Delete(int id);
    }
}
