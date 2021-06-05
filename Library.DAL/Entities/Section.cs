using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Section : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public bool? IsTopSection { get; set; }
        [Required]
        [MaxLength(256)]
        public string ImageFileName { get; set; }

        public IEnumerable<Document> Documents { get; set; }
    }
}
