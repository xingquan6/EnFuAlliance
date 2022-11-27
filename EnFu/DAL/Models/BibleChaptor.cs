using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace EnFu.DAL.Models
{
    [Table("BibleChaptor")]
    public class BibleChaptor
    {
        public BibleChaptor() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
}