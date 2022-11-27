namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSortOrderFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallChaptor", "SortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.DonateBibleChaptor", "SortOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonateBibleChaptor", "SortOrder");
            DropColumn("dbo.CallChaptor", "SortOrder");
        }
    }
}
