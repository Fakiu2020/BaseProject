using BaseProject.Persistence;
using BaseProject.WebApi.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace BaseProject.WebApi.Data
{
    public class ProcessDbCommands
    {
        public static void Process(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));


            using (var scope = services.CreateScope())
            {
                try
                {
                    var db = GetDbContext(scope);
                    db.Database.Migrate();
                    db.Seed(host);
                }
                catch (Exception ex)
                {
                    var logger = GetLogger(scope);
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }
        }

        private static BaseProjectDbContext GetDbContext(IServiceScope services)
        {
            var db = services.ServiceProvider.GetService<BaseProjectDbContext>();
            return db;
        }

        private static ILogger<Program> GetLogger(IServiceScope services)
        {
            var logger = services.ServiceProvider.GetRequiredService<ILogger<Program>>();
            return logger;
        }
    }
}
