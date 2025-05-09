using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(GroupDto group)
        {
            var mappedGroup = _mapper.Map<Group>(group);
            if (mappedGroup != null)
            {
                var mappedGroupId = await _groupRepository.Create(mappedGroup);
                return mappedGroupId;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            return await _groupRepository.Delete(id);
        }

        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            var groups = await _groupRepository.ReadAll();
            var mappedGroups = groups.Select(u => _mapper.Map<GroupDto>(u));
            return mappedGroups;
        }

        public async Task<GroupDto?> GetById(int id)
        {
            var group = await _groupRepository.ReadById(id);
            var mappedGroup = _mapper.Map<GroupDto>(group);
            return mappedGroup;
        }

        public async Task<bool> Update(GroupDto group)
        {
            if (group == null)
            {
                return false;
            }
            var mappedGroup = _mapper.Map<Group>(group);
            var existingGroup = await _groupRepository.ReadById(group.Id);
            if (existingGroup == null)
            {
                return false;
            }
            return await _groupRepository.Update(mappedGroup);
        }
    }
}
