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
    public interface IDocumentStore
    {
        Task<Document> Add(Document document);
        Task<Document> Delete(Document document);
        Task<Document> GetById(int id, bool asNoTracking = true);
        Task<Document> Update(Document document);
        IQueryable<Document> GetAll();
    }

    public class DocumentStore : IDocumentStore
    {

        private readonly ApplicationContext _context;

        public DocumentStore(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Document> GetAll() => _context.Documents.AsNoTracking()
                                                                  .Include(d => d.AuthorDocuments)
                                                                  .ThenInclude(d => d.Author);

        public async Task<Document> GetById(int id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.Documents.AsNoTracking().Include(f => f.AuthorDocuments).ThenInclude(a => a.Author).SingleOrDefaultAsync(f => f.Id == id);
            }

            return await _context.Documents.Include(f => f.AuthorDocuments).ThenInclude(a => a.Author).SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Document> Add(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> Update(Document document)
        {
            _context.Update(document);
            await _context.SaveChangesAsync();
            return await GetById(document.Id);
        }

        public async Task<Document> Delete(Document document)
        {
            _context.Remove(document);
            await _context.SaveChangesAsync();
            return document;
        }
    }
}
