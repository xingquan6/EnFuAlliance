using EnFu.Models;
using EnFu.Modules;
using Newtonsoft.Json;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace EnFu.Controllers
{
    //[Authorize]
    public class DocumentController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            //object d = 10;
            //int k = (int)d + 10;
            //var result = GetBibleAllLections();
            //var result = GetBibleAllChaptors();
            return View();
        }
        #endregion

        #region Varibles
        //private List<CallChaptorDetail> CallChaptorDetails = EnFu.Modules.DataProcesser.GetCallChaptorDetails();
        //private List<DonateBibleChaptorModel> DonateBibleChaptorDetails = EnFu.Modules.DataProcesser.GetDonateBibleChaptorDetails();
        //private List<BibleChaptorModel> BibleChaptorModels = EnFu.Modules.DataProcesser.GetBibleChaptorDetails();
        //public string CallChaptorDetail(string callChaptor)
        //{
        //    return CallChaptorDetails
        //            .Where(x => x.CallChaptor == callChaptor)
        //            .FirstOrDefault().CallDetail;
        //}

        //public string DonateBibleChaptorDetail(string chaptor)
        //{
        //    return DonateBibleChaptorDetails
        //            .Where(x => x.Chaptor == chaptor)
        //            .FirstOrDefault().ChaptorDetail;
        //}
        #endregion

        #region WorkFlow

        public ActionResult WorkFlow()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.WorkFlow
                }
           );
        }
        [HttpPost]
        public ActionResult WorkFlow(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("WorkFlowDetails", model);
            }
            return View();
        }

        public ActionResult WorkFlowDetails(SearchViewModel searchModel)
        {
            var model = DataProcesser.GetWorkFlow(DateTime.Parse(searchModel.SundayReportDate));
            if (model == null || model.WorkFlowId == 0) 
            {
                model = new WorkFlowViewModel();
                DataProcesser.CreateWorkFlowFromLastSunday(DateTime.Parse(searchModel.SundayReportDate).AddDays(-7));
                model = DataProcesser.GetWorkFlow(DateTime.Parse(searchModel.SundayReportDate));
            };
            //model.WorshipSongs.Add(new WorshipSongServeViewModel());
            model.SundayDate = DateTime.Parse(searchModel.SundayReportDate);
            return View(model);
        }
        [HttpPost]
        public ActionResult WorkFlowDetails(WorkFlowViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateWorkFlow(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }

        #endregion

        #region Event
        public ActionResult Event()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.Event
                }
           );
        }
        [HttpPost]
        public ActionResult Event(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("EventDetails", model);
            }
            return View();
        }
        public ActionResult EventDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var eventList = DataProcesser.GetEvents(DateTime.Parse(model.SundayReportDate));
                int eventsLength = eventList.Count;
                if (eventList.Count == 0)
                {
                    DataProcesser.CreateEventsFromLastSunday(DateTime.Parse(model.SundayReportDate).AddDays(-7));
                    eventList = DataProcesser.GetEvents(DateTime.Parse(model.SundayReportDate));
                }
                for (int i = 0; i < (10 - eventsLength); i++)
                {
                    eventList.Add(new EventViewModel());
                }
                return View(new EventListViewModel() { EventList = eventList });
            }
            return View();
        }
        [HttpPost]
        public ActionResult EventDetails(EventListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateEvents(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }
        #endregion event

        #region PrayMatter
        public ActionResult PrayMatter()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.PrayMatter
                }
           );
        }
        [HttpPost]
        public ActionResult PrayMatter(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PrayMatterDetails", model);
            }
            return View();
        }
        public ActionResult PrayMatterDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var prayMatterList = DataProcesser.GetPrayMatters(DateTime.Parse(model.SundayReportDate));
                int prayMatterLength = prayMatterList.Count;
                if (prayMatterList.Count == 0)
                {
                    DataProcesser.CreatePrayMatterFromLastSunday(DateTime.Parse(model.SundayReportDate).AddDays(-7));
                    prayMatterList = DataProcesser.GetPrayMatters(DateTime.Parse(model.SundayReportDate));
                }
                for (int i = 0; i < (10 - prayMatterLength); i++)
                {
                    prayMatterList.Add(new PrayMatterViewModel());
                }
                return View(new PrayMatterListViewModel() { PrayMatterList = prayMatterList });
            }
            return View();
        }
        [HttpPost]
        public ActionResult PrayMatterDetails(PrayMatterListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdatePrayMatters(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }

        #endregion PrayMatter

        #region GroupMeeting

        public ActionResult GroupMeeting()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.GroupMeeting
                }
           );
        }
        [HttpPost]
        public ActionResult GroupMeeting(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("GroupMeetingDetails", model);
            }
            return View();
        }
        public ActionResult GroupMeetingDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var groupMeetingList = DataProcesser.GetGroupMeetings(DateTime.Parse(model.SundayReportDate));
                if (groupMeetingList.Count == 0)
                {
                    DataProcesser.CreateGroupMeetingFromLastSunday(DateTime.Parse(model.SundayReportDate).AddDays(-7));
                    groupMeetingList = DataProcesser.GetGroupMeetings(DateTime.Parse(model.SundayReportDate));
                }
                return View(new GroupMeetingListViewModel() { GroupMeetingList = groupMeetingList });
            }
            return View(new GroupMeetingListViewModel());
        }
        [HttpPost]
        public ActionResult GroupMeetingDetails(GroupMeetingListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateGroupMeetings(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }
        #endregion GroupMeeting

        #region Donate
        public ActionResult Donate()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.Donate
                }
           );
        }
        [HttpPost]
        public ActionResult Donate(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DonateDetails", model);
            }
            return View();
        }
        public ActionResult DonateDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var donateList = DataProcesser.GetDonates(DateTime.Parse(model.SundayReportDate));
                if (donateList.Count == 0)
                {
                    DataProcesser.CreateDonates(DateTime.Parse(model.SundayReportDate).AddDays(-7));
                    donateList = DataProcesser.GetDonates(DateTime.Parse(model.SundayReportDate));
                }
                return View(new DonateListViewModel() { DonateList = donateList } );
            }
            return View(new DonateListViewModel());
        }
        [HttpPost]
        public ActionResult DonateDetails(DonateListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateDonates(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }
        #endregion

        #region SpiritualEssay
        public ActionResult SpiritualEssay()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.SpiritualEssay
                }
           );
        }
        [HttpPost]
        public ActionResult SpiritualEssay(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SpiritualEssayDetails", model);
            }
            return View();
        }
        public ActionResult SpiritualEssayDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var spiritualEssay = DataProcesser.GetSpiritualEssay(DateTime.Parse(model.SundayReportDate));
                return View(spiritualEssay);
            }
            return View(new SpiritualEssayViewModel());
        }
        [HttpPost]
        public ActionResult SpiritualEssayDetails(SpiritualEssayViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateSpiritualEssay(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }
        #endregion

        #region SundayServe
        public ActionResult SundayServe()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.SundayServe
                }
           );
        }
        [HttpPost]
        public ActionResult SundayServe(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SundayServeDetails", model);
            }
            return View();
        }
        public ActionResult SundayServeDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sundayServes = DataProcesser.GetSundayServeList(DateTime.Parse(model.SundayReportDate));
                var sundayServeListViewModel = new SundayServeListViewModel() { SundayServeList = new List<SundayServeViewModel>() };
                if (sundayServes == null || sundayServes.SundayServeList == null || sundayServes.SundayServeList.Count == 0)
                {
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName= "讲员", SundayServeDateTime=DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "主席", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "祷告", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "领诗", SundayServeDateTime=DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "敬拜", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "司琴", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "音响", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "司事", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "后勤", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "财务", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "儿主", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "青少", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                    sundayServeListViewModel.SundayServeList.Add(new SundayServeViewModel() { SundayServeDutyName = "新人", SundayServeDateTime = DateTime.Parse(model.SundayReportDate) });
                }
                else
                {
                    return View(sundayServes);
                }
                return View(sundayServeListViewModel);
            }
            return View(new SundayServeListViewModel());
        }
        [HttpPost]
        public ActionResult SundayServeDetails(SundayServeListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateSundayServeList(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }


        #endregion

        #region SundayServe
        public ActionResult WorshipSongServe()
        {
            return View(
                new SearchViewModel()
                {
                    SearchType = SearchType.WorshipSongServe
                }
           );
        }
        [HttpPost]
        public ActionResult WorshipSongServe(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("WorshipSongServeDetails", model);
            }
            return View();
        }
        public ActionResult WorshipSongServeDetails(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var worshipSongServes = DataProcesser.GetWorshipSongServeList(DateTime.Parse(model.SundayReportDate));
                var worshipSongServeListViewModel = new WorshipSongServeListViewModel() {  WorshipSongServeList = new List<WorshipSongServeViewModel>() };
                if (worshipSongServes == null || worshipSongServes.WorshipSongServeList == null || worshipSongServes.WorshipSongServeList.Count == 0)
                {
                    DataProcesser.CreateWorshipSongServeFromLastSunday(DateTime.Parse(model.SundayReportDate).AddDays(-7));
                    worshipSongServeListViewModel = DataProcesser.GetWorshipSongServeList(DateTime.Parse(model.SundayReportDate));
                    //worshipSongServeListViewModel.WorshipSongServeList.Add(new WorshipSongServeViewModel() { Name="", Url= "", WorshipDate = DateTime.Parse(model.SundayReportDate) });
                    //worshipSongServeListViewModel.WorshipSongServeList.Add(new WorshipSongServeViewModel() { Name = "", Url = "", WorshipDate = DateTime.Parse(model.SundayReportDate) });
                    //worshipSongServeListViewModel.WorshipSongServeList.Add(new WorshipSongServeViewModel() { Name = "", Url = "", WorshipDate = DateTime.Parse(model.SundayReportDate) });
                    //worshipSongServeListViewModel.WorshipSongServeList.Add(new WorshipSongServeViewModel() { Name = "", Url = "", WorshipDate = DateTime.Parse(model.SundayReportDate) });
                }
                else
                {
                    return View(worshipSongServes);
                }
                return View(worshipSongServeListViewModel);
            }
            return View(new SundayServeListViewModel());
        }
        [HttpPost]
        public ActionResult WorshipSongServeDetails(WorshipSongServeListViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataProcesser.UpdateWorshipSongServeList(model);
                return RedirectToAction("SaveSuccess");
            }
            return RedirectToAction("SaveError");
        }


        #endregion

        #region Save
        public ActionResult SaveSuccess()
        {
            return View();
        }

        public ActionResult SaveError()
        {
            return View();
        }

        #endregion

        #region Download
        public ActionResult Download()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download(DownloadDocumentViewModel model)
        {
            DataProcesser.Init(DateTime.Parse(model.SundayDate));
            SundayReportPdfViewModel pdfViewModel = DataProcesser.GetData();
            string templateName =
                (model.Type == 1) ? "~/Views/Document/PdfMobileExport.cshtml"
               : (model.Type == 2) ? "~/Views/Document/PdfMobileExport.cshtml"
               : (model.Type == 3) ? "~/Views/Document/PdfMobileExportSpecialEvent.cshtml"
               : (model.Type == 4) ? "~/Views/Document/PdfMobileExportTemplate.cshtml"
               : "~/Views/Document/PrintWorshipExport.cshtml";
            string html = RenderViewToString(ControllerContext, templateName, pdfViewModel, true);
            TempData["RenderedHtml"] = html;
            return RedirectToAction("DownloadDetail");
            //return View(model);
        }

        public ActionResult DownloadDetail()
        {
            var html = TempData["RenderedHtml"] as string;
            var model = new RenderDocumentViewModel();
            model.Content = html;
            return View(model);
        }

        static string RenderViewToString(ControllerContext context,
                                    string viewPath,
                                    object model = null,
                                    bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view,
                                            context.Controller.ViewData,
                                            context.Controller.TempData,
                                            sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }

        public ActionResult DownloadPdf()
        {
            return View();
        }        

        [HttpPost]
        public FileResult DownloadPdf(DownloadDocumentViewModel model)
        {
            string fileName =
                (model.Type == 1) ? model.SundayDate.Replace("/", "").Replace("-", "") + "手机版.pdf"
               : (model.Type == 2) ? model.SundayDate.Replace("/", "") + "Print.pdf"
               : model.SundayDate.Replace("/", "") + "Worship.pdf";
            MemoryStream stream = GetPdfStream(DateTime.Parse(model.SundayDate), model.Type);
            return File(stream, "application/pdf", fileName);
        }
        private MemoryStream GetPdfStream(DateTime sundayDate, int pdfType)
        {
            DataProcesser.Init(sundayDate);
            SundayReportPdfViewModel model = DataProcesser.GetData();
            return CreatePDFDocument(model, pdfType);
        }

        private MemoryStream CreateHtmlDocument(SundayReportPdfViewModel model, int pdfType)
        {
            var header = "";
            var content = RenderView(ControllerContext,
                (pdfType == 1) ? "PdfPrintExport"
                : (pdfType == 2) ? "PdfMobileExport"
                : (pdfType == 3) ? "PdfMobileExportSpecialEvent"
                : (pdfType == 4) ? "PdfMobileExportTemplate"
                : "PdfWorshipExport", model);
            var footer = "";

            var htmlToPdf = new HtmlToPdfConverter { PageHeaderHtml = header, PageFooterHtml = footer };

            if (pdfType == 1)
            {
                htmlToPdf.PageWidth = 356;
                htmlToPdf.PageHeight = 216;
            }
            else
            if (pdfType == 2)
            {
                htmlToPdf.PageWidth = 216;
                htmlToPdf.PageHeight = 2400;
            }
            else
            {
                htmlToPdf.PageWidth = 254;
                htmlToPdf.PageHeight = 191;
            };
            htmlToPdf.Margins = new PageMargins { Top = 0, Bottom = 0, Left = 0, Right = 0 };
            htmlToPdf.CustomWkHtmlArgs = "--header-spacing -30 --footer-spacing -30";
            var contentByte = htmlToPdf.GeneratePdf(content, null);
            MemoryStream pdfStream = new MemoryStream(contentByte);
            pdfStream.Flush(); //Always catches me out
            pdfStream.Position = 0; //Not sure if this is required
            return pdfStream;
        }
        private MemoryStream CreatePDFDocument(SundayReportPdfViewModel model, int pdfType)
        {
            var content = RenderView(ControllerContext,
                (pdfType == 1) ? "PdfMobileExport"
                : (pdfType == 2) ? "PdfPrintExport"
                : (pdfType == 3) ? "PdfMobileExportSpecialEvent"
                : (pdfType == 4) ? "PdfMobileExportTemplate"
                : "PdfWorshipExport", model);
            var htmlToPdf = new HtmlToPdfConverter { PageHeaderHtml = "", PageFooterHtml = "" };
            switch (pdfType)
            {
                case 1: htmlToPdf.PageWidth = 41;htmlToPdf.PageHeight = 1450;break;
                case 2: htmlToPdf.PageWidth = 356; htmlToPdf.PageHeight = 216; break;
                case 3: htmlToPdf.PageWidth = 216; htmlToPdf.PageHeight = 2800; break;
                case 4: htmlToPdf.PageWidth = 254; htmlToPdf.PageHeight = 191; break;
                default: htmlToPdf.PageWidth = 55; htmlToPdf.PageHeight = 2800; break;
            };            
            htmlToPdf.Margins = new PageMargins { Top = 0, Bottom = 0, Left = 0, Right = 0 };
            htmlToPdf.CustomWkHtmlArgs = "--header-spacing -30 --footer-spacing -30";
            var contentByte = htmlToPdf.GeneratePdf(content, null);
            MemoryStream pdfStream = new MemoryStream(contentByte);
            pdfStream.Flush(); //Always catches me out
            pdfStream.Position = 0; //Not sure if this is required
            return pdfStream;
        }

        private string RenderView(ControllerContext controller, string view, object model)
        {
            if (string.IsNullOrEmpty(view)) view = controller.RouteData.GetRequiredString("action");

            ViewDataDictionary data = new ViewDataDictionary(model);

            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult result = ViewEngines.Engines.FindPartialView(controller, view);
                ViewContext context = new ViewContext(controller, result.View, data, new TempDataDictionary(), writer);
                result.View.Render(context, writer);
                var htmlString = writer.GetStringBuilder().ToString();
                return writer.GetStringBuilder().ToString();
            }
        }
        #endregion

        #region BibleReading Pdf 
        [HttpPost]
        public FileResult DownloadBiblePdf(DownloadDocumentViewModel model)
        {
            string fileName = model.SundayDate+"-恩福每日读经.pdf";
            MemoryStream stream = GetBibleReadingPdfStream(model);
            return File(stream, "application/pdf", fileName);
        }
        private MemoryStream GetBibleReadingPdfStream(DownloadDocumentViewModel downloadDocumentViewModel)
        {
            DataProcesser.Init(DateTime.Parse(downloadDocumentViewModel.SundayDate));
            BibleReadingPdfViewModel model = DataProcesser.GetBibleReadingData(downloadDocumentViewModel);
            return CreateBibleReadingPdfDocument(model);
        }
        private MemoryStream CreateBibleReadingPdfDocument(BibleReadingPdfViewModel model)
        {
            var header = "";
            var content = RenderView(ControllerContext, "PdfBibleReading2023", model);
            var footer = "";

            var htmlToPdf = new HtmlToPdfConverter { PageHeaderHtml = header, PageFooterHtml = footer };

            htmlToPdf.PageWidth = 216;
            htmlToPdf.PageHeight = 700;
            htmlToPdf.Margins = new PageMargins { Top = 0, Bottom = 0, Left = 0, Right = 0 };
            htmlToPdf.CustomWkHtmlArgs = "--header-spacing -30 --footer-spacing -30";
            var contentByte = htmlToPdf.GeneratePdf(content, null);
            MemoryStream pdfStream = new MemoryStream(contentByte);
            pdfStream.Flush(); //Always catches me out
            pdfStream.Position = 0; //Not sure if this is required
            return pdfStream;
        }

        [HttpPost]
        public FileResult DownloadBibleMonthPdf(DownloadDocumentViewModel model)
        {
            string fileName = model.SundayDate + ".html";
            MemoryStream stream = GetBibleReadingMonthPdfStream(model);
            return File(stream, "application/pdf", fileName);
        }
        private MemoryStream GetBibleReadingMonthPdfStream(DownloadDocumentViewModel downloadDocumentViewModel)
        {
            DataProcesser.Init(DateTime.Parse(downloadDocumentViewModel.SundayDate));
            List<BibleReadingPdfViewModel> models = DataProcesser.GetBibleReadingMonthData(downloadDocumentViewModel);
            return CreateBibleReadingMonthPdfDocument(models);
        }
        private MemoryStream CreateBibleReadingMonthPdfDocument(List<BibleReadingPdfViewModel> models)
        {
            var content = RenderView(ControllerContext, "PdfBibleReadingMonth", models);
            var contentByte = System.Text.Encoding.UTF8.GetBytes(content);
            MemoryStream pdfStream = new MemoryStream(contentByte);
            pdfStream.Flush(); //Always catches me out
            pdfStream.Position = 0; //Not sure if this is required
            return pdfStream;
        }
        #endregion


        #region CreateBibleJson
        public string GetBibleAllLections()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(DataProcesser.GetBibleAllLections());
            return result;
        }
        public string GetBibleAllChaptors()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(DataProcesser.GetBibleAllChaptors());
            return result;
        }
        #endregion
    }
}
