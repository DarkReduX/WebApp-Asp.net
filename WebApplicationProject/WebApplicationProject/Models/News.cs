using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationProject.Models
{
    public class News
    {
        public int ID { get; set; }
        public string header { get; set; }
        public string info { get; set; }
    }

}