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
    [Table("ChildrenBook")]
    public class ChildrenBook
    {
        public ChildrenBook() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ChildrenBookId { get; set; }
        public string ChildrenBookName { get; set; }
        public string ChildrenBookAuthor { get; set; }
        public string ChildrenBookDesc { get; set; }
        public string ChildrenBookComment { get; set; }
        public bool IsActive { get; set; }
    }
}