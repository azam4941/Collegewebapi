namespace collegewebapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BranchMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 20),
                        StudentMstID = c.Int(nullable: false),
                        TeacherMstID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentMsts", t => t.StudentMstID, cascadeDelete: true)
                .ForeignKey("dbo.TeacherMsts", t => t.TeacherMstID, cascadeDelete: true)
                .Index(t => t.StudentMstID)
                .Index(t => t.TeacherMstID);
            
            CreateTable(
                "dbo.StudentMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RollNo = c.String(maxLength: 50),
                        Name = c.String(),
                        BranchName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        MobileNumber = c.String(maxLength: 50),
                        DateOfBirth = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Pincode = c.String(maxLength: 50),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        BranchName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Qualification = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Pincode = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        Edate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ComplainMsts",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        RoLLNo = c.String(),
                        Name = c.String(),
                        MobileNumber = c.String(maxLength: 50),
                        Complaint = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.EventMsts",
                c => new
                    {
                        NID = c.Int(nullable: false, identity: true),
                        NewsEvt = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NID);
            
            CreateTable(
                "dbo.FeedBackMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 20),
                        Feedbackentered = c.String(maxLength: 500),
                        FeedbackEnrollmentDate = c.String(),
                        RollNo = c.String(),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LeaveMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RollNo = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        BranchName = c.String(maxLength: 50),
                        TeacherName = c.String(maxLength: 50),
                        Message = c.String(maxLength: 500),
                        NumberOfDays = c.Int(),
                        Reply = c.String(maxLength: 50),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(maxLength: 20),
                        email = c.String(),
                        Password = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UpgradMsts",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Grade = c.Int(),
                        Marks = c.Int(nullable: false),
                        StudentMstID = c.Int(nullable: false),
                        TeacherMstID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.StudentMsts", t => t.StudentMstID, cascadeDelete: true)
                .ForeignKey("dbo.TeacherMsts", t => t.TeacherMstID, cascadeDelete: true)
                .Index(t => t.StudentMstID)
                .Index(t => t.TeacherMstID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        City = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpgradMsts", "TeacherMstID", "dbo.TeacherMsts");
            DropForeignKey("dbo.UpgradMsts", "StudentMstID", "dbo.StudentMsts");
            DropForeignKey("dbo.BranchMsts", "TeacherMstID", "dbo.TeacherMsts");
            DropForeignKey("dbo.BranchMsts", "StudentMstID", "dbo.StudentMsts");
            DropIndex("dbo.UpgradMsts", new[] { "TeacherMstID" });
            DropIndex("dbo.UpgradMsts", new[] { "StudentMstID" });
            DropIndex("dbo.BranchMsts", new[] { "TeacherMstID" });
            DropIndex("dbo.BranchMsts", new[] { "StudentMstID" });
            DropTable("dbo.Users");
            DropTable("dbo.UpgradMsts");
            DropTable("dbo.Registers");
            DropTable("dbo.LeaveMsts");
            DropTable("dbo.FeedBackMsts");
            DropTable("dbo.EventMsts");
            DropTable("dbo.ComplainMsts");
            DropTable("dbo.TeacherMsts");
            DropTable("dbo.StudentMsts");
            DropTable("dbo.BranchMsts");
        }
    }
}
