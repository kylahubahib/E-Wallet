using System;
using System.Globalization;
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
    public partial class ViewTransaction : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ViewAllDeWith(object sender, EventArgs e)
        {
            table1.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND (TRANS_TYPE = 'DEPOSIT' OR TRANS_TYPE='WITHDRAW')" +
                            "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        DepoWithdraw.DataSource = dt;
                        DepoWithdraw.DataBind();
                        int ctr = DepoWithdraw.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearSentReceived();
            clearStatement();
        }

        protected void ViewDeposits(object sender, EventArgs e)
        {
            table1.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND TRANS_TYPE = 'DEPOSIT' " +
                            "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        DepoWithdraw.DataSource = dt;
                        DepoWithdraw.DataBind();
                        int ctr = DepoWithdraw.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearSentReceived();
            clearStatement();
        }

        protected void ViewWithdrawals(object sender, EventArgs e)
        {
            table1.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {

                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND TRANS_TYPE = 'WITHDRAW'" +
                             "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        DepoWithdraw.DataSource = dt;
                        DepoWithdraw.DataBind();
                        int ctr = DepoWithdraw.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearStatement();
            clearSentReceived();
        }
        void clearStatement()
        {
            table.Visible = false;

        }
        void clearDepositWithdrawal()
        {
            table1.Visible = false;
        }

        void clearSentReceived()
        {
            table2.Visible = false;
        }

        //History for all the transaction of your account
        protected void Button1_Click(object sender, EventArgs e)
        {
            table.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND " +
                            "(TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        stateAccount.DataSource = dt;
                        stateAccount.DataBind();
                        int ctr = stateAccount.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearDepositWithdrawal();
            clearSentReceived();
        }

        // View All History of Sent and Received Money
        protected void Button3_Click(object sender, EventArgs e)
        {
            table2.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND (TRANS_TYPE = 'SEND MONEY' OR TRANS_TYPE='RECEIVE MONEY')" +
                             "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        ReceivedSent.DataSource = dt;
                        ReceivedSent.DataBind();
                        int ctr = ReceivedSent.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearDepositWithdrawal();
            clearStatement();
        }

        // View history of SEND money
        protected void Button6_Click(object sender, EventArgs e)
        {
            table2.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND TRANS_TYPE = 'SEND MONEY'" +
                             "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        ReceivedSent.DataSource = dt;
                        ReceivedSent.DataBind();
                        int ctr = ReceivedSent.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearDepositWithdrawal();
            clearStatement();
        }

        //View history of RECEIVE money
        protected void Button7_Click(object sender, EventArgs e)
        {
            table2.Visible = true;
            string from = fromdate.Text;
            DateTime selectedDate = DateTime.ParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fromDate = selectedDate.ToString("M/d/yyyy");
            string to = todate.Text;
            DateTime selectedDate1 = DateTime.ParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = selectedDate1.ToString("M/d/yyyy");

            if (selectedDate1 > DateTime.Now)
            {
                Response.Write("<script>alert('Error! Future dates are not allowed!')</script>");
                return;
            }
            else
            {
                string idNUm = Session["id"].ToString();
                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM TRANSACT_TBL WHERE CLIENT_ID = '" + idNUm + "' AND TRANS_TYPE = 'RECEIVE MONEY'" +
                             "AND (TRANS_DATE >= '" + fromDate + "' AND TRANS_DATE <= '" + toDate + "')";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        ReceivedSent.DataSource = dt;
                        ReceivedSent.DataBind();
                        int ctr = ReceivedSent.Rows.Count;
                        if (ctr == 0)
                        {
                            Response.Write("<script>alert('The table is empty')</script>");
                        }

                    }

                }
            }

            clearDepositWithdrawal();
            clearStatement();
        }
    }
}