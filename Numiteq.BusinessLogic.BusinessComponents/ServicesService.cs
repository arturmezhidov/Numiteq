using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class ServicesService : DataService<Service>, IServicesService
    {
        public ServicesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
