using Application.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AcademicBuildingService : IAcademicBuildingService
    {
        private IAcademicBuildingRepository academicBuildingRepository;
        public AcademicBuildingService(IAcademicBuildingRepository academicBuildingRepository)
        {
            this.academicBuildingRepository = academicBuildingRepository;
        }
        public Task Add(AcademicBuildingDto academicBuilding)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AcademicBuildingDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AcademicBuildingDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AcademicBuildingDto academicBuilding)
        {
            throw new NotImplementedException();
        }
    }
}
