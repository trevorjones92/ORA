using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA_Data.Model
{
    public class LoginDM
    {
        public int LoginId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public int EmployeeId { get; set; }
    }
}