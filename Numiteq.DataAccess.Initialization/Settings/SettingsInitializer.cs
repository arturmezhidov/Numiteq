using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.Initialization.Settings
{
    public class SettingsInitializer : BaseInitializer<Setting>, ITableInitializer
    {
        public SettingsInitializer(IUnitOfWork context, IInitializationDataStorage<Setting> storage) : base(context, storage)
        {
        }

        public void Init()
        {
            var items = Storage.GetItems();
            var repository = Context.GetRepository<Setting>();

            if (items == null || repository == null)
            {
                return;
            }

            repository.AddRange(items);

            Context.Save();
        }
    }
}