using System;

namespace Whoever.Common
{
    public abstract class AppSettingsBase : IAppSettingsBase
    {
        public string PathBase
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

    }
}