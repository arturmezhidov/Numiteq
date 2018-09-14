using Microsoft.AspNetCore.Http;
using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IFileService : IDataService<File>
    {
        File CreateFile(IFormFile file);

        string GetFileLink(File file);
    }
}