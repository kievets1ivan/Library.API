using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class PagedList<T> : List<T>
    {
		public int PageNumber { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public PagedList(List<T> items, int count, int pageNumber, int pageSize, int totalPages)
		{
			TotalCount = count;
			PageSize = pageSize;
			PageNumber = pageNumber;
			TotalPages = totalPages;

			AddRange(items);
		}
	}
}
