namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeWorshipSongFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorshipSongLyrics", "WorshipSongLyricsContentEnglish", c => c.String());
            DropColumn("dbo.WorshipSongLyrics", "WorshipSongLyricsVersion");
            DropColumn("dbo.WorshipSongLyrics", "IsActive");
            DropColumn("dbo.WorshipSong", "WorshipSongName");
            DropColumn("dbo.WorshipSong", "WorshipSongAuthor");
            DropColumn("dbo.WorshipSong", "WorshipSongDesc");
            DropColumn("dbo.WorshipSong", "WorshipSongDuration");
            DropColumn("dbo.WorshipSong", "WorshipSongLyrics");
            DropColumn("dbo.WorshipSong", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorshipSong", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorshipSong", "WorshipSongLyrics", c => c.String());
            AddColumn("dbo.WorshipSong", "WorshipSongDuration", c => c.Int(nullable: false));
            AddColumn("dbo.WorshipSong", "WorshipSongDesc", c => c.String());
            AddColumn("dbo.WorshipSong", "WorshipSongAuthor", c => c.String());
            AddColumn("dbo.WorshipSong", "WorshipSongName", c => c.String());
            AddColumn("dbo.WorshipSongLyrics", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorshipSongLyrics", "WorshipSongLyricsVersion", c => c.String());
            DropColumn("dbo.WorshipSongLyrics", "WorshipSongLyricsContentEnglish");
        }
    }
}
