namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBibleChaptor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BibleChaptor",
                c => new
                    {
                        BibleChaptorId = c.Int(nullable: false, identity: true),
                        BibleChaptorKindSN = c.String(),
                        BibleChaptorNumber = c.String(),
                        IsNewOrOld = c.Boolean(nullable: false),
                        PinYin = c.String(),
                        ShortName = c.String(),
                        MiddleName = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.BibleChaptorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BibleChaptor");
        }
    }
}
