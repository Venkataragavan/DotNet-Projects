using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllDoctorDetails;

namespace prjClinic
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        clsDoctorDetails objD = new clsDoctorDetails();
        clsDocAdmin objDA = new clsDocAdmin(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlClinicID.Items.Clear();
            //ddlDoctorID.Items.Clear();
            if (!IsPostBack)
            {
                ddlDoctorID.Visible = false;
                txtDoctorID.Visible = true;
                txtDoctorName.Enabled = false;
                txtDoctorSpeciality.Enabled = false;
                ddlClinicID.Enabled = false;
                txtDoctorDescription.Enabled = false;
                btnInsertConfirm.Enabled = false;
                btnUpdateConfirm.Enabled = false;
                ddlClinicID.Items.Add("--Clinic ID--");
                foreach (string item in objDA.GetClinicID())
                {
                    ddlClinicID.Items.Add(item);
                }

                //foreach (string item in objDA.GetDoctorID())
                //{
                //    ddlDoctorID.Items.Add(item);
                //}
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            txtDoctorID.Visible = true;
            txtDoctorID.Text = "";
            txtDoctorName.Text = "";
            txtDoctorSpeciality.Text = "";
            txtDoctorDescription.Text = "";

            txtDoctorName.Enabled = true;
            txtDoctorSpeciality.Enabled = true;
            txtDoctorDescription.Enabled = true;

            ddlClinicID.Enabled = true;

            btnUpdate.Visible = false;
            btnUpdateConfirm.Visible = false;
            ddlDoctorID.Visible = false;
            btnInsertConfirm.Enabled = true;
            btnInsert.Enabled = false;

            txtDoctorID.Text = objDA.GenerateNewDocID();
            txtDoctorID.Enabled = false;

        }

        protected void lblUpdate_Click(object sender, EventArgs e)
        {
            txtDoctorID.Visible = false;
            txtDoctorName.Text = "";
            txtDoctorSpeciality.Text = "";
            txtDoctorDescription.Text = "";

            txtDoctorName.Enabled = true;
            txtDoctorSpeciality.Enabled = true;
            txtDoctorDescription.Enabled = true;

           
            lblInsertDone.Visible = false;
            btnInsert.Visible = false;

            btnInsertConfirm.Visible = false;

            ddlDoctorID.Visible = true;
            ddlClinicID.Enabled = true;

            btnUpdateConfirm.Enabled = true;
            btnUpdate.Enabled = false;
       }

        protected void btnInsertConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                objD.DoctorID = txtDoctorID.Text;
                objD.DoctorName = txtDoctorName.Text;
                objD.DoctorSpeciality = txtDoctorSpeciality.Text;
                objD.DoctorDesc = txtDoctorDescription.Text;
                objD.ClinicID = ddlClinicID.Text;
                btnUpdate.Visible = false;
                btnUpdateConfirm.Visible = false;
                ddlDoctorID.Visible = false;


                bool bRes = true;

                if(bRes)
                {
                    if (txtDoctorName.Text.Equals("")&& bRes)
                    {
                        lblInsertDone.Text = "Doctor Name cannot be empty";
                        lblInsertDone.Visible = true;
                        txtDoctorName.Focus();
                        bRes = false;
                    }

                    if (txtDoctorSpeciality.Text.Equals("")&&bRes)
                    {
                        lblInsertDone.Text = "Doctor Speciality cannot be empty";
                        lblInsertDone.Visible = true;
                        txtDoctorSpeciality.Focus();
                        bRes = false;
                    }

                    if (txtDoctorDescription.Text.Equals("")&&bRes)
                    {
                        lblInsertDone.Text = "Doctor Description cannot be empty ";
                        lblInsertDone.Visible = true;
                        txtDoctorDescription.Focus();

                     }
                }
                if((!txtDoctorName.Text.Equals(""))&&(!txtDoctorSpeciality.Text.Equals(""))&&(!txtDoctorDescription.Text.Equals("")))
                {
                    if (objDA.InsertDoc(objD))
                    {
                        lblInsertDone.Text = "Inserted successfully";
                        lblInsertDone.Visible = true;
                        txtDoctorID.Enabled = false;
                        ddlDoctorID.Enabled = false;
                        ddlClinicID.Enabled = false;

                        Cancel();

                        txtDoctorName.Enabled = false;
                        txtDoctorSpeciality.Enabled = false;
                        txtDoctorDescription.Enabled = false;
                    }
                    else
                    {
                        lblInsertDone.Visible=true;
                        lblInsertDone.Text="Sorry Cannot Insert";

                    }
                }
            }
            catch (Exception)
            {
                lblInsertDone.Text = "Clinic ID is not available";
                lblInsertDone.Visible = true;
            }
        }

        protected void btnUpdateConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                lblUpdated.Visible = false;
                ddlDoctorID.Visible = true;
                txtDoctorID.Visible = false;
                //clsDoctorDetails objD = new clsDoctorDetails();
                objD.DoctorID=ddlDoctorID.SelectedValue.ToString();
                //objD.DoctorID = ddlDoctorID.Text;
                objD.DoctorName = txtDoctorName.Text;
                objD.DoctorSpeciality = txtDoctorSpeciality.Text;
                objD.DoctorDesc = txtDoctorDescription.Text;
                objD.ClinicID = ddlClinicID.Text;

                bool bRes = true;
                if (bRes)
                {
                    if (txtDoctorName.Text.Equals("") && bRes)
                    {
                        lblUpdated.Text = "Doctor Name cannot be empty";
                        lblUpdated.Visible = true;
                        txtDoctorName.Focus();
                        bRes = false;
                    }

                    if (txtDoctorSpeciality.Text.Equals("") && bRes)
                    {
                        lblUpdated.Text = "Doctor Speciality cannot be empty";
                        lblUpdated.Visible = true;
                        txtDoctorSpeciality.Focus();
                        bRes = false;
                    }

                    if (txtDoctorDescription.Text.Equals("") && bRes)
                    {
                        lblUpdated.Text = "Doctor Description cannot be empty ";
                        lblUpdated.Visible = true;
                        txtDoctorDescription.Focus();
                    }
                }


                if ((!txtDoctorName.Text.Equals("")) && (!txtDoctorSpeciality.Text.Equals("")) && (!txtDoctorDescription.Text.Equals("")))
                {

                    if (objDA.UpdateCommand(objD))
                    {
                        lblUpdated.Text = "Updated successfully";
                        lblUpdated.Visible = true;

                        ddlDoctorID.Visible = false;
                        txtDoctorID.Visible = false;

                        txtDoctorDescription.Enabled = false;
                        txtDoctorName.Enabled = false;
                        txtDoctorSpeciality.Enabled = false;

                        ddlClinicID.Enabled = false;

                        Cancel();

                    }
                    else
                    {
                        lblUpdated.Text = "SORRY CANT UPDATE";
                        lblUpdated.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                lblUpdated.Text = "Sorry exception occured";
                lblUpdated.Visible = true;
            }
        }

        protected void ddlDoctorID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlClinicID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clinicid = ddlClinicID.Text;
            foreach(string item in objDA.GetDoctorID(clinicid))
            {
                ddlDoctorID.Items.Add(item);
            }
        }
        protected void Cancel()
        {
            ddlDoctorID.Visible = false;
            txtDoctorID.Visible = false;
            txtDoctorName.Enabled = false;
            txtDoctorSpeciality.Enabled = false;
            ddlClinicID.Enabled = false;
            txtDoctorDescription.Enabled = false;

            btnInsert.Visible = true;
            btnInsert.Enabled = true;

            btnInsertConfirm.Visible = true;
            btnInsertConfirm.Enabled = false;

            btnUpdate.Visible = true;
            btnUpdate.Enabled = true;

            btnUpdateConfirm.Visible = true;
            btnUpdateConfirm.Enabled = false;
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        protected void btnInsertConfirm_Click1(object sender, EventArgs e)
        {

        }
    }
}
