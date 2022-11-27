namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMultimediaAndMultimediaType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Multimedia",
                c => new
                    {
                        MultimediaId = c.Int(nullable: false, identity: true),
                        MultimediaName = c.String(),
                        MultimediaAuthor = c.String(),
                        MultimediaDesc = c.String(),
                        MultimediaDuration = c.Int(),
                        MultimediaPublishDate = c.DateTime(),
                        MultimediaLink = c.String(),
                        MultimediaEmbedLink = c.String(),
                        MultimediaFormat = c.Int(),
                        MultimediaType = c.Int(),
                        MultimediaComment = c.String(),
                        MultimediaLyrics = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaId);
            
            CreateTable(
                "dbo.MultimediaType",
                c => new
                    {
                        MultimediaTypeId = c.Int(nullable: false, identity: true),
                        MultimediaTypeName = c.String(),
                        MultimediaTypeDesc = c.String(),
                        Comment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MultimediaType");
            DropTable("dbo.Multimedia");
        }
    }
}
