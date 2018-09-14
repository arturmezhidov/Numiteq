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
            MainService mainService = GetById(id);

            if (mainService == null)
            {
                return null;
            }

            mainService.Title = title;
            mainService.Description = desc;
            mainService.Icon = icon;

            Update(mainService);
            Save();

            return mainService;
        }
    }
}
