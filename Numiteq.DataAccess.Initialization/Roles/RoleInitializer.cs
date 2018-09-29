using Microsoft.AspNetCore.Identity;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.Initialization.Roles
{
    public class RoleInitializer : BaseInitializer<IdentityRole>, ITableInitializer
    {
        public RoleInitializer(IUnitOfWork context, IInitializationDataStorage<IdentityRole> storage) : base(context, storage)
        {
        }

        public void Init()
        {
            var items = Storage.GetItems();
            var repository = Context.GetRepository<IdentityRole>();

            if (items == null || repository == null)
            {
                return;
            }

            repository.AddRange(items);

            Context.Save();
        }
    }
}