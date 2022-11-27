namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlForWorshipSOngServe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorshipSongServe", "WorshipSongUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorshipSongServe", "WorshipSongUrl");
        }
    }
}
