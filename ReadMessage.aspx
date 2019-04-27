<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReadMessage.aspx.cs" Inherits="ReadMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="adsShowMsg">
        <Columns>
         <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" />
            <asp:BoundField DataField="from_User" HeaderText="From" 
                SortExpression="from_User" />
            <asp:BoundField DataField="msg_Date" HeaderText="Date" 
                SortExpression="msg_Date" />
               
            <asp:BoundField DataField="msg_Subject" HeaderText="Subject" 
                SortExpression="msg_Subject" />
        </Columns>
    </asp:GridView>
    <asp:AccessDataSource ID="adsShowMsg" runat="server" DataFile="~/data.mdb" 
        SelectCommand="SELECT [from_User], [msg_Date], [msg_Subject], [ID] FROM [tbl_Messages] WHERE ([to_User] = ?)">
        <SelectParameters>
            <asp:SessionParameter Name="to_User" SessionField="user" Type="String" />
        </SelectParameters>
    </asp:AccessDataSource>
    <br />
    <br />
    <br />
    <br />
    </asp:Content>

