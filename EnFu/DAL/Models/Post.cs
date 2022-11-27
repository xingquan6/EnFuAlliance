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
    [Table("Post")]
    public class Post
    {
        public Post() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool isPublish { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }

    }
    [Table("PostContent")]
    public class PostContent
    {
        public PostContent() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostContentId { get; set; }
        public int PostId { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }

    }
}