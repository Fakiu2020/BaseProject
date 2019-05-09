using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class BraintreeSubscription : Entity, IHasCreationTime
    {
        public BraintreeSubscription()
        {
            Transactions = new HashSet<BraintreeTransaction>();
            Events = new HashSet<BraintreeSubscriptionEvent>();
        }

        public string BraintreeId { get; set; }
        public string PlanId { get; set; }
        public int BraintreeCustomerId { get; set; }
        public int CreditCardId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ActiveUntil { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual BraintreeCustomer Customer { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<BraintreeTransaction> Transactions { get; private set; }
        public virtual ICollection<BraintreeSubscriptionEvent> Events { get; private set; }
    }
}
