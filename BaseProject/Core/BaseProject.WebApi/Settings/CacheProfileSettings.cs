namespace BaseProject.WebApi.Settings
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The caching settings for the application.
    /// </summary>
    public class CacheProfileSettings
    {
        public const string Key = nameof(CacheProfileSettings);

        /// <summary>
        /// Gets or sets the cache profiles (How long to cache things for).
        /// </summary>
        public Dictionary<string, CacheProfile> CacheProfiles { get; set; }
    }
}
