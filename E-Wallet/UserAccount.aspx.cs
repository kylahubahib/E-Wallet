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
    public partial class UserAccount : System.Web.UI.Page
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
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID = '" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            balance.Text = reader["BALANCE"].ToString();
                            accnum.Text = reader["CLIENT_ID"].ToString();
                            name.Text = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString(); 
                            datereg.Text = reader["DATESTARTED"].ToString();
                            totalsent.Text = reader["TOTALSENTMONEY"].ToString();

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
    }
}