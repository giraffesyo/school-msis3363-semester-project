using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class preferences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clients.aspx");
        }

        protected void btnSavePreferences_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clients.aspx");
        }
    }
}