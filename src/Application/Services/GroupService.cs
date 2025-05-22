using Application.DTOs;
using Application.Exceptions;
using Application.Requests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.GroupRepository;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupService> _logger;

        public GroupService(IGroupRepository groupRepository, IMapper mapper, ILogger<GroupService> logger)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Add(CreateGroupRequest request)
        {
            var group = new Group()
            {
                GroupName = request.GroupName,
                EducationLevel = request.EducationLevel,
                EducationForm = request.EducationForm,
                AdmissionYear = request.AdmissionYear
            };
            var res = await _groupRepository.Create(group);
            _logger.LogInformation(@"Group with ID = {0} was created.", res);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _groupRepository.Delete(id);
            if (res == false)
            {
                throw new EntityDeleteException("Group for deletion not found");
            }
            _logger.LogInformation(@"Group with ID = {0} was deleted.", id);
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
            if (group == null)
            {
                throw new NotFoundApplicationException("Group not found.");
            }
            var mappedGroup = _mapper.Map<GroupDto>(group);
            return mappedGroup;
        }

        public async Task Update(UpdateGroupRequest request)
        {
            var group = new Group()
            {
                Id = request.Id,
                GroupName = request.GroupName,
                EducationLevel = request.EducationLevel,
                EducationForm = request.EducationForm,
                AdmissionYear = request.AdmissionYear
            };
            var res = await _groupRepository.Update(group);
            if (res == false)
            {
                throw new EntityUpdateException("Group wasn't updated.");
            }
            _logger.LogInformation(@"Group with ID = {0} was updated.", group.Id);
        }
    }
}
