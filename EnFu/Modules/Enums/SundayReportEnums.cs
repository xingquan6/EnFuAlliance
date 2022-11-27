using EnFu.Helpers;
using System;
using System.Collections.Generic;

namespace EnFu.Modules.Enums
{
    public static class SundayReportConst
    {
        public static List<string> GetSundayList()
        {
            var list = new List<string>();
            var initial = DateTime.Now.CurrentSunday().AddDays(-28).ToString("yyyy-MM-dd");
            for (int i = 0; i < 40; i++)
            {
                list.Add(DateTime.Parse(initial).AddDays(i * 7).ToString("yyyy-MM-dd"));
            };
            return list;
        }
        public static List<ReportType> GetReportTypes()
        {
            return new List<ReportType>()
            {
                new ReportType()
                {
                    Value = 1,
                    Text = "手机版"
                },
                new ReportType()
                {
                    Value = 2,
                    Text = "打印版"
                },
                new ReportType()
                {
                    Value = 3,
                    Text = "特别版"
                },
                new ReportType()
                {
                    Value = 4,
                    Text = "模版"
                },
                new ReportType()
                {
                    Value = 5,
                    Text = "崇拜版"
                }
            };
        }
        public static List<ReportType> GetVerseSNs()
        {
            return new List<ReportType>()
            {
                new ReportType()
                {
                    Value = 0,
                    Text = "不选择节数"
                },
                new ReportType()
                {
                    Value = 1,
                    Text = "选择节数"
                }
            };
        }
        public static List<string> GetSundayServeDutyNameList()
        {
            return new List<string>()
            {
                "讲员",
                "主席",
                "领诗",
                "司琴",
                "音响",
                "司事",
                "后勤",
                "财务",
                "儿主",
                "青少",
                "新人"
            };
        }

    }

    public static class BibleReadingConst
    {
        public static List<string> GetDateList()
        {
            var list = new List<string>();
            var initial = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            for (int i = 0; i < 400; i++)
            {
                list.Add(DateTime.Parse(initial).AddDays(i).ToString("yyyy-MM-dd"));
            };
            return list;
        }
        public static List<string> GetYearMonthList()
        {
            var list = new List<string>();
            var initial = DateTime.Now.CurrentSunday().AddMonths(-3).ToString("yyyy-MM");
            for (int i = 0; i < 40; i++)
            {
                list.Add(DateTime.Parse(initial).AddMonths(i).ToString("yyyy-MM"));
            };
            return list;
        }
    }


    public class ReportType
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}