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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        //POST: api/Author
        public async Task<IActionResult> Create([FromBody] AuthorDTO authorDTO)
        {
            return Ok(await _authorService.Add(authorDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        //PUT: api/Author
        public async Task<IActionResult> Update([FromBody] AuthorDTO authorDTO)
        {
            return Ok(await _authorService.Update(authorDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{authorId}")]
        //DELETE: api/Author/{authorId}
        public async Task<IActionResult> Delete([FromRoute] int authorId)
        {
            return Ok(await _authorService.DeleteById(authorId));
        }
    }
}
