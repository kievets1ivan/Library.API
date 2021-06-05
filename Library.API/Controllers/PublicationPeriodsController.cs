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
    public class PublicationPeriodsController : ControllerBase
    {
        private readonly IPublicationPeriodService _publicationPeriodService;

        public PublicationPeriodsController(IPublicationPeriodService publicationPeriodService)
        {
            _publicationPeriodService = publicationPeriodService;
        }

        [HttpGet]
        //GET: api/PublicationPeriods
        public IActionResult GetAll()
        {
            return Ok(_publicationPeriodService.GetAll());
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/PublicationPeriods
        public async Task<IActionResult> Create([FromBody] PublicationPeriodsDTO publicationPeriodsDTO)
        {
            return Ok(await _publicationPeriodService.Add(publicationPeriodsDTO));
        }
    }
}
