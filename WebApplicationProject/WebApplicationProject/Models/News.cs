//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<News> posts { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}