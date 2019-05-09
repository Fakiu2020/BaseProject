using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{

    public partial class CreditCard : Entity, ISoftDelete
    {
        public CreditCard()
        {
            GymMemberPlans = new HashSet<GymMemberPlan>();
            Subscriptions = new HashSet<BraintreeSubscription>();
            Transactions = new HashSet<BraintreeTransaction>();
        }

        public string Token { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string CardType { get; set; }
        public string LastFourNumbers { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<GymMemberPlan> GymMemberPlans { get; private set; }
        public virtual ICollection<BraintreeSubscription> Subscriptions { get; private set; }
        public virtual ICollection<BraintreeTransaction> Transactions { get; private set; }
    }
}
