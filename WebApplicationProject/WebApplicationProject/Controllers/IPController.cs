using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class IPController
    {
        public static IPAddress getCurrentIPv6Address => (IPAddress)System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0);

        public static IPAddress getCurrentIPv4Address => Context.Request.GetHttpContext().Request.UserHostAdress;

        public static IP getIpInfo(string IP_adress)
        {
            const String IP_STACK_API_KEY = "7bf69112c979a5fcaab766926395eee4"; ;
            //var url = "http://freegeoip.net/json/" + IP;
            //var url = "http://freegeoip.net/json/" + IP;
            string url = "http://api.ipstack.com/" + IP_adress + $"?access_key={IP_STACK_API_KEY}";
            var request = System.Net.WebRequest.Create(url);
            IP ip = new IP();
            using (WebResponse wrs = request.GetResponse())
            using (Stream stream = wrs.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                JObject obj = JObject.Parse(json);
                ip.ip = (String)obj["ip"];
                ip.type = (String)obj["type"];
                ip.continentCode = (String)obj["continent_code"];
                ip.continentName = (String)obj["continent_name"];
                ip.countryCode = (String)obj["country_code"];
                ip.countryName = (String)obj["country_name"];
                ip.regionCode = (String)obj["region_code"];
                ip.regionName = (String)obj["region_name"];
                ip.city = (String)obj["city"];
                ip.zip = (String)obj["zip"];
                ip.latitude = (String)obj["latitude"];
                ip.longitude = (String)obj["longitude"];

                /*string City = (string)obj["city"];
                string Country = (string)obj["region_name"];
                string CountryCode = (string)obj["country_code"];
                string ContinentName = (string)obj["continent_name"];
                string RegionName = (string)obj["region_name"];
                String Location = (string)obj["ip"];*/

                //return (CountryCode + " - " + Country + "," + City);
                return ip;
            }
        }
    }
}