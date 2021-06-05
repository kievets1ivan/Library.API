using Microsoft.AspNetCore.Http;

namespace UtilityServices.Models
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
    }
}
