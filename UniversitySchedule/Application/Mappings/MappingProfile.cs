using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AcademicBuilding, AcademicBuildingDto>().ReverseMap();
            CreateMap<Auditorium, AuditoriumDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<ScheduleItems, ScheduleItemsDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
