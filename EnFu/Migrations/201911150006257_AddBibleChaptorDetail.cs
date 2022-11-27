namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBibleChaptorDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BibleChaptorDetail",
                c => new
                    {
                        BibleChaptorDetailId = c.Int(nullable: false, identity: true),
                        VolumeSN = c.Int(nullable: false),
                        ChapterSN = c.Int(nullable: false),
                        VerseSN = c.Int(nullable: false),
                        Lection = c.String(maxLength: 500),
                        SoundBegin = c.Double(nullable: false),
                        SoundEnd = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BibleChaptorDetailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BibleChaptorDetail");
        }
    }
}
