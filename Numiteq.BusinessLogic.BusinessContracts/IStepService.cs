using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IStepService : IDataService<Step>
    {
        Step Update(int id, string title, string desc, string icon);
    }
}
