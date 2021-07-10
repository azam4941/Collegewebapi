using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegewebapi.Models
{
    public class TeacherMst
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Qualification { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Pincode { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Edate { get; set; }

        //public virtual ICollection<FeedBackMst> FeedBackMsts { get; set; }
        //public virtual ICollection<LeaveMst> LeaveMsts { get; set; }
        //public virtual ICollection<UpgradMst> UpgradMsts { get; set; }
        //public virtual ICollection<BranchMs> BranchMss { get; set; }
    }
}