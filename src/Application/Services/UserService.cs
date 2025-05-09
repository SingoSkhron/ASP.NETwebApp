using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            if (mappedUser != null)
            {
                var mappedUserId = await _userRepository.Create(mappedUser);
                return mappedUserId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.ReadAll();
            var mappedUsers = users.Select(u => _mapper.Map<UserDto>(u));
            return mappedUsers;
        }

        public async Task<UserDto?> GetById(int id)
        {
            var user = await _userRepository.ReadById(id);
            var mappedUser = _mapper.Map<UserDto>(user);
            return mappedUser;
        }

        public async Task<bool> Update(UserDto user)
        {
            if (user == null)
            {
                return false;
            }
            var mappedUser = _mapper.Map<User>(user);
            var existingUser = await _userRepository.ReadById(user.Id);
            if (existingUser == null)
            {
                return false;
            }
            return await _userRepository.Update(mappedUser);
        }
    }
}
