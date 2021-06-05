using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.BLL.Services;
using Library.DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("{documentId}")]
        //GET: api/Document/{documentId}
        public async Task<IActionResult> GetById([FromRoute] int documentId)
        {
            return Ok(await _documentService.GetById(documentId));
        }

        [HttpGet("query")]
        //GET: api/Document/query
        public IActionResult GetByFreshFlag([FromQuery] DocumentFilterParameters request)
        {
            return Ok(_documentService.GetDocumentsByFreshFlag(request));
        }

        [HttpGet]
        //GET: api/Document
        public IActionResult GetDocuments([FromQuery] PagingParameters pagingParams)
        {
            return Ok(_documentService.GetDocuments(pagingParams));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/Document
        public async Task<IActionResult> Create([FromBody] DocumentDTO documentDTO)
        {
            return Ok(await _documentService.Add(documentDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        //PUT: api/Document
        public async Task<IActionResult> Update([FromBody] DocumentDTO documentDTO)
        {
            return Ok(await _documentService.Update(documentDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{documentId}")]
        //DELETE: api/Document/{documentId}
        public async Task<IActionResult> Delete([FromRoute] int documentId)
        {
            return Ok(await _documentService.DeleteById(documentId));
        }
    }
}
