using EnFu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EnFu.Modules
{
    public static class EntityMapper
    {
        public static BibleReadingViewModel LoadDTO(this DAL.Models.BibleReading entity)
        {
            if (entity != null)
            {
                var viewModel = new BibleReadingViewModel()
                {
                    BibleReadingDate = entity.BibleReadingDateTime,
                    BibleReadingChaptor = entity.BibleReadingChaptor,
                    VolumeSN = entity.VolumeSN,
                    ChapterSN = entity.ChapterSN,
                    VerseSNFrom = entity.VerseSNFrom,
                    VerseSNTo = entity.VerseSNTo,
                    Url = entity.Url,
                    Audio = entity.Audio,
                    Youtube = entity.Youtube,
                    AudioEnfu = entity.AudioEnfu,
                    VideoEnfu = entity.VideoEnfu,
                    AudioCai = entity.AudioCai,
                    BibleUrl = entity.BibleUrl
                };
                return viewModel;
            }
            else return new BibleReadingViewModel();

        }
        public static EventViewModel LoadDTO(this DAL.Models.Event entity)
        {
            if (entity != null)
            {
                var viewModel = new EventViewModel()
                {
                    EventId = entity.EventId,
                    EventName = entity.EventName,
                    EventDateTime = entity.EventDateTime,
                    EventDesc = entity.EventDesc,
                    EventOrder = entity.EventOrder
                };
                return viewModel;
            }
            else return new EventViewModel();

        }
        public static SundayServeViewModel LoadDTO(this DAL.Models.SundayServe entity)
        {
            if (entity != null)
            {
                var viewModel = new SundayServeViewModel()
                {
                    SundayServeId = entity.SundayServeId,
                    SundayServeDutyName = entity.SundayServeDutyName,
                    SundayServeDateTime = entity.SundayServeDateTime,
                    SundayServeName = entity.SundayServeName
                };
                return viewModel;
            }
            else return new SundayServeViewModel();
        }

        public static DAL.Models.SundayServe LoadEntity(this SundayServeViewModel viewModel)
        {
            if (viewModel != null)
            {
                var entity = new DAL.Models.SundayServe()
                {
                    SundayServeId = viewModel.SundayServeId,
                    SundayServeDutyName = viewModel.SundayServeDutyName,
                    SundayServeDateTime = viewModel.SundayServeDateTime,
                    SundayServeName = viewModel.SundayServeName
                };
                return entity;
            }
            else return new DAL.Models.SundayServe();
        }

        public static WorshipSongServeViewModel LoadDTO(this DAL.Models.WorshipSongServe entity)
        {
            if (entity != null)
            {
                var viewModel = new WorshipSongServeViewModel()
                {
                    Id = entity.WorshipSongServeId,
                    Name = entity.WorshipSongName,
                    WorshipDate = entity.WorshipDate,
                    Url = entity.WorshipSongUrl
                };
                return viewModel;
            }
            else return new WorshipSongServeViewModel();

        }

        public static WorshipSongLyricsViewModel LoadDTO(this DAL.Models.WorshipSongLyrics entity)
        {
            if (entity != null)
            {
                var viewModel = new WorshipSongLyricsViewModel()
                {
                    WorshipSongId = entity.WorshipSongId,
                    WorshipSongLyricsOrder = entity.WorshipSongLyricsOrder,
                    WorshipSongLyricsTitle = entity.WorshipSongLyricsTitle,
                    WorshipSongLyricsContent = entity.WorshipSongLyricsContent,
                    WorshipSongLyricsContentEnglish = entity.WorshipSongLyricsContentEnglish
                };
                return viewModel;
            }
            else return new WorshipSongLyricsViewModel();

        }
        public static TeamViewModel LoadDTO(this DAL.Models.Team entity)
        {
            if (entity != null)
            {
                var viewModel = new TeamViewModel()
                {
                    TeamName = entity.TeamName,
                    TeamLeaderName = entity.TeamComment,
                    TeamPhone = entity.TeamPhone,
                    TeamDate = entity.TeamDate
                };
                return viewModel;
            }
            else return new TeamViewModel();
        }

        public static WorkFlowViewModel LoadDTO(this DAL.Models.WorkFlow entity)
        {
            if (entity != null)
            {
                var viewModel = new WorkFlowViewModel()
                {
                    WorkFlowId = entity.WorkFlowId,
                    SundayDate = entity.SundayDate,
                    CallDetail = entity.CallDetail,
                    CallChaptor = entity.CallChaptor,
                    IsEucharist = entity.IsEucharist,
                    BibleReading = entity.BibleReading,
                    SermonTitle = entity.SermonTitle,
                    SermonDetails = Regex.Split(entity.SermonDetails, "\r\n|\r|\n").ToList(),
                    SermonSpeaker = entity.SermonSpeaker,
                    SermonSpeakerUrl = entity.SermonSpeakerUrl,
                    BibleWeeklyChaptor = entity.BibleWeeklyChaptor,
                    BibleWeeklyChaptorDetail = entity.BibleWeeklyChaptorDetail,
                    DonationWeeklyChaptor = entity.DonationWeeklyChaptor,
                    DonationWeeklyChaptorDetail = entity.DonationWeeklyChaptorDetail,
                    Blessing = entity.Blessing,
                    Witness = entity.Witness.HasValue ? entity.Witness.Value : false,
                    EucharistOperator = entity.EucharistOperator,
                    VideoLiveLink = entity.VideoLiveLink,
                    SermonAudioUrl = entity.SermonAudioUrl,
                    SermonWorshipSong = entity.SermonWorshipSong,
                    SermonWorshipSongAudioUrl = entity.SermonWorshipSongAudioUrl
                };
                return viewModel;
            }
            else return new WorkFlowViewModel();
        }

        //public static InformationNoteViewModel LoadDTO(this DAL.Models.InformationNote entity)
        //{
        //    if (entity != null)
        //    {
        //        var viewModel = new InformationNoteViewModel()
        //        {
        //            InformationNoteDate = entity.InformationNoteDate,
        //            InformationNoteTitle = entity.InformationNoteTitle,
        //            InformationNoteSpeaker = entity.InformationNoteSpeaker,
        //            InformationNoteDetailLines = String.IsNullOrWhiteSpace(entity.InformationNoteDetail) ? new List<string>() : entity.InformationNoteDetail.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList()
        //        };
        //        return viewModel;
        //    }
        //    else return new InformationNoteViewModel();
        //}

        public static PrayMatterViewModel LoadDTO(this DAL.Models.PrayMatter entity)
        {
            if (entity != null)
            {
                var viewModel = new PrayMatterViewModel()
                {
                    PrayMatterId = entity.PrayMatterId,
                    PrayMatterDesc = entity.PrayMatterDesc,
                    PrayMatterDate = entity.PrayMatterDate
                };
                return viewModel;
            }
            else return new PrayMatterViewModel();
        }

        public static GroupMeetingViewModel LoadDTO(this DAL.Models.GroupMeeting entity)
        {
            if (entity != null)
            {
                var viewModel = new GroupMeetingViewModel()
                {
                    GroupMeetingId = entity.GroupMeetingId,
                    GroupMeetingType = entity.GroupMeetingType,
                    GroupMeetingNumber = entity.GroupMeetingNumber,
                    GroupMeetingSundayReportDate = entity.GroupMeetingSundayReportDate,
                    GroupType = entity.GroupType
                };
                return viewModel;
            }
            else return new GroupMeetingViewModel();
        }

        public static DonateViewModel LoadDTO(this DAL.Models.Donate entity)
        {
            if (entity != null)
            {
                var viewModel = new DonateViewModel()
                {
                    DonateId = entity.DonateId,
                    DonateType = entity.DonateType,
                    DonateNumber = entity.DonateNumber,
                    DonateDate = entity.DonateDate
                };
                return viewModel;
            }
            else return new DonateViewModel();
        }

        public static CallChaptorDetail LoadDTO(this DAL.Models.CallChaptor entity)
        {
            if (entity != null)
            {
                var viewModel = new CallChaptorDetail()
                {
                    CallChaptor = entity.Chaptor,
                    CallDetail = entity.ChaptorDetail
                };
                return viewModel;
            }
            else return new CallChaptorDetail();
        }

        public static DonateBibleChaptorModel LoadDTO(this DAL.Models.DonateBibleChaptor entity)
        {
            if (entity != null)
            {
                var viewModel = new DonateBibleChaptorModel()
                {
                    Chaptor = entity.Chaptor,
                    ChaptorDetail = entity.ChaptorDetail,
                    SortOrder = entity.SortOrder,
                    IsActive = entity.IsActive
                };
                return viewModel;
            }
            else return new DonateBibleChaptorModel();
        }
        public static SpiritualEssayViewModel LoadDTO(this DAL.Models.SpiritualEssay entity)
        {
            if (entity != null)
            {
                var viewModel = new SpiritualEssayViewModel()
                {
                    SpiritualEssayId = entity.SpiritualEssayId,
                    SpiritualEssayTitle = entity.SpiritualEssayTitle,
                    SpiritualEssayChaptor = entity.SpiritualEssayChaptor,
                    SpiritualEssayContent = entity.SpiritualEssayContent,
                    SpiritualEssayPray = entity.SpiritualEssayPray,
                    SpiritualEssaySunday = entity.SpiritualEssaySunday
                };
                return viewModel;
            }
            else return new SpiritualEssayViewModel();
        }

        public static BibleChaptorModel LoadDTO(this DAL.Models.BibleChaptor entity)
        {
            if (entity != null)
            {
                var model = new BibleChaptorModel()
                {
                    BibleChaptorId = entity.BibleChaptorId,
                    KindSn = entity.KindSn,
                    TotalChaptors = entity.TotalChaptors,
                    TotalVerses = entity.TotalVerses,
                    NewOrOld = entity.NewOrOld,
                    PinYin = entity.PinYin,
                    ShortName = entity.ShortName,
                    MiddleName = entity.MiddleName,
                    FullName = entity.FullName,
                    ShortNameEnglish = entity.ShortNameEnglish,
                    MiddleNameEnglish = entity.MiddleName,
                    FullNameEnglish = entity.FullNameEnglish
                };
                return model;
            }
            else return new BibleChaptorModel();
        }

        public static BibleChaptorDetailModel LoadDTO(this DAL.Models.BibleChaptorDetail entity)
        {
            if (entity != null)
            {
                var model = new BibleChaptorDetailModel()
                {
                    BibleChaptorDetailId = entity.BibleChaptorDetailId,
                    VolumeSN = entity.VolumeSN,
                    ChapterSN = entity.ChapterSN,
                    VerseSN = entity.VerseSN,
                    Lection = entity.Lection,
                    LectionEnglish = entity.LectionEnglish
                };
                return model;
            }
            else return new BibleChaptorDetailModel();
        }
        public static PostViewModel LoadDTO(this DAL.Models.Post entity)
        {
            if (entity != null)
            {
                var model = new PostViewModel()
                {
                    PostId = entity.PostId,
                    Author = entity.Author,
                    Title = entity.Title,
                    isPublish = entity.isPublish,
                    CreatedDateTime = entity.CreatedDateTime,
                    UpdatedDateTime = entity.UpdatedDateTime,
                    PublishDateTime = entity.PublishDateTime,
                    Content = entity.Content
                };
                return model;
            }
            else return new PostViewModel();
        }

        public static PostContentViewModel LoadDTO(this DAL.Models.PostContent entity)
        {
            if (entity != null)
            {
                var model = new PostContentViewModel()
                {
                    PostContentId = entity.PostContentId,
                    PostId = entity.PostId,
                    Subtitle = entity.Subtitle,
                    Content = entity.Content
                };
                return model;
            }
            else return new PostContentViewModel();
        }
        public static MultimediaViewModel LoadDTO(this DAL.Models.Multimedia entity)
        {
            if (entity != null)
            {
                var model = new MultimediaViewModel()
                {
                    MultimediaId = entity.MultimediaId,
                    MultimediaName = entity.MultimediaName,
                    MultimediaAuthor = entity.MultimediaAuthor,
                    MultimediaDesc = entity.MultimediaDesc,
                    MultimediaDuration = entity.MultimediaDuration,
                    MultimediaPublishDate = entity.MultimediaPublishDate,
                    MultimediaLink = entity.MultimediaLink,
                    MultimediaEmbedLink = entity.MultimediaEmbedLink,
                    MultimediaFormat = entity.MultimediaFormat,
                    MultimediaTypeId = entity.MultimediaTypeId,
                    MultimediaComment = entity.MultimediaComment,
                    MultimediaLyrics = entity.MultimediaLyrics,
                    IsActive = entity.IsActive
                };
                return model;
            }
            else return new MultimediaViewModel();
        }
        public static MultimediaTypeViewModel LoadDTO(this DAL.Models.MultimediaType entity)
        {
            if (entity != null)
            {
                var model = new MultimediaTypeViewModel()
                {
                    MultimediaTypeId = entity.MultimediaTypeId,
                    MultimediaTypeName = entity.MultimediaTypeName,
                    MultimediaTypeDesc = entity.MultimediaTypeDesc,
                    Comment = entity.Comment,
                    IsActive = entity.IsActive
                };
                return model;
            }
            else return new MultimediaTypeViewModel();
        }
        public static UserProfileModel LoadDTO(this DAL.Models.UserProfile entity)
        {
            if (entity != null)
            {
                var model = new UserProfileModel()
                {
                    UserId = entity.UserId,
                    UserName = entity.UserName,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    ShortName = entity.ShortName,
                    Email = entity.Email,
                    Gender = entity.Gender,
                    Age = entity.Age,
                    Phone = entity.Phone,
                    CellPhone = entity.CellPhone,
                    Address = entity.Address,
                    WorkerType = entity.WorkerType,
                    IsBaptism = entity.IsBaptism
                };
                return model;
            }
            else return new UserProfileModel();
        }
    }
}