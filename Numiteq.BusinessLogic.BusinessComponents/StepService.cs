using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class StepService : DataService<Step>, IStepService
    {
        public StepService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Step Update(int id, string title, string desc, string icon)
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
