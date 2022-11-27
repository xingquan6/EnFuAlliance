namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBibleDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BibleChaptorDetail", "LectionEnglish", c => c.String(maxLength: 500));
            DropColumn("dbo.BibleChaptorDetail", "SoundBegin");
            DropColumn("dbo.BibleChaptorDetail", "SoundEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BibleChaptorDetail", "SoundEnd", c => c.Double(nullable: false));
            AddColumn("dbo.BibleChaptorDetail", "SoundBegin", c => c.Double(nullable: false));
            DropColumn("dbo.BibleChaptorDetail", "LectionEnglish");
        }
    }
}
