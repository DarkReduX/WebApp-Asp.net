//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplicationProject.Models
{
    public class News
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        public string header { get; set; }
        [Required]
        [Display(Name = "Содержание поста")]
        [DataType(DataType.MultilineText)]
        public string info { get; set; }
        public byte[] Image { get; set; }
        public string UserId { get; set; }
    }
    public class Vote
    {
        [Key]
        [Column(Order = 1)]
        public int NewsId { get; set; }
        public virtual News post { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
    public class Comment
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int NewsId { get; set; }
        public string Message { get; set; }
    }
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class NewsViewModel
    {
        public List<News> Posts { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<string> CreatedByNames { get; set; }
    }

    public class PostViewModel
    {
        public News Post { get; set; }
        public string UserName { get; set; }
    }
}