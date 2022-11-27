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
    [Table("WorshipSongLyrics")]
    public class WorshipSongLyrics
    {
        public WorshipSongLyrics() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorshipSongLyricsId { get; set; }
        public int WorshipSongId { get; set; }
        public int WorshipSongLyricsOrder { get; set; }
        public string WorshipSongLyricsTitle { get; set; }
        public string WorshipSongLyricsContent { get; set; }
        public string WorshipSongLyricsContentEnglish { get; set; }
    }
}