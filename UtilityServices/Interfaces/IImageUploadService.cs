using System.Threading.Tasks;
using UtilityServices.Models;

namespace UtilityServices.Interfaces
{
    public interface IImageUploadService
    {
        Task<byte[]> GetImage(string fileName);
        Task<string> UploadImage(FileUpload fileUpload);
    }
}
