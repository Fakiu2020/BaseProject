using System.Collections.Generic;
using System.Linq;

namespace Whoever.Mailing
{
    public class Message
    {
        public Message()
        {
            To = new Dictionary<string, string>();
            Cc = new Dictionary<string, string>();
            Bcc = new Dictionary<string, string>();
            Attachments = new List<MessageAttachment>();
        }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> To { get; private set; }
        public Dictionary<string, string> Cc { get; private set; }
        public Dictionary<string, string> Bcc { get; private set; }
        public List<MessageAttachment> Attachments { get; private set; }

        public void AddTo(string email)
        {
            AddTo(email, null);
        }

        public void AddTo(string email, string name)
        {
            Add(To, email, name);
        }

        public void AddCc(string email)
        {
            AddCc(email, null);
        }

        public void AddCc(string email, string name)
        {
            Add(Cc, email, name);
        }

        public void AddBcc(string email)
        {
            AddBcc(email, null);
        }

        public void AddBcc(string email, string name)
        {
            Add(Bcc, email, name);
        }

        private void Add(Dictionary<string, string> list, string key, string value)
        {
            if (list.ContainsKey(key)) return;
            list.Add(key, value);
        }

        public void AddAttachment(string name, string type, byte[] content)
        {
            if (Attachments.Any(x => x.Name == name)) return;
            Attachments.Add(new MessageAttachment(name, type, content));
        }
    }
}
