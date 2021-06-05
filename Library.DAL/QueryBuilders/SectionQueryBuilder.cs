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
    public interface ISectionQueryBuilder
    {
        IQueryable<Section> Build();
        ISectionQueryBuilder InitSections();
        ISectionQueryBuilder SetTopSection(bool? isTopSection);
    }

    public class SectionQueryBuilder : ISectionQueryBuilder
    {
        private readonly ApplicationContext _context;
        private IQueryable<Section> _query;

        public SectionQueryBuilder(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Section> Build()
        {
            IQueryable<Section> resultQuery = _query;
            _query = null;
            return resultQuery;
        }

        public ISectionQueryBuilder InitSections()
        {
            _query = _context.Sections.AsNoTracking();

            return this;
        }

        public ISectionQueryBuilder SetTopSection(bool? isTopSection)
        {
            if (isTopSection.HasValue)
            {
                _query = _query.Where(d => d.IsTopSection == isTopSection);
            }

            return this;
        }
    }
}
