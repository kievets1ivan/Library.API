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
    public interface ISectionStore
    {
        Task<Section> Add(Section section);
        Task<Section> Delete(Section section);
        Task<Section> GetById(int sectionId, bool asNoTracking = true);
        Task<Section> Update(Section section);
    }

    public class SectionStore : ISectionStore
    {
        private readonly ApplicationContext _context;

        public SectionStore(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Section> GetById(int sectionId, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.Sections.AsNoTracking().Include(x => x.Documents).ThenInclude(x => x.AuthorDocuments).ThenInclude(x => x.Author).SingleOrDefaultAsync(f => f.Id == sectionId);
            }

            return await _context.Sections.Include(x => x.Documents).ThenInclude(x => x.AuthorDocuments).ThenInclude(x => x.Author).SingleOrDefaultAsync(f => f.Id == sectionId);
        }

        public async Task<Section> Add(Section section)
        {
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
            return section;
        }

        public async Task<Section> Update(Section section)
        {
            _context.Update(section);
            await _context.SaveChangesAsync();
            return await GetById(section.Id);
        }

        public async Task<Section> Delete(Section section)
        {
            _context.Remove(section);
            await _context.SaveChangesAsync();
            return section;
        }




    }
}
