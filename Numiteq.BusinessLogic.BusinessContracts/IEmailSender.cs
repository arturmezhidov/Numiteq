using System.Collections.Generic;
using System.Threading.Tasks;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(IEnumerable<string> emails, string subject, string message);
    }
}