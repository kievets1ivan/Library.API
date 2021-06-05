using Library.DAL.EF;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Stores
{
    public interface IQuestionAnswerStore
    {
        Task<QuestionAnswer> Add(QuestionAnswer questionAnswer);
        IQueryable<QuestionAnswer> GetByUserId(Guid userId);
        Task<QuestionAnswer> GetById(int questionId, bool asNoTracking = true);
        Task<QuestionAnswer> Update(QuestionAnswer question);
        IQueryable<QuestionAnswer> GetAll();
    }

    public class QuestionAnswerStore : IQuestionAnswerStore
    {
        private readonly ApplicationContext _context;

        public QuestionAnswerStore(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<QuestionAnswer> Add(QuestionAnswer questionAnswer)
        {
            await _context.QuestionAnswers.AddAsync(questionAnswer);
            await _context.SaveChangesAsync();
            return questionAnswer;
        }

        public IQueryable<QuestionAnswer> GetAll()
        {
            return _context.QuestionAnswers.AsNoTracking().OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<QuestionAnswer> GetByUserId(Guid userId)
        {
            return _context.QuestionAnswers.AsNoTracking().Where(x => x.UserId == userId).OrderByDescending(x => x.ModifiedOn);
        }

        public async Task<QuestionAnswer> GetById(int questionId, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.QuestionAnswers.AsNoTracking().SingleOrDefaultAsync(u => u.Id == questionId);
            }

            return await _context.QuestionAnswers.SingleOrDefaultAsync(u => u.Id == questionId);
        }

        public async Task<QuestionAnswer> Update(QuestionAnswer question)
        {
            _context.Update(question);
            await _context.SaveChangesAsync();
            return await GetById(question.Id);
        }
    }
}
