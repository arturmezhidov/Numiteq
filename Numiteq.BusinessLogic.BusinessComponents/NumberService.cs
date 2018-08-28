using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class NumberService : DataService<Number>, INumberService
    {
        public NumberService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
