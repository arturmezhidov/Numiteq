using Microsoft.AspNetCore.Http;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class MainServicesService : DataService<MainService>, IMainServicesService
    {
        private readonly IFileService fileService;

        public MainServicesService(IUnitOfWork unitOfWork, IFileService fileService) : base(unitOfWork)
        {
            this.fileService = fileService;
        }

        public override MainService GetById(object entityId)
        {
            MainService mainService = base.GetById(entityId);

            if (mainService != null)
            {
                mainService.File = fileService.GetById(mainService.FileId);
            }

            return mainService;
        }

        public MainService Update(int id, string title, string desc, IFormFile file)
        {
            MainService mainService = base.GetById(id);

            if (mainService == null)
            {
                return null;
            }

            mainService.Title = title;
            mainService.Description = desc;

            if (file != null)
            {
                File newFile = fileService.CreateFile(file);

                if (newFile != null)
                {
                    mainService.File = newFile;
                    mainService.FileId = newFile.Id;
                }
            }

            Update(mainService);

            Save();

            return mainService;
        }
    }
}
