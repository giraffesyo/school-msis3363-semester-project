using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class loggedin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbPreferences_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/preferences.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}