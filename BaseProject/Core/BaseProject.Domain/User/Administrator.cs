using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class Administrator : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual User User { get; set; }
    }
}
