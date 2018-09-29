using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.BusinessLogic.BusinessContracts.Models;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class MessageService : IMessageService
    {
        private readonly IEmailSender sender;
        private readonly IMessageEmailService messageEmailService;

        private const string FEEDBACK_SUBJECT = "Message from contacts!";

        public MessageService(IEmailSender sender, IMessageEmailService messageEmailService)
        {
            this.sender = sender;
            this.messageEmailService = messageEmailService;
        }

        public Task SendMessageAsync(FeedbackMessage feedbackMessage)
        {
            var message = FormatMessage(feedbackMessage);
            var emails = messageEmailService.GetAll().Select(i => i.Email);

            return sender.SendEmailAsync(emails, FEEDBACK_SUBJECT, message);
        }

        protected string FormatMessage(FeedbackMessage message)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Name: {0}\n", message.Name);
            builder.AppendFormat("Email: {0}\n", message.Email);
            builder.AppendFormat("Phone: {0}\n", message.Phone);
            builder.AppendFormat("Company: {0}\n\n", message.Company);
            builder.AppendFormat("Message: {0}\n", message.Message);

            return builder.ToString();
        }
    }
}