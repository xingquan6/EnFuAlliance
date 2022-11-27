namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWorshipSongServe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorshipSongServe",
                c => new
                    {
                        WorshipSongServeId = c.Int(nullable: false, identity: true),
                        WorshipDate = c.DateTime(nullable: false),
                        WorshipSongName = c.String(),
                    })
                .PrimaryKey(t => t.WorshipSongServeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorshipSongServe");
        }
    }
}
