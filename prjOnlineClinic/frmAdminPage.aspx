<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmAdminPage.aspx.cs" Inherits="prjClinic.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div id="middle">
       
        <h2 class="heading">ADMIN LOGIN</h2>
        
           
               <asp:Label ID="lblAdmin" runat="server" Text="Click on the tables you want to modify"
                Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:Label>
            <br />
            <br /><br />
            <table>
            <tr>
            
                <td><asp:Button ID="btnClinic" runat="server" onclick="btnClinic_Click" Text="Clinic Table" 
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="460px"/><br />
                    <br />
                </td>
                </tr>
                <tr>
                <td><asp:Button ID="btnDoctor" runat="server" onclick="btnDoctor_Click" Text="Doctor Table" 
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="460px"/>    <br />
                    <br />
                    </td>
                </tr>
                <tr>
                <td><asp:Button ID="btnDoctorTimings" runat="server" Text="Doctor Timings Table" 
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        onclick="btnDoctorTimings_Click" Width="460px"/></td>
            </tr>
        </table>
    </div>
   

</asp:Content>
