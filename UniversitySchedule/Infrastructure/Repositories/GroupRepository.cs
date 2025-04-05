using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private List<Group> groups = new List<Group>();
        public GroupRepository()
        {
            PopulateTestData();
        }
        public Task Create(Group group)
        {
            groups.Add(group);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!groups.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            groups.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<Group>> ReadAll()
        {
            return Task.FromResult(groups);
        }

        public Task<Group?> ReadById(int id)
        {
            var group = groups.Find(x => x.Id == id);
            return Task.FromResult(group);
        }

        public Task<bool> Update(Group group)
        {
            var groupToUpdate = groups.Find(x => x.Id == group.Id);
            if (groupToUpdate == null)
            {
                return Task.FromResult(false);
            }
            groupToUpdate.GroupName = group.GroupName;
            groupToUpdate.EducationForm = group.EducationForm;
            groupToUpdate.EducationLevel = group.EducationLevel;
            groupToUpdate.AdmissionYear = group.AdmissionYear;
            return Task.FromResult(true);
        }
        private void PopulateTestData()
        {
            var faker = new Faker();
            groups = new List<Group>();
            for (int i = 0; i < 5; i++)
            {
                var group = new Group();
                group.Id = i + 1;
                group.GroupName = $"КБ-{i + 1}1СО";
                group.EducationForm = "Очная";
                group.EducationLevel = "Специалитет";
                group.AdmissionYear = 2020 + i;
                groups.Add(group);
            }
        }
    }
}
