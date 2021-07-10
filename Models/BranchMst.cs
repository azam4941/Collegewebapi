using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class BranchMst
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string BranchName { get; set; }

        [ForeignKey("Student")]
        public int StudentMstID { get; set; }
        public StudentMst Student { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherMstID { get; set; }
        public TeacherMst Teacher { get; set; }
    }
}