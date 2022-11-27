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
    [Table("Department")]
    public class Department
    {
        public Department() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public int? DeptLeaderUserId { get; set; }
        public int? DeptLeader2UserId { get; set; }
        public string DeptComment { get; set; }
        public bool IsActive { get; set; }
    }
}