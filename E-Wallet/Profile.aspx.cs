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
    public partial class Profile : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            String idNum = Session["id"].ToString();
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID='" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            divView.Visible = true;
                            byte[] pic = (byte[])reader["PIC"];
                            string str = Convert.ToBase64String(pic);
                            vwPic.ImageUrl = "data:image/jpeg;base64," + str;
                            accnumlbl.Text = reader["CLIENT_ID"].ToString();
                            fnamelbl.Text = reader["FIRSTNAME"].ToString();
                            lnamelbl.Text = reader["LASTNAME"].ToString();
                            genderlbl.Text = reader["GENDER"].ToString();
                            doblbl.Text = reader["DOB"].ToString();
                            addlbl.Text = reader["ADDRESS"].ToString();
                            pnumlbl.Text = reader["PHONE_NUM"].ToString();
                            emaillbl.Text = reader["EMAIL_ADD"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('No Records Found!!')</script>");
                        }
                    }

                    var ctr = cmd.ExecuteNonQuery();

                }
            }

        }

        protected void Deactivate_Click(object sender, EventArgs e)
        {
            String idNum = Session["id"].ToString();
            string Status = "DEACTIVATED";
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CLIENT_TBL SET STATUS = @stat WHERE CLIENT_ID = '" + idNum + "'";
                    cmd.Parameters.AddWithValue("@stat", Status);
                    Response.Write("<script>alert('Successfully deactivated account. Just login to your account to activate it again.')</script>");
                    var ctr = cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("SignIn.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("SignIn.aspx");
        }

        protected void EditProfile_Click(object sender, EventArgs e)
        {
            viewpass.Visible = false;
            savechanges.Visible = true;
            Editprofile.Visible = false;
            editprof.Visible = true;
            viewprofile.Visible = false;
            accnum.Text = accnumlbl.Text;
            fname.Text = fnamelbl.Text;
            lname.Text = lnamelbl.Text;
            genderList.SelectedValue = genderlbl.Text;
            birthday.Text = doblbl.Text;
            address.Text = addlbl.Text;
            pnumber.Text = pnumlbl.Text;
            email.Text = emaillbl.Text;
        }

        protected void Savechanges_Click(object sender, EventArgs e)
        {
            String lastname = lname.Text;
            String firstname = fname.Text;
            String bday = birthday.Text;
            String addrss = address.Text;
            String phoneNum = pnumber.Text;
            String emailadd = email.Text;
            String gender = genderList.SelectedValue;
            String idNum = Session["id"].ToString();

                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE CLIENT_TBL SET LASTNAME = @l, FIRSTNAME = @f, " +
                        "GENDER = @g, DOB = @b, ADDRESS = @a, PHONE_NUM = @p, EMAIL_ADD = @e " +
                        "WHERE CLIENT_ID = @id";

                        cmd.Parameters.AddWithValue("@l", lastname);
                        cmd.Parameters.AddWithValue("@f", firstname);
                        cmd.Parameters.AddWithValue("@g", gender);
                        cmd.Parameters.AddWithValue("@b", bday);
                        cmd.Parameters.AddWithValue("@a", addrss);
                        cmd.Parameters.AddWithValue("@p", phoneNum);
                        cmd.Parameters.AddWithValue("@e", emailadd);
                        cmd.Parameters.AddWithValue("@id", idNum);


                    var ctr = cmd.ExecuteNonQuery();

                        if (ctr >= 1)
                        {
                            Response.Write("<script>alert('Profile is updated successfully!')</script>");
                            viewpass.Visible = true;
                            savechanges.Visible = false;
                            Editprofile.Visible = true;
                            editprof.Visible = false;
                            viewprofile.Visible = true;

                    }
                        else
                        {
                            Response.Write("<script>alert('Oops... Something is wrong')</script>");
                        }
                    }
                }
        }

        protected void imgBtn_Click(object sender, EventArgs e)
        {
            imgUpload.Visible = true;
            imgBtn.Visible = false;
        }

        protected void imgUpload_Click(object sender, EventArgs e)
        {
            picUpload.Visible = true;
            String idNum = Session["id"].ToString();


            if (IsPostBack)
            {
                HttpPostedFile postedFile = picUpload.PostedFile;
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    byte[] picData = new byte[postedFile.ContentLength];
                    postedFile.InputStream.Read(picData, 0, postedFile.ContentLength);

                    using (var db = new SqlConnection(connString))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE CLIENT_TBL SET PIC =  @file WHERE CLIENT_ID = '" + idNum + "'";
                            cmd.Parameters.AddWithValue("@file", picData);

                            var ctr = cmd.ExecuteNonQuery();

                            if (ctr >= 1)
                            {
                                Response.Write("<script>alert('Successfully change profile picture!')</script>");
                                viewpass.Visible = true;
                                savechanges.Visible = false;
                                Editprofile.Visible = true;
                                editprof.Visible = false;
                                viewprofile.Visible = true;
                            }
                            else
                            {
                                Response.Write("<script>alert('Oops... Something is wrong!')</script>");
                            }
                        }
                    }
                }
            }
        }

        protected void Editpass_Click(object sender, EventArgs e)
        {
            newpass.Enabled = true;
            UpdatePass.Visible = true;
            Editpass.Visible = false;
        }

        protected void UpdatePass_Click(object sender, EventArgs e)
        {
            var pass = newpass.Text;
            String idNum = Session["id"].ToString();
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID='" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["PASSWORD"].ToString() != pass)
                        {
                            cmd.CommandText = "UPDATE CLIENT_TBL SET PASSWORD = @pass WHERE CLIENT_ID = @id";
                            cmd.Parameters.AddWithValue("@pass", pass);
                            cmd.Parameters.AddWithValue("@id", idNum);
                            Response.Write("<script>alert('Successfully updated password!')</script>");

                            newpass.Enabled = false;
                            UpdatePass.Visible = false;
                            Editpass.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('New password must not be the same as the old password')</script>");
                            return;
                        }
                    }

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}