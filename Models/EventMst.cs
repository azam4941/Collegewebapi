using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class EventMst
    {
        [Key]
        public int NID { get; set; }

        [StringLength(500)]
        public string NewsEvt { get; set; }
    }
}