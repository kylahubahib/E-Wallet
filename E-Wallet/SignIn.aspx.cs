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
    public partial class SignIn : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";
        protected void LoginBtn(object sender, EventArgs e)
        {
            string Email = email.Text;
            string pass = password.Text;

            if (adminCheck.Checked)
            {
                using (var db = new SqlConnection(connString))
                {

                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM ADMIN_TBL WHERE EMAIL = '" + Email + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["EMAIL"].ToString() == Email && reader["PASSWORD"].ToString() == pass)
                                {
                                    Session["id"] = reader["ADMIN_ID"].ToString();
                                    Response.Redirect("AdminPanel.aspx");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Wrong Password or Username')</script>");
                                }

                            }
                            else
                            {
                                Response.Write("<script>alert('No Records Found!')</script>");
                            }
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (var db = new SqlConnection(connString))
                {

                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE EMAIL_ADD = '" + Email + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if(reader["STATUS"].ToString() == "SUSPENDED")
                                {
                                    Response.Write("<script>alert('Your Account is Suspended.')</script>");
                                    return;
                                }
                                else if(reader["EMAIL_ADD"].ToString() == Email && reader["PASSWORD"].ToString() == pass)
                                {
                                    Session["id"] = reader["CLIENT_ID"].ToString();
                                    Response.Redirect("UserAccount.aspx");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Wrong Password or Username')</script>");
                                    return;
                                }

                            }
                            else
                            {
                                Response.Write("<script>alert('No Records Found! Register First')</script>");
                                return;
                            }
                        }
                    }
                }
            }

        }
    }
}