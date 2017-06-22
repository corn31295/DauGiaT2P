using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMT2P.Models
{
    public class Register
    {
        public string Username { get; set; }
        public string RawPWD { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
    }
}