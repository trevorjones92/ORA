<<<<<<< HEAD
﻿namespace ORA.Models
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORA.Models
>>>>>>> 89562c2daffb2b1e31bd1f535fa184120dd28224
{
    public class LoginVM
    {
        public int LoginId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$",ErrorMessage = "Password must be at least 8 characters, no more than 15 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$", ErrorMessage = "Password must be at least 8 characters, no more than 15 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }

        public int EmployeeId { get; set; }
    }
}