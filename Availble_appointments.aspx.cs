using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Calendar;
using BeforeCellRenderEventArgs = DayPilot.Web.Ui.Events.Navigator.BeforeCellRenderEventArgs;
using CommandEventArgs = DayPilot.Web.Ui.Events.CommandEventArgs;

public partial class Default2 : System.Web.UI.Page
{
    private DataTable _appointments;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCalendarData();
    }

    private void LoadCalendarData()
    {
        if(_appointments == null)
        {
            LoadAppointments();
        }

        OleDbConnection con = ConnectDB.getConStr();
        OleDbCommand AppointmentTable = new OleDbCommand("SELECT * FROM Appointment", con);
        OleDbDataAdapter da = new OleDbDataAdapter(AppointmentTable);
        con.Open();

        DayPilotCalendar1.DataSource = _appointments;
        DayPilotCalendar1.DataStartField = "AppointmentStart";
        DayPilotCalendar1.DataEndField = "AppointmentEnd";
        DayPilotCalendar1.DataIdField = "AppointmentId";
        DayPilotCalendar1.DataTextField = "AppointmentPatientName";
        DayPilotCalendar1.DataTagFields = "AppointmentStatus";
        DayPilotCalendar1.DataBind();
        DayPilotCalendar1.Update();


        con.Close();
    }
    private void LoadAppointments()
    {
        //Response.Write();
   
        int id = ConnectDB.LoadUserId(Session["Doctortoview"].ToString());
        _appointments = ConnectDB.LoadAppointments(id,DayPilotCalendar1.VisibleStart,DayPilotCalendar1.VisibleEnd);
    }

    protected void DayPilotCalendar1_OnCommand(object sender, CommandEventArgs e)
    {
        
    }

    protected void DayPilotCalendar1_OnTimeRangeSelected(object sender, TimeRangeSelectedEventArgs e)
    {
        /*
        int id = ConnectDB.LoadUserId(Session["Doctortoview"].ToString());
        ConnectDB.CreateAppointment(id, e.Start, e.End);
        LoadAppointments();
        LoadCalendarData();
        */
    }

    protected void DayPilotCalendar1_OnBeforeEventRender(object sender, BeforeEventRenderEventArgs e)
    {
        string status = e.Tag["AppointmentStatus"];
        

        switch (status)
        {
            case "free":
                e.DurationBarColor = "green";
                e.Html = "Available";
                e.ToolTip = "Click to Request This Time Slot";
                break;
            case "confirmed":
                e.DurationBarColor = "#f41616";
                e.Html = "the appointment, confirmed";
                break;
        }

    }

    protected void DayPilotCalendar1_OnEventMove(object sender, EventMoveEventArgs e)
    {
       
    }

    protected void DayPilotCalendar1_OnEventResize(object sender, EventResizeEventArgs e)
    {
     
    }
}