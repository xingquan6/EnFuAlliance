namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBibleChaptor0 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BibleChaptor", "BibleChaptorKindSN", c => c.Int(nullable: false));
            AlterColumn("dbo.BibleChaptor", "BibleChaptorNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BibleChaptor", "BibleChaptorNumber", c => c.String());
            AlterColumn("dbo.BibleChaptor", "BibleChaptorKindSN", c => c.String());
        }
    }
}
