using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class AuthorDTO : BaseEntityDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<AuthorDocumentDTO> AuthorDocuments { get; set; }
    }
}
