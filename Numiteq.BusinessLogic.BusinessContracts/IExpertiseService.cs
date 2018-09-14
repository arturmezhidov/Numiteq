using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IExpertiseService : IDataService<Expertise>
    {
        Expertise Update(int id, string title, string desc, string icon);
    }
}
