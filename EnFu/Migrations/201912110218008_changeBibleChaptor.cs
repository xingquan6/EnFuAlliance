namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBibleChaptor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleChaptor", "KindSn", c => c.Int(nullable: false));
            AddColumn("dbo.BibleChaptor", "TotalChaptors", c => c.Int(nullable: false));
            AddColumn("dbo.BibleChaptor", "TotalVerses", c => c.Int(nullable: false));
            AddColumn("dbo.BibleChaptor", "NewOrOld", c => c.Boolean(nullable: false));
            AddColumn("dbo.BibleChaptor", "ShortNameEnglish", c => c.String());
            AddColumn("dbo.BibleChaptor", "MiddleNameEnglish", c => c.String());
            AddColumn("dbo.BibleChaptor", "FullNameEnglish", c => c.String());
            DropColumn("dbo.BibleChaptor", "BibleChaptorKindSN");
            DropColumn("dbo.BibleChaptor", "BibleChaptorNumber");
            DropColumn("dbo.BibleChaptor", "IsNewOrOld");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleChaptor", "IsNewOrOld", c => c.Boolean(nullable: false));
            AddColumn("dbo.BibleChaptor", "BibleChaptorNumber", c => c.Int(nullable: false));
            AddColumn("dbo.BibleChaptor", "BibleChaptorKindSN", c => c.Int(nullable: false));
            DropColumn("dbo.BibleChaptor", "FullNameEnglish");
            DropColumn("dbo.BibleChaptor", "MiddleNameEnglish");
            DropColumn("dbo.BibleChaptor", "ShortNameEnglish");
            DropColumn("dbo.BibleChaptor", "NewOrOld");
            DropColumn("dbo.BibleChaptor", "TotalVerses");
            DropColumn("dbo.BibleChaptor", "TotalChaptors");
            DropColumn("dbo.BibleChaptor", "KindSn");
        }
    }
}
