using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class ExpertiseService : DataService<Expertise>, IExpertiseService
    {
        public ExpertiseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
