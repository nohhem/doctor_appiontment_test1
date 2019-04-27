using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        OleDbConnection con = ConnectDB.getConStr();
        OleDbCommand cmd = new OleDbCommand("select username from tbl_Users where username=@un and userPassword=@up",con);
        cmd.Parameters.AddWithValue("@un", txtUsername.Text);
        cmd.Parameters.AddWithValue("@up", txtPassword.Text);
        con.Open();
        object usr=cmd.ExecuteScalar();
        if (usr != null)
        {
            Response.Write("Login succeded");
            Session["user"] = txtUsername.Text;
            Response.Redirect("SendMessage.aspx");
        }
        else 
        {
            Response.Write("there is no such a user");
        }
    }
}