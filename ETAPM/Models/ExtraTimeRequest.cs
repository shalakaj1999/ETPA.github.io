using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class ExtraTimeRequest
    {
        public int ExtraTimeRequestId { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Duration.*")]
        public int Duration { get; set; }

        public string Message { get; set; }

        [Required]
        public int RequestStatusId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        public virtual Task Task { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
    }
}