using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllOperations;
using dllPatient;

namespace prjClinic
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnLogOut.Visible = false;
            if (Session["Testsession"] == "Logged in")
            {
                if (Session["ADMIN"] == "Admin Login")
                {
                    btnLoginSignup.Text = "Logged in as Admin";
                    btnLoginSignup.Enabled = false;
                        btnLogOut.Visible = true;
                }

                    try
                    {
                        string strPatName = Session["PatName"].ToString();
                        btnLoginSignup.Text = "Welcome " + strPatName;

                        btnLoginSignup.Enabled = false;
                        btnLogOut.Visible = true;
                    }
                    catch (Exception)
                    {
                        
                    }
                
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHome.aspx");
        }
        protected void btnLoginSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAboutUs.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("frmHome.aspx");
        }
    }
}
