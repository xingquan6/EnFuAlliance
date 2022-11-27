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
    [Table("WorshipSong")]
    public class WorshipSong
    {
        public WorshipSong() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorshipSongId { get; set; }

        [Display(Name = "歌曲名字")]
        public string WorshipSongName { get; set; }

        [Display(Name = "文件名字")]
        public string WorshipSongFileName { get; set; }

        [Display(Name = "声频或视频连接")]
        public string WorshipSongLink { get; set; }
        [Display(Name = "网页内部连接")]
        public string WorshipSongEmbedLink { get; set; }

    }
}