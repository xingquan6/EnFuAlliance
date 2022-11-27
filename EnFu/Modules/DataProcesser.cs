using EnFu.DAL;
using EnFu.Helpers;
using EnFu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnFu.Modules
{
    public static class DataProcesser
    {
        private static UnitOfWork _unitOfWork;
        private static DateTime _sundayReportDate;
        private static DateTime _maxLastSunday;
        private static DateTime _maxNextSunday;
        private static DateTime _maxCurrentSaturday;

        static DataProcesser()
        {
            DateTime today = DateTime.Now;
            _sundayReportDate = today.CurrentSunday();
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public static void Init(DateTime sundayReportDate)
        {
            _sundayReportDate = sundayReportDate;
            _maxLastSunday = _sundayReportDate.AddDays(-7);
            _maxNextSunday = _sundayReportDate.AddDays(7);
            _maxCurrentSaturday = _sundayReportDate.AddDays(14);
        }

        #region Update
        public static void UpdateWorkFlow(WorkFlowViewModel model)
        {
            var sundayDate = model.SundayDate;
            var dbEntity = _unitOfWork.WorkFlowRepository.GetAll()
                .Where(x => x.SundayDate == sundayDate).FirstOrDefault();
            if (dbEntity != null)
            {
                dbEntity.CallDetail = model.CallDetail;
                dbEntity.CallChaptor = model.CallChaptor;
                dbEntity.IsEucharist = model.IsEucharist;
                dbEntity.EucharistOperator = model.EucharistOperator;
                dbEntity.BibleReading = model.BibleReading;
                dbEntity.SermonTitle = model.SermonTitle;
                dbEntity.SermonSpeaker = model.SermonSpeaker;
                dbEntity.BibleWeeklyChaptor = model.BibleWeeklyChaptor;
                dbEntity.BibleWeeklyChaptorDetail = model.BibleWeeklyChaptorDetail;
                dbEntity.DonationWeeklyChaptor = model.DonationWeeklyChaptor;
                dbEntity.DonationWeeklyChaptorDetail = model.DonationWeeklyChaptorDetail;
                dbEntity.Blessing = model.Blessing;
                dbEntity.Witness = model.Witness;
                dbEntity.SermonDetails = String.Join<string>("/r/n", model.SermonDetails);
                dbEntity.SermonSpeakerUrl = model.SermonSpeakerUrl;
                dbEntity.SundayDate = sundayDate;
                dbEntity.SermonAudioUrl = model.SermonAudioUrl;
                dbEntity.SermonWorshipSong = model.SermonWorshipSong;
                dbEntity.SermonWorshipSongAudioUrl = model.SermonWorshipSongAudioUrl;

                _unitOfWork.WorkFlowRepository.Update(dbEntity);
                _unitOfWork.Save();
            }
            else
            {
                dbEntity = new DAL.Models.WorkFlow();
                dbEntity.CallDetail = model.CallDetail;
                dbEntity.CallChaptor = model.CallChaptor;
                dbEntity.IsEucharist = model.IsEucharist;
                dbEntity.EucharistOperator = model.EucharistOperator;
                dbEntity.BibleReading = model.BibleReading;
                dbEntity.SermonTitle = model.SermonTitle;
                dbEntity.SermonSpeaker = model.SermonSpeaker;
                dbEntity.BibleWeeklyChaptor = model.BibleWeeklyChaptor;
                dbEntity.BibleWeeklyChaptorDetail = model.BibleWeeklyChaptorDetail;
                dbEntity.DonationWeeklyChaptor = model.DonationWeeklyChaptor;
                dbEntity.DonationWeeklyChaptorDetail = model.DonationWeeklyChaptorDetail;
                dbEntity.Blessing = model.Blessing;
                dbEntity.Witness = model.Witness;
                dbEntity.SermonDetails = String.Join<string>("/r/n", model.SermonDetails);
                dbEntity.SermonSpeakerUrl = model.SermonSpeakerUrl;
                dbEntity.SundayDate = sundayDate;
                dbEntity.SermonAudioUrl = model.SermonAudioUrl;
                dbEntity.SermonWorshipSong = model.SermonWorshipSong;
                dbEntity.SermonWorshipSongAudioUrl = model.SermonWorshipSongAudioUrl;
                _unitOfWork.WorkFlowRepository.Insert(dbEntity);
                _unitOfWork.Save();
            }
        }
        public static void UpdateEvents(EventListViewModel eventListViewModel)
        {
            var sundayDate = eventListViewModel.EventList.FirstOrDefault().EventDateTime;
            var validList = eventListViewModel.EventList.Where(x => x.EventName != null).ToList();
            var dbEntities = _unitOfWork.EventRepository.GetAll()
                .Where(x => x.EventDateTime == sundayDate);
            if (validList.Count < dbEntities.ToList().Count)
            {
                for (int i = 0; i <= (dbEntities.ToList().Count - validList.Count); i++)
                {
                    int id = dbEntities.ToList()[dbEntities.ToList().Count - 1 - i].EventId;
                    _unitOfWork.EventRepository.Delete(dbEntities.Where(x => x.EventId == id).FirstOrDefault());
                };
                _unitOfWork.Save();
            }
            foreach (var entity in validList)
            {
                var dbEntity = _unitOfWork.EventRepository.GetByID(entity.EventId);
                if (dbEntity != null)
                {
                    dbEntity.EventName = entity.EventName;
                    dbEntity.EventDateTime = entity.EventDateTime;
                    dbEntity.EventDesc = entity.EventDesc;
                    dbEntity.EventOrder = entity.EventOrder;
                    _unitOfWork.EventRepository.Update(dbEntity);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.EventRepository.Insert(
                            new DAL.Models.Event()
                            {
                                EventId = entity.EventId,
                                EventName = entity.EventName,
                                EventDateTime = sundayDate,
                                EventDesc = entity.EventDesc,
                                EventOrder = entity.EventOrder
                            });
                    _unitOfWork.Save();
                };
            };
            //_unitOfWork.Save();
        }

        public static void UpdatePrayMatters(PrayMatterListViewModel prayMatterListViewModel)
        {
            var sundayDate = prayMatterListViewModel.PrayMatterList.FirstOrDefault().PrayMatterDate;
            var validList = prayMatterListViewModel.PrayMatterList.Where(x => x.PrayMatterDesc != null).ToList();
            var dbEntities = _unitOfWork.PrayMatterRepository.GetAll()
                .Where(x => x.PrayMatterDate == sundayDate);
            if (validList.Count < dbEntities.ToList().Count)
            {
                for (int i = 0; i <= (dbEntities.ToList().Count - validList.Count); i++)
                {
                    int id = dbEntities.ToList()[dbEntities.ToList().Count - 1 - i].PrayMatterId;
                    _unitOfWork.PrayMatterRepository.Delete(dbEntities.Where(x => x.PrayMatterId == id).FirstOrDefault());
                };
                _unitOfWork.Save();
            }
            foreach (var entity in validList)
            {
                var dbEntity = _unitOfWork.PrayMatterRepository.GetByID(entity.PrayMatterId);
                if (dbEntity != null)
                {
                    dbEntity.PrayMatterId = entity.PrayMatterId;
                    dbEntity.PrayMatterDesc = entity.PrayMatterDesc;
                    dbEntity.PrayMatterDate = entity.PrayMatterDate;
                    _unitOfWork.PrayMatterRepository.Update(dbEntity);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.PrayMatterRepository.Insert(
                            new DAL.Models.PrayMatter()
                            {
                                PrayMatterId = entity.PrayMatterId,
                                PrayMatterDesc = entity.PrayMatterDesc,
                                PrayMatterDate = sundayDate
                            });
                    _unitOfWork.Save();
                };
            };
        }

        public static void UpdateGroupMeetings(GroupMeetingListViewModel groupMeetingListViewModel)
        {
            var sundayDate = groupMeetingListViewModel.GroupMeetingList.FirstOrDefault().GroupMeetingSundayReportDate;
            var dbEntities = _unitOfWork.GroupMeetingRepository.GetAll()
                .Where(x => x.GroupMeetingSundayReportDate == sundayDate);
            foreach (var model in groupMeetingListViewModel.GroupMeetingList)
            {
                var dbEntity = _unitOfWork.GroupMeetingRepository.GetByID(model.GroupMeetingId);
                if (dbEntity != null)
                {
                    //dbEntity.GroupMeetingId = entity.GroupMeetingId;
                    dbEntity.GroupMeetingType = model.GroupMeetingType;
                    dbEntity.GroupMeetingNumber = model.GroupMeetingNumber;
                    dbEntity.GroupMeetingSundayReportDate = sundayDate;
                    dbEntity.GroupType = model.GroupType;
                    _unitOfWork.GroupMeetingRepository.Update(dbEntity);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.GroupMeetingRepository.Insert(
                            new DAL.Models.GroupMeeting
                            {
                                GroupMeetingType = model.GroupMeetingType,
                                GroupMeetingNumber = model.GroupMeetingNumber,
                                GroupMeetingSundayReportDate = sundayDate,
                                GroupType = model.GroupType
                            });
                    _unitOfWork.Save();
                };
            };
        }

        public static void UpdateSpiritualEssay(SpiritualEssayViewModel model)
        {
            var sundayDate = model.SpiritualEssaySunday;
            var dbEntity = _unitOfWork.SpiritualEssayRepository.GetAll()
                .Where(x => x.SpiritualEssaySunday == sundayDate).FirstOrDefault();
            if (dbEntity != null)
            {
                dbEntity.SpiritualEssayTitle = model.SpiritualEssayTitle;
                dbEntity.SpiritualEssayChaptor = model.SpiritualEssayChaptor;
                dbEntity.SpiritualEssayContent = model.SpiritualEssayContent;
                dbEntity.SpiritualEssayPray = model.SpiritualEssayPray;
                dbEntity.SpiritualEssaySunday = sundayDate;
                _unitOfWork.SpiritualEssayRepository.Update(dbEntity);
                _unitOfWork.Save();
            }
            else
            {
                dbEntity = new DAL.Models.SpiritualEssay();
                dbEntity.SpiritualEssayTitle = model.SpiritualEssayTitle;
                dbEntity.SpiritualEssayChaptor = model.SpiritualEssayChaptor;
                dbEntity.SpiritualEssayContent = model.SpiritualEssayContent;
                dbEntity.SpiritualEssayPray = model.SpiritualEssayPray;
                dbEntity.SpiritualEssaySunday = sundayDate;
                _unitOfWork.SpiritualEssayRepository.Insert(dbEntity);
                _unitOfWork.Save();
            }
        }

        public static void UpdateDonates(DonateListViewModel donateListViewModel)
        {
            var lastSundayDate = donateListViewModel.DonateList.FirstOrDefault().DonateDate;
            var dbEntities = _unitOfWork.DonateRepository.GetAll()
                .Where(x => x.DonateDate == lastSundayDate);
            foreach (var model in donateListViewModel.DonateList)
            {
                var dbEntity = _unitOfWork.DonateRepository.GetByID(model.DonateId);
                if (dbEntity != null)
                {
                    dbEntity.DonateType = model.DonateType;
                    dbEntity.DonateNumber = model.DonateNumber;
                    dbEntity.DonateDate = lastSundayDate;
                    _unitOfWork.DonateRepository.Update(dbEntity);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.DonateRepository.Insert(
                            new DAL.Models.Donate
                            {
                                DonateType = model.DonateType,
                                DonateNumber = model.DonateNumber,
                                DonateDate = lastSundayDate
                            });
                    _unitOfWork.Save();
                };
            };
        }

        public static void UpdateSundayServeList(SundayServeListViewModel model)
        {
            var sundayDate = model.SundayServeList[0].SundayServeDateTime;
            var dbEntities = _unitOfWork.SundayServeRepository.GetAll()
                .Where(x => x.SundayServeDateTime.ToString("yyyy-MM-dd") == sundayDate.ToString("yyyy-MM-dd"))
                .ToList();
            if (dbEntities == null || dbEntities.Count == 0)
            {
                foreach (var item in model.SundayServeList)
                {
                    var entity = new DAL.Models.SundayServe();
                    entity.SundayServeName = item.SundayServeName;
                    entity.SundayServeDutyName = item.SundayServeDutyName;
                    entity.SundayServeDateTime = item.SundayServeDateTime;
                    _unitOfWork.SundayServeRepository.Insert(entity);
                };
                _unitOfWork.Save();
            }
            else
            {
                foreach (var entity in dbEntities)
                {
                    if (entity != null)
                    {
                        var item = model.SundayServeList.Where(x => x.SundayServeDutyName == entity.SundayServeDutyName).FirstOrDefault();
                        entity.SundayServeName = item.SundayServeName;
                        _unitOfWork.SundayServeRepository.Update(entity);
                    };
                    _unitOfWork.Save();
                }
            }
        }

        public static void UpdateWorshipSongServeList(WorshipSongServeListViewModel model)
        {
            var sundayDate = model.WorshipSongServeList[0].WorshipDate;
            var dbEntities = _unitOfWork.WorshipSongServeRepository.GetAll()
                .Where(x => x.WorshipDate.ToString("yyyy-MM-dd") == sundayDate.ToString("yyyy-MM-dd"))
                .ToList();
            if (dbEntities == null || dbEntities.Count == 0)
            {
                foreach (var item in model.WorshipSongServeList)
                {
                    var entity = new DAL.Models.WorshipSongServe();
                    entity.WorshipSongName = item.Name;
                    entity.WorshipDate = item.WorshipDate;
                    entity.WorshipSongUrl = item.Url;
                    _unitOfWork.WorshipSongServeRepository.Insert(entity);
                };
                _unitOfWork.Save();
            }
            else
            {
                foreach (var entity in dbEntities)
                {
                    if (entity != null)
                    {
                        var item = model.WorshipSongServeList
                            .Where(x => x.Id == entity.WorshipSongServeId).FirstOrDefault();
                        entity.WorshipSongName = item.Name;
                        entity.WorshipSongUrl = item.Url;
                        _unitOfWork.WorshipSongServeRepository.Update(entity);
                    };
                };
                _unitOfWork.Save();
            }
        }


        #endregion Update

        #region
        public static SundayReportPdfViewModel GetData()
        {
            var sundayReportPdfViewModel = new SundayReportPdfViewModel();

            sundayReportPdfViewModel.CurrentYear = _sundayReportDate.Year;
            sundayReportPdfViewModel.LastSaturdayDate = _sundayReportDate.AddDays(-1).Month + "月" + _sundayReportDate.AddDays(-1).Day + "日";
            sundayReportPdfViewModel.LastSundayDate = _sundayReportDate.AddDays(-7).Month + "月" + _sundayReportDate.AddDays(-7).Day + "日";
            sundayReportPdfViewModel.Last2WeeksSaturdayDate = _sundayReportDate.AddDays(-8).Month + "月" + _sundayReportDate.AddDays(-8).Day + "日";
            sundayReportPdfViewModel.Last2WeeksSundayDate = _sundayReportDate.AddDays(-14).Month + "月" + _sundayReportDate.AddDays(-14).Day + "日";
            sundayReportPdfViewModel.CurrentSundayDate = _sundayReportDate.Month + "月" + _sundayReportDate.Day + "日";
            sundayReportPdfViewModel.NextSundayDate = _sundayReportDate.AddDays(7).Month + "月" + _sundayReportDate.AddDays(7).Day + "日";
            sundayReportPdfViewModel.Next2SundayDate = _sundayReportDate.AddDays(14).Month + "月" + _sundayReportDate.AddDays(14).Day + "日";

            sundayReportPdfViewModel.BibleReadings = GetBibleReadings();     // WeeklyBibleReadingInfos
            //sundayReportPdfViewModel.BibleReadings = new List<BibleReadingViewModels>();
            sundayReportPdfViewModel.WorkFlow = GetWorkFlow(_sundayReportDate);               // WorkFlow
            sundayReportPdfViewModel.WorshipSongServeViewModels = GetWorshipSongServeViewModels(_sundayReportDate);  // WorshipSongServes
            sundayReportPdfViewModel.Events = GetEvents(_sundayReportDate);  // Events            
            sundayReportPdfViewModel.PrayEvents = GetPrayMatters(_sundayReportDate);//PrayEvents
            sundayReportPdfViewModel.CurrentSundayServe = GetSundayServe(_sundayReportDate);
            sundayReportPdfViewModel.NextSundayServe = GetSundayServe(_sundayReportDate.AddDays(7));
            sundayReportPdfViewModel.Next2WeeksSundayServe = GetSundayServe(_sundayReportDate.AddDays(14));
            sundayReportPdfViewModel.Teams = GetTeams(); // ChurchTeams

            var groupMeetings = GetGroupMeetings(_sundayReportDate); //GroupMeetings
            sundayReportPdfViewModel.TeamGroupMeetings = groupMeetings.Where(x => x.GroupType == 1).ToList();
            sundayReportPdfViewModel.AdultGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "成人").FirstOrDefault();
            sundayReportPdfViewModel.TeenGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "青少年").FirstOrDefault();
            sundayReportPdfViewModel.ChildrenGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "儿童").FirstOrDefault();
            sundayReportPdfViewModel.PrayGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "祷告会").FirstOrDefault();
            sundayReportPdfViewModel.SundayPrayGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "主日祷告会").FirstOrDefault();
            sundayReportPdfViewModel.BibleReadingGroupMeeting = groupMeetings.Where(x => x.GroupMeetingType == "查经班").FirstOrDefault();
            sundayReportPdfViewModel.LastSundayPeopleNumber =
                sundayReportPdfViewModel.AdultGroupMeeting.GroupMeetingNumber
                + sundayReportPdfViewModel.TeenGroupMeeting.GroupMeetingNumber
                + sundayReportPdfViewModel.ChildrenGroupMeeting.GroupMeetingNumber;
            var donateList = GetDonates(_sundayReportDate);
            sundayReportPdfViewModel.SundayDonate = new SundayDonateViewModel();
            sundayReportPdfViewModel.SundayDonate.RegularDonate = donateList.Where(x => x.DonateType == "常費").FirstOrDefault().DonateNumber;
            sundayReportPdfViewModel.SundayDonate.BuildChurchDonate = donateList.Where(x => x.DonateType == "建堂").FirstOrDefault().DonateNumber;
            sundayReportPdfViewModel.SundayDonate.SpreadDonate = donateList.Where(x => x.DonateType == "差傳").FirstOrDefault().DonateNumber;
            sundayReportPdfViewModel.SundayDonate.HuanHuanDonate = donateList.Where(x => x.DonateType == "歡歡").FirstOrDefault().DonateNumber;
            sundayReportPdfViewModel.SundayDonate.ThankGivingDonate = donateList.Where(x => x.DonateType == "感恩").FirstOrDefault().DonateNumber;
            sundayReportPdfViewModel.SundayDonate.OtherDonate = donateList.Where(x => x.DonateType == "其他").FirstOrDefault().DonateNumber;

            sundayReportPdfViewModel.MonthlyDonate = GetMonthlyDonate(); //MonthDonates

            // to do calculate MonthDonate, MonthBudget, Percentage
            sundayReportPdfViewModel.MonthDonate =
                sundayReportPdfViewModel.MonthlyDonate.MonthlyRegularDonate
                + sundayReportPdfViewModel.MonthlyDonate.MonthlyBuildChurchDonate
                + sundayReportPdfViewModel.MonthlyDonate.MonthlySpreadDonate
                + sundayReportPdfViewModel.MonthlyDonate.MonthlyHuanHuanDonate
                + sundayReportPdfViewModel.MonthlyDonate.MonthlyThankGivingDonate
                + sundayReportPdfViewModel.MonthlyDonate.MonthlyOtherDonate;
            sundayReportPdfViewModel.MonthBudget = (decimal)9081;
            sundayReportPdfViewModel.MonthDonatePercentage = sundayReportPdfViewModel.MonthDonate / sundayReportPdfViewModel.MonthBudget;


            sundayReportPdfViewModel.SpiritualEssayPray = GetSpiritualEssay(_sundayReportDate);
            sundayReportPdfViewModel.SpiritualEssayContents = sundayReportPdfViewModel.SpiritualEssayPray.SpiritualEssayContent.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
            sundayReportPdfViewModel.SpiritualEssayPrays = sundayReportPdfViewModel.SpiritualEssayPray.SpiritualEssayPray.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();

            sundayReportPdfViewModel.SerminViewModels = GetSermonViewModels(_sundayReportDate);

            return sundayReportPdfViewModel;
        }
        public static BibleReadingPdfViewModel GetBibleReadingData(DownloadDocumentViewModel downloadDocumentViewModel)
        {
            DateTime theDate = DateTime.Parse(downloadDocumentViewModel.SundayDate);
            var bibleReadingPdfViewModel = new BibleReadingPdfViewModel();

            bibleReadingPdfViewModel.CurrentYear = _sundayReportDate.Year;
            bibleReadingPdfViewModel.CurrentDate = theDate.Month + "月" + theDate.Day + "日";
            bibleReadingPdfViewModel.BibleReadings = GetDailyBibleReadings(theDate);     // WeeklyBibleReadingInfos
            var chaptors = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                .GroupBy(x => x.BibleReadingChaptor)
                .Select(grp => grp.Key.Trim())
                .ToList();
            var bibleReadings = JsonConvert.DeserializeObject<List<BibleReadingViewModel>>(JsonConvert.SerializeObject(bibleReadingPdfViewModel.BibleReadings[0].ViewModels));
            bibleReadingPdfViewModel.BibleReadings1 = bibleReadings.Where(x => x.BibleReadingChaptor.Trim() == chaptors[0]).ToList();
            bibleReadingPdfViewModel.BibleReadings2 = bibleReadings.Where(x => x.BibleReadingChaptor.Trim() == chaptors[1]).ToList();
            var minChaptor1 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels[0];
            var maxChaptor1 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                .Where(x => x.BibleReadingChaptor.Trim() == chaptors[0].Trim()).LastOrDefault();
            var minChaptor2 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                .Where(x => x.BibleReadingChaptor.Trim() == chaptors[1].Trim()).FirstOrDefault();
            var maxChaptor2 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                .Where(x => x.BibleReadingChaptor.Trim() == chaptors[1].Trim()).LastOrDefault();
            bibleReadingPdfViewModel.ChaptorTitle1 = 
                (minChaptor1.ChapterSN== maxChaptor1.ChapterSN) 
                ? chaptors[0].Trim() + minChaptor1.ChapterSN + "章"
                : chaptors[0].Trim() + minChaptor1.ChapterSN+"-"+ maxChaptor1.ChapterSN+"章";
            bibleReadingPdfViewModel.ChaptorTitle2 = 
                (minChaptor2.ChapterSN == maxChaptor2.ChapterSN) 
                ? chaptors[1].Trim() + minChaptor2.ChapterSN + "章" 
                    + ((downloadDocumentViewModel.Type==0)?"":minChaptor2.VerseSNFrom +"-"+maxChaptor2.VerseSNTo+"节")
                : (downloadDocumentViewModel.Type == 0)
                ?chaptors[1].Trim() + minChaptor2.ChapterSN + "-" + maxChaptor2.ChapterSN + "章"
                : chaptors[1].Trim() + minChaptor2.ChapterSN + "章" + minChaptor2.VerseSNFrom + "-" + minChaptor2.VerseSNTo + "节"
                 + maxChaptor2.ChapterSN + "章" + maxChaptor2.VerseSNFrom + "-" + maxChaptor2.VerseSNTo + "节";
            return bibleReadingPdfViewModel;
        }
        public static List<BibleReadingPdfViewModel> GetBibleReadingMonthData(DownloadDocumentViewModel downloadDocumentViewModel)
        {
            DateTime theDate = DateTime.Parse(downloadDocumentViewModel.SundayDate);
            var models = new List<BibleReadingPdfViewModel>();
            int days = DateTime.DaysInMonth(theDate.Year, theDate.Month);
            for (int day = 1; day <= days; day++)
            {
                var bibleReadingPdfViewModel = new BibleReadingPdfViewModel();
                bibleReadingPdfViewModel.CurrentYear = _sundayReportDate.Year;
                bibleReadingPdfViewModel.CurrentMonth = theDate.Month + "月";
                bibleReadingPdfViewModel.CurrentDay = day + "日";
                bibleReadingPdfViewModel.CurrentDate = theDate.Month + "月" + theDate.Day + "日";
                bibleReadingPdfViewModel.BibleReadings = GetDailyBibleReadings(DateTime.Parse(theDate.Month+@"/"+day+@"/"+_sundayReportDate.Year));
                var chaptors = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                    .GroupBy(x => x.BibleReadingChaptor)
                    .Select(grp => grp.Key.Trim())
                    .ToList();
                var bibleReadings = JsonConvert.DeserializeObject<List<BibleReadingViewModel>>(JsonConvert.SerializeObject(bibleReadingPdfViewModel.BibleReadings[0].ViewModels));
                bibleReadingPdfViewModel.BibleReadings1 = bibleReadings.Where(x => x.BibleReadingChaptor.Trim() == chaptors[0]).ToList();
                bibleReadingPdfViewModel.BibleReadings2 = bibleReadings.Where(x => x.BibleReadingChaptor.Trim() == chaptors[1]).ToList();
                var minChaptor1 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels[0];
                var maxChaptor1 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                    .Where(x => x.BibleReadingChaptor.Trim() == chaptors[0].Trim()).LastOrDefault();
                var minChaptor2 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                    .Where(x => x.BibleReadingChaptor.Trim() == chaptors[1].Trim()).FirstOrDefault();
                var maxChaptor2 = bibleReadingPdfViewModel.BibleReadings[0].ViewModels
                    .Where(x => x.BibleReadingChaptor.Trim() == chaptors[1].Trim()).LastOrDefault();
                bibleReadingPdfViewModel.ChaptorTitle1 =
                    (minChaptor1.ChapterSN == maxChaptor1.ChapterSN)
                    ? chaptors[0].Trim() + minChaptor1.ChapterSN + "章"
                    : chaptors[0].Trim() + minChaptor1.ChapterSN + "-" + maxChaptor1.ChapterSN + "章";
                bibleReadingPdfViewModel.ChaptorTitle2 =
                    (minChaptor2.ChapterSN == maxChaptor2.ChapterSN)
                    ? chaptors[1].Trim() + minChaptor2.ChapterSN + "章"
                        + ((downloadDocumentViewModel.Type == 0) ? "" : minChaptor2.VerseSNFrom + "-" + maxChaptor2.VerseSNTo + "节")
                    : (downloadDocumentViewModel.Type == 0)
                    ? chaptors[1].Trim() + minChaptor2.ChapterSN + "-" + maxChaptor2.ChapterSN + "章"
                    : chaptors[1].Trim() + minChaptor2.ChapterSN + "章" + minChaptor2.VerseSNFrom + "-" + minChaptor2.VerseSNTo + "节"
                     + maxChaptor2.ChapterSN + "章" + maxChaptor2.VerseSNFrom + "-" + maxChaptor2.VerseSNTo + "节";
                models.Add(bibleReadingPdfViewModel);
            };
            return models;            
        }
        public static List<BibleReadingViewModels> GetDailyBibleReadings(DateTime theDate)
        {
            DateTime beginDate = theDate.Date;
            DateTime endDate = theDate.Date.AddDays(1);
            var entities = _unitOfWork.BibleReadingRepository.GetAll()
                .Where(x => x.BibleReadingDateTime >= beginDate && x.BibleReadingDateTime < endDate)
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var groupedList = entities.GroupBy(u => u.BibleReadingDateTime).Select(grp => grp.ToList()).ToList();
                var list = new List<BibleReadingViewModels>();
                foreach (var items in groupedList)
                {
                    var itemDetails = new BibleReadingViewModels();
                    itemDetails.ViewModels = new List<BibleReadingViewModel>();
                    foreach (var item in items)
                    {
                        var itemDetail = new BibleReadingViewModel();
                        itemDetail = item.LoadDTO();
                        var bibleLink = _unitOfWork.BibleChaptorLinkRepository.GetAll()
                            .Where(x => x.VolumeSN == itemDetail.VolumeSN && x.ChapterSN == itemDetail.ChapterSN)
                            .FirstOrDefault();
                        itemDetail.Url = bibleLink.UrlCMC;
                        itemDetail.Audio = bibleLink.AudioCMC;
                        itemDetail.AudioCai = bibleLink.AudioCai;
                        itemDetail.BibleUrl = bibleLink.BibleUrl;
                        itemDetails.ViewModels.Add(itemDetail);
                    };
                    list.Add(itemDetails);
                }
                return list;
            }
            else
            {
                return new List<BibleReadingViewModels>();
            };
        }

        public static List<BibleReadingViewModels> GetBibleReadings()
        {
            DateTime maxBibleReadingDate = _sundayReportDate.AddDays(14);
            DateTime minBibleReadingDate = _sundayReportDate;
            var entities = _unitOfWork.BibleReadingRepository.GetAll()
                .Where(x => x.BibleReadingDateTime >= minBibleReadingDate && x.BibleReadingDateTime < maxBibleReadingDate)
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var groupedList = entities.GroupBy(u => u.BibleReadingDateTime).Select(grp => grp.ToList()).ToList();
                var list = new List<BibleReadingViewModels>();
                foreach (var items in groupedList)
                {
                    var itemDetails = new BibleReadingViewModels();
                    itemDetails.ViewModels = new List<BibleReadingViewModel>();
                    foreach (var item in items)
                    {
                        BibleDetail bibleDetailFrom = new BibleDetail()
                        {
                            VolumeSN = item.VolumeSN,
                            ChapterSN = item.ChapterSN,
                            VerseSN = item.VerseSNFrom
                        };
                        BibleDetail bibleDetailTo = new BibleDetail()
                        {
                            VolumeSN = item.VolumeSN,
                            ChapterSN = item.ChapterSN,
                            VerseSN = item.VerseSNTo
                        };
                        var itemDetail = new BibleReadingViewModel();
                        //itemDetail.BibleReadingChaptor = GetBibleChaptorShortNameById(items[0].VolumeSN);
                        itemDetail = item.LoadDTO();
                        
                        // add CMC link to BibleReading
                        var link = _unitOfWork.BibleChaptorLinkRepository.GetAll()
                            .Where(x => x.ChapterSN == itemDetail.ChapterSN && x.VolumeSN == itemDetail.VolumeSN).FirstOrDefault();
                        if (link != null)
                        {
                            itemDetail.Url = link.UrlCMC;
                            itemDetail.Audio = link.AudioCMC; 
                        };

                        //itemDetail.BibleReadingContent = GetBibleReadingContent(bibleDetailFrom, bibleDetailTo);
                        if (itemDetail.BibleReadingChaptor.Length > 4)
                            itemDetail.BibleReadingChaptor = _unitOfWork.BibleChaptorRepository.GetAll()
                                .Where(x => x.BibleChaptorId == item.VolumeSN).FirstOrDefault().ShortName;
                        itemDetails.ViewModels.Add(itemDetail);
                    };
                    list.Add(itemDetails);
                }
                return list;
            }
            else
            {
                return new List<BibleReadingViewModels>();
            };
        }
        public static List<EventViewModel> GetEvents(DateTime eventsDate)
        {
            var entities = _unitOfWork.EventRepository.GetAll()
                     .Where(x => x.EventDateTime.ToString("yyyyMMdd") == eventsDate.ToString("yyyyMMdd"))
                     .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<EventViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<EventViewModel>();
            };
        }
        public static List<WorshipSongServeViewModel> GetWorshipSongServeViewModels(DateTime worshipSongServeDate)
        {
            var entities = _unitOfWork.WorshipSongServeRepository.GetAll()
                     .Where(x => x.WorshipDate.ToString("yyyyMMdd") == worshipSongServeDate.ToString("yyyyMMdd"))
                     .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<WorshipSongServeViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<WorshipSongServeViewModel>();
            };
        }

        public static void CreateWorkFlowFromLastSunday(DateTime lastSundayDate)
        {
            var entity = _unitOfWork.WorkFlowRepository.GetAll()
                     .Where(x => x.SundayDate.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .FirstOrDefault();
            entity.SundayDate = lastSundayDate.AddDays(7);
            entity.SermonAudioUrl = null;
            _unitOfWork.WorkFlowRepository.Insert(entity);
            _unitOfWork.Save();
        }
        public static void CreateEventsFromLastSunday(DateTime lastSundayDate)
        {
            var entities = _unitOfWork.EventRepository.GetAll()
                     .Where(x => x.EventDateTime.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.EventDateTime = lastSundayDate.AddDays(7);
            };
            _unitOfWork.EventRepository.Insert(entities);
            _unitOfWork.Save();
        }

        public static void CreatePrayMatterFromLastSunday(DateTime lastSundayDate)
        {
            var entities = _unitOfWork.PrayMatterRepository.GetAll()
                     .Where(x => x.PrayMatterDate.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.PrayMatterDate = lastSundayDate.AddDays(7);
            };
            _unitOfWork.PrayMatterRepository.Insert(entities);
            _unitOfWork.Save();
        }

        public static void CreateGroupMeetingFromLastSunday(DateTime lastSundayDate)
        {
            var entities = _unitOfWork.GroupMeetingRepository.GetAll()
                     .Where(x => x.GroupMeetingSundayReportDate.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.GroupMeetingNumber = 0;
                entity.GroupMeetingSundayReportDate = lastSundayDate.AddDays(7);
            };
            _unitOfWork.GroupMeetingRepository.Insert(entities);
            _unitOfWork.Save();
        }

        public static void CreateDonates(DateTime lastSundayDate)
        {
            var lastTwoSundayDate = lastSundayDate.AddDays(-7);
            var entities = _unitOfWork.DonateRepository.GetAll()
                     .Where(x => x.DonateDate.ToString("yyyyMMdd") == lastTwoSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.DonateNumber = 0;
                entity.DonateDate = lastSundayDate;
            };
            _unitOfWork.DonateRepository.Insert(entities);
            _unitOfWork.Save();
        }

        public static void CreateWorshipSongServeFromLastSunday(DateTime lastSundayDate)
        {
            var entities = _unitOfWork.WorshipSongServeRepository.GetAll()
                     .Where(x => x.WorshipDate.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.WorshipDate = lastSundayDate.AddDays(7);
            };
            _unitOfWork.WorshipSongServeRepository.Insert(entities);
            _unitOfWork.Save();
        }



        public static void CreateSundaySongServesFromLastSunday(DateTime lastSundayDate)
        {
            var entities = _unitOfWork.WorshipSongServeRepository.GetAll()
                     .Where(x => x.WorshipDate.ToString("yyyyMMdd") == lastSundayDate.ToString("yyyyMMdd"))
                     .ToList();
            foreach (var entity in entities)
            {
                entity.WorshipDate = lastSundayDate.AddDays(7);
            };
            _unitOfWork.WorshipSongServeRepository.Insert(entities);
            _unitOfWork.Save();
        }










        public static SundayServeDetails GetSundayServe(DateTime sundayDate)
        {
            var entities = _unitOfWork.SundayServeRepository.GetAll()
                .Where(x => x.SundayServeDateTime.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<SundayServeViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                };
                var model = new SundayServeDetails();
                model.SundayServeSpeaker = list.Where(x => x.SundayServeDutyName == "讲员").FirstOrDefault();
                model.SundayServeChairmen = list.Where(x => x.SundayServeDutyName == "主席").FirstOrDefault();
                model.SundayServeWorshipLeadName = list.Where(x => x.SundayServeDutyName == "领诗").FirstOrDefault();
                model.SundayServeWorshipName = list.Where(x => x.SundayServeDutyName == "敬拜").FirstOrDefault();
                model.SundayServePrayName = list.Where(x => x.SundayServeDutyName == "祷告").FirstOrDefault();
                model.SundayServePanio = list.Where(x => x.SundayServeDutyName == "司琴").FirstOrDefault();
                model.SundayServeSound = list.Where(x => x.SundayServeDutyName == "音响").FirstOrDefault();
                model.SundayServeSecretary = list.Where(x => x.SundayServeDutyName == "司事").FirstOrDefault();
                model.SundayServeLogistics = list.Where(x => x.SundayServeDutyName == "后勤").FirstOrDefault();
                model.SundayServeAccounting = list.Where(x => x.SundayServeDutyName == "财务").FirstOrDefault();
                model.SundayServeChildTeacher = list.Where(x => x.SundayServeDutyName == "儿主").FirstOrDefault();
                model.SundayServeTeenTeacher = list.Where(x => x.SundayServeDutyName == "青少").FirstOrDefault();
                model.SundayServeNewPerson = list.Where(x => x.SundayServeDutyName == "新人").FirstOrDefault();
                return model;
            }
            else
            {
                return new SundayServeDetails();
            };
        }
        public static SundayServeListViewModel GetSundayServeList(DateTime sundayDate)
        {
            var entities = _unitOfWork.SundayServeRepository.GetAll()
                .Where(x => x.SundayServeDateTime.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<SundayServeViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                };
                return new SundayServeListViewModel { SundayServeList = list };
            }
            else
            {
                return new SundayServeListViewModel();
            };
        }

        public static WorshipSongServeListViewModel GetWorshipSongServeList(DateTime sundayDate)
        {
            var entities = _unitOfWork.WorshipSongServeRepository.GetAll()
                .Where(x => x.WorshipDate.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<WorshipSongServeViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                };
                return new WorshipSongServeListViewModel { WorshipSongServeList = list };
            }
            else
            {
                return new WorshipSongServeListViewModel();
            };
        }
        //public static WorkFlowViewModel GetWorkFlow(DateTime sundayDate)
        //{
        //    var workFlow = new WorkFlowViewModel();
        //    var entity = _unitOfWork.WorkFlowRepository.GetAll()
        //        .Where(x => x.SundayDate.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
        //        .FirstOrDefault();
        //    workFlow = entity.LoadDTO();
        //    var worshipSongServes = _unitOfWork.WorshipSongServeRepository.GetAll()
        //        .Where(x => x.WorshipDate.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
        //        .ToList();
        //    var worshipSongServeList = new List<WorshipSongServeViewModel>();
        //    if (worshipSongServes != null && worshipSongServes.Count() > 0)
        //    {
        //        foreach (var item in worshipSongServes)
        //        {
        //            var model = item.LoadDTO();
        //            model.Lyrics = new List<WorshipSongLyricsViewModel>();
        //            worshipSongServeList.Add(item.LoadDTO());
        //        };
        //        workFlow.WorshipSongs = worshipSongServeList;
        //    }
        //    else
        //    {
        //        workFlow.WorshipSongs = new List<WorshipSongServeViewModel>();
        //    };
        //    return workFlow;
        //}

        public static List<PrayMatterViewModel> GetPrayMatters(DateTime prayMattersDate)
        {
            var entities = _unitOfWork.PrayMatterRepository.GetAll()
                .Where(x => x.PrayMatterDate.ToString("yyyyMMdd") == prayMattersDate.ToString("yyyyMMdd"))
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<PrayMatterViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<PrayMatterViewModel>();
            };
        }

        public static List<TeamViewModel> GetTeams()
        {
            var entities = _unitOfWork.TeamRepository.GetAll().ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<TeamViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<TeamViewModel>();
            };
        }

        public static List<GroupMeetingViewModel> GetGroupMeetings(DateTime sundayReportDate)
        {
            var entities = _unitOfWork.GroupMeetingRepository.GetAll()
                            .Where(x => x.GroupMeetingSundayReportDate.ToString("yyyyMMdd") == sundayReportDate.ToString("yyyyMMdd"))
                            .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<GroupMeetingViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<GroupMeetingViewModel>();
            };
        }

        public static List<DonateViewModel> GetDonates(DateTime sundayReportDate)
        {
            var lastSunday = sundayReportDate.AddDays(-7);
            var entities = _unitOfWork.DonateRepository.GetAll()
                .Where(x => x.DonateDate.ToString("yyyyMMdd") == lastSunday.ToString("yyyyMMdd"))
                .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<DonateViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<DonateViewModel>();
            };
        }

        public static MonthlyDonateViewModel GetMonthlyDonate()
        {
            var lastSunday = _sundayReportDate.AddDays(-7);
            var entities = _unitOfWork.DonateRepository.GetAll()
                           .Where(x => x.DonateDate.ToString("yyyyMM") == lastSunday.ToString("yyyyMM") && x.DonateDate <= lastSunday)
                           .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<DonateViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                var model = new MonthlyDonateViewModel();
                model.MonthlyRegularDonate = list.Where(x => x.DonateType == "常費").Sum(y => y.DonateNumber);
                model.MonthlyBuildChurchDonate = list.Where(x => x.DonateType == "建堂").Sum(y => y.DonateNumber);
                model.MonthlySpreadDonate = list.Where(x => x.DonateType == "差傳").Sum(y => y.DonateNumber);
                model.MonthlyHuanHuanDonate = list.Where(x => x.DonateType == "歡歡").Sum(y => y.DonateNumber);
                model.MonthlyThankGivingDonate = list.Where(x => x.DonateType == "感恩").Sum(y => y.DonateNumber);
                model.MonthlyOtherDonate = list.Where(x => x.DonateType == "其他").Sum(y => y.DonateNumber);
                return model;
            }
            else
            {
                return new MonthlyDonateViewModel();
            };
        }

        public static List<SundayServeViewModel> GetSundayServe()
        {
            var entities = _unitOfWork.SundayServeRepository.GetAll()
                            .Where(x => x.SundayServeDateTime.ToString("yyyyMMdd") == _sundayReportDate.ToString("yyyyMMdd"))
                            .ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<SundayServeViewModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<SundayServeViewModel>();
            };
        }

        public static SpiritualEssayViewModel GetSpiritualEssay(DateTime sundayDate)
        {
            var entity = _unitOfWork.SpiritualEssayRepository.GetAll()
                .Where(x => x.SpiritualEssaySunday.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
                .FirstOrDefault();
            if (entity != null)
            {
                return entity.LoadDTO();
            }
            else
            {
                return new SpiritualEssayViewModel()
                {
                    SpiritualEssaySunday = sundayDate
                };
            };
        }

        public static WorkFlowViewModel GetWorkFlow(DateTime sundayDate)
        {
            var entity = _unitOfWork.WorkFlowRepository.GetAll()
                .Where(x => x.SundayDate.ToString("yyyyMMdd") == sundayDate.ToString("yyyyMMdd"))
                .FirstOrDefault();
            if (entity != null)
            {
                return entity.LoadDTO();
            }
            else
            {
                return new WorkFlowViewModel()
                {
                    SundayDate = sundayDate
                };
            };
        }


        public static List<SermonViewModel> GetSermonViewModels(DateTime sundayDate)
        {
            var sermonViewModels = new List<SermonViewModel>();
            var entities = _unitOfWork.WorkFlowRepository.GetAll()
                            .Where(x => x.SundayDate <= sundayDate
                            && !string.IsNullOrWhiteSpace(x.SermonAudioUrl))
                            .OrderByDescending(x => x.SundayDate).Take(5);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    sermonViewModels.Add(
                        new SermonViewModel()
                        {
                            SermonTitle = entity.SermonTitle,
                            SermonSpeaker = entity.SermonSpeaker,
                            BibleReading = entity.BibleReading,
                            SermonDetails = string.IsNullOrWhiteSpace(entity.SermonDetails) ? new List<string>() : entity.SermonDetails.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList(),
                            AudioUrl = entity.SermonAudioUrl,
                            SundayDate = entity.SundayDate
                        }
                    );
                }
            };
            return sermonViewModels;
        }


        #endregion


        #region
        public static List<CallChaptorDetail> GetCallChaptorDetails()
        {
            return new List<CallChaptorDetail>();
            //var entities = _unitOfWork.CallChaptorRepository.GetAll().Where(x => x.CallChaptorId < 100);
            //if (entities != null && entities.Count() > 0)
            //{
            //    var list = new List<CallChaptorDetail>();
            //    foreach (var item in entities)
            //    {
            //        list.Add(item.LoadDTO());
            //    }
            //    return list;
            //}
            //else
            //{
            //    return new List<CallChaptorDetail>();
            //};
        }

        public static List<string> GetCallChaptors()
        {
            var callChaptorList = GetCallChaptorDetails();
            var list = new List<string>();
            foreach (var item in callChaptorList)
            {
                list.Add(item.CallChaptor);
            };
            return list;
        }


        public static List<DonateBibleChaptorModel> GetDonateBibleChaptorDetails()
        {
            var entities = _unitOfWork.DonateBibleChaptorRepository.GetAll().ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<DonateBibleChaptorModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<DonateBibleChaptorModel>();
            };
        }

        public static List<string> GetDonateBibleChaptors()
        {
            var list = new List<string>();
            /*            var donateList = GetDonateBibleChaptorDetails();

                        foreach (var item in donateList)
                        {
                            list.Add(item.Chaptor);
                        };*/
            return list;
        }

        public static List<BibleChaptorModel> GetBibleChaptorDetails()
        {
            var entities = _unitOfWork.BibleChaptorRepository.GetAll().ToList();
            if (entities != null && entities.Count() > 0)
            {
                var list = new List<BibleChaptorModel>();
                foreach (var item in entities)
                {
                    list.Add(item.LoadDTO());
                }
                return list;
            }
            else
            {
                return new List<BibleChaptorModel>();
            };
        }

        public static List<string> GetBibleChaptorFullNames()
        {
            var bibleChaptorList = GetBibleChaptorDetails();
            var list = new List<string>();
            foreach (var item in bibleChaptorList)
            {
                list.Add(item.FullName);
            };
            return list;
        }

        public static List<string> GetBibleChaptorShortNames()
        {
            var bibleChaptorList = GetBibleChaptorDetails();
            var list = new List<string>();
            foreach (var item in bibleChaptorList)
            {
                list.Add(item.ShortName);
            };
            return list;
        }

        public static string GetBibleChaptorShortNameById(int id)
        {
            var entity = _unitOfWork.BibleChaptorRepository.GetAll()
                .Where(x => x.BibleChaptorId == id).FirstOrDefault();
            return entity == null ? "" : entity.ShortName;
        }

        public static List<UserProfileModel> GetWorkerByType(int workType)
        {
            var userProfiles = (workType == 0)
                ? _unitOfWork.UserProfileRepository.GetAll()
                : _unitOfWork.UserProfileRepository.GetAll()
                    .Where(m => m.WorkerType == workType)
                    .ToList();
            var list = new List<UserProfileModel>();
            foreach (var item in userProfiles)
            {
                list.Add(item.LoadDTO());
            };
            return list;
        }

        public static string GetBibleReadingContent(BibleDetail bibleDetailFrom, BibleDetail bibleDetailTo)
        {
            var entities = _unitOfWork.BibleChaptorDetailRepository.GetAll()
                .Where(x =>
                  x.VolumeSN >= bibleDetailFrom.VolumeSN && x.ChapterSN >= bibleDetailFrom.ChapterSN && x.VerseSN >= bibleDetailFrom.VerseSN
               && x.VolumeSN <= bibleDetailTo.VolumeSN && x.ChapterSN <= bibleDetailTo.ChapterSN && x.VerseSN <= bibleDetailTo.VerseSN)
                .Select(y => y.VerseSN + y.Lection + " ")
                .ToList();

            if (entities != null && entities.Count() > 0)
            {
                return string.Join("", entities);
            };
            return "";
        }
        #endregion

        #region
        public static List<string> GetSundayReportFileNames()
        {
            var entities = _unitOfWork.WorkFlowRepository.GetAll().OrderByDescending(x=>x.SundayDate).Take(10).ToList();
            var list = new List<string>();
            foreach (var item in entities)
            {
                list.Add(item.SundayDate.ToString("yyyyMMdd"));
            };
            return list;
        }
        #endregion

        #region
        public static List<DAL.Models.BibleChaptorDetail> GetBibleAllLections()
        {
            return _unitOfWork.BibleChaptorDetailRepository.GetAll().ToList();
        }
        public static List<DAL.Models.BibleChaptor> GetBibleAllChaptors()
        {
            return _unitOfWork.BibleChaptorRepository.GetAll().ToList();
        }
        #endregion
    }
}
