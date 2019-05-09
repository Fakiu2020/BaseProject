using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class BraintreeCustomer : Entity, IHasCreationTime
    {
        public BraintreeCustomer()
        {
            Subscriptions = new HashSet<BraintreeSubscription>();
            Transactions = new HashSet<BraintreeTransaction>();
        }

        public string BraintreeId { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BraintreeSubscription> Subscriptions { get; private set; }
        public virtual ICollection<BraintreeTransaction> Transactions { get; private set; }
    }
}
