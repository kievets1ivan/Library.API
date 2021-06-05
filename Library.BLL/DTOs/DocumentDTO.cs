using Library.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class DocumentDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public DocumentType DocumentType { get; set; }
        public string YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string ImageFileName { get; set; }
        public string DocumentFileName { get; set; }
        public int Pages { get; set; }
        public bool IsFresh { get; set; }
        public int SectionId { get; set; }

        public SectionDTO Section { get; set; }

        public IEnumerable<AuthorDocumentDTO> AuthorDocuments { get; set; }
    }
}
