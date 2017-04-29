<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="prjClinic.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="middle">
    <div>
    <table>
    <tr>
    <td><asp:Label ID="lblUserName" runat="server" Text="User Name"  Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:Label></td>
    <td><asp:TextBox ID="txtUserName" runat="server"  Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:TextBox><br /></td>
    </tr>
    
    <tr>
    <td><asp:Label ID="lblPassword" runat="server" Text="Password" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" ></asp:Label></td>
    <td><asp:TextBox ID="txtPassword" runat="server"  Font-Names="Book Antiqua"  
            ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" 
            TextMode="Password"></asp:TextBox><br /></td>
    </tr>
    
    <tr>
    <td><asp:Label ID="lblRetype" runat="server" Text="Re Type Password" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" ></asp:Label></td>
    <td><asp:TextBox ID="txtRetype" runat="server"  Font-Names="Book Antiqua"  
            ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" 
            TextMode="Password"></asp:TextBox><br /></td>
    </tr>
    
    <tr>
    <td><asp:Label ID="lblPhoneno" runat="server" Text="Phone No" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" ></asp:Label></td>
    <td><asp:TextBox ID="txtPhoneno" runat="server"  Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px"></asp:TextBox><br /></td>
    </tr>
    
    <tr>
    <td>
    <asp:Button ID="btnSignUp" runat="server" Font-Names="Book Antiqua" ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" Text="SignUp" 
    onclick="btnSignUp_Click" /></td>
    <td><asp:Button ID="btnLogin" runat="server" Text="Login" 
            Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" 
            onclick="btnLogin_Click"/></td>
    </tr>
    
    <tr>
    <td ><asp:Label ID="lblResult" runat="server" Text="Sign Up Status" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" Enabled="false"></asp:Label></td>
    <td><asp:Label ID="lblUserID" runat="server" Text="User ID" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" Font-Size="XX-Large" Width="500px" Enabled="false"></asp:Label></td>
    </tr>
    
    </table>
    </div>
    </div>



</asp:Content>
