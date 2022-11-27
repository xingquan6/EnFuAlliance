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
    [Table("WorkFlow")]
    public class WorkFlow
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorkFlowId { get; set; }
        public string CallDetail { get; set; }
        public string CallChaptor { get; set; }
        public bool IsEucharist { get; set; }
        public string EucharistOperator { get; set; }
        public string BibleReading { get; set; }
        public string SermonTitle { get; set; }
        public string SermonSpeaker { get; set; }
        public string BibleWeeklyChaptor { get; set; }
        public string BibleWeeklyChaptorDetail { get; set; }
        public string DonationWeeklyChaptor { get; set; }
        public string DonationWeeklyChaptorDetail { get; set; }
        public string Blessing { get; set; }
        public bool? Witness { get; set; }
        public DateTime SundayDate { get; set; }
        public string SermonDetails { get; set; }
        public string SermonAudioUrl { get; set; }
        public string VideoLiveLink { get; set; }
        public string SermonSpeakerUrl { get; set; }
        public string SermonWorshipSong { get; set; }
        public string SermonWorshipSongAudioUrl { get; set; }

    }
}