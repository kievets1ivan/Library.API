using Library.DAL.EF;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.QueryBuilders
{
    public interface IDocumentQueryBuilder
    {
        IQueryable<Document> Build();
        IDocumentQueryBuilder InitDocs();
        IDocumentQueryBuilder OrderByCreatedOn();
        IDocumentQueryBuilder SetFreshFlag(bool? isFresh);
        IDocumentQueryBuilder SetTakeAmount(int? takeAmount);
        IDocumentQueryBuilder SetSearchTerm(string searchTitle);
        IDocumentQueryBuilder SetSection(int? sectionId);
    }

    public class DocumentQueryBuilder : IDocumentQueryBuilder
    {
        private readonly ApplicationContext _context;
        private IQueryable<Document> _query;

        public DocumentQueryBuilder(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Document> Build()
        {
            IQueryable<Document> resultQuery = _query;
            _query = null;
            return resultQuery;
        }

        public IDocumentQueryBuilder InitDocs()
        {
            _query = _context.Documents.AsNoTracking().Include(d => d.AuthorDocuments).ThenInclude(x => x.Author);

            return this;
        }

        public IDocumentQueryBuilder SetFreshFlag(bool? isFresh)
        {
            if (isFresh.HasValue)
            {
                _query = _query.Where(d => d.IsFresh == isFresh);
            }

            return this;
        }

        public IDocumentQueryBuilder OrderByCreatedOn()
        {
            _query = _query.OrderByDescending(d => d.CreatedOn);

            return this;
        }

        public IDocumentQueryBuilder SetTakeAmount(int? takeAmount)
        {
            if (takeAmount.HasValue)
            {
                _query = _query.Take(takeAmount.Value);
            }

            return this;
        }

        public IDocumentQueryBuilder SetSearchTerm(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var selectedByTitle  = _query.Where(x => x.Title.Contains(searchTerm));
                var selectedByAuthor  = _query.Where(x => x.AuthorDocuments.Any(a => a.Author.FirstName.Contains(searchTerm) || a.Author.LastName.Contains(searchTerm)));
                var selectedByYearOfPublicion  = _query.Where(x => x.YearOfPublication.Contains(searchTerm));

                _query = selectedByTitle.Union(selectedByAuthor).Union(selectedByYearOfPublicion);
            }

            return this;
        }

        public IDocumentQueryBuilder SetSection(int? sectionId)
        {
            if (sectionId.HasValue)
            {
                _query = _query.Where(d => d.SectionId == sectionId);
            }

            return this;
        }
    }
}
