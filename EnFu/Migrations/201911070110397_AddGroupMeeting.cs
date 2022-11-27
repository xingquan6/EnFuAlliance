namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupMeeting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupMeeting",
                c => new
                    {
                        GroupMeetingId = c.Int(nullable: false, identity: true),
                        GroupMeetingType = c.String(),
                        GroupMeetingNumber = c.Int(nullable: false),
                        GroupMeetingDate = c.DateTime(),
                        GroupMeetingSundayReportDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupMeetingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupMeeting");
        }
    }
}
