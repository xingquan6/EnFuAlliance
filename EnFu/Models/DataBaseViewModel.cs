using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnFu.Models
{
    // Base class
    public class DataBaseViewModel
    {
        public int Id { get; set; }
        public bool IsMobile { get; set; }

    }
    #region
    public class DownloadDocumentViewModel
    {
        [Display(Name = "选择周报日期")]
        public string SundayDate { get; set; }
        [Display(Name = "周报类型")]
        public int Type { get; set; }
    }

    public class RenderDocumentViewModel
    {
        public string Content { get; set; }
    }

    // web view model
    public class SundayReportViewModel : DataBaseViewModel
    {
        public List<BibleReadingViewModel> WeeklyBibleReadingInfos { get; set; }
        public WorkFlowViewModel WorkFlow { get; set; }
        //public InformationNoteViewModel InformationNote { get; set; }
        public List<EventViewModel> Events { get; set; }
        public List<PrayMatterViewModel> PrayMatters { get; set; }
        public List<SundayServeViewModel> SundayServes { get; set; }
        public List<SundayServeViewModel> NextSundayServes { get; set; }
        public List<SundayServeViewModel> Next2WeeksSundayServes { get; set; }
        public List<GroupMeetingViewModel> GroupMeetings { get; set; }
        public List<TeamViewModel> ChurchTeams { get; set; }
        public List<DonateListViewModel> Donates { get; set; }

    }

    #endregion

    #region
    // pdf view model
    public class SundayReportPdfViewModel : DataBaseViewModel
    {
        public int CurrentYear { get; set; }
        public string LastSaturdayDate { get; set; }
        public string LastSundayDate { get; set; }

        public string Last2WeeksSundayDate { get; set; }
        public string Last2WeeksSaturdayDate { get; set; }
        public string CurrentSundayDate { get; set; }
        public string NextSundayDate { get; set; }
        public string Next2SundayDate { get; set; }
        public List<BibleReadingViewModels> BibleReadings { get; set; }
        public WorkFlowViewModel WorkFlow { get; set; }
        public List<WorshipSongServeViewModel> WorshipSongServeViewModels { get; set; }
        public List<EventViewModel> Events { get; set; }
        public List<PrayMatterViewModel> PrayEvents { get; set; }
        public SundayServeDetails CurrentSundayServe { get; set; }
        public SundayServeDetails NextSundayServe { get; set; }
        public SundayServeDetails Next2WeeksSundayServe { get; set; }
        public List<GroupMeetingViewModel> TeamGroupMeetings { get; set; }
        public GroupMeetingViewModel AdultGroupMeeting { get; set; }
        public GroupMeetingViewModel TeenGroupMeeting { get; set; }
        public GroupMeetingViewModel ChildrenGroupMeeting { get; set; }
        public GroupMeetingViewModel PrayGroupMeeting { get; set; }
        public GroupMeetingViewModel SundayPrayGroupMeeting { get; set; }
        public GroupMeetingViewModel BibleReadingGroupMeeting { get; set; }
        public int LastSundayPeopleNumber { get; set; }
        public List<TeamViewModel> Teams { get; set; }
        public SundayDonateViewModel SundayDonate { get; set; }
        public MonthlyDonateViewModel MonthlyDonate { get; set; }
        public decimal MonthDonate { get; set; }
        public decimal MonthBudget { get; set; }
        public decimal MonthDonatePercentage { get; set; }

        public SpiritualEssayViewModel SpiritualEssayPray { get; set; }
        public List<string> SpiritualEssayContents { get; set; }
        public List<string> SpiritualEssayPrays { get; set; }

        public List<SermonViewModel> SerminViewModels { get; set; }

    }
    public class BibleReadingPdfViewModel : DataBaseViewModel
    {
        public int CurrentYear { get; set; }
        public string CurrentDay { get; set; }
        public string CurrentMonth { get; set; }
        public string CurrentDate { get; set; }
        public string ChaptorTitle1 { get; set; }
        public string ChaptorTitleUrl1 { get; set; }
        public string ChaptorTitle2 { get; set; }
        public string ChaptorTitleUrl2 { get; set; }
        public string ChaptorTitle3 { get; set; }
        public string ChaptorTitleUrl3 { get; set; }
        public List<BibleReadingViewModels> BibleReadings { get; set; }
        public List<BibleReadingViewModel> BibleReadings1 { get; set; }
        public List<BibleReadingViewModel> BibleReadings2 { get; set; }
    }
    #endregion

    #region
    // pdf view model
    public class WorshipSongViewModel
    {
        public List<WorshipSongServeViewModel> WorshipSongs { get; set; }
    }
    public class BibleChaptorModel
    {
        public int BibleChaptorId { get; set; }
        public int KindSn { get; set; }
        public int TotalChaptors { get; set; }

        public int TotalVerses { get; set; }
        public bool NewOrOld { get; set; }
        public string PinYin { get; set; }
        public string ShortName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }

        public string ShortNameEnglish { get; set; }
        public string MiddleNameEnglish { get; set; }
        public string FullNameEnglish { get; set; }
    }
    public class BibleChaptorDetailModel
    {
        public int BibleChaptorDetailId { get; set; }
        public int VolumeSN { get; set; }
        public int ChapterSN { get; set; }
        public int VerseSN { get; set; }
        public string Lection { get; set; }
        public string LectionEnglish { get; set; }
    }

    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool isPublish { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }
    }

    public class PostContentViewModel
    {
        public int PostContentId { get; set; }
        public int PostId { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
    }

    public class MultimediaViewModel
    {
        public int MultimediaId { get; set; }
        [Display(Name = "名字")]
        public string MultimediaName { get; set; }
        [Display(Name = "作者")]
        public string MultimediaAuthor { get; set; }
        [Display(Name = "简介")]
        public string MultimediaDesc { get; set; }
        [Display(Name = "时间长短（秒）")]
        public int? MultimediaDuration { get; set; }
        [Display(Name = "发表时间(yyyy-mm-dd)")]
        public DateTime? MultimediaPublishDate { get; set; }
        [Display(Name = "声频或视频连接")]
        public string MultimediaLink { get; set; }
        [Display(Name = "网页内部连接")]
        public string MultimediaEmbedLink { get; set; }
        [Display(Name = "格式")]
        public int? MultimediaFormat { get; set; }
        [Display(Name = "类型")]
        public int MultimediaTypeId { get; set; }
        [Display(Name = "注解")]
        public string MultimediaComment { get; set; }
        [Display(Name = "歌词")]
        public string MultimediaLyrics { get; set; }
        [Display(Name = "是否有效")]
        public bool IsActive { get; set; }
    }
    public class MultimediaTypeViewModel
    {
        public int MultimediaTypeId { get; set; }
        public string MultimediaTypeName { get; set; }
        public string MultimediaTypeDesc { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

}