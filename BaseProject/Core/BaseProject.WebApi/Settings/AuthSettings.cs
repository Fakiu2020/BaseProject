namespace BaseProject.WebApi.Settings
{
    public class AuthSettings
    {
        public const string Key = nameof(AuthSettings);

        public string SecretKey { get; set; }
    }
}
