using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class ExpertiseService : DataService<Expertise>, IExpertiseService
    {
        public ExpertiseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Expertise Update(int id, string title, string desc, string icon)
        {
            var item = GetById(id);

            if (item == null)
            {
                return null;
            }

            item.Title = title;
            item.Description = desc;

            if (!string.IsNullOrEmpty(icon))
            {
                item.Icon = icon;
            }

            Update(item);

            return item;
        }
    }
}