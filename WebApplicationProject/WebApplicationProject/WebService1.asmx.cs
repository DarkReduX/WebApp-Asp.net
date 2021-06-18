using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Microsoft.AspNet.Identity;
using WebApplicationProject.Models;

namespace WebApplicationProject
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        
        public void GetAllNews()
        {
            List<GlobeDataModel> globeData = new List<GlobeDataModel>();
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string userId = User.Identity.GetUserId();
            string selectUnReadedPosts = "";
            if (userId != null)
            {
                selectUnReadedPosts = " And ReadedPosts.UserId <> " + "'" + userId.ToString() + "'" + " and ReadedPosts.PostId = News.ID ";
            }
            string cmdText = "select top 50 News.ID, header, UserName, latitude, longitude, countryName From News join AspNetUsers on News.UserId = AspNetUsers.Id join Ips on Ips.NewsId = News.ID;";
            using (SqlConnection sqlConnection = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(
                   cmdText
                    , sqlConnection);
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GlobeDataModel post = new GlobeDataModel();
                    post.ID = Convert.ToInt32(reader["ID"]);
                    post.UserName = Convert.ToString(reader["UserName"]);
                    post.countryName = Convert.ToString(reader["countryName"]);
                    post.header = Convert.ToString(reader["header"]);
                    post.latitude = Convert.ToString(reader["latitude"]);
                    post.longitude = Convert.ToString(reader["longitude"]);
                    //object image = reader["Image"];
                    ////convert object to byte[]
                    //if (image == null)
                    //    post.Image = null;
                    //else
                    //{
                    //    //BinaryFormatter bf = new BinaryFormatter();
                    //    //using (MemoryStream ms = new MemoryStream())
                    //    //{
                    //    //    bf.Serialize(ms, image);
                    //    //    post.Image = ms.ToArray();
                    //    //}
                    //}
                    //post.UserId = Convert.ToString(reader["UserId"]);

                    globeData.Add(post);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(globeData));
        }
    }
}
