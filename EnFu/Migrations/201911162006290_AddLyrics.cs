namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLyrics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorshipSongLyrics",
                c => new
                    {
                        WorshipSongLyricsId = c.Int(nullable: false, identity: true),
                        WorshipSongId = c.Int(nullable: false),
                        WorshipSongLyricsOrder = c.Int(nullable: false),
                        WorshipSongLyricsTitle = c.String(),
                        WorshipSongLyricsContent = c.String(),
                        WorshipSongLyricsVersion = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorshipSongLyricsId);
            
            AddColumn("dbo.WorshipSong", "WorshipSongFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorshipSong", "WorshipSongFileName");
            DropTable("dbo.WorshipSongLyrics");
        }
    }
}
