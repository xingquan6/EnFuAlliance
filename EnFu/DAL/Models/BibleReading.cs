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
    [Table("BibleReading")]
    public class BibleReading
    {
        public BibleReading() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BibleReadingId { get; set; }
        public string BibleReadingChaptor { get; set; }
        public DateTime BibleReadingDateTime { get; set; }
        public int VolumeSN { get; set; }
        public int ChapterSN { get; set; }
        public int VerseSNFrom { get; set; }
        public int VerseSNTo { get; set; }
        public string Url { get; set; }
        public string Audio { get; set; }


        // for the everyday bible enfu and cai
        public string Youtube { get; set; }
        public string AudioEnfu { get; set; }
        public string VideoEnfu { get; set; }
        public string AudioCai { get; set; }
        public string BibleUrl { get; set; }

    }
}