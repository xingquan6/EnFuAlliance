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
    [Table("Story")]
    public class Story
    {
        public Story() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StoryId { get; set; }
        public string StoryName { get; set; }
        public string StoryAuthor { get; set; }
        public string StoryDesc { get; set; }
        public DateTime? StoryDateTime { get; set; }
        public string StoryComment { get; set; }
        public int? StoryType { get; set; }
        public bool IsActive { get; set; }
    }
}