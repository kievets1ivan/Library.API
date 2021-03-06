using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class PublicationPeriods : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string ImageFileName { get; set; }

        public IEnumerable<Period> Periods { get; private set; }
    }
}
