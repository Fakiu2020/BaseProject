using Microsoft.EntityFrameworkCore;
using BaseProject.Domain;

namespace BaseProject.Persistence
{
    public partial class BaseProjectDbContext
    {
        #region Braintree

        //public virtual DbSet<BraintreeCustomer> BraintreeCustomers { get; set; }
        //public virtual DbSet<BraintreeSubscription> BraintreeSubscriptions { get; set; }
        //public virtual DbSet<BraintreeSubscriptionEvent> BraintreeSubscriptionEvents { get; set; }
        //public virtual DbSet<BraintreeTransaction> BraintreeTransactions { get; set; }

        #endregion

        #region Common

        //public virtual DbSet<Address> Addresses { get; set; }
        //public virtual DbSet<CreditCard> CreditCards { get; set; }
        //public virtual DbSet<Day> Days { get; set; }
        //public virtual DbSet<EmailNotificationBatch> EmailNotificationBatches { get; set; }
        //public virtual DbSet<FingerPrint> FingerPrints { get; set; }
        //public virtual DbSet<Notification> Notifications { get; set; }
        //public virtual DbSet<Setting> Settings { get; set; }
        //public virtual DbSet<State> States { get; set; }

        #endregion

        #region Gym

        //public virtual DbSet<Gym> Gyms { get; set; }
        //public virtual DbSet<GymOwnerEmailNotificationBatch> GymOwnerEmailNotificationBatches { get; set; }
        //public virtual DbSet<GymTermsOfServices> GymTermsOfServices { get; set; }
        //public virtual DbSet<Kiosk> Kiosks { get; set; }
        //public virtual DbSet<KioskAccess> KioskAccesses { get; set; }
        //public virtual DbSet<KioskFingerPrint> KioskFingerPrints { get; set; }
        //public virtual DbSet<SubMerchantAccount> SubMerchantAccounts { get; set; }

        #endregion

        #region GymMember

       // public virtual DbSet<GymMemberGymTermsOfServices> GymMemberGymToses { get; set; }

        #endregion

        #region GymMemberPlan

        //public virtual DbSet<Group> Groups { get; set; }
        //public virtual DbSet<GroupGymMember> GroupGymMembers { get; set; }
        //public virtual DbSet<GymMemberChild> GymMemberChildren { get; set; }
        //public virtual DbSet<GymMemberPlan> GymMemberPlans { get; set; }

        #endregion

        #region GymPlan

        //public virtual DbSet<EnrollmentFee> EnrollmentFees { get; set; }
        //public virtual DbSet<GymPlan> GymPlans { get; set; }
        //public virtual DbSet<GymPlanDay> GymPlanDays { get; set; }
        //public virtual DbSet<GymPlanFrequency> GymPlanFrequencies { get; set; }
        //public virtual DbSet<PriceRange> PriceRanges { get; set; }

        #endregion

        #region JWT

       // public virtual DbSet<ApplicationClient> ApplicationClients { get; set; }
        public virtual DbSet<DeviceToken> DeviceTokens { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion

        #region Payments

        //public virtual DbSet<Payment> Payments { get; set; }
        //public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

        #endregion

        #region User

        //public virtual DbSet<Administrator> Administrators { get; set; }
        //public virtual DbSet<GymMember> GymMembers { get; set; }
        //public virtual DbSet<GymMonitor> GymMonitors { get; set; }
        //public virtual DbSet<GymOwner> GymOwners { get; set; }

        #endregion
    }
}
