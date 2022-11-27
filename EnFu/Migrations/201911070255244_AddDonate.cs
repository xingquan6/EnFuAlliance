namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donate",
                c => new
                    {
                        DonateId = c.Int(nullable: false, identity: true),
                        DonateType = c.String(),
                        DonateDesc = c.String(),
                        DonateDate = c.DateTime(nullable: false),
                        DonateNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DonateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donate");
        }
    }
}
