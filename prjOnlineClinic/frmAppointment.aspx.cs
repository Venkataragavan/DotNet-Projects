using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace prjClinic
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            appointmentFunction();
        }

        void appointmentFunction()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source =INCHOL0278844\DOTNETCON; user id= sa; password=system;Initial Catalog=dbClinic");
                SqlCommand cmd = new SqlCommand("Select vcPatient_Name from tblPatient where cPatient_ID=@PatientID", con);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();
                cmd.Parameters.Add("@PatientID", SqlDbType.Char, 4);
                cmd.Parameters[0].Value = Session["PID"].ToString();

                string PatientName = cmd.ExecuteScalar().ToString();
                con.Close();
                Session.Add("PatName", PatientName);

                txtName.Text = PatientName;
                txtDocName.Text = Session["DoctorName"].ToString();
                txtClName.Text = Session["ClinicName"].ToString();
                txtDate.Text = Session["Date"].ToString();
                txtStTime.Text = Session["AppFromTime"].ToString();
                txtEndTime.Text = Session["AppEndTime"].ToString();
            }
            catch (Exception)
            {
                txtDocName.Text = "Invalid";
            }
        }
    }
}
