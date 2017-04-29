using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllDoctorTimings;
using dllDoctorDetails;

namespace prjClinic
{
    public partial class WebForm11 : System.Web.UI.Page
    {
      
        clsDoctorTimings objDT = new clsDoctorTimings();
        clsDoctimeAdmin objDTA = new clsDoctimeAdmin(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string item in objDTA.GetDoctorID())
            {
                ddlDoctorID.Items.Add(item);
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                clsDoctorTimings objDT = new clsDoctorTimings();
                clsDoctimeAdmin objDTA = new clsDoctimeAdmin();
                objDT.DoctorID = ddlDoctorID.Text;
                
                objDT.AvDate = DateTime.Parse(txtAvDate.Text);
                if (txtAvDate.Text.Equals(""))
                {
                    lblInserted.Text = "Doctor Available Date Cannot be Empty";
                    lblInserted.Visible = true;
                    txtAvDate.Focus();
                }
                objDT.DocSTime = TimeSpan.Parse(txtDocSTime.Text);
                objDT.DocETime = TimeSpan.Parse(txtDocETime.Text);


                bool bRes = true;
                if (bRes)
                {
                    if (txtAvDate.Text.Equals("") && bRes)
                    {
                        lblInserted.Text = "Doctor Available Date Cannot be Empty";
                        lblInserted.Visible = true;
                        txtAvDate.Focus();
                        bRes = false;
                    }
                    if (txtDocSTime.Text.Equals("") && bRes)
                    {
                        lblInserted.Text = "Doctor Start Time cannot be Empty";
                        lblInserted.Visible = true;
                        txtDocSTime.Focus();
                        bRes = false;
                    }
                    if (txtDocETime.Text.Equals("") && bRes)
                    {
                        lblInserted.Text = "Doctor End Time cannot be Empty";
                        lblInserted.Visible = true;
                        txtDocETime.Focus();
                        bRes = false;
                    }
                    // if()
                    //{
                    //    lblInserted.Text="Doctor Timing is INVALID";
                    //    lblInserted.Visible=true;
                    //}

                }

                if ((!txtAvDate.Text.Equals("")) && (!txtDocSTime.Text.Equals("")) && (!txtDocETime.Text.Equals("")))
                {

                    if (objDTA.InsertDoctime(objDT))
                    {
                        lblInserted.Text = "Inserted Successfully";
                        lblInserted.Visible = true;
                    }
                    else
                    {
                        lblInserted.Text = "Sorry cannot Insert";
                        lblInserted.Visible = true;
                    }
                }
            }
             catch(ArgumentException)
            {
                lblInserted.Text = "Invalid Details";
                lblInserted.Visible = true;
             }
            catch(InvalidTimeZoneException)
            {
                lblInserted.Text = "Invalid Date ";
                lblInserted.Visible = true;
            }

            catch (TimeZoneNotFoundException)
            {
                lblInserted.Text = "Invalid Time Format";
                lblInserted.Visible = true;
            }
            catch (Exception)
            {
                lblInserted.Text = "Please enter a Valid Date and Time";
                lblInserted.Visible = true;
            }
            
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    objDT.DoctorID = txtDoctorID.Text;
        //    objDT.AvDate = DateTime.Parse(txtAvDate.Text);
        //    objDT.DocSTime = TimeSpan.Parse(txtDocSTime.Text);
        //    objDT.DocETime = TimeSpan.Parse(txtDocETime.Text);

        //    if (objDTA.UpdateCommand(objDT))
        //    {
        //        lblUpdate.Visible = true;
        //    }
        //    else
        //    {
        //        lblUpdate.Text = "SORRY CANT UPDATE";
        //    } 
        //}
    }
}
