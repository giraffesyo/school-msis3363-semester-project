﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SemesterProject
{
    public partial class CTS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbPreferences_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/preferences.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            //Log the user out
            FormsAuthentication.SignOut();
            //Redirect them to the home page
            Response.Redirect("~/Default.aspx");
        }

        protected void lbAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin.aspx");
        }
    }
}
