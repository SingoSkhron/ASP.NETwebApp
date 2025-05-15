using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.UserRepository;

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

        public async Task<int> Add(CreateUserRequest request)
        {
            var user = new User()
            {
                Type = request.Type,
                FirstName = request.FirstName,
                LastName = request.LastName,
                AdmissionYear = request.AdmissionYear,
                GroupId = request.GroupId
            };
            return await _userRepository.Create(user);
        }

        public async Task Delete(int id)
        {
            var res = await _userRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("User for deletion not found");
            }
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
            if (user == null)
            {
                throw new NotFoundApplicationException("User not found.");
            }
            var mappedUser = _mapper.Map<UserDto>(user);
            return mappedUser;
        }

        public async Task Update(UpdateUserRequest request)
        {
            var user = new User()
            {
                Id = request.Id,
                Type = request.Type,
                FirstName = request.FirstName,
                LastName = request.LastName,
                AdmissionYear = request.AdmissionYear,
                GroupId = request.GroupId
            };
            var res = await _userRepository.Update(user);
            if (res == false)
            {
                throw new EntityUpdateException("User wasn't updated.");
            }
        }
    }
}
