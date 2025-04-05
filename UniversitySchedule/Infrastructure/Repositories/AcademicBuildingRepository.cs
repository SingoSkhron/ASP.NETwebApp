using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AcademicBuildingRepository : IAcademicBuildingRepository
    {
        private List<AcademicBuilding> buildings = new List<AcademicBuilding>();
        public AcademicBuildingRepository()
        {
            PopulateTestData();
        }
        public Task Create(AcademicBuilding academicBuilding)
        {
            buildings.Add(academicBuilding);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!buildings.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            buildings.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<AcademicBuilding>> ReadAll()
        {
            return Task.FromResult(buildings);
        }

        public Task<AcademicBuilding?> ReadById(int id)
        {
            var building = buildings.Find(x => x.Id == id);
            return Task.FromResult(building);
        }

        public Task<bool> Update(AcademicBuilding academicBuilding)
        {
            var buildingToUpdate = buildings.Find(x => x.Id == academicBuilding.Id);
            if (buildingToUpdate == null)
            {
                return Task.FromResult(false);
            }
            buildingToUpdate.LessonsStartTime = academicBuilding.LessonsStartTime;
            buildingToUpdate.BigBreakDuration = academicBuilding.BigBreakDuration;
            buildingToUpdate.Address = academicBuilding.Address;
            buildingToUpdate.Name = academicBuilding.Name;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            buildings = new List<AcademicBuilding>();
            for (int i = 0; i < 5; i++)
            {
                var building = new AcademicBuilding();
                building.Id = i + 1;
                building.LessonsStartTime = new TimeOnly(9, 0);
                building.BigBreakDuration = new TimeOnly(1, 0);
                building.Address = "г. Ярославль, ул. Союзная, д. 144";
                building.Name = "Корпус 7";
                buildings.Add(building);
            }
        }
    }
}
