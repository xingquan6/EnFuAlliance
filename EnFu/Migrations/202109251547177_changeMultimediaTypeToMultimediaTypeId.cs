namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMultimediaTypeToMultimediaTypeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Multimedia", "MultimediaTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Multimedia", "MultimediaType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Multimedia", "MultimediaType", c => c.Int());
            DropColumn("dbo.Multimedia", "MultimediaTypeId");
        }
    }
}
