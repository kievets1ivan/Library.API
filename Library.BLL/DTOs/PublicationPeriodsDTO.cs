using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class PublicationPeriodsDTO : BaseEntityDTO
    {
        public string ImageFileName { get; set; }

        public IEnumerable<PeriodDTO> Periods { get; set; }
    }
}
