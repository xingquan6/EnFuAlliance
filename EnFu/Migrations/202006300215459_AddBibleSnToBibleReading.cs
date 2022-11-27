namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBibleSnToBibleReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "VolumeSN", c => c.Int(nullable: false));
            AddColumn("dbo.BibleReading", "ChapterSN", c => c.Int(nullable: false));
            AddColumn("dbo.BibleReading", "VerseSNFrom", c => c.Int(nullable: false));
            AddColumn("dbo.BibleReading", "VerseSNTo", c => c.Int(nullable: false));
            DropColumn("dbo.BibleReading", "BibleChaptorIdFrom");
            DropColumn("dbo.BibleReading", "BibleChaptorIdTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleReading", "BibleChaptorIdTo", c => c.String());
            AddColumn("dbo.BibleReading", "BibleChaptorIdFrom", c => c.String());
            DropColumn("dbo.BibleReading", "VerseSNTo");
            DropColumn("dbo.BibleReading", "VerseSNFrom");
            DropColumn("dbo.BibleReading", "ChapterSN");
            DropColumn("dbo.BibleReading", "VolumeSN");
        }
    }
}
