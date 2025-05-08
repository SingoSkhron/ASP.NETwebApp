using Bogus;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AcademicBuildingRepository : IAcademicBuildingRepository
    {
        private readonly List<AcademicBuilding> buildings = new List<AcademicBuilding>();
        public AcademicBuildingRepository()
        {
            buildings = new List<AcademicBuilding>();
            PopulateTestData();
        }
        public Task<int> Create(AcademicBuilding academicBuilding)
        {
            academicBuilding.Id = GetId();
            buildings.ToList().Add(academicBuilding);
            return Task.FromResult(academicBuilding.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!buildings.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            buildings.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<AcademicBuilding>> ReadAll()
        {
            return Task.FromResult<IEnumerable<AcademicBuilding>>(buildings);
        }

        public Task<AcademicBuilding?> ReadById(int id)
        {
            var building = buildings.ToList().Find(x => x.Id == id);
            return Task.FromResult(building);
        }

        public Task<bool> Update(AcademicBuilding academicBuilding)
        {
            var buildingToUpdate = buildings.ToList().Find(x => x.Id == academicBuilding.Id);
            if (buildingToUpdate == null)
            {
                return Task.FromResult(false);
            }
            buildingToUpdate.Address = academicBuilding.Address;
            buildingToUpdate.Name = academicBuilding.Name;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            for (int i = 0; i < 5; i++)
            {
                var building = new AcademicBuilding();
                building.Id = i + 1;
                building.Address = faker.Address.ToString();
                building.Name = "Корпус 7";
                buildings.Add(building);
            }
        }
        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (buildings.ToList().Find(x => x.Id == id) == null)
                {
                    return id;
                }
                else
                {
                    id++;
                }
            }
        }
    }
}
