using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class QuestionAnswerDTO : BaseEntityDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid? UserId { get; set; }
    }
}
