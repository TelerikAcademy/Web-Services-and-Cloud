namespace Teleimot.Web.Api
{
    using Teleimot.Data;
    using Teleimot.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());
        }
    }
}
