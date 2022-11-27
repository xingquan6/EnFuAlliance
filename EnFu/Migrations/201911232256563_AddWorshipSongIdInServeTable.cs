namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorshipSongIdInServeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorshipSongServe", "WorshipSongId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorshipSongServe", "WorshipSongId");
        }
    }
}
