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
    [Table("MultimediaType")]
    public class MultimediaType
    {
        public MultimediaType() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MultimediaTypeId { get; set; }
        public string MultimediaTypeName { get; set; }
        public string MultimediaTypeDesc { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}