using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string subject, string body, IEnumerable<string> to, IEnumerable<string> toCc);
    }
}
