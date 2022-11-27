namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInformationNoteToWorkFlow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "SermonDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow", "SermonDetails");
        }
    }
}
