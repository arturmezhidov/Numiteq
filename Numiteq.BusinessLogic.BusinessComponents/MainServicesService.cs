using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class MainServicesService : DataService<MainService>, IMainServicesService
    {
        public MainServicesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
