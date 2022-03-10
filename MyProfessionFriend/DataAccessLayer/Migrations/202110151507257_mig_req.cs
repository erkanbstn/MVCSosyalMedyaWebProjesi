namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_req : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        RFID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        RFDate = c.DateTime(nullable: false),
                        PeopleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RFID)
                .ForeignKey("dbo.People", t => t.PeopleID, cascadeDelete: true)
                .Index(t => t.PeopleID);
            
            AddColumn("dbo.People", "People_PeopleID", c => c.Int());
            CreateIndex("dbo.People", "People_PeopleID");
            AddForeignKey("dbo.People", "People_PeopleID", "dbo.People", "PeopleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "PeopleID", "dbo.People");
            DropForeignKey("dbo.People", "People_PeopleID", "dbo.People");
            DropIndex("dbo.FriendRequests", new[] { "PeopleID" });
            DropIndex("dbo.People", new[] { "People_PeopleID" });
            DropColumn("dbo.People", "People_PeopleID");
            DropTable("dbo.FriendRequests");
        }
    }
}
