using Application.DTOs;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<int> Add(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
