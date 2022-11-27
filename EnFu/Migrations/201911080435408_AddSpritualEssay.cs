namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpritualEssay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpiritualEssay",
                c => new
                    {
                        SpiritualEssayId = c.Int(nullable: false, identity: true),
                        SpiritualEssayTitle = c.String(),
                        SpiritualEssayChaptor = c.String(),
                        SpiritualEssayContent = c.String(),
                        SpiritualEssayPray = c.String(),
                        SpiritualEssaySunday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SpiritualEssayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpiritualEssay");
        }
    }
}
