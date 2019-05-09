using System;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public class RefreshToken : Entity<string>
    {
        public string Subject { get; set; }
        public string ApplicationClientId { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }

        //public virtual ApplicationClient ApplicationClient { get; set; }

    }
}
