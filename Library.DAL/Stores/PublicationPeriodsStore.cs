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
    public interface IPublicationPeriodsStore
    {
        IEnumerable<PublicationPeriods> GetAll();
        Task<PublicationPeriods> Add(PublicationPeriods publicationPeriods);
    }

    public class PublicationPeriodsStore : IPublicationPeriodsStore
    {
        private readonly ApplicationContext _context;

        public PublicationPeriodsStore(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<PublicationPeriods> GetAll() => _context.PublicationPeriods.AsNoTracking()
                                                                                      .Include(p => p.Periods)
                                                                                      .ThenInclude(p => p.Publications);

        public async Task<PublicationPeriods> Add(PublicationPeriods publicationPeriods)
        {
            await _context.PublicationPeriods.AddAsync(publicationPeriods);
            await _context.SaveChangesAsync();
            return publicationPeriods;
        }
    }
}
