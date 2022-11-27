namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTwoFieldsBibleReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "Url", c => c.String());
            AddColumn("dbo.BibleReading", "Audio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BibleReading", "Audio");
            DropColumn("dbo.BibleReading", "Url");
        }
    }
}
