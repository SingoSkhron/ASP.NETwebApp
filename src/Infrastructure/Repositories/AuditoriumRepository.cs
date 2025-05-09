using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly List<Auditorium> auditoriums = new List<Auditorium>();

        public AuditoriumRepository()
        {
            auditoriums = new List<Auditorium>();
            PopulateTestData();
        }

        public Task<int> Create(Auditorium auditorium)
        {
            auditorium.Id = GetId();
            auditoriums.ToList().Add(auditorium);
            return Task.FromResult(auditorium.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!auditoriums.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            auditoriums.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Auditorium>> ReadAll()
        {
            return Task.FromResult<IEnumerable<Auditorium>>(auditoriums);
        }

        public Task<Auditorium?> ReadById(int id)
        {
            var auditorium = auditoriums.ToList().Find(x => x.Id == id);
            return Task.FromResult(auditorium);
        }

        public Task<bool> Update(Auditorium auditorium)
        {
            var auditoriumToUpdate = auditoriums.ToList().Find(x => x.Id == auditorium.Id);
            if (auditoriumToUpdate == null)
            {
                return Task.FromResult(false);
            }
            auditoriumToUpdate.Name = auditorium.Name;
            auditoriumToUpdate.FloorNumber = auditorium.FloorNumber;
            auditoriumToUpdate.BuildingId = auditorium.BuildingId;
            return Task.FromResult(true);
        }

        private void PopulateTestData()
        {
            for (int i = 0; i < 5; i++)
            {
                var auditorium = new Auditorium();
                auditorium.Id = i + 1;
                auditorium.Name = $"31{i + 1}";
                auditorium.FloorNumber = 3;
                auditorium.BuildingId = i + 1;
                auditoriums.Add(auditorium);
            }
        }

        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (auditoriums.ToList().Find(x => x.Id == id) == null)
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
