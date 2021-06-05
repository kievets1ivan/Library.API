using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }

        public IEnumerable<AuthorDocument> AuthorDocuments { get; private set; }
    }
}
