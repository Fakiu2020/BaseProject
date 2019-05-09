using BaseProject.Common;
using BaseProject.WebApi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Whoever.Web.Extensions;

namespace BaseProject.WebApi.Extensions
{
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Uses the static files middleware to serve static files. Also adds the Cache-Control and Pragma HTTP
        /// headers. The cache duration is controlled from configuration.
        /// See http://andrewlock.net/adding-cache-control-headers-to-static-files-in-asp-net-core/.
        /// </summary>
        public static IApplicationBuilder UseStaticFilesWithCacheControl(
            this IApplicationBuilder application,
            IConfiguration configuration)
        {
            var cacheProfile = configuration
                .GetSection<CacheProfileSettings>(CacheProfileSettings.Key)
                .CacheProfiles
                .First(x => string.Equals(x.Key, CacheProfileName.StaticFiles, StringComparison.Ordinal))
                .Value;

            var options = new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.ApplyCacheProfile(cacheProfile);
                }
            };

            application.UseStaticFiles(options);
                       //.UseSpaStaticFiles(options);

            return application;
        }
    }
}
