namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIndexForBibleChaptorDetail : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BibleChaptorDetail", new[] { "VolumeSN","ChapterSN", "VerseSN" }, unique: true, name: "IX_VolumeAndChapterAndVerse");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BibleChaptorDetail", "IX_VolumeAndChapterAndVerse");
        }
    }
}
