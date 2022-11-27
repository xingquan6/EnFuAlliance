namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUselessFieldFromGroupMeeting : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GroupMeeting", "GroupMeetingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupMeeting", "GroupMeetingDate", c => c.DateTime());
        }
    }
}
