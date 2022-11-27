namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInformationNote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationNote",
                c => new
                    {
                        InformationNoteId = c.Int(nullable: false, identity: true),
                        InformationNoteDate = c.DateTime(nullable: false),
                        InformationNoteTitle = c.String(),
                        InformationNoteDetail = c.String(),
                        InformationNoteSpeaker = c.String(),
                    })
                .PrimaryKey(t => t.InformationNoteId);
            
            AddColumn("dbo.PrayMatter", "PrayMatterDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PrayMatter", "PrayMatterEnterDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrayMatter", "PrayMatterEnterDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.PrayMatter", "PrayMatterDate");
            DropTable("dbo.InformationNote");
        }
    }
}
