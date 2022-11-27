namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallChaptor",
                c => new
                    {
                        CallChaptorId = c.Int(nullable: false, identity: true),
                        Chaptor = c.String(),
                        ChaptorDetail = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CallChaptorId);
            
            CreateTable(
                "dbo.DonateBibleChaptor",
                c => new
                    {
                        DonateBibleChaptorId = c.Int(nullable: false, identity: true),
                        Chaptor = c.String(),
                        ChaptorDetail = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DonateBibleChaptorId);
            
            AddColumn("dbo.WorkFlow", "CallChaptorId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkFlow", "DonationWeeklyChaptorId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow", "DonationWeeklyChaptorId");
            DropColumn("dbo.WorkFlow", "CallChaptorId");
            DropTable("dbo.DonateBibleChaptor");
            DropTable("dbo.CallChaptor");
        }
    }
}
