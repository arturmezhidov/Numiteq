using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class StepService : DataService<Step>, IStepService
    {
        public StepService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
