using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTOs
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Speciality { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}
