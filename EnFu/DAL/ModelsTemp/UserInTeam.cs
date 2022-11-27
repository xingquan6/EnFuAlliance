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
    [Table("UserInTeam")]
    public class UserInTeam
    {
        [Key, Column(Order = 0)]
        public int TeamId { get; set; }
        [Key, Column(Order = 1)]
        public int UserId { get; set; }
    }
}