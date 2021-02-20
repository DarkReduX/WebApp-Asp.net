//using Microsoft.EntityFrameworkCore;
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

}