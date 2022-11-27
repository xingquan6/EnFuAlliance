using EnFu.DAL;
using EnFu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnFu.Modules
{
    public static class BibleProcesser
    {
        private static UnitOfWork _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static BibleProcesser()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public static string GetBibleReadingContent(BibleDetail bibleDetailFrom, BibleDetail bibleDetailTo)
        {
            //var entities = _unitOfWork.BibleChaptorDetailRepository.GetAll()
            //    .Where(x =>
            //      x.VolumeSN >= bibleDetailFrom.VolumeSN
            //   && x.ChapterSN >= bibleDetailFrom.ChapterSN
            //   && x.VerseSN >= bibleDetailFrom.VerseSN
            //   && x.VolumeSN <= bibleDetailTo.VolumeSN
            //   && x.ChapterSN <= bibleDetailTo.ChapterSN
            //   && x.VerseSN <= bibleDetailTo.VerseSN)
            //    .Select(y => y.Lection)
            //    .ToList();
            var entities = _unitOfWork.BibleChaptorDetailRepository.GetAll()
             .Where(x =>
               x.VolumeSN == 1
            && x.ChapterSN == 1
            && x.VerseSN == 1).Select(y => y.Lection)
                .ToList(); ;

            if (entities != null && entities.Count() > 0)
            {
                return string.Join("", entities);
            };
            return "test";
        }
    }
}