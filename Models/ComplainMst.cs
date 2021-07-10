using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class ComplainMst
    {
        [Key]
        public int CID { get; set; }
        public string RoLLNo { get; set; }
        public string Name { get; set; }
        [StringLength(50)]
        public string MobileNumber { get; set; }
        public string Complaint { get; set; }
    }
}