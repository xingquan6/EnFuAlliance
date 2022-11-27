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
    [Table("SundayServe")]
    public class SundayServe
    {
        public SundayServe()
        {

        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SundayServeId { get; set; }
        [Display(Name = "服侍人员")]
        public string SundayServeName { get; set; }
        [Display(Name = "服侍类型")]
        public string SundayServeDutyName { get; set; }
        [Display(Name = "服侍时间")]
        public DateTime SundayServeDateTime { get; set; }
    }
}