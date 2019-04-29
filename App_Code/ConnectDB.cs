using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for ConnectDB
/// </summary>
public class ConnectDB
{
    public static OleDbConnection getConStr()
    {
        return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+HttpContext.Current.Server.MapPath("data.mdb"));
    }
	public ConnectDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void CreateAppointment (int id, DateTime start, DateTime end)
    {
        using (OleDbConnection con = ConnectDB.getConStr())
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO [Appointment] ([AppointmentStart], [AppointmentEnd], [DoctorId], [AppointmentStatus]) VALUES(@start, @end, @doctor,'free')", con);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.Parameters.AddWithValue("doctor", id);
            cmd.ExecuteNonQuery();
        }
    }
    public static DataTable LoadAppointments(int id, DateTime start, DateTime end)
    {
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Appointment] WHERE [DoctorId] = @doctor AND NOT (([AppointmentEnd] <= @start) OR ([AppointmentStart] >= @end))",getConStr());
        da.SelectCommand.Parameters.AddWithValue("doctor", id);
        da.SelectCommand.Parameters.AddWithValue("start", start);
        da.SelectCommand.Parameters.AddWithValue("end", end);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public static int LoadUserId(String username)
    {
        OleDbConnection conn = ConnectDB.getConStr();
        OleDbCommand cmd = new OleDbCommand("SELECT ID FROM tbl_Users WHERE userName=@un",conn);
        cmd.Parameters.Add("un", username);
        conn.Open();
        int id = (Int32)cmd.ExecuteScalar();
        conn.Close();
        return id;
    }
}