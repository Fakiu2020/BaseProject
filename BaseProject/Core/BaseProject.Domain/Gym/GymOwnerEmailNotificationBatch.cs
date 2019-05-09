using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class GymOwnerEmailNotificationBatch
    {
        public GymOwnerEmailNotificationBatch()
        {
        }

        public int GymOwnerId { get; set; }
        public int EmailNotificationBatchId { get; set; }

        public virtual GymOwner GymOwner { get; set; }
        public virtual EmailNotificationBatch EmailNotificationBatch { get; set; }
    }
}
