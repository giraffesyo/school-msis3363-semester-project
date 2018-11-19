using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class ChooseCompany : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect logged in users to the portal page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/clients.aspx");
            }
        }

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            Session["ChosenCompany"] = ddlCompanyName.SelectedValue;
            Response.Redirect("~/Register.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Redirec to clients page on cancel button clicked
            Response.Redirect("~/clients.aspx");
        }

        protected void ddlCompanyName_DataBound(object sender, EventArgs e)
        {
            //if we have no companies, redirect to the company add page 
            if (ddlCompanyName.Items.Count == 0)
            {
                Response.Redirect("~/RegisterCompany.aspx");
            }
        }


    }
}