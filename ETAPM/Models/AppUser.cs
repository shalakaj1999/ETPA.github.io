using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public string UniqueName {
            get
            {
                return string.Format("{0} {1} <{2}>", FirstName, LastName, EmailId);
            }
        }


        [Required]
        [StringLength(10)]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(256)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        [Required]
        public int AppRoleId { get; set; }

        public virtual AppRole AppRole { get; set; }
    }
}