using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAcademicBuildingService
    {
        public Task<AcademicBuildingDto?> GetById(int id);
        public Task<List<AcademicBuildingDto>> GetAll();
        public Task Add(AcademicBuildingDto academicBuilding);
        public Task<bool> Update(AcademicBuildingDto academicBuilding);
        public Task<bool> Delete(int id);
    }
}
