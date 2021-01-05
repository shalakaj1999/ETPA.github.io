using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class CreateTask
    { 
        [Required(ErrorMessage ="Title should not be empty")]
        [StringLength(256)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Start date.*")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Hours.*")]
        public int StartHours { get; set; }

        [Required(ErrorMessage = "Minutes.*")]
        public int StartMinutes { get; set; }

        [Required(ErrorMessage = "Duration.*")]
        public int? Duration { get; set; }
          
        public int? ParentTaskId { get; set; }

        [Required(ErrorMessage = "Assigned to a user to complete task")]
        public int AssignedToAppUserId { get; set; } 
         
    }

    public class UpdateTaskProgress
    {
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Progress in %")]
        [Range(0, 100, ErrorMessage = "0-100 % is allowed")]
        public int? Progress { get; set; }
    }

    public class CreateExtraTimeRequest
    {
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Duration.*")]
        public int? Duration { get; set; }
        public string Message { get; set; }
    }
     
}