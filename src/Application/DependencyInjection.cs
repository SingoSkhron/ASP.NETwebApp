using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IAcademicBuildingService, AcademicBuildingService>();
            services.AddTransient<IAuditoriumService, AuditoriumService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IScheduleItemsService, ScheduleItemsService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
