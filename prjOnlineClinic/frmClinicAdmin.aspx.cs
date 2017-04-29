using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllClinic;

namespace prjClinic
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        clsClinic objC = new clsClinic();
        clsAdminClinic objAdC = new clsAdminClinic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lblUpdated.Visible = false;
            txtClinicID.Text = objAdC.GenerateNewClinicID();
            txtClinicID.Enabled = false;
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblInserted.Visible = false;
            txtClinicID.Visible = false;
            foreach (string item in objAdC.GetClinicID())
            {
                ddlClinicID.Items.Add(item);
            }
            ddlClinicID.Visible = true;
           
        }

        protected void btnInsertConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                lblUpdated.Visible = false;
                objC.ClinicID = txtClinicID.Text;
                objC.ClinicName = txtClinicName.Text;
                objC.ClinicLocation = txtClinicLocation.Text;
                bool bVal = true;
                if (bVal)
                {
                    if (txtClinicName.Text.Equals("") && bVal)
                    {
                        lblInserted.Text = "Clinic Name cannot be empty ";
                        lblInserted.Visible = true;
                        txtClinicName.Focus();
                        bVal = false;
                    }
                    if (txtClinicLocation.Text.Equals("") && bVal)
                    {
                        lblInserted.Text = "Location cannot be empty";
                        lblInserted.Visible = true;
                        txtClinicLocation.Focus();
                    }
                }
                if ((!txtClinicID.Text.Equals("")) && (!txtClinicName.Text.Equals("")) && (!txtClinicLocation.Text.Equals("")))
                {

                    if (objAdC.InsertClinic(objC))
                    {
                        lblInserted.Text = "Inserted Successfully";
                        lblInserted.Visible = true;
                        txtClinicLocation.Text = "";
                        txtClinicName.Text = "";

                    }
                    else
                    {
                        lblInserted.Text = "Sorry Cannot Insert";
                        lblInserted.Visible = true;
                        txtClinicLocation.Text = "";
                        txtClinicName.Text = "";

                    }
                }
            }
            catch (Exception)
            {
                lblInserted.Text = "Clinic Name is too long";
                lblInserted.Visible = true;
            }
        }

        protected void btnUpdateConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                lblInserted.Visible = false;
                clsClinic objC = new clsClinic();
                objC.ClinicID = ddlClinicID.Text;
                objC.ClinicName = txtClinicName.Text;
                objC.ClinicLocation = txtClinicLocation.Text;

                bool bVal = true;
                if (bVal)
                {
                    if (txtClinicName.Text.Equals("") && bVal)
                    {
                        lblUpdated.Text = "Clinic Name cannot be empty ";
                        lblUpdated.Visible = true;
                        txtClinicName.Focus();
                        bVal = false;
                    }
                    if (txtClinicLocation.Text.Equals("") && bVal)
                    {
                        lblUpdated.Text = "Location cannot be empty";
                        lblUpdated.Visible = true;
                        txtClinicLocation.Focus();
                    }
                }

                if ((!txtClinicName.Text.Equals("")) && (!txtClinicLocation.Text.Equals("")))
                {
                    if (objAdC.UpdateCommand(objC))
                    {
                        lblUpdated.Text = "Updated Successfully";
                        lblUpdated.Visible = true;
                        txtClinicLocation.Text = "";
                        txtClinicName.Text = "";
                    }
                    else
                    {
                        lblUpdated.Text = "Sorry Cannot Update";
                        lblUpdated.Visible = true;
                        txtClinicLocation.Text = "";
                        txtClinicName.Text = "";

                    }
                }
            }
            catch(Exception)
            {
                lblUpdated.Text = "Enter valid Details";
                lblUpdated.Visible = true;
            }
        }
    }
}
