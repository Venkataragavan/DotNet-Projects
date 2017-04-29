<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmDoctorDetails.aspx.cs" Inherits="prjClinic.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="middle">
    <asp:GridView ID="gvDocDetails" runat="server" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" 
        onselectedindexchanged="gvDocDetails_SelectedIndexChanged" 
        BorderColor="Gray" BorderStyle="Groove" BorderWidth="2px" 
        ForeColor="Black" >
        <Columns>
            <asp:BoundField DataField="vcDoctor_Name" HeaderText="Doctor Name" 
                SortExpression="vcDoctor_Name" />
            <asp:BoundField DataField="vcClinic_Name" HeaderText="Clinic Name" 
                SortExpression="vcClinic_Name" />
            <asp:BoundField DataField="vcDoctor_Desc" HeaderText="Doctor Description" 
                SortExpression="vcDoctor_Desc" />
            <asp:BoundField DataField="vcSpeciality" HeaderText="Speciality" 
                SortExpression="vcSpeciality" />
            <asp:CommandField HeaderText="Date" SelectText="Show/Hide Calendar" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:dbClinicConnectionString %>" 
    
        SelectCommand="sp_GetDocDetails" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:SessionParameter Name="Locations" SessionField="Location" Type="String" />
        <asp:SessionParameter Name="Speciality" SessionField="Specialization" 
            Type="String" />
    </SelectParameters>
</asp:SqlDataSource>


    <table align="center">
     
    <tr><td>
    <asp:Calendar ID="cldDate" runat="server" BackColor="White" BorderColor="Black" 
        DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" 
        ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" 
        Visible="False" Width="400px" 
        onselectionchanged="cldDate_SelectionChanged" 
        ondayrender="cldDate_DayRender">
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" 
            Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TodayDayStyle BackColor="#CCCC99" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" 
            ForeColor="#333333" Height="10pt" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" 
            ForeColor="White" Height="14pt" />
    </asp:Calendar>
    </td></tr>
    
    
   
    <tr>
    <td><asp:Button ID="btnPick" runat="server" onclick="btnPick_Click1" Text="Pick Date" Font-Names="Book Antiqua"  
    ForeColor="Teal" Font-Size="XX-Large" BorderColor="ActiveBorder" Width="399px" Height="60px"  />
    </td></tr>
    
    <tr><td><asp:Button ID="btnBook" runat="server" onclick="btnBook_Click" 
        Text="Book Appointment" Font-Names="Book Antiqua"  ForeColor="Teal" 
            Font-Size="XX-Large" BorderColor="ActiveBorder"
        Width="398px" Height="60px" />
    
     </td></tr>
    
    <tr><td align="center"><asp:Label  ID="Label1" runat="server" Text="Date availability Status" Font-Names="Book Antiqua"  ForeColor="Teal" 
    Font-Size="Large" BorderColor="ActiveBorder" Width="300px" Height="60px"></asp:Label></td></tr>
    
    <tr><td align="center"><asp:Label ID="lblappointment" runat="server" Text="Appointment Status" 
            Font-Names="Book Antiqua"  ForeColor="Teal" 
    Font-Size="Large" BorderColor="ActiveBorder" Width="300px" Height="60px" ></asp:Label></td></tr>
   
    </table>
    
    
</div>
</asp:Content>
