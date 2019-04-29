using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
public partial class SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {


        String user = ddlUsers.Text;
        Response.Write("there is no such a Doctor "+user);

        OleDbConnection con = ConnectDB.getConStr();
        OleDbCommand cmd = new OleDbCommand("select username from tbl_Users where username=@un", con);
        cmd.Parameters.AddWithValue("@un", ddlUsers.Text);
       // cmd.Parameters.AddWithValue("@up", txtPassword.Text);
        con.Open();
        object usr = cmd.ExecuteScalar();
        if (usr != null)
        {
            Response.Write("Login succeded");
            Session["Doctortoview"] = ddlUsers.Text;
            Response.Redirect("Availble_appointments.aspx");
        }
        else
        {
            Response.Write("there is no such a Doctor");
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

        /*
        OleDbConnection con = ConnectDB.getConStr();
        OleDbCommand cmd = new OleDbCommand("insert into tbl_Messages (msg_Subject,msg_Content,msg_Date,from_User,to_User) values (@s,@c,@d,@f,@t)",con);
        cmd.Parameters.AddWithValue("@s",txtSubject.Text);
        cmd.Parameters.AddWithValue("@c", txtContent.Text);
        cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString());
        cmd.Parameters.AddWithValue("@f", Session["user"].ToString());
        cmd.Parameters.AddWithValue("@t", txtToUser.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        ltrlMessage.Text = "Succesfull";
        con.Close();
        */

    }



    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}