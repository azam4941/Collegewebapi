using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class FeedBackMst
    {
        //[Key]
        //public int FID { get; set; }

        //[StringLength(50)]
        //public string Email { get; set; }

        //[StringLength(50)]
        //public string Mobile { get; set; }

        //[StringLength(50)]
        //public string Feedback { get; set; }

        //public DateTime? Edate { get; set; }

        ////[ForeignKey("StudentMst")]
        ////public int RollNo { get; set; }
        ////public StudentMst StudentMst { get; set; }

        //[ForeignKey("Student")]
        //public int StudentMstID { get; set; }
        //public StudentMst Student { get; set; }

        //[ForeignKey("Teacher")]
        //public int TeacherMstID { get; set; }
        //public TeacherMst Teacher { get; set; }

        ////[ForeignKey("TeacherMst")]
        ////public int TeacherId { get; set; }
        ////public TeacherMst TeacherMst { get; set; }
        ///
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string Mobile { get; set; }

        [StringLength(500)]
        public string Feedbackentered { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FeedbackEnrollmentDate { get; set; }

        public string RollNo { get; set; }
        public string TeacherName { get; set; }

    }
}
