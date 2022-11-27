namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameOfWorshipSong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorshipSong", "WorshipSongName", c => c.String());
            DropColumn("dbo.WorshipSong", "IsIncludeEnglish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorshipSong", "IsIncludeEnglish", c => c.Boolean(nullable: false));
            DropColumn("dbo.WorshipSong", "WorshipSongName");
        }
    }
}
