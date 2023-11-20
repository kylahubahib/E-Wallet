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
    public partial class UpdateClient : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Enabled = true;
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "Hello";
           TextBox1.Enabled = false;
        }
        /*protected void Page_Load(object sender, EventArgs e)
{
txtlname.Enabled = false;
txtfname.Enabled = false;
btnDelete.Enabled = false;
btnEdit.Enabled = false;
btnUpdate.Enabled = false;
}

protected void btnSearch_Click(object sender, EventArgs e)
{
var idno = txtIdno.Text;
using (var db = new SqlConnection(connString))
{
db.Open();
using (var cmd = db.CreateCommand())
{
  cmd.CommandType = CommandType.Text;
  cmd.CommandText = "SELECT * FROM USERS_TBL WHERE ID ='" + idno + "'";
  using (SqlDataReader reader = cmd.ExecuteReader())
  {
      if (reader.Read())
      {
          btnSearch.Enabled = false;
          btnEdit.Enabled = true;

          txtlname.Text = reader["LASTNAME"].ToString();
          txtfname.Text = reader["FIRSTNAME"].ToString();
      }
      else
      {
          Response.Write("<script>alert('Id number does not exist')</script>");
      }
  }
}
}
}

protected void btnEdit_Click(object sender, EventArgs e)
{
txtlname.Enabled = true;
txtfname.Enabled = true;
btnDelete.Enabled = true;
btnUpdate.Enabled = true;
btnSearch.Enabled = false;
}

protected void btnUpdate_Click(object sender, EventArgs e)
{
var lname = txtlname.Text;
var fname = txtfname.Text;
var idno = txtIdno.Text;
using (var db = new SqlConnection(connString))
{
db.Open();
using (var cmd = db.CreateCommand())
{
  cmd.CommandType = CommandType.Text;
  cmd.CommandText = "UPDATE CLIENT_TBL SET "
                  + " LASTNAME = @lname, "
                  + " FIRSTNAME =@fname "
                  + " WHERE ID='" + idno + "'";
  cmd.Parameters.AddWithValue("@lname", lname);
  cmd.Parameters.AddWithValue("@fname", fname);

  int ctr = cmd.ExecuteNonQuery();
  if (ctr >= 1)
  {
      Response.Write("<script>alert('The record is updated')</script>");
      Response.Redirect("viewRecords");
  }
  else
  {
      Response.Write("<script>alert('Ooopss.. something missing')</script>");
  }

}
}
}

protected void btnDelete_Click(object sender, EventArgs e)
{
using (var db = new SqlConnection(connString))
{
db.Open();
using (var cmd = db.CreateCommand())
{
  cmd.CommandType = CommandType.Text;
  cmd.CommandText = "DELETE FROM CLIENT_TBL WHERE ID='" + txtIdno.Text + "'";
  int ctr = cmd.ExecuteNonQuery();
  if (ctr >= 1)
  {
      Response.Write("<script>alert('The record is permanently remove')</script>");
  }
  else
  {
      Response.Write("<script>alert('id number not found!')</script>");
  }
}
}
}
*/



    }
}