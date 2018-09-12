using Microsoft.AspNetCore.Http;
using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IMainServicesService : IDataService<MainService>
    {
        MainService Update(int id, string title, string desc, IFormFile file);
    }
}
