using Library.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Models
{
    public class SignInResult
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public ErrorCode? ErrorCode { get; set; }
    }
}
