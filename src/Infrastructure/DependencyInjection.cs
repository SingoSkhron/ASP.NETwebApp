using FluentMigrator.Runner;
using Infrastructure.Repositories.AcademicBuildingRepository;
using Infrastructure.Repositories.AuditoriumRepository;
using Infrastructure.Repositories.GroupRepository;
using Infrastructure.Repositories.LessonRepository;
using Infrastructure.Repositories.ScheduleItemsRepository;
using Infrastructure.Repositories.UserRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("PostgresDB");
                return new NpgsqlDataSourceBuilder(connectionString).Build();
            });

            services.AddScoped(sp =>
            {
                var datasource = sp.GetRequiredService<NpgsqlDataSource>();
                return datasource.CreateConnection();
            });

            services.AddTransient<IAcademicBuildingRepository, AcademicBuildingPostgresRepository>();
            services.AddTransient<IAuditoriumRepository, AuditoriumPostgresRepository>();
            services.AddTransient<IGroupRepository, GroupPostgresRepository>();
            services.AddTransient<ILessonRepository, LessonPostgresRepository>();
            services.AddTransient<IScheduleItemsRepository, ScheduleItemsPostgresRepository>();
            services.AddTransient<IUserRepository, UserPostgresRepository>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(
                rb => rb.AddPostgres()
                .WithGlobalConnectionString("PostgresDB")
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
                )
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddScoped<DataBase.MigrationRunner>();
            DapperConfig.Configure();

            return services;
        }
    }
}
