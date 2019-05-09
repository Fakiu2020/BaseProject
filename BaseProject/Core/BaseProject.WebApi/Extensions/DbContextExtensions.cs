using BaseProject.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BaseProject.WebApi.Extensions
{
    public static class DbContextExtensions
    {
        public static void Seed(this BaseProjectDbContext db, IWebHost host)
        {
            if (db.AllMigrationsApplied())
            {
                BaseProjectInitializer.Initialize(db);
            }
        }

        public static bool AllMigrationsApplied(this BaseProjectDbContext db)
        {
            var applied = db.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = db.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}
