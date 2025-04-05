using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public UserRepository()
        {
            PopulateTestData();
        }
        public Task Create(User user)
        {
            users.Add(user);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int id)
        {
            if (!users.Any(x => x.Id == id))
            {
                return Task.FromResult(false);
            }
            users.RemoveAll(x => x.Id == id);
            return Task.FromResult(true);
        }

        public Task<List<User>> ReadAll()
        {
            return Task.FromResult(users);
        }

        public Task<User?> ReadById(int id)
        {
            var user = users.Find(x => x.Id == id);
            return Task.FromResult(user);
        }

        public Task<bool> Update(User user)
        {
            var userToUpdate = users.Find(x => x.Id == user.Id);
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
            users = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                var user = new User();
                user.Id = i + 1;
                user.FirstName = faker.Person.FirstName;
                user.LastName = faker.Person.LastName;
                user.Type = "Студент";
                user.GroupId = i + 1;
                user.AdmissionYear = 2020 + i;
                users.Add(user);
            }
        }
    }
}
