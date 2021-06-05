using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Models
{
    public class PagingParameters
    {
        const int MaxPageSize = 50;

        private int pageSize = 10;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public int PageNumber { get; set; } = 1;
        public string SearchTerm { get; set; }
        public int? SectionId { get; set; }
    }
}
