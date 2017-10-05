<<<<<<< HEAD
=======
﻿using System;
using System.Collections.Generic;
>>>>>>> 386b201499e73d21a7ce3c78e5996ac6ba23bcb6
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
<<<<<<< HEAD

=======
>>>>>>> 386b201499e73d21a7ce3c78e5996ac6ba23bcb6
{
    public class LoginVM
    {
        public int LoginId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$", ErrorMessage = "Password must be at least 8 characters, no more than 15 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit")]
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