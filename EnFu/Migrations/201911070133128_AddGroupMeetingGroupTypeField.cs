namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupMeetingGroupTypeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupMeeting", "GroupType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupMeeting", "GroupType");
        }
    }
}
