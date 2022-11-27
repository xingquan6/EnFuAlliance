namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInformationNoteTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.InformationNote");
        }
        
        public override void Down()
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
            
        }
    }
}
