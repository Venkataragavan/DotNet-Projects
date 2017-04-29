using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjClinic
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDocAdmin.aspx");
        }

        protected void btnClinic_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmClinicAdmin.aspx");

        }

        protected void btnDoctorTimings_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDoctimeAdmin.aspx");
        }
    }
}
