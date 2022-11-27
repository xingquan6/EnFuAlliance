namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostAndPostContent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostContent",
                c => new
                    {
                        PostContentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Subtitle = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PostContentId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Title = c.String(),
                        isPublish = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        PublishDateTime = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Post");
            DropTable("dbo.PostContent");
        }
    }
}
