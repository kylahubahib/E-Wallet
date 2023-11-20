using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

namespace E_Wallet
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";
        protected void BtnSubmit(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = picUpload.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string filext = Path.GetExtension(filename).ToLower();
            //Get the file size
            int filesize = postedFile.ContentLength;
            //Convert the image into ascii code
            byte[] pic = new byte[picUpload.PostedFile.ContentLength];
            picUpload.PostedFile.InputStream.Read(pic, 0, picUpload.PostedFile.ContentLength);

            String lastname = lname.Text;
            String firstname = fname.Text;
            String bday = dob.Text;
            String addrss = address.Text;
            String phoneNum = pnumber.Text;
            String emailadd = email.Text;
            String passWord = password.Text;
            String gender;


            if (btnMale.Checked == true)
                gender = "Male";
            else if (btnFmale.Checked == true)
                gender = "Female";
            else
                gender = "Non-binary";


            if (filext == ".bmp" || filext == ".jpg" || filext == ".png" || filext == ".jpeg")
            {
                //Response.Write("It is an image file");

                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM CLIENT_TBL";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["EMAIL_ADD"].ToString() == emailadd)
                                {
                                    Response.Write("<script>alert('Email already existed!')</script>");
                                    return;
                                }
                            }
                        }
                            cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO CLIENT_TBL(LASTNAME, FIRSTNAME, GENDER, DOB, ADDRESS, PHONE_NUM, EMAIL_ADD, PIC, PASSWORD, DATESTARTED, BALANCE, TOTALSENTMONEY, STATUS) "
                                        + " VALUES(@l, @f, @g, @b, @a, @p, @e, @file, @pass, GETDATE(), 0, 0, 'ACTIVE')";
                        cmd.Parameters.AddWithValue("@l", lastname);
                        cmd.Parameters.AddWithValue("@f", firstname);
                        cmd.Parameters.AddWithValue("@g", gender);
                        cmd.Parameters.AddWithValue("@b", bday);
                        cmd.Parameters.AddWithValue("@a", addrss);
                        cmd.Parameters.AddWithValue("@p", phoneNum);
                        cmd.Parameters.AddWithValue("@e", emailadd);
                        cmd.Parameters.AddWithValue("@file", pic);
                        cmd.Parameters.AddWithValue("@pass", passWord);

                        //Check if naay natandog nga record, return siyag pila karows ang natandog
                        var ctr = cmd.ExecuteNonQuery();

                        if (ctr >= 1)
                        {
                            Response.Write("<script>alert('Record is saved')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Record is not saved')</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("It is not an image file");
            }


        }


        protected void btnVwPic_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " SELECT * FROM CLIENT_TBL WHERE CLIENT_ID='' ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            picUpload.Visible = true;
                            byte[] pic = (byte[])reader["PIC"];
                            string str = Convert.ToBase64String(pic);
                            vwPic.ImageUrl = "data:image/jpg;based64," + str;
                        }
                    }
                }
            }
        }

       
    }
}