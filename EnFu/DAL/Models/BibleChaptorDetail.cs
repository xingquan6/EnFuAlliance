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
    [Table("BibleChaptorDetail")]
    public class BibleChaptorDetail
    {
        public BibleChaptorDetail() { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BibleChaptorDetailId { get; set; }

        [Index("IX_VolumeAndChapterAndVerse", 1, IsUnique = true)]
        public int VolumeSN { get; set; }

        [Index("IX_VolumeAndChapterAndVerse", 2, IsUnique = true)]
        public int ChapterSN { get; set; }

        [Index("IX_VolumeAndChapterAndVerse", 3, IsUnique = true)]
        public int VerseSN { get; set; }

        [StringLength(500)]
        public string Lection { get; set; }

        [StringLength(500)]
        public string LectionEnglish { get; set; }

    }
}