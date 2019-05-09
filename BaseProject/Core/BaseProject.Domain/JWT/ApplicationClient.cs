using BaseProject.Domain.Enums;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Common;

namespace BaseProject.Domain
{
    public class ApplicationClient : Entity<string>
    {
        public ApplicationClient()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public string Secret { get; set; }
        public string Name { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; private set; }
    }
}
