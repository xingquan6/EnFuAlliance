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
    [Table("Teacher")]
    public class Teacher
    {
        public Teacher() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "老师名字")]
        public string TeacherName { get; set; }
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "老师介绍")]
        public string TeacherDesc { get; set; }
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "老师注解")]
        public string TeacherComment { get; set; }
        [Display(Name = "老师类型")]
        public int? TeacherType { get; set; }
        [Display(Name = "是否有效")]
        public bool IsActive { get; set; }
    }
}