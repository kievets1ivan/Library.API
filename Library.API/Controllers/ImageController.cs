using Library.DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtilityServices.Interfaces;
using UtilityServices.Models;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService;

        public ImageController(IImageUploadService imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        //GET: api/Image
        public async Task<IActionResult> GetImage([FromQuery] string fileName)
        {
            return File(await _imageUploadService.GetImage(fileName), "image/jpeg");
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/Image
        public async Task<IActionResult> AddImage([FromForm] FileUpload fileUpload)
        {
            return Ok(await _imageUploadService.UploadImage(fileUpload));
        }
    }
}
