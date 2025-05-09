using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAcademicBuildingRepository, AcademicBuildingInMemoryRepository>();
            services.AddSingleton<IAuditoriumRepository, AuditoriumInMemoryRepository>();
            services.AddSingleton<IGroupRepository, GroupInMemoryRepository>();
            services.AddSingleton<ILessonRepository, LessonInMemoryRepository>();
            services.AddSingleton<IScheduleItemsRepository, ScheduleItemsInMemoryRepository>();
            services.AddSingleton<IUserRepository, UserInMemoryRepository>();
            return services;
        }
    }
}
