namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderInEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "EventOrder");
        }
    }
}
