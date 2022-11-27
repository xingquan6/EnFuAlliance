namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpeakerUrlToWorkFlow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "SermonSpeakerUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow", "SermonSpeakerUrl");
        }
    }
}
