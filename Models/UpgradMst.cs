using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{

    public enum Grade
    {
        A, B, C, D, E, F
    }
    public enum Status
    {
        Pass,Fail
    }
    
    public class UpgradMst
    {
        [Key]
        //public int MID { get; set; }

        //[StringLength(50)]
        //public string Rollno { get; set; }

        //[StringLength(50)]
        //public string Name { get; set; }

        //[StringLength(50)]
        //public string BranchName { get; set; }

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Grade? Grade { get; set; }
        public int Marks { get; set; }



        //public Status? Status { get; set; }

        //[ForeignKey("StudentMst")]
        //public int RollNo { get; set; }
        //public StudentMst StudentMst { get; set; }

        //[ForeignKey("TeacherMst")]
        //public int TeacherId { get; set; }
        //public TeacherMst TeacherMst { get; set; }
        [ForeignKey("Student")]
        public int StudentMstID { get; set; }
        public StudentMst Student { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherMstID { get; set; }
        public TeacherMst Teacher { get; set; }


    }
}