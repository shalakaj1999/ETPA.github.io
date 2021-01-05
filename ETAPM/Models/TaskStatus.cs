using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class TaskStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskStatusId { get; set; }

        [Required]
        [StringLength(256)]
        public string TaskStatusName { get; set; }
    }
}