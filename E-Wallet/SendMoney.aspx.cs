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
    public partial class SendMoney : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void SendBtn_Click(object sender, EventArgs e)
        {
            string idNum = Session["id"].ToString();
            float amnt = Convert.ToSingle(amount1.Text);
            string p = pass.Text;
            string accnumber = accnum.Text;

            if (amnt > 10000)
            {
                Response.Write("<script>alert('Oops! Maximum Amount to send is 10,000.00!')</script>");
            }
            else if (amnt < 100)
            {
                Response.Write("<script>alert('Oops! Minimum Amount to send is 100.00!')</script>");
            }
            else if (amnt % 100 != 0)
            {
                Response.Write("<script>alert('Oops! Amount must be divisible by 100!')</script>");
            }
            else
            {
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
                                string bal = reader["BALANCE"].ToString();
                                float balAmnt = Convert.ToSingle(bal);

                                if (balAmnt < amnt)
                                {
                                    Response.Write("<script>alert('Cannot proceed! Insufficient funds!')</script>");
                                    return;
                                }
                                else if (reader["PASSWORD"].ToString() != p)
                                {
                                    Response.Write("<script>alert('Cannot Proceed. Wrong Password!!')</script>");
                                    return;
                                }
                                else
                                {
                                    UpdateBalanceReceiver(amnt);
                                   

                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Cannot Proceed. Account does not exist!!')</script>");
                                return;
                            }
                        }


                        var ctr = cmd.ExecuteNonQuery();
                    }

                }

            }
        }


        //This method is used to store the transaction history in the senders account
        void SendMoneytransact(float amnt)
        {
            string idNum = Session["id"].ToString();

            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO TRANSACT_TBL(TRANS_DATE, TRANS_RECIPIENT, TRANS_TYPE, TRANS_AMOUNT, CLIENT_ID, TRANS_SENDER)" +
                                       "VALUES(GETDATE(), (SELECT CONCAT(FIRSTNAME, ' ', LASTNAME) FROM CLIENT_TBL WHERE CLIENT_ID = '" + accnum.Text + "'), 'SEND MONEY', @amount1, @ID, (SELECT CONCAT(FIRSTNAME, ' ', LASTNAME) FROM CLIENT_TBL WHERE CLIENT_ID = @ID))";
                    cmd.Parameters.AddWithValue("@amount1", amnt);
                    cmd.Parameters.AddWithValue("@ID", idNum);
                    var ctr = cmd.ExecuteNonQuery();
                }

            }
        }

        //This method is used to store the transaction history in the receivers account
        void ReceiveMoneytransact(float amnt, string acc)
        {
            string idNum = Session["id"].ToString();

            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO TRANSACT_TBL(TRANS_DATE, TRANS_RECIPIENT, TRANS_TYPE, TRANS_AMOUNT, CLIENT_ID, TRANS_SENDER)" +
                                      "VALUES(GETDATE(), (SELECT CONCAT(FIRSTNAME, ' ', LASTNAME) FROM CLIENT_TBL WHERE CLIENT_ID = '" + acc + "'), 'RECEIVE MONEY', @amount3, @ID, (SELECT CONCAT(FIRSTNAME, ' ', LASTNAME) FROM CLIENT_TBL WHERE CLIENT_ID = '" + idNum + "'))";
                    cmd.Parameters.AddWithValue("@amount3", amnt);
                    cmd.Parameters.AddWithValue("@ID", acc);
                    var ctr = cmd.ExecuteNonQuery();
                }
            }
        }

        void UpdateBalance(float amount)
        {
            string idnum = Session["id"].ToString();
            string password = pass.Text;
            float totalbal = 0;

            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID = '" + idnum + "' AND PASSWORD = '" + password + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string bal = reader["BALANCE"].ToString();
                            float balAmnt = Convert.ToSingle(bal);
                            totalbal = balAmnt - amount;
                        }
                        else
                        {
                            Response.Write("<script>alert('Cannot Proceed. Account does not exist!!')</script>");
                            return;
                        }
                    }

                    cmd.CommandText = "UPDATE CLIENT_TBL " +
                              "SET BALANCE = @amount, TOTALSENTMONEY = TOTALSENTMONEY + @amnt WHERE CLIENT_ID = '" + idnum + "'";
                    cmd.Parameters.AddWithValue("@amnt", amount);
                    cmd.Parameters.AddWithValue("@amount", totalbal);
                    SendMoneytransact(amount);


                    var ctr = cmd.ExecuteNonQuery();


                    if (ctr >= 1)
                    {
                        Response.Write("<script>alert('Successfully Sent the Money!')</script>");
                        accnum.Text = "";
                        name.Text = "";
                        amount1.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('Oops! Something is wrong!')</script>");
                    }

                }
            }
        }

        void UpdateBalanceReceiver(float amount)
        {
            float totalbal = 0;
            string accNum = accnum.Text;
            string Name = name.Text;
           
            using (var db = new SqlConnection(connString))
            {
                db.Open();
                using (var cmd2 = db.CreateCommand())
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID = '" + accNum + "' AND STATUS = 'ACTIVE'";
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullname = (reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString());
                            
                            if(Name == fullname)
                            {
                                string bal = reader["BALANCE"].ToString();
                                float balAmnt = Convert.ToSingle(bal);
                                totalbal = amount + balAmnt;
                                UpdateBalance(amount);
                            }
                            else
                            {
                              Response.Write("<script>alert('Error! Account Number and Name do not match')</script>");
                            return;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Cannot Proceed. Account Number does not exist!!')</script>");
                            return;
                        }
                    }

                    if (totalbal <= 50000)
                    {
                        cmd2.CommandText = "UPDATE CLIENT_TBL " +
                                "SET BALANCE = @amount1 " +
                                "WHERE CLIENT_ID = '" + accNum + "'";
                        cmd2.Parameters.AddWithValue("@amount1", totalbal);
                        ReceiveMoneytransact(amount, accNum);

                    }
                    else
                    {
                        Response.Write("<script>alert('Oops! Current Balance of the Receiver exceeds to 50,000.00')</script>");
                        return;
                    }


                    cmd2.ExecuteNonQuery();

                }
            }
        }
    }
}