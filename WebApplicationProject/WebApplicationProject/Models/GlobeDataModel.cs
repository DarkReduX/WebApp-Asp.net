using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Models
{
    public class GlobeDataModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string header { get; set; }
        public string countryName { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

 //"SELECT TOP 50 ID, header, latitude, longitude, countryName FROM [dbo].[News], [dbo].[Ips] WHERE ID = NewsId"
    }
}