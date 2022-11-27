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
    [Table("Event")]
    public class Event
    {
        public Event() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public DateTime EventDateTime { get; set; }
        public int EventOrder { get; set; }

    }
}