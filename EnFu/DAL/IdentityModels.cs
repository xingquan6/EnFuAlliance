using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using EnFu.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace EnFu.DAL
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<ChildrenClass> ChildrenClasses { get; set; }
        //public DbSet<ChildrenLesson> ChildrenLessons { get; set; }
        //public DbSet<ChildrenBook> ChildrenBooks { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Book> Books { get; set; }
        //public DbSet<UserInTeam> UserInTeams { get; set; }
        //public DbSet<FileUpload> FileUploads { get; set; }
        //public DbSet<Multimedia> Multimedias { get; set; }
        //public DbSet<MultimediaType> MultimediaTypes { get; set; }

        //public DbSet<Story> Stories { get; set; }
        //public DbSet<Notice> Notices { get; set; }
        //public DbSet<NoticePerson> NoticePersons { get; set; }

        //public DbSet<MemberDuty> MemberDutys { get; set; }
        //public DbSet<Visiter> Visiters { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PrayMatter> PrayMatters { get; set; }
        public DbSet<SundayServe> SundayServes { get; set; }
        public DbSet<BibleReading> BibleReadings { get; set; }
        public DbSet<WorshipSong> WorshipSongs { get; set; }
        public DbSet<WorshipSongLyrics> WorshipSongLyrices { get; set; }
        public DbSet<WorshipSongServe> WorshipSongServes { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<GroupMeeting> GroupMeetings { get; set; }
        public DbSet<Donate> Donates { get; set; }
        public DbSet<SpiritualEssay> SpiritualEssays { get; set; }
        public DbSet<BibleChaptor> BibleChaptors { get; set; }
        public DbSet<BibleChaptorDetail> BibleChaptorDetails { get; set; }
        public DbSet<BibleChaptorLink> BibleChaptorLinks { get; set; }
        public DbSet<CallChaptor> CallChaptors { get; set; }
        public DbSet<DonateBibleChaptor> DonateBibleChaptors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<MultimediaType> MultimediaTypes { get; set; }

    }
}