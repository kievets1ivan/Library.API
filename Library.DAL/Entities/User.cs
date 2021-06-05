using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid RoleId { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        [MaxLength(256)]
        public string Status { get; set; }
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Patronymic { get; set; }
        [MaxLength(256)]
        public string Faculty { get; set; }
        public int? Course { get; set; }
        [MaxLength(256)]
        public string Speciality { get; set; }
        [MaxLength(256)]
        public string Department { get; set; }
        [MaxLength(256)]
        public string Position { get; set; }
        [Required]
        [MaxLength(256)]
        public string Gender { get; set; }

        public IdentityRole<Guid> Role { get; set; }
    }
}
