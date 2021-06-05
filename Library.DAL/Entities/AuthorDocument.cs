using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class AuthorDocument : BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
