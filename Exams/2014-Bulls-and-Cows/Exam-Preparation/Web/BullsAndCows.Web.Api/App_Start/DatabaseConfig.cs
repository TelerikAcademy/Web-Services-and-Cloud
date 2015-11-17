namespace BullsAndCows.Web.Api
{
    using BullsAndCows.Data;
    using BullsAndCows.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }
    }
}
