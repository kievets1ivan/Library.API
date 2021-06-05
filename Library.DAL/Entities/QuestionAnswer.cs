using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class QuestionAnswer : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Question { get; set; }
        [MaxLength(200)]
        public string Answer { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
