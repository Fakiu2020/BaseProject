using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class GymOwner : Entity
    {
        public GymOwner()
        {
            EmailNotificationBatches = new HashSet<GymOwnerEmailNotificationBatch>();
            Gyms = new HashSet<Gym>();
            Monitors = new HashSet<GymMonitor>();
            Payments = new HashSet<Payment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SubMerchantAccountId { get; set; }
        public bool UseMasterMerchantAccount { get; set; }
        public string EmailNotification { get; set; }

        public virtual User User { get; set; }
        public virtual SubMerchantAccount SubMerchantAccount { get; set; }
        public virtual ICollection<GymOwnerEmailNotificationBatch> EmailNotificationBatches { get; private set; }
        public virtual ICollection<Gym> Gyms { get; private set; }
        public virtual ICollection<GymMonitor> Monitors { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }
    }
}
