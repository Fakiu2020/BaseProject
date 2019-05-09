using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.WebApi.Common
{
    public class CurrentUser : ICurrentUser
    {
        public int Id => 0;

        public string UserName => string.Empty;

        public bool IsAuthenticated => false;
    }
}
