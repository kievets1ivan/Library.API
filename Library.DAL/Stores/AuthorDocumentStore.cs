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
    public interface IAuthorDocumentStore
    {
        IQueryable<AuthorDocument> GetAuthorsByDocumentId(int documentId);
    }

    public class AuthorDocumentStore : IAuthorDocumentStore
    {
        private readonly ApplicationContext _context;

        public AuthorDocumentStore(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<AuthorDocument> GetAuthorsByDocumentId(int documentId)
        {
            return _context.AuthorDocuments.AsNoTracking()
                                            .Include(x => x.Author)
                                            .Where(x => x.DocumentId == documentId);
        }

    }
}
