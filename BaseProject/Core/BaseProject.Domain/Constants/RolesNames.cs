using Whoever.Entities.Common;

namespace BaseProject.Domain.Constants
{
    public abstract class RolesNames : Enumeration
    {
        public static RolesNames Admin = new AdminType();
        public static RolesNames SuperAdmin = new SuperAdminType();
        

        protected RolesNames(int id, string name)
            : base(id, name)
        {
        }

        private class AdminType : RolesNames
        {
            public AdminType() : base(2, "Admin")
            { }
        }

        private class SuperAdminType : RolesNames
        {
            public SuperAdminType() : base(1, "Super Admin")
            { }
        }

      
    }
   
}
