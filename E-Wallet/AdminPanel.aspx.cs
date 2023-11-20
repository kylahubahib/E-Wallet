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
    public partial class AdminPanel : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string idNum = Session["id"].ToString();

            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM ADMIN_TBL WHERE ADMIN_ID = '" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adnum.Text = reader["ADMIN_ID"].ToString();
                            name.Text = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                            email.Text = reader["EMAIL"].ToString();
                            datecreated.Text = reader["DATE_CREATED"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('No Records Found!!')</script>");
                        }
                    }

                    cmd.CommandText = "UPDATE CLIENT_TBL SET STATUS = 'ACTIVE' WHERE CLIENT_ID = '" + idNum + "' AND STATUS = 'DEACTIVATED'";
                    cmd.ExecuteNonQuery();

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
                    cmd.CommandText = "SELECT * FROM ADMIN_TBL WHERE ADMIN_ID='" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["PASSWORD"].ToString() != pass)
                        {
                            cmd.CommandText = "UPDATE ADMIN_TBL SET PASSWORD = @pass WHERE ADMIN_ID = @id";
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

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("SignIn.aspx");
        }
    }
}