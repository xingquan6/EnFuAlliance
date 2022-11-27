namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWorshipSong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorshipSong", "WorshipSongDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorshipSong", "WorshipSongDuration", c => c.Int());
        }
    }
}
