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
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "名")]
        public string FirstName { get; set; }
        [Display(Name = "姓")]
        public string LastName { get; set; }
        [Display(Name = "简称")]
        public string ShortName { get; set; }
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }
        [Display(Name = "性别")]
        public bool Gender { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }
        [Display(Name = "电话")]
        public string Phone { get; set; }
        [Display(Name = "手机")]
        public string CellPhone { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "同工类型")]
        public int WorkerType { get; set; }
        [Display(Name = "是否受洗")]
        public bool IsBaptism { get; set; }
    }
}