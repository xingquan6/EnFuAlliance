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
    [Table("GroupMeeting")]
    public class GroupMeeting
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GroupMeetingId { get; set; }
        public string GroupMeetingType { get; set; }
        public int GroupMeetingNumber { get; set; }
        public DateTime GroupMeetingSundayReportDate { get; set; }
        public int GroupType { get; set; } // 0 - 其他 1 - 小组

    }
}