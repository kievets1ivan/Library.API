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
    public interface IAuthorStore
    {
        Task<Author> GetById(int authorId, bool asNoTracking = true);
        Task<Author> Add(Author author);
        Task<Author> Delete(Author author);
        Task<Author> Update(Author author);
    }

    public class AuthorStore : IAuthorStore
    {
        private readonly ApplicationContext _context;

        public AuthorStore(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Author> GetById(int authorId, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.Authors.AsNoTracking().Include(x => x.AuthorDocuments).SingleOrDefaultAsync(f => f.Id == authorId);
            }

            return await _context.Authors.Include(x => x.AuthorDocuments).SingleOrDefaultAsync(f => f.Id == authorId);
        }

        public async Task<Author> Add(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            _context.Update(author);
            await _context.SaveChangesAsync();
            return await GetById(author.Id);
        }

        public async Task<Author> Delete(Author author)
        {
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }



    }
}
