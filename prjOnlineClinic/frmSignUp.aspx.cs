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
    public partial class WebForm3 : System.Web.UI.Page
    {
        clsOperations objO = new clsOperations();
        clsPatient objP = new clsPatient();
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Visible = false;
            lblUserID.Visible = false;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            objP.PatientName = txtUserName.Text;
            objP.PatientPass = txtPassword.Text;
            objP.PatientPhone = txtPhoneno.Text;

            bool bres = true;
            bool ares = true;

            if (bres)
            {

                if (txtUserName.Text.Equals(""))
                {
                    lblResult.Text = "Username cannot be empty";
                    lblResult.Visible = true;
                    txtUserName.Focus();
                }
                if (txtPassword.Text.Equals(""))
                {
                    lblResult.Text = "Password cannot be empty";
                    lblResult.Visible = true;
                    txtUserName.Focus();
                }
                if (!(txtPassword.Text.Equals(txtRetype.Text)))
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Password Mismatch";
                    txtPassword.Focus();
                    txtRetype.Text = "";
                }
            }

            if (((txtUserName.Text.Equals("")==false) && (txtPassword.Text.Equals("")==false) && (txtPassword.Text.Equals(txtRetype.Text)==true)))
            {
                ares = false;
            }
            if (ares == false) 
            {
                if (objO.signup(objP.PatientName, objP.PatientPass, objP.PatientPhone))
                {
                    lblResult.Visible = true;
                    lblUserID.Visible = true;
                    lblResult.Text = "Registered successfully!";
                    lblUserID.Text = "Your USER ID is " + objO.UserID();
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtRetype.Text = "";
                    txtPhoneno.Text = "";
                    txtUserName.Enabled = false;
                    txtPassword.Enabled = false;
                    txtRetype.Enabled = false;
                    txtPhoneno.Enabled = false;
                    btnSignUp.Enabled = false;

                }
                else
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Failed";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}
