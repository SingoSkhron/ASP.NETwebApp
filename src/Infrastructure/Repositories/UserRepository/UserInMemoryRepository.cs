using Bogus;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Repositories.UserRepository
{
    public class UserInMemoryRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();

        public UserInMemoryRepository()
        {
            users = new List<User>();
            PopulateTestData();
        }

        public Task<int> Create(User user)
        {
            user.Id = GetId();
            users.ToList().Add(user);
            return Task.FromResult(user.Id);
        }

        public Task<bool> Delete(int id)
        {
            if (!users.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            users.ToList().RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<User>> ReadAll()
        {
            return Task.FromResult<IEnumerable<User>>(users);
        }

        public Task<User?> ReadById(int id)
        {
            var user = users.ToList().Find(x => x.Id == id);
            return Task.FromResult(user);
        }

        public Task<bool> Update(User user)
        {
            var userToUpdate = users.ToList().Find(x => x.Id == user.Id);
            if (userToUpdate == null)
            {
                return Task.FromResult(false);
            }
            userToUpdate.Type = user.Type;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.GroupId = user.GroupId;
            userToUpdate.AdmissionYear = user.AdmissionYear;
            return Task.FromResult(true);
        }

        private void PopulateTestData()
        {
            var faker = new Faker();
            for (int i = 0; i < 5; i++)
            {
                var user = new User();
                user.Id = i + 1;
                user.FirstName = faker.Person.FirstName;
                user.LastName = faker.Person.LastName;
                user.Type = UserTypeEnum.Student;
                user.GroupId = i + 1;
                user.AdmissionYear = 2020 + i;
                users.Add(user);
            }
        }

        private int GetId()
        {
            int id = 1;
            while (true)
            {
                if (users.ToList().Find(x => x.Id == id) == null)
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
