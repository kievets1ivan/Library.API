using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        //POST: api/user/signUp
        public async Task<IActionResult> SignUp([FromBody] SignUpModel newUserModel)
        {
            return Ok(await _userService.SignUp(newUserModel));
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        //POST: api/user/signIn
        public async Task<IActionResult> SignIn([FromBody] AuthModel user)
        {
            var result = await _userService.SignIn(user);
            if (result.IsSuccess)
                HttpContext.Response.Cookies.Append("Token", result.Token);

            return Ok(new AuthResponse { IsSuccess = result.IsSuccess, ErrorCode = result.ErrorCode });
        }

        [HttpGet]
        //GET: api/user
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(await _userService.GetUserById(GetUserId()));
        }

        [HttpPut]
        //PUT: api/user
        public async Task<IActionResult> Update([FromBody] UserDTO userDTO)
        {
            return Ok(await _userService.UpdateUser(userDTO, GetUserId()));
        }

        private Guid GetUserId()
        {
            return new Guid(User.Claims.First(c => c.Type == "id").Value);
        }
    }
}
