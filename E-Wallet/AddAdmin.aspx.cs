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
    public partial class AddAdmin : System.Web.UI.Page
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\E-Wallet\E-Wallet\App_Data\e-walletDB.mdf;Integrated Security=True";
        protected void BtnSubmit(object sender, EventArgs e)
        {
            String lastname = lname.Text;
            String firstname = fname.Text;
            String emailadd = email.Text;

                using (var db = new SqlConnection(connString))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        /*
                        INSERT INTO TABLENAME(attrib1, attrib2, attribN)
                        VALUES(alias1,alias2,aliasN)
                         */
                        cmd.CommandText = "INSERT INTO ADMIN_TBL(LASTNAME, FIRSTNAME, EMAIL, DATE_CREATED) "
                                        + " VALUES(@l, @f, @e, GETDATE())";
                        cmd.Parameters.AddWithValue("@l", lastname);
                        cmd.Parameters.AddWithValue("@f", firstname);
                        cmd.Parameters.AddWithValue("@e", emailadd);

                        //Check if naay natandog nga record, return siyag pila karows ang natandog
                        var ctr = cmd.ExecuteNonQuery();

                        if (ctr >= 1)
                        {
                            Response.Write("<script>alert('Record is saved')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Record is not saved')</script>");
                        }
                    }
                }

        }

    }
}