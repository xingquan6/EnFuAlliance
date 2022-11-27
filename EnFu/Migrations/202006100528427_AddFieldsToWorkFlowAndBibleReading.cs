namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToWorkFlowAndBibleReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "BibleReadingContent", c => c.String());
            AddColumn("dbo.WorkFlow", "VideoLiveLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow", "VideoLiveLink");
            DropColumn("dbo.BibleReading", "BibleReadingContent");
        }
    }
}
