using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class SettingService : DataService<Setting>, ISettingService
    {
        public SettingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
