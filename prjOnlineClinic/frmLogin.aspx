


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="prjClinic.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id="middle">
    <table>
    <tr>
    <td><asp:Label ID="lblUserName" runat="server" Text="User ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="16px" Width="200px"></asp:Label></td>
        
    <td align="justify"><asp:TextBox ID="txtUserName" runat="server"  Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" >
                        </asp:TextBox><br /></td>
    </tr> 
    
    <tr>
    <td><asp:Label ID="lblPassword" runat="server" Text="Password" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large"
        Height="16px" Width="200px" ></asp:Label></td>
    <td><asp:TextBox ID="txtPassword" runat="server"  Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" TextMode="Password" >
        </asp:TextBox><br /></td>
    
    </tr>
   
    <tr>
    
    <td><asp:Button ID="btnLogin" runat="server"  Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"
            Text="Login" onclick="btnLogin_Click" /></td>
    <td><asp:Button ID="btnSignUp" runat="server"  Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large"
            Text="SignUp" onclick="btnSignUp_Click" /></td>
    </tr>
    
    <tr>
    <td> <asp:Label ID="lblStatus" runat="server" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" 
        Text="Login Status"></asp:Label> </td>
    </tr>
    </table>
    
</div>

</asp:Content>
