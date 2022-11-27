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
    [Table("DonateBibleChaptor")]
    public class DonateBibleChaptor
    {
        public DonateBibleChaptor() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DonateBibleChaptorId { get; set; }
        public string Chaptor { get; set; }
        public string ChaptorDetail { get; set; }
        public bool IsActive { get; set; }

        public int SortOrder { get; set; }

    }
}