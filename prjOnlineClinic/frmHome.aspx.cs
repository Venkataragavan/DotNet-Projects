using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dllOperations;

namespace prjClinic
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        clsOperations objO = new clsOperations();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                SetImageUrl();
                ddlArea.Items.Clear();
               // int i = 0;
                ddlArea.Items.Add("--Location--");
                foreach (string item in objO.GetArea())
                {
                    ddlArea.Items.Add(item);
                }
            }
        }

        private void SetImageUrl()
        {
            Random rand = new Random();
            int i = rand.Next(2, 6);
            Image1.ImageUrl = "~/Images/" + i.ToString() + ".jpg";
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
                string area = ddlArea.Text;
                ddlSpeciality.Items.Clear();
                int i = 0;
                foreach (string item in objO.GetSpeciality(area))
                {
                    ddlSpeciality.Items.Insert(0, objO.GetSpeciality(area).ToList()[i].ToString());
                    i = i + 1;
                }
                Session.Add("Location",area);
                searchbtn.Enabled = true;
        }

        protected void ddlSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Specialization = ddlSpeciality.Text;
            //Session.Add("Specialization", Specialization);
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            string Specialization = ddlSpeciality.Text;
            Session.Add("Specialization", Specialization);
            Response.Redirect("frmDoctorDetails.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetImageUrl();
        }
    }
}
