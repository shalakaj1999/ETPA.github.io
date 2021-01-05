using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int DataId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }

        [ForeignKey("NotificationTo")]
        public int NotificationToAppUserId { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        public virtual AppUser NotificationTo { get; set; }

    }
}