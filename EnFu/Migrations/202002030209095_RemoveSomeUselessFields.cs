namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSomeUselessFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "SermonAudioUrl", c => c.String());
            DropColumn("dbo.CallChaptor", "IsActive");
            DropColumn("dbo.CallChaptor", "SortOrder");
            DropColumn("dbo.WorkFlow", "CallChaptorSortOrder");
            DropColumn("dbo.WorkFlow", "DonationWeeklyChaptorSortOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkFlow", "DonationWeeklyChaptorSortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.WorkFlow", "CallChaptorSortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.CallChaptor", "SortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.CallChaptor", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.WorkFlow", "SermonAudioUrl");
        }
    }
}
