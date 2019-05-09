using System;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public partial class Notification : Entity, IHasCreationTime
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReadDate { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual User User { get; set; }
    }
}
