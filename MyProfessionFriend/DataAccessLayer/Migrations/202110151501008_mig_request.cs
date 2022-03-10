namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(maxLength: 100),
                        ActivityContent = c.String(maxLength: 100),
                        ActivityDate = c.DateTime(nullable: false),
                        ActivityAdded = c.DateTime(nullable: false),
                        ActivityStatus = c.Boolean(nullable: false),
                        PeopleID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.People", t => t.PeopleID)
                .Index(t => t.PeopleID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PeopleID = c.Int(nullable: false, identity: true),
                        PeopleName = c.String(nullable: false, maxLength: 50),
                        PeopleSurName = c.String(nullable: false, maxLength: 50),
                        PeopleImage = c.String(maxLength: 150),
                        TimelineImage = c.String(maxLength: 150),
                        PeopleBirth = c.DateTime(nullable: false),
                        PeopleAdded = c.DateTime(nullable: false),
                        PeopleAbout = c.String(maxLength: 150),
                        PeopleMail = c.String(nullable: false, maxLength: 50),
                        PeoplePass = c.String(nullable: false, maxLength: 50),
                        PeopleRepass = c.String(nullable: false, maxLength: 50),
                        PeopleTitle = c.String(maxLength: 50),
                        PeopleStatus = c.Boolean(nullable: false),
                        GroupID = c.Int(),
                        ScpartID = c.Int(),
                    })
                .PrimaryKey(t => t.PeopleID)
                .ForeignKey("dbo.Groups", t => t.GroupID)
                .ForeignKey("dbo.SchoolParts", t => t.ScpartID)
                .Index(t => t.GroupID)
                .Index(t => t.ScpartID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(maxLength: 1000),
                        CommentAdded = c.DateTime(nullable: false),
                        CommentStatus = c.Boolean(nullable: false),
                        PeopleID = c.Int(nullable: false),
                        MediaID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Media", t => t.MediaID)
                .ForeignKey("dbo.People", t => t.PeopleID, cascadeDelete: true)
                .Index(t => t.PeopleID)
                .Index(t => t.MediaID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediaID = c.Int(nullable: false, identity: true),
                        MediaSelf = c.String(maxLength: 100),
                        MediaContent = c.String(maxLength: 1000),
                        MediaAdded = c.DateTime(nullable: false),
                        MediaStatus = c.Boolean(nullable: false),
                        PeopleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MediaID)
                .ForeignKey("dbo.People", t => t.PeopleID, cascadeDelete: true)
                .Index(t => t.PeopleID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength: 50),
                        MediaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Media", t => t.MediaID, cascadeDelete: true)
                .Index(t => t.MediaID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 100),
                        GroupNote = c.String(maxLength: 1000),
                        GroupStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.SchoolParts",
                c => new
                    {
                        ScpartID = c.Int(nullable: false, identity: true),
                        ScpartName = c.String(maxLength: 50),
                        ScpartStatus = c.Boolean(nullable: false),
                        SchoolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScpartID)
                .ForeignKey("dbo.Schools", t => t.SchoolID, cascadeDelete: true)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolID = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(maxLength: 100),
                        SchoolAdress = c.String(maxLength: 100),
                        SchoolTel = c.String(maxLength: 50),
                        SchoolStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        ContactDate = c.DateTime(nullable: false),
                        Message = c.String(),
                        ContactStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolParts", "SchoolID", "dbo.Schools");
            DropForeignKey("dbo.People", "ScpartID", "dbo.SchoolParts");
            DropForeignKey("dbo.People", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Comments", "PeopleID", "dbo.People");
            DropForeignKey("dbo.Tags", "MediaID", "dbo.Media");
            DropForeignKey("dbo.Media", "PeopleID", "dbo.People");
            DropForeignKey("dbo.Comments", "MediaID", "dbo.Media");
            DropForeignKey("dbo.Activities", "PeopleID", "dbo.People");
            DropIndex("dbo.SchoolParts", new[] { "SchoolID" });
            DropIndex("dbo.Tags", new[] { "MediaID" });
            DropIndex("dbo.Media", new[] { "PeopleID" });
            DropIndex("dbo.Comments", new[] { "MediaID" });
            DropIndex("dbo.Comments", new[] { "PeopleID" });
            DropIndex("dbo.People", new[] { "ScpartID" });
            DropIndex("dbo.People", new[] { "GroupID" });
            DropIndex("dbo.Activities", new[] { "PeopleID" });
            DropTable("dbo.Messages");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Contacts");
            DropTable("dbo.Admins");
            DropTable("dbo.Schools");
            DropTable("dbo.SchoolParts");
            DropTable("dbo.Groups");
            DropTable("dbo.Tags");
            DropTable("dbo.Media");
            DropTable("dbo.Comments");
            DropTable("dbo.People");
            DropTable("dbo.Activities");
        }
    }
}
