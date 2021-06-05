using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class AuthorDocumentDTO : BaseEntityDTO
    {
        public int AuthorId { get; set; }
        public AuthorDTO Author { get; set; }

        public int DocumentId { get; set; }
        public DocumentDTO Document { get; set; }
    }
}
