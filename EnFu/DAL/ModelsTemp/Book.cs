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
    [Table("Book")]
    public class Book
    {
        public Book()
        {
            BookQuantity = 1;
            IsActive = true;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "书籍ID")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public int BookId { get; set; }
        [Display(Name = "书名")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookName { get; set; }
        [Display(Name = "书号")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookCode { get; set; }
        [Display(Name = "作者")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookAuthor { get; set; }
        [Display(Name = "图片连接")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookPicLink { get; set; }
        [Display(Name = "出版单位")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookPublisher { get; set; }
        [Display(Name = "出版日期(YYYY-MM-DD)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BookPublishDate { get; set; }
        [Display(Name = "简介")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string BookDesc { get; set; }
        [Display(Name = "借书人")]
        public string BookBorrowerUserName { get; set; }
        public int? BookBorrowerUserId { get; set; }
        [Display(Name = "借书日期(YYYY-MM-DD)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BookBorrowDateTime { get; set; }
        [Display(Name = "书籍归类")]
        public string BookCategory { get; set; }
        public DateTime? BookEnterDateTime { get; set; }
        [Display(Name = "注解")]
        public string BookComment { get; set; }
        [Display(Name = "数量")]
        public int? BookQuantity { get; set; }
        [Display(Name = "是否有效")]
        public bool IsActive { get; set; }
    }
}