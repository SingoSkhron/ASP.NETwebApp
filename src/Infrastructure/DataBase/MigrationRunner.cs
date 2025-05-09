using FluentMigrator.Runner;

namespace Infrastructure.DataBase
{
    public class MigrationRunner
    {
        private readonly IMigrationRunner migrationRunner;
        public MigrationRunner(IMigrationRunner migrationRunner)
        {
            this.migrationRunner = migrationRunner;
        }
        public void Run()
        {
            migrationRunner.MigrateUp();
        }
    }
}
