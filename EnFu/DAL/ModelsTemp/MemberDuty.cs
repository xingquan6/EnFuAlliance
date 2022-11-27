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
    [Table("MemberDuty")]
    public class MemberDuty
    {
        public MemberDuty()
        {
            IsActive = true;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MemberDutykId { get; set; }
        public string MemberDutyName { get; set; }
        public string MemberDutyDesc { get; set; }
        public string MemberDutyComment { get; set; }
        public string MemberDutyAddress { get; set; }
        public bool IsActive { get; set; }
    }
}