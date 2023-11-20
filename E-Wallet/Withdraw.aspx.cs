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
    public partial class Withdraw : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";


        protected void CurrentBalance(object sender, EventArgs e)
        {
            string idNum = Session["id"].ToString();

            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT BALANCE FROM CLIENT_TBL WHERE CLIENT_ID = '" + idNum + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            balance.Text = reader["BALANCE"].ToString();

                        }
                        else
                        {
                            Response.Write("<script>alert('No Records Found!!')</script>");

                        }
                    }
                }

            }
        }
        protected void WithdrawBtn(object sender, EventArgs e)
        {
            string idNum = Session["id"].ToString();
            float amnt = Convert.ToSingle(amount.Text);
            float totalbal = 0;
            string bal;

            if (amnt > 10000)
            {
                Response.Write("<script>alert('Oops! Maximum Amount Withdrawn is 10,000.00!')</script>");
                return;
            }
            else if (amnt < 100)
            {
                Response.Write("<script>alert('Oops! Minimum Amount Withdrawn is 100.00!')</script>");
                return;
            }
            else if (amnt % 100 != 0)
            {
                Response.Write("<script>alert('Oops! Minimum Amount Withdrawn is 100.00!')</script>");
                return;
            }
            else
            {
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT BALANCE FROM CLIENT_TBL WHERE CLIENT_ID = '" + idNum + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bal = reader["BALANCE"].ToString();
                                float balAmnt = Convert.ToSingle(bal);

                                if(balAmnt < amnt)
                                {
                                    Response.Write("<script>alert('Cannot proceed! Insufficient funds!')</script>");
                                    return;
                                }
                                else
                                {
                                    totalbal = balAmnt - amnt;
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Cannot Proceed. Account doesn't exist!!')</script>");
                                return;
                            }
                        }

                        cmd.CommandText = "UPDATE CLIENT_TBL " +
                                  "SET BALANCE = @amount " +
                                  "WHERE CLIENT_ID = '" + idNum + "'";
                        cmd.Parameters.AddWithValue("@amount", totalbal);
                        Storetransaction(amnt);
                      
                        var ctr = cmd.ExecuteNonQuery();

                        if (ctr >= 1)
                        {
                            Response.Write("<script>alert('Successfully Withdrawn Your Money!')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Oops! Something's wrong!')</script>");
                        }
                    }
                }

            }
        }

        void Storetransaction(float amnt)
        {
            string idNum = Session["id"].ToString();
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO TRANSACT_TBL(TRANS_DATE, TRANS_RECIPIENT, TRANS_TYPE, TRANS_AMOUNT, CLIENT_ID)" +
                                       "VALUES(GETDATE(), (SELECT CONCAT(FIRSTNAME, ' ', LASTNAME) FROM CLIENT_TBL WHERE CLIENT_ID = '" + idNum + "'), 'WITHDRAW', @amount1, @ID  )";
                    cmd.Parameters.AddWithValue("@amount1", amnt);
                    cmd.Parameters.AddWithValue("@ID", idNum);
                    var ctr = cmd.ExecuteNonQuery();
                }
            }
        }

    }
}