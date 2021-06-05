using System.IO;
using System.Threading.Tasks;
using UtilityServices.Interfaces;
using UtilityServices.Models;
using UtilityServices.Settings;

namespace UtilityServices.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly FolderSettings _folderSettings;
        public ImageUploadService(FolderSettings folderSettings)
        {
            _folderSettings = folderSettings;
        }
        public async Task<string> UploadImage(FileUpload fileUpload)
        {
            using (FileStream fileStream = File.Create(_folderSettings.PathToImgFolder + fileUpload.File.FileName))
            {
                await fileUpload.File.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return fileUpload.File.FileName;
            }
        }

        public async Task<byte[]> GetImage(string fileName)
        {
            return await File.ReadAllBytesAsync(_folderSettings.PathToImgFolder + fileName);
        }
    }
}
