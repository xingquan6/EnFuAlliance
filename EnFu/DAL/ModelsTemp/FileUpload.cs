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
    [Table("FileUpload")]
    public class FileUpload
    {
        public FileUpload() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        [Display(Name = "文件名字")]
        public string FileName { get; set; }
        [Display(Name = "文件作者")]
        public string FileAuthor { get; set; }
        [Display(Name = "文件简介")]
        public string FileDesc { get; set; }
        [Display(Name = "文件发表时间(yyyy-mm-dd)")]
        public DateTime? FileDateTime { get; set; }
        [Display(Name = "文件地址")]
        public string FileLocation { get; set; }
        [Display(Name = "文件格式")]
        public int? FileFormat { get; set; }
        [Display(Name = "文件归类")]
        public int? FileCategory { get; set; }
        [Display(Name = "文件注解")]
        public string FileComment { get; set; }
        [Display(Name = "是否有效")]
        public bool? IsActive { get; set; }
    }
}