<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmAppointment.aspx.cs" Inherits="prjClinic.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 482px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="middle">
   
   <table align="center" style="width: 1287px; height: 364px; margin-left: 0px">
   <tr>
      <td class="style1" colspan="2"> <asp:Label ID="lblHeading" runat="server" Text="Your Appointment Details" Font-Names="Book Antiqua" ForeColor="LightSeaGreen"
      Font-Size="XX-Large" ></asp:Label></td>
   </tr>
   
   <tr>
    <td class="style1"><asp:Label ID="lblName" runat="server" Text="Patient Name" 
            Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Height="34px" Width="222px"></asp:Label></td>
    <td><asp:TextBox ID="txtName" runat="server" Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>
   
    <tr>
    <td class="style1"><asp:Label ID="lblDocName" runat="server" Text="Doctor Name" 
            Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="37px" Width="228px"></asp:Label></td>
    <td><asp:TextBox ID="txtDocName" runat="server" Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>
    
    <tr>
    <td class="style1"><asp:Label ID="lblClName" runat="server" Text="Clinic Name" 
            Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="37px" Width="262px"></asp:Label></td>
    <td><asp:TextBox ID="txtClName" runat="server" Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>

    <tr>    
    <td class="style1"><asp:Label ID="lblDate" runat="server" Text="Appointment Date" 
            Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="39px" Width="423px"></asp:Label></td>
    <td><asp:TextBox ID="txtDate" runat="server"  Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>
    
    <tr>
    <td class="style1"><asp:Label ID="lblStTime" runat="server" 
            Text="Appointment Start Time" Font-Names="Book Antiqua"  
            ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="41px" Width="412px"></asp:Label></td>
    <td><asp:TextBox ID="txtStTime" runat="server" Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>
    
    <tr>
    <td class="style1"><asp:Label ID="lblEndTime" runat="server" 
            Text="Appointment End Time" Font-Names="Book Antiqua"  
            ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="37px" Width="357px"></asp:Label></td>
    <td><asp:TextBox ID="txtEndTime" runat="server" Enabled="false" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
    </tr>
    
   </table>
   </div>
   

</asp:Content>
