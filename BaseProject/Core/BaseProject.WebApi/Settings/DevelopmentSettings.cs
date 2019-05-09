namespace BaseProject.WebApi.Settings
{
    /// <summary>
    /// The caching settings for the application.
    /// </summary>
    public class DevelopmentSettings
    {
        public const string Key = nameof(DevelopmentSettings);

        /// <summary>
        /// Run net core and angular together(Restart when something change)
        /// </summary>
        public bool UseAngularCliServer { get; set; }

        /// <summary>
        /// Run net core and add a proxy for run angular from console.
        /// This should be the angular cli url.
        /// </summary>
        public string UseProxyToSpaDevelopmentServer { get; set; }
    }
}
