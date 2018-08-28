using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class FileService : DataService<File>, IFileService
    {
        public FileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
