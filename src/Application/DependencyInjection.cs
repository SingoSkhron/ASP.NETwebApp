using Application.Mappings;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
