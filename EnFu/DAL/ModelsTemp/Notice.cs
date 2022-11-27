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
    [Table("Notice")]
    public class Notice
    {
        public Notice() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NoticeId { get; set; }
        public string NoticeName { get; set; }
        public string NoticeDesc { get; set; }
        public DateTime? NoticeDateTime { get; set; }
        public int NoticeAuthorId { get; set; }
        public int NoticeType { get; set; }
        public string NoticeComment { get; set; }
        public bool IsActive { get; set; }
    }
}