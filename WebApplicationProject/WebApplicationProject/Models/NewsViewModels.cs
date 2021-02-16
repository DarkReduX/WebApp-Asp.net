//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace WebApplicationProject.Models
{
    public class News
    {
        public int ID { get; set; }
        public string header { get; set; }
        public string info { get; set; }
    }
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }
    }
}