<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmDocAdmin.aspx.cs" Inherits="prjClinic.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="middle">
        <table>
            <tr>
                <td><asp:Label ID="lblDoctorID" runat="server" Text="Doctor ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td><asp:TextBox ID="txtDoctorID" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox>
                    <asp:DropDownList ID="ddlDoctorID" runat="server"  Font-Names="Book Antiqua"  
                        ForeColor="LightSeaGreen"  Font-Size="XX-Large" Height="60px" 
                        Width="286px" onselectedindexchanged="ddlDoctorID_SelectedIndexChanged">
                    <asp:ListItem Text="--Doctor ID--"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td><asp:Label ID="lblDoctorName" runat="server" Text="Doctor Name" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td><asp:TextBox ID="txtDoctorName" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblDoctorSpeciality" runat="server" Text="Doctor Speciality" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td><asp:TextBox ID="txtDoctorSpeciality" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblDoctorDescription" runat="server" Text="Doctor Description" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td><asp:TextBox ID="txtDoctorDescription" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblClinicID" runat="server" Text="Clinic ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td>
                <asp:DropDownList ID="ddlClinicID" runat="server" Font-Names="Book Antiqua"  
                        ForeColor="LightSeaGreen"  Font-Size="XX-Large" Height="60px" 
                        Width="286px" onselectedindexchanged="ddlClinicID_SelectedIndexChanged" 
                        AutoPostBack="True">
                    <asp:ListItem Text="--Clinic ID--"></asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnInsert" runat="server" onclick="btnInsert_Click" Text="Insert"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" />
                    
                    <asp:Button ID="btnInsertConfirm" runat="server" Text="Confirm Insert"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        onclick="btnInsertConfirm_Click"/>
                    
                </td>
                <td><asp:Button ID="btnUpdate" runat="server" onclick="lblUpdate_Click" Text="Update"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" />
                   
                    <asp:Button ID="btnUpdateConfirm" runat="server" Text="Confirm Update"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        onclick="btnUpdateConfirm_Click" />
                   
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblInsertDone" runat="server" Text="Insertion Done" 
                        Visible="False" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" 
                        Font-Size="XX-Large" Width="500px"></asp:Label></td>
                <td><asp:Label ID="lblUpdated" runat="server" Text="Updated" Visible="False" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
            </tr>
            <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                    Height="43px" Width="261px" onclick="btnCancel_Click" />
            </td>
            </tr>
            
    </table>
</div>
</asp:Content>
