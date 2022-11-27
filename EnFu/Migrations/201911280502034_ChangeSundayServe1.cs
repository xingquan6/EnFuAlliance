namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSundayServe1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SundayServe", "SundayServeDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.SundayServe", "SundayServeUserId");
            DropColumn("dbo.SundayServe", "SundayServeUserName");
            DropColumn("dbo.SundayServe", "SundayServeDutyId");
            DropColumn("dbo.SundayServe", "SundayServeAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SundayServe", "SundayServeAddress", c => c.String());
            AddColumn("dbo.SundayServe", "SundayServeDutyId", c => c.Int(nullable: false));
            AddColumn("dbo.SundayServe", "SundayServeUserName", c => c.String());
            AddColumn("dbo.SundayServe", "SundayServeUserId", c => c.Int());
            AlterColumn("dbo.SundayServe", "SundayServeDateTime", c => c.DateTime());
        }
    }
}
