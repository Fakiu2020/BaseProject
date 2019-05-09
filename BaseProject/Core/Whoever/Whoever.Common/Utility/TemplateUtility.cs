using System.Collections.Generic;
using System.IO;
using System.Text;
using Whoever.Common.Extensions;

namespace Whoever.Common.Utility
{
    public class TemplateUtility
    {
        private readonly Dictionary<string, string> Cache = new Dictionary<string, string>();

        public TemplateUtility()
        {
        }

        private string GetStringFromFile(string key, string filePath)
        {
            var template = string.Empty;
            if (Cache.ContainsKey(key))
                return Cache[key];

            Cache.Add(key, File.ReadAllText(filePath));
            return Cache[key];
        }

        public string GetTemplate(string fullPath, IDictionary<string, string> templateItems)
        {
            if (!File.Exists(fullPath))
                return string.Empty;

            var sb = new StringBuilder(GetStringFromFile(fullPath, fullPath));
            foreach (var item in templateItems)
            {
                sb.Replace($"{{{item.Key}}}", $"{item.Value}");
            }

            return sb.ToString();
        }

        public string GetTemplate(string fullPath, object templateItems)
        {
            return GetTemplate(fullPath, templateItems.ToDictionary<string>());
        }

    }
}
