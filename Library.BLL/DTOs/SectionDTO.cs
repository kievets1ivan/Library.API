using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class SectionDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public bool IsTopSection { get; set; }
        public string ImageFileName { get; set; }

        public IEnumerable<DocumentDTO> Documents { get; set; }
    }
}
