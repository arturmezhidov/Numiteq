using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class TechnologyService : DataService<Technology>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
