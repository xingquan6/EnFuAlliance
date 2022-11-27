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
    [Table("Donate")]
    public class Donate
    {
        public Donate() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DonateId { get; set; }
        public string DonateType { get; set; } 
        public DateTime DonateDate { get; set; }
        public decimal DonateNumber { get; set; }

    }
}