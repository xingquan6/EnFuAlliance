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
    [Table("WorshipSongServe")]
    public class WorshipSongServe
    {
        public WorshipSongServe() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorshipSongServeId { get; set; }
        [Display(Name = "日期")]
        public int WorshipSongId { get; set; }
        [Display(Name = "日期")]
        public DateTime WorshipDate { get; set; }
        [Display(Name = "名字")]
        public string WorshipSongName { get; set; }
        [Display(Name = "网络链接")]
        public string WorshipSongUrl { get; set; }

    }
}