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
    public partial class ViewRecords : System.Web.UI.Page
    {

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            clearDisplay();
        }

        protected void vwRcrdsBtn_Click(object sender, EventArgs e)
        {
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
                            lname.Text = reader["LASTNAME"].ToString();
                            fname.Text = reader["FIRSTNAME"].ToString();

                        }
                        else
                        {
                            Response.Write("<script>alert('No Records Found!!')</script>");
                            clearDisplay();
                        }
                    }

                }
            }
        }

        void clearDisplay()
        {
            divView.Visible = false;
        }
    }
}