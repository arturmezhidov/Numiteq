using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface INumberService : IDataService<Number>
    {
        Number Add(int value, string label);

        Number Update(int id, int value, string label);
    }
}
