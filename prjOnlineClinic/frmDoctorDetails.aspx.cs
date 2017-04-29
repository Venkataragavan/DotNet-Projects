using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllOperations;

namespace prjClinic
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageLoadFunction();
        }

        void pageLoadFunction()
        {
            try
            {

                string Location = Session["Location"].ToString();
                string Spec = Session["Specialization"].ToString();
                btnBook.Visible = false;
                btnPick.Visible = false;
                lblappointment.Visible = false;
                Label1.Visible = false;
            }
            catch
            {
                Response.Redirect("frmHome.aspx");
            }
        }

        private string getdate()
        {
            string date = cldDate.SelectedDate.ToShortDateString().ToString();
            return date;
        }

        protected void gvDocDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnPick.Visible = true;
            btnBook.Visible = true;
            if (cldDate.Visible == true)
                cldDate.Visible = false;
            else
                cldDate.Visible = true;
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            bookclickFunction();

        }

        void bookclickFunction()
        {
            try
            {
                Label1.Visible = false;
                lblappointment.Visible = false;
                string Location = Session["Location"].ToString();
                string Spec = Session["Specialization"].ToString();
                string DocName = gvDocDetails.SelectedRow.Cells[0].Text;
                string ClinicName = gvDocDetails.SelectedRow.Cells[1].Text;
                string Date = cldDate.SelectedDate.ToShortDateString(); ;
                
                clsOperations objO = new clsOperations();
                string strDocID = objO.GetDocID(DocName, Spec);
                Session.Add("DoctorName", DocName);
                Session.Add("ClinicName", ClinicName);
                Session.Add("DoctorID", strDocID);
                Session.Add("Date", Date);
                TimeSpan DocFromTime = objO.GetDocFromTime(strDocID, Date);
                DateTime DocToTime = objO.GetDocToTime(strDocID,Date);
                TimeSpan FTime = DocFromTime;
                TimeSpan DocETime = DocToTime.TimeOfDay;

                if (DocFromTime.Equals(DocETime))
                { 
                    string appState="DocBusy";
                    Session.Add("AppState", appState);
                }

                if ((Session["Testsession"] == "Logged in"))
                {
                    if (Session["AppState"] != "DocBusy")
                    {
                        if (objO.UpdateTime(strDocID, Date, FTime))
                        {
                            lblappointment.Text = "apoinmtment fixed";
                        }
                        else
                        {
                            lblappointment.Visible = true;
                            lblappointment.Text = "Sorry..Error occurred.Please try Again.";
                            cldDate.Focus();
                        }
                        string strClinicID = objO.GetClinicID(ClinicName, Location);
                        Session.Add("ClinicID", strClinicID);
                        string strAppointmentID = objO.generateAppID();
                        Session.Add("AppointmentID", strAppointmentID);
                        Session.Add("AppFromTime", DocFromTime);
                        TimeSpan onehour = new TimeSpan(1, 0, 0);
                        TimeSpan ETime = FTime.Add(onehour);
                        Session.Add("AppEndTime", ETime);

                        string AppID = Session["AppointmentID"].ToString();
                        string PatID = Session["PID"].ToString();
                        string ClinID = Session["ClinicID"].ToString();
                        string DocID = Session["DoctorID"].ToString();
                        DateTime DocDate = DateTime.Parse(Session["Date"].ToString());
                        TimeSpan FromTime = TimeSpan.Parse(Session["AppFromTime"].ToString());
                        TimeSpan EndTime = TimeSpan.Parse(Session["AppEndTime"].ToString());

                        objO.InsertInAppTable(AppID, PatID, DocID, ClinID, DocDate, FromTime, EndTime);
                        Response.Redirect("frmAppointment.aspx");
                    }
                    else
                    {
                        lblappointment.Visible = true;
                        lblappointment.Text = "Sorry..Doctor is Busy..Please choose another day";
                    }
                }
                else
                {
                    Response.Redirect("frmLogin.aspx");
                }
            }
            catch (Exception)
            {
                Label1.Visible = true;
                Label1.Text = "Select date again";
            }
        
        }


        protected void cldDate_SelectionChanged(object sender, EventArgs e)
        {
            btnBook.Visible = true;
            btnPick.Visible = true;

        }

        protected void btnPick_Click1(object sender, EventArgs e)
        {
            string date = cldDate.SelectedDate.ToShortDateString();
            DayRenderEventArgs a = null;
            DateTime date2 = Convert.ToDateTime(date);
            bool ares = cldDate_DayRender2(sender, a, date2);
            if (ares == true)
            {
                gvDocDetails.SelectedRow.ForeColor = System.Drawing.Color.LightSeaGreen;
                gvDocDetails.SelectedRow.Cells[4].Text = date.ToString();
                cldDate.Visible = false;
                btnBook.Visible = true;
                Label1.Text = "";
            }
            else
            {
                //Label1.Visible = true;
                //Label1.Text = "Invalid Date...Please choose 3 days from the current Date ";
                btnPick.Visible = true;
                btnBook.Visible = true;
            }
        }

        private bool cldDate_DayRender2(object sender, DayRenderEventArgs a, DateTime date)
        {

            bool bres = true;
            try
            {
                DateTime threedays = new DateTime(2016, 09, 30);
                DateTime plusthreedays = threedays.AddDays(3);
                if (date > plusthreedays)
                {
                    a.Day.IsSelectable = false;
                    a.Cell.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception)
            {
                bres = false;
            }
            return bres;
        }
        protected void cldDate_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime one = new DateTime(2016,10,01);
            DateTime two = new DateTime(2016,10,02);
            DateTime three = new DateTime(2016,10,03);

            if (e.Day.Date<= (DateTime.Now))
            { 
                e.Day.IsSelectable = false;
            }
            if (e.Day.Date == one || e.Day.Date == two || e.Day.Date == three)
            {
                e.Day.IsSelectable = true;
            }
            else
                e.Day.IsSelectable = false; 
        }
    }
}
