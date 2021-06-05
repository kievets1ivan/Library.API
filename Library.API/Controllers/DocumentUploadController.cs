using Library.DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityServices.Interfaces;
using UtilityServices.Models;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentUploadController : ControllerBase
    {
        private readonly IDocumentUploadService _documentUploadService;

        public DocumentUploadController(IDocumentUploadService documentUploadService)
        {
            _documentUploadService = documentUploadService;
        }

        [HttpGet]
        //GET: api/Image
        public async Task<IActionResult> GetDocument([FromQuery] string fileName)
        {
            return File(await _documentUploadService.GetDocument(fileName), "application/pdf");
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/Image
        public async Task<IActionResult> AddDocument([FromForm] FileUpload fileUpload)
        {
            return Ok(await _documentUploadService.UploadDocument(fileUpload));
        }
    }
}
