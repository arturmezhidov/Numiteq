using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class MessageEmailService : DataService<MessageEmail>, IMessageEmailService
    {
        public MessageEmailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}