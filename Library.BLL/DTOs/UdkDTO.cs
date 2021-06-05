using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class UdkDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public string Annotation { get; set; }
        public string UDK { get; set; }
        public Guid? UserId { get; set; }
    }
}
