namespace EnFu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDesc = c.String(),
                        EventSpeaker = c.String(),
                        EventDateTime = c.DateTime(nullable: false),
                        EventAuthor = c.String(),
                        EventAuthorPhone = c.String(),
                        EventAuthorEmail = c.String(),
                        EventEnterDateTime = c.DateTime(nullable: false),
                        EventComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
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
                "dbo.NoticePerson",
                c => new
                    {
                        NoticeId = c.Int(nullable: false),
                        NoticePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NoticeId, t.NoticePersonId });
            
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
                "dbo.PrayMatter",
                c => new
                    {
                        PrayMatterId = c.Int(nullable: false, identity: true),
                        PrayMatterName = c.String(),
                        PrayMatterDesc = c.String(),
                        IsSpecial = c.Boolean(nullable: false),
                        PrayMatterEnterDateTime = c.DateTime(nullable: false),
                        PrayMatterComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrayMatterId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.SundayServe",
                c => new
                    {
                        SundayServeId = c.Int(nullable: false, identity: true),
                        SundayServeName = c.String(),
                        SundayServeUserId = c.Int(),
                        SundayServeDutyId = c.Int(nullable: false),
                        SundayServeDutyName = c.String(),
                        SundayServeDateTime = c.DateTime(),
                        SundayServeAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SundayServeId);
            
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
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        TeamDesc = c.String(),
                        TeamDate = c.String(),
                        TeamPhone = c.String(),
                        TeamLocation = c.String(),
                        TeamLeaderUserId = c.Int(),
                        TeamLeader2UserId = c.Int(),
                        TeamComment = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.UserInTeam",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.UserId });
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Phone = c.String(),
                        CellPhone = c.String(),
                        Address = c.String(),
                        Baptism = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Visiter",
                c => new
                    {
                        VisiterId = c.Int(nullable: false, identity: true),
                        VisiterIP = c.String(),
                        VisiterCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisiterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Visiter");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfile");
            DropTable("dbo.UserInTeam");
            DropTable("dbo.Team");
            DropTable("dbo.Teacher");
            DropTable("dbo.SundayServe");
            DropTable("dbo.Story");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PrayMatter");
            DropTable("dbo.Notice");
            DropTable("dbo.NoticePerson");
            DropTable("dbo.MultimediaType");
            DropTable("dbo.Multimedia");
            DropTable("dbo.MemberDuty");
            DropTable("dbo.FileUpload");
            DropTable("dbo.Event");
            DropTable("dbo.Department");
            DropTable("dbo.ChildrenLesson");
            DropTable("dbo.ChildrenClass");
            DropTable("dbo.ChildrenBook");
            DropTable("dbo.Book");
        }
    }
}
