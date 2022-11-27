namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAllUselessFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Donate", "DonateDesc");
            DropColumn("dbo.PrayMatter", "PrayMatterName");
            DropColumn("dbo.PrayMatter", "IsSpecial");
            DropColumn("dbo.PrayMatter", "PrayMatterComment");
            DropColumn("dbo.PrayMatter", "IsActive");
            DropColumn("dbo.SundayServe", "IsActive");
            DropColumn("dbo.Team", "TeamDesc");
            DropColumn("dbo.Team", "TeamLocation");
            DropColumn("dbo.Team", "TeamLeaderUserId");
            DropColumn("dbo.Team", "TeamLeader2UserId");
            DropColumn("dbo.Team", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Team", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Team", "TeamLeader2UserId", c => c.Int());
            AddColumn("dbo.Team", "TeamLeaderUserId", c => c.Int());
            AddColumn("dbo.Team", "TeamLocation", c => c.String());
            AddColumn("dbo.Team", "TeamDesc", c => c.String());
            AddColumn("dbo.SundayServe", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.PrayMatter", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.PrayMatter", "PrayMatterComment", c => c.String());
            AddColumn("dbo.PrayMatter", "IsSpecial", c => c.Boolean(nullable: false));
            AddColumn("dbo.PrayMatter", "PrayMatterName", c => c.String());
            AddColumn("dbo.Donate", "DonateDesc", c => c.String());
        }
    }
}
