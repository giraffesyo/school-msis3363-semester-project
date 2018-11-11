﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class ChooseCompany : System.Web.UI.Page
    {

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            Session["ChosenCompany"] = ddlCompanyName.SelectedValue;
            Response.Redirect("~/Register.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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