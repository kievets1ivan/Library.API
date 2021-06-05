using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Services
{
    public interface IPagingService<T>
    {
        PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize);
    }

    public class PagingService<T> : IPagingService<T>
    {
        public PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (source == null || !source.Any())
            {
                return new PagedList<T>(items: source.ToList(),
                                        count: 0,
                                        pageNumber: pageNumber,
                                        pageSize: pageSize,
                                        totalPages: 0);
            }

            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            var count = source.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            List<T> items = new List<T>();

            if (pageNumber > totalPages)
                pageNumber = totalPages;

            items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize, totalPages);
        }
    }
}
