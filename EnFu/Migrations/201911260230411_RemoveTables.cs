namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTables : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Book");
            DropTable("dbo.ChildrenBook");
            DropTable("dbo.ChildrenClass");
            DropTable("dbo.ChildrenLesson");
            DropTable("dbo.Department");
            DropTable("dbo.FileUpload");
            DropTable("dbo.MemberDuty");
            DropTable("dbo.Multimedia");
            DropTable("dbo.MultimediaType");
            DropTable("dbo.NoticePerson");
            DropTable("dbo.Notice");
            DropTable("dbo.Story");
            DropTable("dbo.Teacher");
            DropTable("dbo.UserInTeam");
            DropTable("dbo.Visiter");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Visiter",
                c => new
                    {
                        VisiterId = c.Int(nullable: false, identity: true),
                        VisiterIP = c.String(),
                        VisiterCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisiterId);
            
            CreateTable(
                "dbo.UserInTeam",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.UserId });
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(maxLength: 100),
                        TeacherDesc = c.String(maxLength: 300),
                        TeacherComment = c.String(maxLength: 300),
                        TeacherType = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        StoryName = c.String(),
                        StoryAuthor = c.String(),
                        StoryDesc = c.String(),
                        StoryDateTime = c.DateTime(),
                        StoryComment = c.String(),
                        StoryType = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StoryId);
            
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeName = c.String(),
                        NoticeDesc = c.String(),
                        NoticeDateTime = c.DateTime(),
                        NoticeAuthorId = c.Int(nullable: false),
                        NoticeType = c.Int(nullable: false),
                        NoticeComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.NoticePerson",
                c => new
                    {
                        NoticeId = c.Int(nullable: false),
                        NoticePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NoticeId, t.NoticePersonId });
            
            CreateTable(
                "dbo.MultimediaType",
                c => new
                    {
                        MultimediaTypeId = c.Int(nullable: false, identity: true),
                        MultimediaTypeName = c.String(),
                        MultimediaTypeDesc = c.String(),
                        DeptComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaTypeId);
            
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
                        SundaySongDateTime = c.DateTime(),
                        IsSundaySong = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.MultimediaId);
            
            CreateTable(
                "dbo.MemberDuty",
                c => new
                    {
                        MemberDutykId = c.Int(nullable: false, identity: true),
                        MemberDutyName = c.String(),
                        MemberDutyDesc = c.String(),
                        MemberDutyComment = c.String(),
                        MemberDutyAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberDutykId);
            
            CreateTable(
                "dbo.FileUpload",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileAuthor = c.String(),
                        FileDesc = c.String(),
                        FileDateTime = c.DateTime(),
                        FileLocation = c.String(),
                        FileFormat = c.Int(),
                        FileCategory = c.Int(),
                        FileComment = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DeptDesc = c.String(),
                        DeptLeaderUserId = c.Int(),
                        DeptLeader2UserId = c.Int(),
                        DeptComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.ChildrenLesson",
                c => new
                    {
                        ChildrenLessonId = c.Int(nullable: false, identity: true),
                        ChildrenLessonName = c.String(),
                        ChildrenLessonDesc = c.String(),
                        ChildrenLessonPublisher = c.String(),
                        ChildrenClassComment = c.String(),
                        ChildrenClassId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChildrenLessonId);
            
            CreateTable(
                "dbo.ChildrenClass",
                c => new
                    {
                        ChildrenClassId = c.Int(nullable: false, identity: true),
                        ChildrenClassName = c.String(),
                        ChildrenClassDesc = c.String(),
                        ChildrenClassLeader = c.String(),
                        ChildrenClassLeader2 = c.String(),
                        ChildrenClassComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChildrenClassId);
            
            CreateTable(
                "dbo.ChildrenBook",
                c => new
                    {
                        ChildrenBookId = c.Int(nullable: false, identity: true),
                        ChildrenBookName = c.String(),
                        ChildrenBookAuthor = c.String(),
                        ChildrenBookDesc = c.String(),
                        ChildrenBookComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChildrenBookId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookCode = c.String(),
                        BookAuthor = c.String(),
                        BookPicLink = c.String(),
                        BookPublisher = c.String(),
                        BookPublishDate = c.DateTime(),
                        BookDesc = c.String(),
                        BookBorrowerUserName = c.String(),
                        BookBorrowerUserId = c.Int(),
                        BookBorrowDateTime = c.DateTime(),
                        BookCategory = c.String(),
                        BookEnterDateTime = c.DateTime(),
                        BookComment = c.String(),
                        BookQuantity = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
    }
}
