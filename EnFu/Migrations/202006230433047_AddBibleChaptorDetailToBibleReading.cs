namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBibleChaptorDetailToBibleReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleReading", "BibleChaptorIdFrom", c => c.String());
            AddColumn("dbo.BibleReading", "BibleChaptorIdTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BibleReading", "BibleChaptorIdTo");
            DropColumn("dbo.BibleReading", "BibleChaptorIdFrom");
        }
    }
}
