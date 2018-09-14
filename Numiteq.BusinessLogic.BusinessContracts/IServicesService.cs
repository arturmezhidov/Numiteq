using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IServicesService : IDataService<Service>
    {
        Service Update(int id, string title, string desc, string icon);
    }
}
