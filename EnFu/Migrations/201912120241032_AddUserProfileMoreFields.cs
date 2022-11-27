namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileMoreFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "ShortName", c => c.String());
            AddColumn("dbo.UserProfile", "WorkerType", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfile", "IsBaptism", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserProfile", "Baptism");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Baptism", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserProfile", "IsBaptism");
            DropColumn("dbo.UserProfile", "WorkerType");
            DropColumn("dbo.UserProfile", "ShortName");
        }
    }
}
