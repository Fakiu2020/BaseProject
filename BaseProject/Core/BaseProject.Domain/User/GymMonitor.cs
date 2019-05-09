using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class GymMonitor : Entity
    {
        
        public GymMonitor()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GymOwnerId { get; set; }

        public virtual User User { get; set; }
        public virtual GymOwner GymOwner { get; set; }
    }
}
