namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSundayServe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SundayServe", "SundayServeUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SundayServe", "SundayServeUserName");
        }
    }
}
