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
    [Table("ChildrenClass")]
    public class ChildrenClass
    {
        public ChildrenClass() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ChildrenClassId { get; set; }
        public string ChildrenClassName { get; set; }
        public string ChildrenClassDesc { get; set; }
        public string ChildrenClassLeader { get; set; }
        public string ChildrenClassLeader2 { get; set; }
        public string ChildrenClassComment { get; set; }
        public bool IsActive { get; set; }
    }
}