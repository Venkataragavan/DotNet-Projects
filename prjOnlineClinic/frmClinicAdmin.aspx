<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmClinicAdmin.aspx.cs" Inherits="prjClinic.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="middle" align="center">
        <table>
            <tr>
                <td ><asp:Label ID="lblClinicID" runat="server" Text="Clinic ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="630px"></asp:Label></td>
                <td><asp:TextBox ID="txtClinicID" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox>
                    <asp:DropDownList ID="ddlClinicID" runat="server" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen"
                        Font-Size="XX-Large" Height="60px" Width="250px" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td ><asp:Label ID="lblClinicName" runat="server" Text="Clinic name" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="630px"></asp:Label></td>
                <td><asp:TextBox ID="txtClinicName" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td ><asp:Label ID="lblClinicLocation" runat="server" Text="Clinic Location" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="630px"></asp:Label></td>
                <td><asp:TextBox ID="txtClinicLocation" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="btnInsert_Click" 
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="370px"/></td>
                
                <td>    
                    <asp:Button ID="btnInsertConfirm" runat="server" Text="Confirm Insert"
                    Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        onclick="btnInsertConfirm_Click" Width="380px" />
                 </td> 
            </tr>
            
            <tr>    
                <td><asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click"
                Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="370px" /></td>
                
                <td>    
                    <asp:Button ID="btnUpdateConfirm" runat="server" Text="Confirm Update"
                    Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        onclick="btnUpdateConfirm_Click" Width="380px" />
                </td>
             </tr>
            
            <tr>    
                <td ><asp:Label ID="lblInserted" runat="server" Text="Insertion Done" 
                        Visible="False" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="630px"></asp:Label></td>
                <td><asp:Label ID="lblUpdated" runat="server" Text="Updated" Visible="False" 
                        Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
                        Width="630px"></asp:Label></td>
                
            </tr>
            
        </table>
    </div>

</asp:Content>
