using BaseProject.Domain.Enums;
using System;
using Whoever.Entities;
using Whoever.Entities.Common;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public partial class PaymentDetail : Entity<long>, IHasCreationTime
    {
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int? BraintreeTransactionId { get; set; }
        public int PaymentTypeId { get; set; }
        public string CheckNumber { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual BraintreeTransaction Transaction { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual PaymentType PaymentType => Enumeration.GetById<PaymentType>(PaymentTypeId);
    }
}
