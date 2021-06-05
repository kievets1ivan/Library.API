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
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;

        public QuestionAnswerController(IQuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }

        [HttpGet("{questionId}")]
        //GET: api/QuestionAnswer/{questionId}
        public async Task<IActionResult> GetById([FromRoute] int questionId)
        {
            return Ok(await _questionAnswerService.GetById(questionId));
        }

        [HttpPost]
        //POST: api/QuestionAnswer
        public async Task<IActionResult> Create([FromBody] QuestionAnswerDTO questionAnswerDTO)
        {
            questionAnswerDTO = questionAnswerDTO ?? throw new ArgumentNullException(nameof(questionAnswerDTO));
            questionAnswerDTO.UserId = GetUserId();

            return Ok(await _questionAnswerService.Add(questionAnswerDTO));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        //PUT: api/QuestionAnswer
        public async Task<IActionResult> Update([FromBody] QuestionAnswerDTO questionDTO)
        {
            return Ok(await _questionAnswerService.Update(questionDTO));
        }

        [HttpGet]
        //GET: api/QuestionAnswer
        public IActionResult GetByUserId([FromQuery] PagingParameters pagingParams)
        {
            var userId = GetUserId();

            return Ok(_questionAnswerService.GetByUserId(userId, pagingParams));
        }

        [HttpGet("all")]
        //GET: api/QuestionAnswer/all
        public IActionResult GetAll([FromQuery] PagingParameters pagingParams)
        {
            return Ok(_questionAnswerService.GetAll(pagingParams));
        }

        private Guid GetUserId()
        {
            return new Guid(User.Claims.First(c => c.Type == "id").Value);
        }
    }
}
