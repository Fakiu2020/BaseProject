using GeoAPI.Geometries;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class Gym : Entity
    {
        public Gym()
        {
            GymPlans = new HashSet<GymPlan>();
            Kiosks = new HashSet<Kiosk>();
            GymTermsOfServices = new HashSet<GymTermsOfServices>();
        }

        public string Name { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public int GymOwnerId { get; set; }
        public bool? AllowMobileFingerPrints { get; set; }
        public IPoint Location { get; set; }
        public string PathLogo { get; set; }

        public virtual Address Address { get; set; }
        public virtual GymOwner GymOwner { get; set; }
        public virtual ICollection<GymPlan> GymPlans { get; private set; }
        public virtual ICollection<Kiosk> Kiosks { get; private set; }
        public virtual ICollection<GymTermsOfServices> GymTermsOfServices { get; private set; }
    }
}
