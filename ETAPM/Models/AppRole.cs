using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class AppRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppRoleId { get; set; }

        [Required]
        [StringLength(256)]
        public string AppRoleName { get; set; }
    }
}