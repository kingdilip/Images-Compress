using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageResize
{
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(Connection.conn);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 cmd.CommandText = "select * from ResizeImg where Id=5";
                cmd.Connection = con;
                adp.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                byte[] pan = (byte[])(dt.Rows[0]["Image1"]);
                string pan64String = Convert.ToBase64String(pan, 0, pan.Length);
                Image1.ImageUrl = "data:image/png;base64," + pan64String;

                byte[] adhar = (byte[])(dt.Rows[0]["Image2"]);
                string adhar64String = Convert.ToBase64String(adhar, 0, adhar.Length);
                Image2.ImageUrl = "data:image/png;base64," + adhar64String;

                byte[] passport = (byte[])(dt.Rows[0]["Image3"]);
                string pass64String = Convert.ToBase64String(passport, 0, passport.Length);
                Image3.ImageUrl = "data:image/png;base64," + pass64String;

                byte[] drive = (byte[])(dt.Rows[0]["Image4"]);
                string drive64String = Convert.ToBase64String(drive, 0, drive.Length);
                Image4.ImageUrl = "data:image/png;base64," + drive64String;
            }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "select * from ResizeImg where Id=5";
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int panno = FileUpload1.PostedFile.ContentLength;
                byte[] pan = new byte[panno];
                HttpPostedFile panfile = FileUpload1.PostedFile;
                panfile.InputStream.Read(pan, 0, panno);
                string panname = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string pan64String = Convert.ToBase64String(pan, 0, pan.Length);
                Image1.ImageUrl = "data:image/png;base64," + pan64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload1);
                byte[] thumbpan = thumbnailPhotoStream.ToArray();

                cmd.CommandText = "update ResizeImg set Image1= @panphoto where Id=5";
                cmd.Parameters.AddWithValue("@panphoto", thumbpan);               
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {

                int panno = FileUpload1.PostedFile.ContentLength;
                byte[] pan = new byte[panno];
                HttpPostedFile panfile = FileUpload1.PostedFile;
                panfile.InputStream.Read(pan, 0, panno);
                string panname = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string pan64String = Convert.ToBase64String(pan, 0, pan.Length);
                Image1.ImageUrl = "data:image/png;base64," + pan64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload1);
                byte[] thumbpan = thumbnailPhotoStream.ToArray();

                byte[] adhar = new byte[0];
                byte[] pass = new byte[0];
                byte[] drive = new byte[0];

                cmd.CommandText = "insert into ResizeImg values(@panphoto,@adhar,@pass,@drive )";
                cmd.Parameters.AddWithValue("@panphoto", thumbpan);
                cmd.Parameters.AddWithValue("@adhar", adhar);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@drive", drive);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       
        protected void Button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "select * from ResizeImg where Id=5";
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int adharno = FileUpload2.PostedFile.ContentLength;
                byte[] adhar = new byte[adharno];
                HttpPostedFile adhafile = FileUpload2.PostedFile;
                adhafile.InputStream.Read(adhar, 0, adharno);
                string adhaname = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string adhar64String = Convert.ToBase64String(adhar, 0, adhar.Length);
                Image2.ImageUrl = "data:image/png;base64," + adhar64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload2);
                byte[] thumbadhar = thumbnailPhotoStream.ToArray();

                cmd.CommandText = "update ResizeImg set Image2= @adharphoto where Id=5";
                cmd.Parameters.AddWithValue("@adharphoto", thumbadhar);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                int adharno = FileUpload2.PostedFile.ContentLength;
                byte[] adhar = new byte[adharno];
                HttpPostedFile adhafile = FileUpload2.PostedFile;
                adhafile.InputStream.Read(adhar, 0, adharno);
                string adhaname = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string adhar64String = Convert.ToBase64String(adhar, 0, adhar.Length);
                Image2.ImageUrl = "data:image/png;base64," + adhar64String;

                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload2);
                byte[] thumbadhar = thumbnailPhotoStream.ToArray();

                byte[] pan = new byte[0];
                byte[] pass = new byte[0];
                byte[] drive = new byte[0];

                cmd.CommandText = "insert into ResizeImg values(@panphoto,@adhar,@pass,@drive )";
                cmd.Parameters.AddWithValue("@panphoto", pan);
                cmd.Parameters.AddWithValue("@adhar", thumbadhar);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@drive", drive);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "select * from ResizeImg where Id=5";
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int passno = FileUpload3.PostedFile.ContentLength;
                byte[] pass = new byte[passno];
                HttpPostedFile passfile = FileUpload3.PostedFile;
                passfile.InputStream.Read(pass, 0, passno);
                string passname = Path.GetFileName(FileUpload3.PostedFile.FileName);
                string pass64String = Convert.ToBase64String(pass, 0, pass.Length);
                Image3.ImageUrl = "data:image/png;base64," + pass64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload3);
                byte[] thumbpass = thumbnailPhotoStream.ToArray();

                cmd.CommandText = "update ResizeImg set Image3= @passphoto where Id=5";
                cmd.Parameters.AddWithValue("@passphoto", thumbpass);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                int passno = FileUpload3.PostedFile.ContentLength;
                byte[] pass = new byte[passno];
                HttpPostedFile passfile = FileUpload3.PostedFile;
                passfile.InputStream.Read(pass, 0, passno);
                string passname = Path.GetFileName(FileUpload3.PostedFile.FileName);
                string pass64String = Convert.ToBase64String(pass, 0, pass.Length);
                Image3.ImageUrl = "data:image/png;base64," + pass64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload3);
                byte[] thumbpass = thumbnailPhotoStream.ToArray();

                byte[] pan = new byte[0];
                byte[] adhar = new byte[0];
                byte[] drive = new byte[0];

                cmd.CommandText = "insert into ResizeImg values(@panphoto,@adhar,@pass,@drive )";
                cmd.Parameters.AddWithValue("@panphoto", pan);
                cmd.Parameters.AddWithValue("@adhar", adhar);
                cmd.Parameters.AddWithValue("@pass", thumbpass);
                cmd.Parameters.AddWithValue("@drive", drive);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "select * from ResizeImg where Id=5";
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int driveno = FileUpload4.PostedFile.ContentLength;
                byte[] drive = new byte[driveno];
                HttpPostedFile drivfile = FileUpload4.PostedFile;
                drivfile.InputStream.Read(drive, 0, driveno);
                string drivname = Path.GetFileName(FileUpload4.PostedFile.FileName);
                string drive64String = Convert.ToBase64String(drive, 0, drive.Length);
                Image4.ImageUrl = "data:image/png;base64," + drive64String;
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload4);
                byte[] thumbdrive = thumbnailPhotoStream.ToArray();

                cmd.CommandText = "update ResizeImg set Image4= @drivephoto where Id=5";
                cmd.Parameters.AddWithValue("@drivephoto", thumbdrive);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                int driveno = FileUpload4.PostedFile.ContentLength;
                byte[] drive = new byte[driveno];
                HttpPostedFile drivfile = FileUpload4.PostedFile;
                drivfile.InputStream.Read(drive, 0, driveno);
                string drivname = Path.GetFileName(FileUpload4.PostedFile.FileName);
                string drive64String = Convert.ToBase64String(drive, 0, drive.Length);
                Image4.ImageUrl = "data:image/png;base64," + drive64String;

                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload4);
                byte[] thumbdrive = thumbnailPhotoStream.ToArray();

                byte[] pan = new byte[0];
                byte[] adhar = new byte[0];
                byte[] pass = new byte[0];

                cmd.CommandText = "insert into ResizeImg values(@panphoto,@adhar,@pass,@drive )";
                cmd.Parameters.AddWithValue("@panphoto", pan);
                cmd.Parameters.AddWithValue("@adhar", adhar);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@drive", thumbdrive);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            
        }

        private MemoryStream ResizeImage(FileUpload fileUpload)
        {

            Bitmap originalBMP = new Bitmap(fileUpload.FileContent);


            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;


            int aspectRatio = origWidth / origHeight;

            if (aspectRatio <= 0)
                aspectRatio = 1;


            int newWidth = 100;


            int newHeight = newWidth / aspectRatio;


            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

            Graphics graphics = Graphics.FromImage(newBMP);


            graphics.SmoothingMode = SmoothingMode.AntiAlias; graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;


            graphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);


            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            newBMP.Save(stream, GetImageFormat(System.IO.Path.GetExtension(fileUpload.FileName)));


            originalBMP.Dispose();
            newBMP.Dispose();
            graphics.Dispose();

            return stream;
        }
        private System.Drawing.Imaging.ImageFormat GetImageFormat(string extension)
        {
            switch (extension.ToLower())
            {
                case "jpg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
            }
            return System.Drawing.Imaging.ImageFormat.Jpeg;
        }

    }
}