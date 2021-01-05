using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
         

        [Required]
        public int Progress { get; set; }

        [Required]
        public int TaskStatusId { get; set; }

        [ForeignKey("ParentTask")]
        public int? ParentTaskId { get; set; }


        [ForeignKey("AssignedBy")]
        public int AssignedByAppUserId { get; set; }
        [ForeignKey("AssignedTo")]
        public int AssignedToAppUserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        public virtual TaskStatus TaskStatus { get; set; }
        public virtual Task ParentTask { get; set; }
        public virtual AppUser AssignedBy { get; set; }
        public virtual AppUser AssignedTo { get; set; }


        public int RemainingDuration {
            get
            {
                if (DateTime.Now <= StartDateTime)
                    return Duration;

                if (DateTime.Now >= EndDateTime)
                    return 0;

                return Convert.ToInt32((EndDateTime - DateTime.Now).TotalMinutes);
            }
        }
    }
}