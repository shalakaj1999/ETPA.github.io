using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Enter registered mobile no or email id.")]
        [StringLength(256, ErrorMessage = "Mobile mobile no or email id should be 256 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [StringLength(100, ErrorMessage = "Password should be 256 characters long.")]
        [RegularExpression("^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = "Password must contain at least one letter, at least one number, and be longer than six charaters.")]
        public string Password { get; set; }
        public bool KeepMeLogin { get; set; }

    }
}