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
    public partial class ViewUsers : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void viewUsers_Click(object sender, EventArgs e)
        {

            viewAdmin.Visible = false;
            divView.Visible = false;
            userView.Visible = true;
            grdRcrds.Visible = true;
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    grdRcrds.DataSource = dt;
                    grdRcrds.DataBind();
                    int ctr = grdRcrds.Rows.Count;
                    if (ctr == 0)
                    {
                        Response.Write("<script>alert('The table is empty')</script>");
                    }

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var id = TextBox1.Text;
            if (id == null || id == "")
            {
                id = "0";
            }
            clearDisplayAll();
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID='" + id + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            divView.Visible = true;
                            byte[] pic = (byte[])reader["PIC"];
                            string str = Convert.ToBase64String(pic);
                            vwPic.ImageUrl = "data:image/jpeg;base64," + str;
                            accnum.Text = reader["CLIENT_ID"].ToString();
                            name.Text = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                            gender.Text = reader["GENDER"].ToString();
                            bday.Text = reader["DOB"].ToString();
                            address.Text = reader["ADDRESS"].ToString();
                            pnumber.Text = reader["PHONE_NUM"].ToString();
                            email.Text = reader["EMAIL_ADD"].ToString();

                            if(reader["STATUS"].ToString() == "SUSPENDED")
                            {
                                suspendBtn.Visible = false;
                                unsuspendBtn.Visible = true;
                            }else if(reader["STATUS"].ToString() == "ACTIVE")
                            {
                                suspendBtn.Visible = true;
                                unsuspendBtn.Visible = false;
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('No Records Found!!')</script>");
                        }
                    }
                    cmd.ExecuteNonQuery();

                }
            }
        }

        void clearDisplay()
        {
            userView.Visible = false;
        }
        void clearDisplayAll()
        {
            grdRcrds.Visible = false;
        }

        protected void Suspend_Click(object sender, EventArgs e)
        {
            var id = TextBox1.Text;
            if (id == null || id == "")
            {
                id = "0";
            }
            string Status = "SUSPENDED";
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CLIENT_TBL SET STATUS = @stat WHERE CLIENT_ID = '" + id + "'";
                    cmd.Parameters.AddWithValue("@stat", Status);
                    var ctr = cmd.ExecuteNonQuery();


                    if (ctr >= 1)
                    {
                        Response.Write("<script>alert('Successfully suspended the account!!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Oops! Something's wrong!')</script>");
                    }

                }
            }

        }

        protected void Unsuspend_Click(object sender, EventArgs e)
        {
            var id = TextBox1.Text;
            if (id == null || id == "")
            {
                id = "0";
            }
            string Status = "ACTIVE";
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CLIENT_TBL SET STATUS = @stat WHERE CLIENT_ID = '" + id + "'";
                    cmd.Parameters.AddWithValue("@stat", Status);
                    var ctr = cmd.ExecuteNonQuery();


                    if (ctr >= 1)
                    {
                        Response.Write("<script>alert('Successfully unsuspended the account!!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Oops! Something's wrong!')</script>");
                    }
                }
            }

        }

        protected void viewAdmins_Click(object sender, EventArgs e)
        {
            userView.Visible = false;
            viewAdmin.Visible = true;
            viewAdminRcrds.Visible = true;
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM ADMIN_TBL";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    viewAdminRcrds.DataSource = dt;
                    viewAdminRcrds.DataBind();
                    int ctr = viewAdminRcrds.Rows.Count;
                    if (ctr == 0)
                    {
                        Response.Write("<script>alert('The table is empty')</script>");
                    }

                }

            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            int id = Convert.ToInt32(viewAdminRcrds.DataKeys[rowIndex].Values[0]);


            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM ADMIN_TBL WHERE ADMIN_ID='" + id.ToString() + "'";
                    int ctr = cmd.ExecuteNonQuery();
                    if (ctr >= 1)
                    {
                        Response.Write("<script>alert('Successfully deleted admin account!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Admin id number not found!')</script>");
                    }
                }
            }
        }

    }
}