using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SemesterProject
{
    public partial class edituser : System.Web.UI.Page
    {
        private static adminEmployees.Employee employee;

        private SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // load employee from session state or redirect backwards if we don't have one
                var loadedEmployee = Session["managingEmployee"];
                var loadedCompanyName = Session["managingCompanyName"];
                if (loadedEmployee == null || loadedCompanyName == null)
                {
                    // Both of these can redirect to same place because managing company is handled there
                    Response.Redirect("~/adminEmployees.aspx");
                }
                employee = (adminEmployees.Employee)loadedEmployee;

                // Fill in the current values for the form
                lblCompanyName.Text = loadedCompanyName.ToString();
                lblPageTitle.Text = "Updating user " + employee.email;
                tbEmail.Text = employee.email;
                tbFirstName.Text = employee.firstName;
                tbLastName.Text = employee.lastName;
                tbPhoneNumber.Text = employee.phone;
                tbTitle.Text = employee.title;
                tbDepartment.Text = employee.department;
                cbNewsletter.Checked = employee.newsletter;
                cbAdministrator.Checked = employee.administrator;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Send them back to manage emplyoees screen
            Response.Redirect("~/adminEmployees.aspx");
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // get the values from the form
                string formEmail = tbEmail.Text;
                string formFirstName = tbFirstName.Text;
                string formLastName = tbLastName.Text;
                string formPhoneNumber = tbPhoneNumber.Text;
                string formJobTitle = tbTitle.Text;
                string formDepartment = tbDepartment.Text;
                bool formNewsletter = cbNewsletter.Checked;
                bool formAdminitrator = cbAdministrator.Checked;

                // call the update function with the information gathered from the form
                int updateResponse = UserManager.updateUser(employee.id, employee.email, formEmail, formFirstName, formLastName, formPhoneNumber, formJobTitle, formDepartment, formNewsletter, formAdminitrator, cblTrainingPreferences);
                if (updateResponse == UserManager.SUCCESS)
                {
                    // we should update the employee object in case they update the email and then want to continue changing things
                    // (since we use it right above this line)
                    employee.email = formEmail;
                    // Show success alert
                    lblStatus.Attributes["class"] = "alert alert-success";
                    lblStatus.InnerText = "Successfully updated user!";
                }
                else if (updateResponse == UserManager.EMAIL_IN_USE)
                {
                    lblStatus.Attributes["class"] = "alert alert-danger";
                    lblStatus.InnerText = "That email is already in use by someone else.";
                }
                else
                {
                    lblStatus.Attributes["class"] = "alert alert-danger";
                    lblStatus.InnerText = "There was a problem updating this user, please try again.";
                }
            }
            else
            {
                // page isnt valid, show error
                lblStatus.Attributes["class"] = "alert alert-danger";
                lblStatus.InnerText = "Check the form is filled out correctly then try again.";
            }
        }

        protected void cblTrainingPreferences_DataBound(object sender, EventArgs e)
        {
            // we need to get the checked user interests from the database
            try
            {
                CTSDatabase.Open();
                const string SelectUserInterestsQuery = "SELECT videoTopicId FROM userInterests where userId = @userId;";
                SqlCommand SelectUserInterests = new SqlCommand(SelectUserInterestsQuery, CTSDatabase);
                SelectUserInterests.Parameters.AddWithValue("@userId", employee.id);
                SqlDataReader userInterests = SelectUserInterests.ExecuteReader();

                while (userInterests.Read())
                {
                    //Get current item that IS selected
                    // subtracting one to mmake it similar to array index 
                    int selectedInterest = Convert.ToInt32(userInterests[0]) - 1;

                    System.Diagnostics.Debug.WriteLine("Index: " + selectedInterest);
                    //Mark it checked
                    cblTrainingPreferences.Items[selectedInterest].Selected = true;
                }
            }
            catch (SqlException sex)
            {
                //Sql Exception
                System.Diagnostics.Debug.WriteLine("Sql Error Number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("Sql Error Message: " + sex.Message);
            }
            catch (Exception ex)
            {
                //General exception
                System.Diagnostics.Debug.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                CTSDatabase.Close();
            }
        }
    }
}
