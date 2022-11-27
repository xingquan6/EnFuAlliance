namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveContentFromBibleReading : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BibleReading", "BibleReadingSection");
            DropColumn("dbo.BibleReading", "BibleReadingContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleReading", "BibleReadingContent", c => c.String());
            AddColumn("dbo.BibleReading", "BibleReadingSection", c => c.String());
        }
    }
}
