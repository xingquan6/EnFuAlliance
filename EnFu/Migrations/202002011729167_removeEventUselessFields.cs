namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeEventUselessFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "EventSpeaker");
            DropColumn("dbo.Event", "EventAuthor");
            DropColumn("dbo.Event", "EventAuthorPhone");
            DropColumn("dbo.Event", "EventAuthorEmail");
            DropColumn("dbo.Event", "EventEnterDateTime");
            DropColumn("dbo.Event", "EventComment");
            DropColumn("dbo.Event", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Event", "EventComment", c => c.String());
            AddColumn("dbo.Event", "EventEnterDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Event", "EventAuthorEmail", c => c.String());
            AddColumn("dbo.Event", "EventAuthorPhone", c => c.String());
            AddColumn("dbo.Event", "EventAuthor", c => c.String());
            AddColumn("dbo.Event", "EventSpeaker", c => c.String());
        }
    }
}
