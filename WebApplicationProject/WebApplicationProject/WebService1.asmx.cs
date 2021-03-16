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
            using (SqlConnection sqlConnection = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 50 News.ID, (SELECT UserName FROM AspNetUsers WHERE AspNetUsers.Id = News.UserId) as UserName, header, latitude, longitude, countryName FROM [dbo].[News], [dbo].[Ips] WHERE News.ID = NewsId"
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
