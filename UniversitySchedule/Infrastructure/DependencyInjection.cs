using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAcademicBuildingRepository, AcademicBuildingRepository>();
            services.AddSingleton<IAuditoriumRepository, AuditoriumRepository>();
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<ILessonRepository, LessonRepository>();
            services.AddSingleton<IScheduleItemsRepository, ScheduleItemsRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
