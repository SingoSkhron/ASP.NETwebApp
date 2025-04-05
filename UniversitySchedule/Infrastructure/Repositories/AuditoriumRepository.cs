using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private List<Auditorium> auditoriums = new List<Auditorium>();
        public AuditoriumRepository()
        {
            PopulateTestData();
        }
        public Task Create(Auditorium auditorium)
        {
            auditoriums.Add(auditorium);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!auditoriums.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            auditoriums.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<Auditorium>> ReadAll()
        {
            return Task.FromResult(auditoriums);
        }

        public Task<Auditorium?> ReadById(int id)
        {
            var auditorium = auditoriums.Find(x => x.Id == id);
            return Task.FromResult(auditorium);
        }

        public Task<bool> Update(Auditorium auditorium)
        {
            var auditoriumToUpdate = auditoriums.Find(x => x.Id == auditorium.Id);
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
            var faker = new Faker();
            auditoriums = new List<Auditorium>();
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
    }
}
