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

    [Table("Visiter")]
    public class Visiter
    {
        public Visiter() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VisiterId { get; set; }
        [Display(Name = "Visiter IP")]
        public string VisiterIP { get; set; }
        [Display(Name = "Visiter Count")]
        public int VisiterCount { get; set; }

    }
}