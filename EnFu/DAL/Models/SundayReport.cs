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
    [Table("SundayReport")]
    public class SundayReport
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public int SundayReportId { get; set; }

        public DateTime SundayReportDateTime{ get; set; }

    }
}