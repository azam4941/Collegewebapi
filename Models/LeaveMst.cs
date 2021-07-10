using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class LeaveMst
    {
        //[Key]
        //public int LID { get; set; }

        //[StringLength(50)]
        //public string Rollno { get; set; }

        //[StringLength(50)]
        //public string Name { get; set; }

        //[StringLength(50)]
        //public string BranchName { get; set; }

        //[StringLength(500)]
        //public string Message { get; set; }

        //public int? Nodays { get; set; }

        //[StringLength(50)]
        //public string Reply { get; set; }

        //public DateTime? Edate
        //{
        //    get; set;
        //}
        ////[ForeignKey("StudentMst")]
        ////public int RollNo { get; set; }
        ////public StudentMst StudentMst { get; set; }

        ////[ForeignKey("TeacherMst")]
        ////public int TeacherId { get; set; }
        ////public TeacherMst TeacherMst { get; set; }
        //[ForeignKey("Student")]
        //public int StudentMstID { get; set; }
        //public StudentMst Student { get; set; }

        //[ForeignKey("Teacher")]
        //public int TeacherMstID { get; set; }
        //public TeacherMst Teacher { get; set; }

        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string RollNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public int? NumberOfDays { get; set; }

        [StringLength(50)]
        public string Reply { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

       
    }
}