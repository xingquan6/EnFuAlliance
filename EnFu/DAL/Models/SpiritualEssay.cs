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

    [Table("SpiritualEssay")]
    public class SpiritualEssay
    {
        public SpiritualEssay() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SpiritualEssayId { get; set; }
        public string SpiritualEssayTitle { get; set; }
        public string SpiritualEssayChaptor { get; set; }
        public string SpiritualEssayContent { get; set; }
        public string SpiritualEssayPray { get; set; }

        public DateTime SpiritualEssaySunday { get; set; }

    }
}