using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class MainServicesService : DataService<MainService>, IMainServicesService
    {
        public MainServicesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public MainService Update(int id, string title, string desc, string icon)
        {
            var item = GetById(id);

            if (item == null)
            {
                return null;
            }

            item.Title = title;
            item.Description = desc;
            item.Icon = icon;

            Update(item);

            return item;
        }
    }
}
