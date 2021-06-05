using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityServices.Models;

namespace UtilityServices.Interfaces
{
    public interface IDocumentUploadService
    {
        Task<byte[]> GetDocument(string fileName);
        Task<string> UploadDocument(FileUpload fileUpload);
    }
}
