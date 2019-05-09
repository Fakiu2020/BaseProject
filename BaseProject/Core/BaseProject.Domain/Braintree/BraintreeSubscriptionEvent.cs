using BaseProject.Domain.Enums;
using System;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class BraintreeSubscriptionEvent : Entity, IHasCreationTime
    {
        public int BraintreeSubscriptionId { get; set; }
        public BraintreeSubscriptionStatus Status { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual BraintreeSubscription Subscription { get; set; }
    }
}
