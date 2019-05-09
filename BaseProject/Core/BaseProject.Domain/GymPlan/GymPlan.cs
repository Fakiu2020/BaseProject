
using BaseProject.Domain.Enums;
using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Common;

namespace BaseProject.Domain
{
    public partial class GymPlan : Entity
    {
        public GymPlan()
        {
            GymPlanDays = new HashSet<GymPlanDay>();
            GymMemberPlans = new HashSet<GymMemberPlan>();
            PriceRanges = new HashSet<PriceRange>();
            EnrollmentFees = new HashSet<EnrollmentFee>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int? GymId { get; set; }
        public bool IsGroup { get; set; }
        public bool Active { get; set; }
        public int? FrequencyId { get; set; }
        public int GymPlanTypeId { get; set; }
        public int? TimeAmount { get; set; }
        public int? TimeUnitId { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public int AnnualFeeScheduleId { get; set; }
        public DateTime? AnnualFeeDate { get; set; }
        public decimal? AnnualFeeAmount { get; set; }
        public decimal? SecondAnnualFeeAmount { get; set; }
        public DateTime? SecondAnnualFeeDate { get; set; }
        public bool IsSpecialtyPlan { get; set; }
        public string PinCode { get; set; }
        public DateTime? BillDate { get; set; }
        public int? GymPlanToConvertId { get; set; }
        public int? Order { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual GymPlanFrequency Frequency { get; set; }
        public virtual GymPlan GymPlanToConvert { get; set; }
        public virtual ICollection<GymPlanDay> GymPlanDays { get; private set; }
        public virtual ICollection<GymMemberPlan> GymMemberPlans { get; private set; }
        public virtual ICollection<PriceRange> PriceRanges { get; private set; }
        public virtual ICollection<EnrollmentFee> EnrollmentFees { get; private set; }

        public virtual TimeUnit TimeUnit => Enumeration.GetById<TimeUnit>(TimeUnitId);
        public virtual AnnualFeeSchedule AnnualFeeSchedule => Enumeration.GetById<AnnualFeeSchedule>(AnnualFeeScheduleId);
        public virtual GymPlanType GymPlanType => Enumeration.GetById<GymPlanType>(GymPlanTypeId);

    }
}
