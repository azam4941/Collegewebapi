using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class User
    {
       
            [Key]
            public int ID { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }

            
            public string Name { get; set; }
            public string City { get; set; }
            public string UserType { get; set; }

    }
}