namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBibleChaptorLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BibleChaptorLink",
                c => new
                    {
                        BibleChaptorLinkId = c.Int(nullable: false, identity: true),
                        VolumeSN = c.Int(nullable: false),
                        ChapterSN = c.Int(nullable: false),
                        UrlCMC = c.String(maxLength: 500),
                        AudioCMC = c.String(maxLength: 500),
                        UrlBibleCom = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.BibleChaptorLinkId)
                .Index(t => new { t.VolumeSN, t.ChapterSN }, unique: true, name: "IX_VolumeAndChapter");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BibleChaptorLink", "IX_VolumeAndChapter");
            DropTable("dbo.BibleChaptorLink");
        }
    }
}
