using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
<<<<<<< Updated upstream

namespace WebApplicationProject.Models
{
    public class NewsContext : DbContext
    {
            public DbSet<News> news { get; set; }

=======
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplicationProject.Models
{
    public class NewsContext : IdentityDbContext
    {
        public NewsContext()
            : base("DefaultConnection")
        { }
        public DbSet<News> news { get; set; }
        public DbSet<Ip> Ips { get; set; }
        public DbSet<Vote> Votes { get; set; }
>>>>>>> Stashed changes
    }
}