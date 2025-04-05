using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAcademicBuildingRepository
    {
        public Task<AcademicBuilding?> ReadById(int id);
        public Task<List<AcademicBuilding>> ReadAll();
        public Task Create(AcademicBuilding academicBuilding);
        public Task<bool> Update(AcademicBuilding academicBuilding);
        public Task<bool> Delete(int id);
    }
}
