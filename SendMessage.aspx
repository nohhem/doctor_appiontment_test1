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
                Chose User
            </td>
            <td>
                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="adsUsers" 
                    DataTextField="userName" DataValueField="userName">
                </asp:DropDownList>
                <asp:Button ID="btnAdd" runat="server" CausesValidation="False" 
                    onclick="btnAdd_Click" Text="Add" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                To</td>
            <td>
                <asp:TextBox ID="txtToUser" runat="server" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtToUser" ErrorMessage="Chose a User"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Subject</td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSubject" ErrorMessage="Write subject"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Content</td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" Height="63px" TextMode="MultiLine" 
                    Width="231px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtContent" ErrorMessage="Write Content"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style2">
                <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" 
                    Text="Send Message" />
            </td>
            <td class="style2">
            </td>
        </tr>
        
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Literal ID="ltrlMessage" runat="server"></asp:Literal>
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        
    </table>
    <asp:AccessDataSource ID="adsUsers" runat="server" DataFile="~/data.mdb" 
        SelectCommand="SELECT [userName] FROM [tbl_Users] WHERE ([userName] &lt;&gt; ?)">
        <SelectParameters>
            <asp:SessionParameter Name="userName" SessionField="user" Type="String" />
        </SelectParameters>
    </asp:AccessDataSource>
</asp:Content>

