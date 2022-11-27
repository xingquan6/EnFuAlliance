namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWorkFlow1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "CallChaptorSortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.WorkFlow", "DonationWeeklyChaptorSortOrder", c => c.Int(nullable: false));
            DropColumn("dbo.WorkFlow", "CallChaptorId");
            DropColumn("dbo.WorkFlow", "DonationWeeklyChaptorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkFlow", "DonationWeeklyChaptorId", c => c.String());
            AddColumn("dbo.WorkFlow", "CallChaptorId", c => c.Int(nullable: false));
            DropColumn("dbo.WorkFlow", "DonationWeeklyChaptorSortOrder");
            DropColumn("dbo.WorkFlow", "CallChaptorSortOrder");
        }
    }
}
