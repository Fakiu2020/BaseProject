namespace BaseProject.WebApi.Settings
{
    public class ResponseCompressionSettings
    {
        public const string Key = nameof(ResponseCompressionSettings);

        public string[] MimeTypes { get; set; }
    }
}
