namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreAudioVideoLinkToBibleReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "Youtube", c => c.String());
            AddColumn("dbo.BibleReading", "Audio1", c => c.String());
            AddColumn("dbo.BibleReading", "Video1", c => c.String());
            AddColumn("dbo.BibleReading", "Audio2", c => c.String());
            AddColumn("dbo.BibleReading", "Video2", c => c.String());
            AddColumn("dbo.BibleReading", "Audio3", c => c.String());
            AddColumn("dbo.BibleReading", "Video3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BibleReading", "Video3");
            DropColumn("dbo.BibleReading", "Audio3");
            DropColumn("dbo.BibleReading", "Video2");
            DropColumn("dbo.BibleReading", "Audio2");
            DropColumn("dbo.BibleReading", "Video1");
            DropColumn("dbo.BibleReading", "Audio1");
            DropColumn("dbo.BibleReading", "Youtube");
        }
    }
}
