namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBibleReadingColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "AudioEnfu", c => c.String());
            AddColumn("dbo.BibleReading", "VideoEnfu", c => c.String());
            AddColumn("dbo.BibleReading", "AudioCai", c => c.String());
            AddColumn("dbo.BibleReading", "BibleUrl", c => c.String());
            DropColumn("dbo.BibleReading", "Audio1");
            DropColumn("dbo.BibleReading", "Video1");
            DropColumn("dbo.BibleReading", "Audio2");
            DropColumn("dbo.BibleReading", "Video2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleReading", "Video2", c => c.String());
            AddColumn("dbo.BibleReading", "Audio2", c => c.String());
            AddColumn("dbo.BibleReading", "Video1", c => c.String());
            AddColumn("dbo.BibleReading", "Audio1", c => c.String());
            DropColumn("dbo.BibleReading", "BibleUrl");
            DropColumn("dbo.BibleReading", "AudioCai");
            DropColumn("dbo.BibleReading", "VideoEnfu");
            DropColumn("dbo.BibleReading", "AudioEnfu");
        }
    }
}
