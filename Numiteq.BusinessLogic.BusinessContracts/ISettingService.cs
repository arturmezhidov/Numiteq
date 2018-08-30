using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface ISettingService : IDataService<Setting>
    {
        T GetSettings<T>() where T: new();

        void SaveSettings<T>(T settings);
    }
}
