using System;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class Kiosk : Entity
    {
        public Kiosk()
        {
            KioskFingerPrints = new HashSet<KioskFingerPrint>();
            KioskAccesses = new HashSet<KioskAccess>();
            Payments = new HashSet<Payment>();
        }

        public Guid KioskIdentifier { get; set; }
        public int GymId { get; set; }
        public string VpnUsername { get; set; }
        public string VpnPassword { get; set; }
        public string VpnIpAddress { get; set; }
        public string Name { get; set; }
        public bool IsBillingEnabled { get; set; }
        public DateTime? FeeExpirationDate { get; set; }
        public DateTime? LastActiveTimeStamp { get; set; }
        public DateTime? SentEmailFail { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual ICollection<KioskFingerPrint> KioskFingerPrints { get; private set; }
        public virtual ICollection<KioskAccess> KioskAccesses { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }
    }
}
