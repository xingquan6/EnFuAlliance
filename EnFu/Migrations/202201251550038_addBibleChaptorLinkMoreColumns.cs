namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBibleChaptorLinkMoreColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleChaptorLink", "Youtube", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "AudioEnfu", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "VideoEnfu", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "AudioCai", c => c.String(maxLength: 500));
            AddColumn("dbo.BibleChaptorLink", "BibleUrl", c => c.String(maxLength: 500));
            DropColumn("dbo.BibleChaptorLink", "UrlBibleCom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleChaptorLink", "UrlBibleCom", c => c.String(maxLength: 500));
            DropColumn("dbo.BibleChaptorLink", "BibleUrl");
            DropColumn("dbo.BibleChaptorLink", "AudioCai");
            DropColumn("dbo.BibleChaptorLink", "VideoEnfu");
            DropColumn("dbo.BibleChaptorLink", "AudioEnfu");
            DropColumn("dbo.BibleChaptorLink", "Youtube");
        }
    }
}
