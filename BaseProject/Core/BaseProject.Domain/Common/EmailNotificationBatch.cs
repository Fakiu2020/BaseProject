using BaseProject.Domain.Enums;
using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public partial class EmailNotificationBatch : Entity, IHasCreationTime
    {
        public EmailNotificationBatch()
        {
            GymOwners = new HashSet<GymOwnerEmailNotificationBatch>();
        }

        public string Message { get; set; }
        public EmailNotificationType Type { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? SentDate { get; set; }

        public virtual ICollection<GymOwnerEmailNotificationBatch> GymOwners { get; private set; }
    }
}
