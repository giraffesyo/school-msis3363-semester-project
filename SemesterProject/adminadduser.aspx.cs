using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class adminadduser : System.Web.UI.Page
    {
        private static int CompanyId;
        private static string CompanyName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Redirect back to main maangement page if we got here without a session variable for the company
                var loadedCompanyName = Session["managingCompanyName"];
                var loadedCompanyId = Session["managingCompanyId"];
                if (loadedCompanyId == null || loadedCompanyName == null)
                {
                    Response.Redirect("~/admin.aspx");
                }
                CompanyId = (int)loadedCompanyId;
                CompanyName = (string)loadedCompanyName;
            }
            // Set company label
            lblCompanyName.Text = CompanyName;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Redirect them backwards
            Response.Redirect("~/adminEmployees.aspx");
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // only process registration if we have a valid page
            if (Page.IsValid)
            {
                //get the values from the form
                String email = tbEmail.Text;
                // ensure the user doesn't already exist
                if (!UserManager.checkEmail(email))
                {
                    addUserAlert.Attributes["class"] = "alert alert-danger";
                    addUserAlert.InnerText = "An account already exists with that email.";
                }
                // Hash our passowrd
                String password = Password.HashPassword(tbPassword.Text);
                String first = tbFirstName.Text;
                String last = tbLastName.Text;
                String phone = tbPhoneNumber.Text;
                String title = tbTitle.Text;
                String department = tbDepartment.Text;
                bool newsletter = cbNewsletter.Checked;
                bool administrator = cbAdministrator.Checked;
                int UserId = UserManager.RegisterUser(email, password, first, last, phone, CompanyId, title, department, newsletter, administrator, cblTrainingPreferences);
                //If UserId != -1 then we succesfully created their account
                if (UserId != -1)
                {
                    //successfull response redirect
                    Response.Redirect("~/adminEmployees.aspx");
                }
                else
                {
                    // something went wrong
                    addUserAlert.InnerText = "There was a problem creating the account, please try again";
                }
            }
        }

    }
}
