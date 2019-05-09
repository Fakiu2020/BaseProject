using BaseProject.Domain.Enums;
using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class BraintreeTransaction : Entity, IHasCreationTime
    {
        public BraintreeTransaction()
        {
            Details = new HashSet<PaymentDetail>();
            RefundedTransactions = new HashSet<BraintreeTransaction>();
            TransactionsToMerchantAccount = new HashSet<BraintreeTransaction>();
        }

        public string BraintreeId { get; set; }
        public string Description { get; set; }
        public int BraintreeCustomerId { get; set; }
        public decimal Amount { get; set; }
        public int CreditCardId { get; set; }
        public int? BraintreeSubscriptionId { get; set; }
        public BraintreeTransactionStatus Status { get; set; }
        public int? RefundedTransactionId { get; set; }
        public int? BraintreeTransactionToMerchantAccountId { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual BraintreeCustomer Customer { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual BraintreeSubscription Subscription { get; set; }
        public virtual BraintreeTransaction RefundedTransaction { get; set; }
        public virtual BraintreeTransaction TransactionToMerchantAccount { get; set; }
        public virtual ICollection<PaymentDetail> Details { get; private set; }
        public virtual ICollection<BraintreeTransaction> RefundedTransactions { get; private set; }
        public virtual ICollection<BraintreeTransaction> TransactionsToMerchantAccount { get; private set; }


    }
}
