using Library.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Document : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        public DocumentType DocumentType { get; set; }
        public string YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        [Required]
        public string ImageFileName { get; set; }
        [Required]
        public string DocumentFileName { get; set; }
        [Required]
        public int Pages { get; set; }
        public bool? IsFresh { get; set; }
        public int SectionId { get; set; }

        public Section Section { get; set; }

        public IEnumerable<AuthorDocument> AuthorDocuments { get; private set; }
    }
}
