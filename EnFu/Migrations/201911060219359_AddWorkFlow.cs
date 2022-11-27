namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkFlow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkFlow",
                c => new
                    {
                        WorkFlowId = c.Int(nullable: false, identity: true),
                        CallDetail = c.String(),
                        CallChaptor = c.String(),
                        IsEucharist = c.Boolean(nullable: false),
                        EucharistOperator = c.String(),
                        BibleReading = c.String(),
                        SermonTitle = c.String(),
                        SermonSpeaker = c.String(),
                        BibleWeeklyChaptor = c.String(),
                        BibleWeeklyChaptorDetail = c.String(),
                        DonationWeeklyChaptor = c.String(),
                        DonationWeeklyChaptorDetail = c.String(),
                        Blessing = c.String(),
                        Witness = c.String(),
                    })
                .PrimaryKey(t => t.WorkFlowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkFlow");
        }
    }
}
