namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWorshipSong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorshipSong",
                c => new
                    {
                        WorshipSongId = c.Int(nullable: false, identity: true),
                        WorshipSongName = c.String(),
                        WorshipSongAuthor = c.String(),
                        WorshipSongDesc = c.String(),
                        WorshipSongDuration = c.Int(),
                        WorshipSongLink = c.String(),
                        WorshipSongEmbedLink = c.String(),
                        WorshipSongLyrics = c.String(),
                    })
                .PrimaryKey(t => t.WorshipSongId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorshipSong");
        }
    }
}
