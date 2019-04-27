using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            OleDbConnection con = ConnectDB.getConStr();
            OleDbCommand cmd = new OleDbCommand("insert into tbl_Users(memberName,memberSurname,memberEmail,userName,userPassword)values(@mn,@ms,@me,@un,@up)", con);
            cmd.Parameters.AddWithValue("@mn", txtName.Text);
            cmd.Parameters.AddWithValue("@ms", txtSurname.Text);
            cmd.Parameters.AddWithValue("@me", txtEmail.Text);
            cmd.Parameters.AddWithValue("@un", txtusername.Text);
            cmd.Parameters.AddWithValue("@up", txtPassword.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("The record is added!<ahref='Default.aspx'>Go to login<a>");

        }
        catch (Exception ex1)
        {
            Response.Write(ex1.Message);
            
        }
        
    }
}