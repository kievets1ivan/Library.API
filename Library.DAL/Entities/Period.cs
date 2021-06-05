using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Period : BaseEntity
    {
        [Required]
        [MaxLength(4)]
        public string Year { get; set; }
        public int PublicationPeriodsId { get; set; }
        public PublicationPeriods PublicationPeriods { get; set; }

        public IEnumerable<Publication> Publications { get; private set; }
    }
}
