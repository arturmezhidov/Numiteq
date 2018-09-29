using System.Threading.Tasks;
using Numiteq.BusinessLogic.BusinessContracts.Models;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IMessageService
    {
        Task SendMessageAsync(FeedbackMessage message);
    }
}