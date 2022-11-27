namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWorkFlow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "SundayDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkFlow", "Witness", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkFlow", "Witness", c => c.String());
            DropColumn("dbo.WorkFlow", "SundayDate");
        }
    }
}
