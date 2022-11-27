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
    [Table("Multimedia")]
    public class Multimedia
    {
        public Multimedia() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MultimediaId { get; set; }
        [Display(Name = "名字")]
        public string MultimediaName { get; set; }
        [Display(Name = "作者")]
        public string MultimediaAuthor { get; set; }
        [Display(Name = "简介")]
        public string MultimediaDesc { get; set; }
        [Display(Name = "时间长短（秒）")]
        public int? MultimediaDuration { get; set; }
        [Display(Name = "发表时间(yyyy-mm-dd)")]
        public DateTime? MultimediaPublishDate { get; set; }
        [Display(Name = "声频或视频连接")]
        public string MultimediaLink { get; set; }
        [Display(Name = "网页内部连接")]
        public string MultimediaEmbedLink { get; set; }
        [Display(Name = "格式")]
        public int? MultimediaFormat { get; set; }
        [Display(Name = "类型")]
        public int MultimediaTypeId { get; set; }
        [Display(Name = "注解")]
        public string MultimediaComment { get; set; }
        [Display(Name = "歌词")]
        public string MultimediaLyrics { get; set; }
        [Display(Name = "是否有效")]
        public bool IsActive { get; set; }
    }
}