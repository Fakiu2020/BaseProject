using Mandrill;
using Mandrill.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whoever.Mailing.Mandrill
{
    public class MandrillMailing : IMailing
    {
        private readonly IMandrillMessagesApi _api;

        public MandrillMailing(IMandrillMessagesApi api)
        {
            _api = api;
        }

        public async Task<List<MailingResult>> SendEmailsAsync(Message message)
        {
            var email = new MandrillMessage()
            {
                FromEmail = message.FromEmail,
                FromName = message.FromName,
                Subject = message.Subject,
                Html = message.Body
            };

            foreach (var to in message.To)
            {
                email.AddTo(to.Key, to.Value, MandrillMailAddressType.To);
            }
            foreach (var cc in message.Cc)
            {
                email.AddTo(cc.Key, cc.Value, MandrillMailAddressType.Cc);
            }
            foreach (var bcc in message.Bcc)
            {
                email.AddTo(bcc.Key, bcc.Value, MandrillMailAddressType.Bcc);
            }

            foreach (var attachment in message.Attachments)
            {
                email.Attachments.Add(new MandrillAttachment()
                {
                    Name = attachment.Name,
                    Type = attachment.Type,
                    Content = attachment.Content,
                });
            }

            var result = await _api.SendAsync(email);
            return result.Select(x => new MailingResult()
            {
                Id = x.Id,
                Email = x.Email,
                RejectReason = x.RejectReason,
                Status = x.Status.ToString()
            }).ToList();
        }
    }
}
