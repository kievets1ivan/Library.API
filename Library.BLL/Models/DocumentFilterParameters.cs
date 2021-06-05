using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Models
{
    public class DocumentFilterParameters
    {
        public bool? IsFresh { get; set; }
        public int? TakeAmount { get; set; }
    }
}
