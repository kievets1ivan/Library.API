using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Publication : BaseEntity
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public string PublicationLink { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
    }
}
