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
    [Table("NoticePerson")]
    public class NoticePerson
    {
        public NoticePerson() { }
        [Key]
        [Column(Order = 0)]
        public int NoticeId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int NoticePersonId { get; set; }
    }
}