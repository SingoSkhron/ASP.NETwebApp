using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly List<Group> groups = new List<Group>();
        public GroupRepository()
        {
            groups = new List<Group>();
            PopulateTestData();
        }
        public Task<int> Create(Group group)
        {
            group.Id = GetId();
            groups.ToList().Add(group);
            return Task.FromResult(group.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!groups.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            groups.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Group>> ReadAll()
        {
            return Task.FromResult<IEnumerable<Group>>(groups);
        }

        public Task<Group?> ReadById(int id)
        {
            var group = groups.ToList().Find(x => x.Id == id);
            return Task.FromResult(group);
        }

        public Task<bool> Update(Group group)
        {
            var groupToUpdate = groups.ToList().Find(x => x.Id == group.Id);
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
            for (int i = 0; i < 5; i++)
            {
                var group = new Group();
                group.Id = i + 1;
                group.GroupName = $"КБ-{i + 1}1СО";
                group.EducationForm = EducationFormEnum.FullTime;
                group.EducationLevel = EducationLevelEnum.Specialty;
                group.AdmissionYear = 2020 + i;
                groups.Add(group);
            }
        }
        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (groups.ToList().Find(x => x.Id == id) == null)
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
