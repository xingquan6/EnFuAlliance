namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSomeFieldsOnBibleChaptorLink : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BibleChaptorLink", "Youtube");
            DropColumn("dbo.BibleChaptorLink", "AudioEnfu");
            DropColumn("dbo.BibleChaptorLink", "VideoEnfu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleChaptorLink", "VideoEnfu", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "AudioEnfu", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "Youtube", c => c.String(maxLength: 500));
        }
    }
}
