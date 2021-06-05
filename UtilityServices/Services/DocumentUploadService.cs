using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityServices.Interfaces;
using UtilityServices.Models;
using UtilityServices.Settings;

namespace UtilityServices.Services
{
    

    public class DocumentUploadService : IDocumentUploadService
    {
        private readonly FolderSettings _folderSettings;
        public DocumentUploadService(FolderSettings folderSettings)
        {
            _folderSettings = folderSettings;
        }
        public async Task<string> UploadDocument(FileUpload fileUpload)
        {
            using (FileStream fileStream = File.Create(_folderSettings.PathToDocFolder + fileUpload.File.FileName))
            {
                await fileUpload.File.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return fileUpload.File.FileName;
            }
        }

        public async Task<byte[]> GetDocument(string fileName)
        {
            return await File.ReadAllBytesAsync(_folderSettings.PathToDocFolder + fileName);
        }
    }
}
