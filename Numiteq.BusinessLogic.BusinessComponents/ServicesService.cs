using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class ServicesService : DataService<Service>, IServicesService
    {
        public ServicesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Service Update(int id, string title, string desc, string icon)
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
