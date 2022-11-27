namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.WorshipSong", new[] { "WorshipSongFileName" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.WorshipSong", "WorshipSongFileName", unique: true);
        }
    }
}
