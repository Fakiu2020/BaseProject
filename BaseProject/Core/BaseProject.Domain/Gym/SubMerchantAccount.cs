using BaseProject.Domain.Enums;
using System;
using Whoever.Entities;
using Whoever.Entities.Common;

namespace BaseProject.Domain
{
    public partial class SubMerchantAccount : Entity
    {
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Ssn { get; set; }
        public string LegalName { get; set; }
        public string DbaName { get; set; }
        public string TaxId { get; set; }
        public string Descriptor { get; set; }
        public FundingDestination Destination { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public bool TosAccepted { get; set; }
        public bool IsDisabled { get; set; }
        public string MasterMerchantAccountId { get; set; }
        public string MerchantAccountId { get; set; }
        public int SubMerchantAccountStatusId { get; set; }
        public string DisbursementExceptionMessage { get; set; }        
        public string DisbursementExceptionFollowUpAction { get; set; }

        public virtual SubMerchantAccountStatus SubMerchantAccountStatus => Enumeration.GetById<SubMerchantAccountStatus>(SubMerchantAccountStatusId);
    }
}
