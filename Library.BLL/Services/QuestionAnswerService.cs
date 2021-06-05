using AutoMapper;
using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.Services;
using Library.DAL.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public interface IQuestionAnswerService
    {
        Task<QuestionAnswerDTO> Add(QuestionAnswerDTO questionAnswerDTO);
        PaginationResponse<QuestionAnswerDTO> GetAll(PagingParameters pagingParameters);
        PaginationResponse<QuestionAnswerDTO> GetByUserId(Guid userId, PagingParameters pagingParameters);
        Task<QuestionAnswerDTO> GetById(int questionId);
        Task<QuestionAnswerDTO> Update(QuestionAnswerDTO questionDTO);
    }

    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IQuestionAnswerStore _questionAnswerStore;
        private readonly IMapper _mapper;
        private readonly IPagingService<QuestionAnswer> _pagingService;


        public QuestionAnswerService(IQuestionAnswerStore questionAnswerStore,
                                     IMapper mapper,
                                     IPagingService<QuestionAnswer> pagingService)
        {
            _questionAnswerStore = questionAnswerStore;
            _mapper = mapper;
            _pagingService = pagingService;
        }

        public async Task<QuestionAnswerDTO> Add(QuestionAnswerDTO questionAnswerDTO)
        {
            if (questionAnswerDTO == null)
                throw new ArgumentNullException(nameof(questionAnswerDTO));

            return _mapper.Map<QuestionAnswerDTO>(await _questionAnswerStore.Add(_mapper.Map<QuestionAnswer>(questionAnswerDTO)));
        }

        public PaginationResponse<QuestionAnswerDTO> GetByUserId(Guid userId, PagingParameters pagingParameters)
        {
            var questionAnswers = _questionAnswerStore.GetByUserId(userId);

            var pagedList = _pagingService.ToPagedList(questionAnswers, pagingParameters.PageNumber, pagingParameters.PageSize);

            return new PaginationResponse<QuestionAnswerDTO>
            {
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = _mapper.Map<IEnumerable<QuestionAnswerDTO>>(pagedList.ToArray())
            };
        }

        public PaginationResponse<QuestionAnswerDTO> GetAll(PagingParameters pagingParameters)
        {
            var questionAnswers = _questionAnswerStore.GetAll();

            var pagedList = _pagingService.ToPagedList(questionAnswers, pagingParameters.PageNumber, pagingParameters.PageSize);


            return new PaginationResponse<QuestionAnswerDTO>
            {
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = _mapper.Map<IEnumerable<QuestionAnswerDTO>>(pagedList.ToArray())
            };
        }

        public async Task<QuestionAnswerDTO> GetById(int questionId)
        {
            var question = await _questionAnswerStore.GetById(questionId);

            if (question == null)
                throw new ArgumentNullException(nameof(question));

            return _mapper.Map<QuestionAnswerDTO>(question);
        }

        public async Task<QuestionAnswerDTO> Update(QuestionAnswerDTO questionDTO)
        {
            if (questionDTO == null)
                throw new ArgumentNullException(nameof(questionDTO));

            return _mapper.Map<QuestionAnswerDTO>(await _questionAnswerStore.Update(_mapper.Map<QuestionAnswer>(questionDTO)));
        }
    }
}
