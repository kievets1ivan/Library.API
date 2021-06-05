using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Udk : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(350)]
        public string Annotation { get; set; }
        [MaxLength(256)] 
        public string UDK { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
