using Library.BLL.DTOs;
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
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        //GET: api/Section
        public IActionResult GetTopSections([FromQuery] bool? isTopSection)
        {
            return Ok(_sectionService.GetSections(isTopSection));
        }

        [HttpGet("{sectionId}")]
        //GET: api/Section/{sectionId}
        public async Task<IActionResult> GetById([FromRoute] int sectionId)
        {
            return Ok(await _sectionService.GetById(sectionId));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/Section
        public async Task<IActionResult> Create([FromBody] SectionDTO sectionDTO)
        {
            return Ok(await _sectionService.Add(sectionDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        //PUT: api/Section
        public async Task<IActionResult> Update([FromBody] SectionDTO sectionDTO)
        {
            return Ok(await _sectionService.Update(sectionDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{sectionId}")]
        //DELETE: api/Section/{sectionId}
        public async Task<IActionResult> Delete([FromRoute] int sectionId)
        {
            return Ok(await _sectionService.DeleteById(sectionId));
        }
    }
}
