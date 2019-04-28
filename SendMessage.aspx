<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                Chose Doctor
            </td>
            <td>
                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="adsUsers" 
                    DataTextField="userName" DataValueField="userName" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btnAdd" runat="server" CausesValidation="False" 
                    onclick="btnAdd_Click" Text="OK" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
                
    </table>
    <asp:AccessDataSource ID="adsUsers" runat="server" DataFile="~/data.mdb" 
        SelectCommand="SELECT [userName] FROM [tbl_Users]">
    </asp:AccessDataSource>
</asp:Content>

