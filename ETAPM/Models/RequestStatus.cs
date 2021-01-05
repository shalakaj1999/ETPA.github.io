using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETAPM.Models
{
    public class RequestStatus
    {
        public int RequestStatusId { get; set; }

        [Required] 
        public string RequestStatusName { get; set; }
    }
}