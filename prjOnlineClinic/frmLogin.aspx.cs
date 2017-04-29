using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllOperations;
using dllPatient;
using System.Data;
using System.Data.SqlClient;


namespace prjClinic
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string test = "Logged in";
        string test2 = "Not Logged in";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session.Add("TestSession", test2);
            lblStatus.Visible = false;
            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            btnLoginClick();
        }

        void btnLoginClick()
        {
            Session.Add("TestSession", test2);

            clsPatient objP = new clsPatient();
            clsOperations objO = new clsOperations();
            objP.PatientID = txtUserName.Text;
            objP.PatientPass = txtPassword.Text;
            

            if (objO.LoginValid(objP.PatientID, objP.PatientPass))
            {
                Session.Add("TestSession", test);

                if ((txtUserName.Text.Equals("P001")) && (txtPassword.Text.Equals("srin")))
                {
                    string strAdmin = "Admin Login";
                    Session.Add("ADMIN", strAdmin);
                    Response.Redirect("frmAdminPage.aspx");


                }

                lblStatus.Text = "Successful Login";
                
               
                
                SqlConnection con = new SqlConnection(@"Data Source =INCHOL0278844\DOTNETCON; user id= sa; password=system;Initial Catalog=dbClinic");
                SqlCommand cmd = new SqlCommand("Select vcPatient_Name from tblPatient where cPatient_ID=@PatientID", con);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();
                cmd.Parameters.Add("@PatientID", SqlDbType.Char, 4);
                cmd.Parameters[0].Value = objP.PatientID;

                string PatientName = cmd.ExecuteScalar().ToString();
                con.Close();

                Session.Add("PatName", PatientName);

                Session.Add("Testsession", test);
                Session.Add("PID", objP.PatientID);
                if (Session["Testsession"] == "Logged in" && Session["Location"] != null)
                    Response.Redirect("frmDoctorDetails.aspx");
                else if (Session["Testsession"] == "Logged in")
                    Response.Redirect("frmHome.aspx");

                else
                    Response.Redirect("frmAppointment.aspx");

                
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Check login credentials again";
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSignUp.aspx");
        }
    }
}

