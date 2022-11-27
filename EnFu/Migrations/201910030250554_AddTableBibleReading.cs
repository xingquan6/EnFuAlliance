namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBibleReading : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BibleReading",
                c => new
                    {
                        BibleReadingId = c.Int(nullable: false, identity: true),
                        BibleReadingChaptor = c.String(),
                        BibleReadingSection = c.String(),
                        BibleReadingDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BibleReadingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BibleReading");
        }
    }
}
