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
    [Table("ChildrenLesson")]
    public class ChildrenLesson
    {
        public ChildrenLesson() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ChildrenLessonId { get; set; }
        public string ChildrenLessonName { get; set; }
        public string ChildrenLessonDesc { get; set; }
        public string ChildrenLessonPublisher { get; set; }
        public string ChildrenClassComment { get; set; }
        public int? ChildrenClassId { get; set; }
        public bool IsActive { get; set; }
    }
}