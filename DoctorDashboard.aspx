<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DoctorDashboard.aspx.cs" Inherits="Default2" %><%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <DayPilot:DayPilotCalendar 
            runat="server" 
            ID="DayPilotCalendar1"
            ClientObjectName="dp"
            ClientIDMode="Static"
            ViewType="Week"
        
            OnCommand="DayPilotCalendar1_OnCommand"
            TimeRangeSelectedHandling="CallBack"
            OnTimeRangeSelected="DayPilotCalendar1_OnTimeRangeSelected"
            OnBeforeEventRender="DayPilotCalendar1_OnBeforeEventRender"
            EventClickHandling="JavaScript"
            EventClickJavaScript="edit(e);"
            EventMoveHandling="CallBack"
            OnEventMove="DayPilotCalendar1_OnEventMove"
            EventResizeHandling="CallBack"
            OnEventResize="DayPilotCalendar1_OnEventResize" style="top: 0px; left: 1px; height: 394px"
            />
    </div>
</asp:Panel>
    
    
<script>
    function edit(e) {    
    }
</script>
</asp:Content>

