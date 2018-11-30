using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Drawing;
using CAS.Core.Core.Management;
using Image=System.Drawing.Image;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TempDatabaseFileWriter
{
    public static void WriteFile()
    {
        Image image = Bitmap.FromFile("C:\\OrenAir.png");
        string serverName = "dev\\dev2005";
        string databaseName = "CASDemo";
        string userName = "TechnicianTest";
        string userPass = "TechnicianTest";
        string connectionString = "SERVER = " +
                    serverName + ";" +
                    "UID=" + userName + ";" +
                    "PWD=" + userPass + ";" +
                    "DATABASE=" + databaseName + "; Pooling=false;";
        SqlConnection connection = new SqlConnection(connectionString);
        //string queary = string.Format("Update AutomobileAdvertisments set Photo = @Photo where ID = 2");
        string queary = string.Format("Insert into AdvertismentPhotos(AdvertismentID, Photo) values (@AdvertismentID, @Photo)");
        SqlCommand command = new SqlCommand(queary, connection);
        byte[] photo = new byte[0];// = ImageWorker.ImageToBytes(Bitmap.FromFile("C:\\OrenAir.png"), ImageFormat.Jpeg);
        SqlParameter param1 = new SqlParameter("@AdvertismentID", SqlDbType.Int);
        SqlParameter res = new SqlParameter("@Photo", SqlDbType.Image, photo.Length);
        param1.Value = 17;
        res.Value = photo;
        //res.IsNullable = true;
        command.Parameters.Add(param1);
        command.Parameters.Add(res);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            
        }
        finally
        {
            connection.Close();
        }
    }


    public static void CheckDirectory()
    {
        HttpRequest httpRequest = new HttpRequest("","","");
        string[] fileNames = Directory.GetFiles(httpRequest.MapPath("~/Banners"));

    }
}
