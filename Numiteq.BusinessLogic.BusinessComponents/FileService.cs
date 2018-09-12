using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Configuration;
using Numiteq.DataAccess.DataContracts;
using File = Numiteq.Common.Entities.File;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class FileService : DataService<File>, IFileService
    {
        private readonly IHostingEnvironment environment;

        public FileService(IUnitOfWork unitOfWork, IHostingEnvironment environment) : base(unitOfWork)
        {
            this.environment = environment;
        }

        public File CreateFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            string fileName = GenerateFileName(file);
            string filePath = GetFilePath(fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            File newFile = new File
            {
                ContentLength = file.Length,
                ContentType = file.ContentType,
                OriginName = file.FileName,
                PhysicalName = fileName
            };

            Add(newFile);

            return newFile;
        }

        public string GetFileLink(File file)
        {
            if (file == null)
            {
                return String.Empty;
            }

            return String.Format("{0}{1}", PlatformConfiguration.UploadsFolderPath, file.PhysicalName);
        }

        private string GetFilePath(string fileName)
        {
            return String.Format("{0}{1}{2}", environment.WebRootPath, PlatformConfiguration.UploadsFolderPath, fileName);
        }

        private string GenerateFileName(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string name = Guid.NewGuid().ToString();

            return String.Format("{0}{1}", name, extension);
        }
    }
}
