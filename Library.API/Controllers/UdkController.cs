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
    public class UdkController : ControllerBase
    {
        private readonly IUdkService _udkService;

        public UdkController(IUdkService udkService)
        {
            _udkService = udkService;
        }

        [HttpGet("{udkId}")]
        //GET: api/Udk/{udkId}
        public async Task<IActionResult> GetById([FromRoute] int udkId)
        {
            return Ok(await _udkService.GetById(udkId));
        }

        [HttpPost]
        //POST: api/Udk
        public async Task<IActionResult> Create([FromBody] UdkDTO udkDTO)
        {
            udkDTO = udkDTO ?? throw new ArgumentNullException(nameof(udkDTO));
            udkDTO.UserId = GetUserId();

            return Ok(await _udkService.Add(udkDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        //PUT: api/Udk
        public async Task<IActionResult> Update([FromBody] UdkDTO udkDTO)
        {
            return Ok(await _udkService.Update(udkDTO));
        }

        [HttpGet]
        //GET: api/Udk
        public IActionResult GetByUserId([FromQuery] PagingParameters pagingParams)
        {
            var userId = GetUserId();

            return Ok(_udkService.GetByUserId(userId, pagingParams));
        }

        [HttpGet("all")]
        //GET: api/Udk/all
        public IActionResult GetAll([FromQuery] PagingParameters pagingParams)
        {
            return Ok(_udkService.GetAll(pagingParams));
        }

        private Guid GetUserId()
        {
            return new Guid(User.Claims.First(c => c.Type == "id").Value);
        }
    }
}
