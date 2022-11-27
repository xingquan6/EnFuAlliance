namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorshipSongFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorshipSong", "IsIncludeEnglish", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorshipSong", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorshipSong", "IsActive");
            DropColumn("dbo.WorshipSong", "IsIncludeEnglish");
        }
    }
}
