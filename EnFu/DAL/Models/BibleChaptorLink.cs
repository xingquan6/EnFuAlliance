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
    [Table("BibleChaptorLink")]
    public class BibleChaptorLink
    {
        public BibleChaptorLink() { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BibleChaptorLinkId { get; set; }

        [Index("IX_VolumeAndChapter", 1, IsUnique = true)]
        public int VolumeSN { get; set; }

        [Index("IX_VolumeAndChapter", 2, IsUnique = true)]
        public int ChapterSN { get; set; }

        [StringLength(500)]
        public string UrlCMC { get; set; }
        [StringLength(500)]
        public string AudioCMC { get; set; }
        [StringLength(500)]
        public string AudioCai { get; set; }
        [StringLength(500)]
        public string BibleUrl { get; set; }

    }
}