using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class TaskFile
    {  
        public int TaskFileId { get; set; }
           
        [Required]
        public int TaskId { get; set; }

        [StringLength(128)]
        public string FileName { get; set; }

        [NotMapped]
        [Display(Name = "Attachments")] 
        public List<HttpPostedFileBase> PostedFiles { get; set; }
         
        public virtual Task Task { get; set; }
        
    }
}