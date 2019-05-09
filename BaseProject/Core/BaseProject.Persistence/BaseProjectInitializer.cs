using BaseProject.Domain;
using BaseProject.Domain.Constants;
using System;
using System.Linq;
using Whoever.Entities.Common;

namespace BaseProject.Persistence
{
    public class BaseProjectInitializer
    {
        //private readonly Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
        //private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
        //private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        //private readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();
        //private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

        public static void Initialize(BaseProjectDbContext context)
        {
            var initializer = new BaseProjectInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(BaseProjectDbContext context)
        {
            context.Database.EnsureCreated();

            SeedRoles(context);
            SeedUsers(context);
            //return; // Db has been seeded

            if (context.Roles.Any())
            {
                return; // Db has been seeded
            }

            //SeedRegions(context);

            //SeedTerritories(context);

            //SeedEmployees(context);

            //SeedCategories(context);

            //SeedShippers(context);

            //SeedSuppliers(context);

            //SeedProducts(context);

            //SeedOrders(context);
        }

        private void SeedRoles(BaseProjectDbContext context)
        {
            var roles = new[]
            {
                new Role { Id = RolesNames.Admin.Id, Name = RolesNames.Admin.Name, NormalizedName = RolesNames.Admin.Name.ToUpper() },
                new Role { Id = RolesNames.SuperAdmin.Id, Name = RolesNames.SuperAdmin.Name, NormalizedName = RolesNames.SuperAdmin.Name.ToUpper() }
            };

            context.Roles.AddRange(roles);

            context.SaveChanges();
        }

        private void SeedUsers(BaseProjectDbContext context)
        {

            var userSuperAdmin = new User() { FirstName = "Admin", LastName = "Devlights", Email = "admin@devlights.com", UserName = "admin@devlights.com", NormalizedEmail = "admin@devlights.com".ToUpper(), NormalizedUserName = "admin@devlights.com".ToUpper(), CreationTime = DateTime.Now, ConcurrencyStamp = "a07301d1-bc56-4e99-a2b3-b59e438bb129", SecurityStamp = "6YYH5RHYUXZC7RVJ4CHFGYRST465ZVFY", PasswordHash = "AQAAAAEAACcQAAAAECqWq4BVHlxZP8v3+lJHuZEt4rHoP8zQ6peVBNjjQvUDuPHUiC8GkrpuVNEw5O8Q7w==" };
            context.Users.Add(userSuperAdmin);
            var userRole = new UserRole() {
                RoleId = RolesNames.SuperAdmin.Id,
                UserId = userSuperAdmin.Id
            };
            context.UserRoles.Add(userRole);
            //context.Users.AddRange(users);

            context.SaveChanges();
        }

        /*
         context.Database.OpenConnection();
    try
    {
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Employees ON");
        context.SaveChanges();
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Employees OFF");
    }
    finally
    {
        context.Database.CloseConnection();
    }*/
    }
}
