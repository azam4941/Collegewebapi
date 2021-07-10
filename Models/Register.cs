using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class Register
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string RegNo { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserType { get; set; }

    }
}