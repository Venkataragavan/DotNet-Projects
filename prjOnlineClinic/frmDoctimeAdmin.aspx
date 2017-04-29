<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmDoctimeAdmin.aspx.cs" Inherits="prjClinic.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="middle">
    <table>
        <tr>
            <td ><asp:Label ID="lblDoctorID" runat="server" Text="Doctor ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDoctorID" runat="server" Font-Names="Book Antiqua"  
                        ForeColor="LightSeaGreen"  Font-Size="XX-Large" Height="60px" Width="286px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAvailableDate" runat="server" Text="Available Date" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
            <td><asp:TextBox ID="txtAvDate" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblStartTime" runat="server" Text="Start Time" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
            <td><asp:TextBox ID="txtDocSTime" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEndTime" runat="server" Text="End Time" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
            <td><asp:TextBox ID="txtDocETime" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Button ID="btnInsert" runat="server" onclick="btnInsert_Click" Text="Insert" 
            Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                    Width="250px"/></td>
           
            <td><asp:Label ID="lblInserted" runat="server" Text="Inserted" Visible="False" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
        </tr>
    </table>
    </div>
</asp:Content>
