using System.Collections.Generic;
using System.Threading.Tasks;

namespace Whoever.Mailing
{
    public interface IMailing
    {
        Task<List<MailingResult>> SendEmailsAsync(Message message);
    }
}
