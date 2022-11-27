namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBibleReadingColumnNames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BibleReading", "Audio3");
            DropColumn("dbo.BibleReading", "Video3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleReading", "Video3", c => c.String());
            AddColumn("dbo.BibleReading", "Audio3", c => c.String());
        }
    }
}
