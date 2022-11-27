namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSermonWorshipSongToWorkflow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "SermonWorshipSong", c => c.String());
            AddColumn("dbo.WorkFlow", "SermonWorshipSongAudioUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow", "SermonWorshipSongAudioUrl");
            DropColumn("dbo.WorkFlow", "SermonWorshipSong");
        }
    }
}
