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
    [Table("PrayMatter")]
    public class PrayMatter
    {
        public PrayMatter() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PrayMatterId { get; set; }
        public string PrayMatterDesc { get; set; }
        public DateTime PrayMatterDate { get; set; }
    }
}