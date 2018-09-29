using System.Linq;
using Microsoft.AspNetCore.Identity;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.SqlDataAccess.Initialization
{
    public class RoleInitializer : BaseInitializer<IdentityRole>, ITableInitializer
    {
        private readonly DataContext context;

        public RoleInitializer(DataContext context, IInitializationDataStorage<IdentityRole> storage) : base(null, storage)
        {
            this.context = context;
        }

        public void Init()
        {
            var items = Storage.GetItems();

            if (items == null || !items.Any())
            {
                return;
            }

            context.Roles.AddRange(items);

            context.SaveChanges();
        }
    }
}