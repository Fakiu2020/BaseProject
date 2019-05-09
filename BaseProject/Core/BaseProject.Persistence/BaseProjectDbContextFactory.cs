using Microsoft.EntityFrameworkCore;
using BaseProject.Persistence.Infrastructure;

namespace BaseProject.Persistence
{
    public class BaseProjectDbContextFactory : DesignTimeDbContextFactoryBase<BaseProjectDbContext>
    {
        protected override BaseProjectDbContext CreateNewInstance(DbContextOptions<BaseProjectDbContext> options)
        {
            return new BaseProjectDbContext(options, null);
        }
    }
}
