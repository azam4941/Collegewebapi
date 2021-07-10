using collegewebapi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace collegewebapi.DAL
{
    public class Collegewebapicontext:DbContext
    {
        public Collegewebapicontext():base("name=collegewebapi")
        {

        }
        public DbSet<StudentMst> StudentMsts { get; set; }
        public DbSet<TeacherMst> TeacherMsts { get; set; }
        public DbSet<BranchMst> BranchMsts {get; set; }
        public DbSet<LeaveMst> LeaveMsts { get; set; }
        public DbSet<FeedBackMst> FeedBackMsts { get; set; }
        public DbSet<UpgradMst> UpgradMsts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<EventMst> EventMsts { get; set; }
        public DbSet<ComplainMst> ComplainMsts { get; set; }


        //public System.Data.Entity.DbSet<collegewebapi.Models.Register> User1 { get; set; }
    }
}