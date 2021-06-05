using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class PeriodDTO : BaseEntityDTO
    {
        public string Year { get; set; }
        public int PublicationPeriodsId { get; set; }
        public PublicationPeriodsDTO PublicationPeriods { get; set; }

        public IEnumerable<PublicationDTO> Publications { get; set; }
    }
}
