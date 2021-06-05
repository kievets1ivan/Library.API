using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class PublicationDTO : BaseEntityDTO
    {
        public int Number { get; set; }
        public string PublicationLink { get; set; }
        public int PeriodId { get; set; }
        public PeriodDTO Period { get; set; }
    }
}
