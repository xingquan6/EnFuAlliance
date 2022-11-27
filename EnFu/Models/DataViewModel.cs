using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnFu.Models
{
    #region
    public class SearchViewModel
    {
        public string SundayReportDate { get; set; }
        public SearchType SearchType { get; set; }
    }
    public enum SearchType
    {
        [Description("崇拜程序")]
        [Display(Name = "崇拜程序")]
        WorkFlow = 1,

        [Description("家事报告")]
        [Display(Name = "家事报告")]
        Event = 2,

        [Description("代祷事项")]
        [Display(Name = "代祷事项")]
        PrayMatter = 3,

        [Description("主日服侍")]
        [Display(Name = "主日服侍")]
        SundayServe = 4,

        [Description("聚会")]
        [Display(Name = "聚会")]
        GroupMeeting = 5,

        [Description("奉献")]
        [Display(Name = "奉献")]
        Donate = 6,

        [Description("灵修小品")]
        [Display(Name = "灵修小品")]
        SpiritualEssay = 7,

        [Description("崇拜歌曲")]
        [Display(Name = "崇拜歌曲")]
        WorshipSongServe = 8
    }
    public class BibleReadingViewModel
    {
        [Display(Name = "读经章节")]
        public string BibleReadingChaptor { get; set; }
        [Display(Name = "读经日期")]
        public DateTime BibleReadingDate { get; set; }
        [Display(Name = "读经内容")]
        public string BibleReadingSection { get; set; }
        [Display(Name = "读经经文")]
        public string BibleReadingContent { get; set; }
        public int VolumeSN { get; set; }
        public int ChapterSN { get; set; }
        public int VerseSNFrom { get; set; }
        public int VerseSNTo { get; set; }
        public string Url { get; set; }
        public string Audio { get; set; }
        public string Youtube { get; set; }
        public string AudioEnfu { get; set; }
        public string VideoEnfu { get; set; }
        public string AudioCai { get; set; }
        public string BibleUrl { get; set; }
    }
    public class BibleReadingViewModels
    {
        public List<BibleReadingViewModel> ViewModels { get;set;}
    }


    public class WorkFlowViewModel
    {
        public int WorkFlowId { get; set; }
        public DateTime SundayDate { get; set; }
        [Display(Name = "宣召经文内容")]
        [Required]
        public string CallDetail { get; set; }

        [Display(Name = "宣召经文")]
        [Required]
        public string CallChaptor { get; set; }

        [Display(Name = "是否有圣餐")]
        [Required]
        public bool IsEucharist { get; set; }

        [Display(Name = "圣餐主持")]
        public string EucharistOperator { get; set; }
        [Display(Name = "读经")]
        [Required]
        public string BibleReading { get; set; }

        [Display(Name = "讲道题目")]
        [Required]
        public string SermonTitle { get; set; }

        [Display(Name = "讲员")]
        [Required]
        public string SermonSpeaker { get; set; }

        [Display(Name = "讲员信息")]
        public string SermonSpeakerUrl { get; set; }

        [Display(Name = "讲道内容")]
        public List<string> SermonDetails { get; set; }

        [Display(Name = "本周金句章节")]
        [Required]
        public string BibleWeeklyChaptor { get; set; }

        [Display(Name = "本周金句内容")]
        [Required]
        public string BibleWeeklyChaptorDetail { get; set; }

        [Display(Name = "奉献经文章节")]
        [Required]
        public string DonationWeeklyChaptor { get; set; }

        [Display(Name = "奉献经文内容")]
        [Required]
        public string DonationWeeklyChaptorDetail { get; set; }

        [Display(Name = "祝祷人")]
        [Required]
        public string Blessing { get; set; }

        [Display(Name = "见证")]
        [Required]
        public bool Witness { get; set; }

        [Display(Name = "受洗")]
        [Required]
        public bool IsBaptized { get; set; }

        [Display(Name = "聚餐")]
        public string Meal { get; set; }

        [Display(Name = "活动")]
        public string Activity { get; set; }

        [Display(Name = "VideoLiveLink")]
        public string VideoLiveLink { get; set; }
        public string SermonAudioUrl { get; set; }
        
        [Display(Name = "回应诗歌")]
        public string SermonWorshipSong { get; set; }
        [Display(Name = "回应诗歌链接")]
        public string SermonWorshipSongAudioUrl { get; set; }

    }
    public class SermonViewModel
    {
        public string SermonTitle { get; set; }
        public string SermonSpeaker { get; set; }
        public string BibleReading { get; set; }
        public List<string> SermonDetails { get; set; }
        public string AudioUrl { get; set; }
        public DateTime SundayDate { get; set; }
    }
    public class EventViewModel
    {
        public int EventId { get; set; }
        [Display(Name = "事件")]
        public string EventName { get; set; }
        [Display(Name = "时间")]
        public DateTime EventDateTime { get; set; }
        [Display(Name = "内容")]
        public string EventDesc { get; set; }

        [Display(Name = "顺序")]
        public int EventOrder { get; set; }
    }
    public class EventListViewModel
    {
        public List<EventViewModel> EventList { get; set; }

    }
    public class WorshipSongServeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "诗歌名称")]
        public string Name { get; set; }

        [Display(Name = "服侍时间")]
        public DateTime WorshipDate { get; set; }

        [Display(Name = "Youtube")]
        public string Url { get; set; }
        public List<WorshipSongLyricsViewModel> Lyrics { get; set; }
    }
    public class WorshipSongLyricsViewModel
    {
        public int WorshipSongId { get; set; }
        public int WorshipSongLyricsOrder { get; set; }
        public string WorshipSongLyricsTitle { get; set; }
        public string WorshipSongLyricsContent { get; set; }
        public string WorshipSongLyricsContentEnglish { get; set; }
    }
    public class SundayServeViewModel
    {
        public int SundayServeId { get; set; }
        [Display(Name = "服侍人员")]
        public string SundayServeName { get; set; }
        [Display(Name = "服侍类型")]
        public string SundayServeDutyName { get; set; }
        [Display(Name = "服侍时间")]
        public DateTime SundayServeDateTime { get; set; }
    }
    public class SundayServeListViewModel
    {
        public List<SundayServeViewModel> SundayServeList { get; set; }
    }

    public class WorshipSongServeListViewModel
    {
        public List<WorshipSongServeViewModel> WorshipSongServeList { get; set; }
    }
    public class SundayServeDetails
    {
        public SundayServeViewModel SundayServeSpeaker { get; set; }
        public SundayServeViewModel SundayServeChairmen { get; set; }
        public SundayServeViewModel SundayServePrayName { get; set; }
        public SundayServeViewModel SundayServeWorshipLeadName { get; set; }
        public SundayServeViewModel SundayServeWorshipName { get; set; }
        public SundayServeViewModel SundayServePanio { get; set; }
        public SundayServeViewModel SundayServeSound { get; set; }
        public SundayServeViewModel SundayServeSecretary { get; set; }
        public SundayServeViewModel SundayServeLogistics { get; set; }
        public SundayServeViewModel SundayServeAccounting { get; set; }
        public SundayServeViewModel SundayServeChildTeacher { get; set; }
        public SundayServeViewModel SundayServeTeenTeacher { get; set; }
        public SundayServeViewModel SundayServeNewPerson { get; set; }
    }
    public class PrayMatterViewModel
    {
        public int PrayMatterId { get; set; }
        [Display(Name = "内容")]
        public string PrayMatterDesc { get; set; }
        public DateTime PrayMatterDate { get; set; }
    }
    public class PrayMatterListViewModel
    {
        public List<PrayMatterViewModel> PrayMatterList { get; set; }
    }
    public class GroupMeetingViewModel
    {
        public int GroupMeetingId { get; set; }
        public string GroupMeetingType { get; set; }
        [Display(Name = "人数")]
        public int GroupMeetingNumber { get; set; }
        public DateTime GroupMeetingSundayReportDate { get; set; }
        public int GroupType { get; set; }
    }
    public class GroupMeetingListViewModel
    {
        public List<GroupMeetingViewModel> GroupMeetingList { get; set; }
    }
    public class TeamViewModel
    {
        public string TeamName { get; set; }
        public string TeamDesc { get; set; }
        public string TeamDate { get; set; }
        public string TeamPhone { get; set; }
        public string TeamLocation { get; set; }
        public string TeamLeaderName { get; set; }
    }
    public class DonateViewModel
    {
        public int DonateId { get; set; }
        public string DonateType { get; set; }
        public DateTime DonateDate { get; set; }
        public decimal DonateNumber { get; set; }
    }
    public class DonateListViewModel
    {
        public List<DonateViewModel> DonateList { get; set; }

    }
    public class SundayDonateViewModel
    {
        public decimal RegularDonate { get; set; }
        public decimal BuildChurchDonate { get; set; }
        public decimal SpreadDonate { get; set; }
        public decimal HuanHuanDonate { get; set; }
        public decimal ThankGivingDonate { get; set; }
        public decimal OtherDonate { get; set; }

    }
    public class MonthlyDonateViewModel
    {
        public decimal MonthlyRegularDonate { get; set; }
        public decimal MonthlyBuildChurchDonate { get; set; }
        public decimal MonthlySpreadDonate { get; set; }
        public decimal MonthlyHuanHuanDonate { get; set; }
        public decimal MonthlyThankGivingDonate { get; set; }
        public decimal MonthlyOtherDonate { get; set; }

    }
    public class SpiritualEssayViewModel
    {
        public int SpiritualEssayId { get; set; }
        [Display(Name = "题目作者")]
        public string SpiritualEssayTitle { get; set; }
        [Display(Name = "圣经章节")]
        public string SpiritualEssayChaptor { get; set; }
        [Display(Name = "内容")]
        public string SpiritualEssayContent { get; set; }
        [Display(Name = "祷告")]
        public string SpiritualEssayPray { get; set; }
        [Display(Name = "日期")]
        public DateTime SpiritualEssaySunday { get; set; }

    }
    #endregion

    #region
    public class UserProfileModel
    {
        public int UserId { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "名")]
        public string FirstName { get; set; }
        [Display(Name = "姓")]
        public string LastName { get; set; }
        [Display(Name = "简称")]
        public string ShortName { get; set; }
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }
        [Display(Name = "性别")]
        public bool Gender { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }
        [Display(Name = "电话")]
        public string Phone { get; set; }
        [Display(Name = "手机")]
        public string CellPhone { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "同工类型")]
        public int WorkerType { get; set; }
        [Display(Name = "是否受洗")]
        public bool IsBaptism { get; set; }
    }
    public class CallChaptorDetail
    {
        public string CallDetail { get; set; }
        public string CallChaptor { get; set; }
    }
    public class DonateBibleChaptorModel
    {
        public string Chaptor { get; set; }
        public string ChaptorDetail { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
    #endregion
}