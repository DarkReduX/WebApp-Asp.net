using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Models
{
    public class Ip
    {
        [Key]
        public int Id { get; set; }
        public int NewsId { get; set; }
        [ForeignKey("NewsId")]
        public virtual News news { get; set; }

        [Required]
        [Display(Name = "Ip")]
        public string ip { get; set; }

        [Required]
        [Display(Name = "Тип")]
        public string type { get; set; }

        [Required]
        [Display(Name = "Код континента")]
        public string continentCode { get; set; }

        [Required]
        [Display(Name = "Континент")]
        public string continentName { get; set; }

        [Required]
        [Display(Name = "Код страны")]
        public string countryCode { get; set; }

        [Required]
        [Display(Name = "Страна")]
        public string countryName { get; set; }

        [Required]
        [Display(Name = "Код региона")]
        public string regionCode { get; set; }

        [Required]
        [Display(Name = "Регион")]
        public string regionName { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string city { get; set; }

        public string zip { get; set; }

        [Required]
        [Display(Name = "Широта")]
        public string latitude { get; set; }

        [Required]
        [Display(Name = "Долгота")]
        public string longitude { get; set; }
    }
}