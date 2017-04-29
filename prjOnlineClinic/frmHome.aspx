<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmHome.aspx.cs" Inherits="prjClinic.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="middle" align="center" >
  
    <asp:Label ID="lblSearchby" runat="server" Text="Search By" 
            Font-Names="Book Antiqua"  ForeColor="Teal"
     Font-Size="XX-Large" BorderColor="Black" Width="331px" Height="60px" 
            BorderStyle="None"></asp:Label>
    
    <asp:DropDownList ID="ddlArea" runat="server" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen"
     Font-Size="XX-Large" Height="60px" Width="250px" onselectedindexchanged="ddlArea_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Text="--Location--"></asp:ListItem>
    
    </asp:DropDownList>
    
    <asp:DropDownList ID="ddlSpeciality" runat="server" Font-Names="Book Antiqua"  ForeColor="LightSeaGreen" 
     Font-Size="XX-Large" Height="60px" Width="250px" onselectedindexchanged="ddlSpeciality_SelectedIndexChanged" >
    <asp:ListItem Text="--Speciality--"></asp:ListItem>
    </asp:DropDownList>
   
    <asp:Button ID="searchbtn" runat="server" Font-Names="Book Antiqua"  
            ForeColor="Teal" Font-Size="XX-Large"
     BorderColor="ActiveBorder" Text="Search" Width="300px" Height="60px" 
            onclick="searchbtn_Click" Enabled="False" />
   
   
   

 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer2" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
                 <asp:Image ID="Image1" runat="server" ImageUrl="~/images/2.jpg" style="z-index: 1; left: 10px; top: 229px;
                 position: absolute; height: 428px; width: 1569px;" />
   
                
            </ContentTemplate>
        </asp:UpdatePanel>

 </div>

</asp:Content>
