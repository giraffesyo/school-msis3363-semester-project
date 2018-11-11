using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SemesterProject
{
    public partial class Register : System.Web.UI.Page
    {
        private Int32 ChosenCompanyId;
        private String ChosenCompanyName;
        private Int32 ChosenCompanyEmployeeCount;

        // Our connection string is defined in Web.Config, retrieve it from there
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ChosenCompany"] == null)
            {
                // If we didn't choose a company go back to the choose company page
                Response.Redirect("~/ChooseCompany.aspx");
            }
            else
            {
                // Set Company ID to the value in our session variable
                ChosenCompanyId = Convert.ToInt32(Session["ChosenCompany"]);
                // Set the company name and employee count from the database, using our Company ID 
                SetCompanyInfo();
                // Set label to our company name
                lblCompanyName.Text = ChosenCompanyName;
                // Set label to our employee count
                lblEmployeeCount.Text = GetEmployeeCountString(ChosenCompanyEmployeeCount);
            }
        }

        private String GetEmployeeCountString(Int32 EmployeeCount)
        {
            // Return string based on number of employees
            return EmployeeCount > 500 ? "Over 500" :
                EmployeeCount > 100 ? "Over 100" :
                EmployeeCount > 50 ? "51-100" :
                EmployeeCount > 25 ? "26-50" :
                EmployeeCount > 10 ? "11-25" : "1-10";
        }

        //sets the company name and employeec ount from the sql database
        private void SetCompanyInfo()
        {
            //open stream 
            myConnection.Open();
            // Define select query with parameters inline
            const String query = "Select name, employeeCount from companies where id = @id";
            //Create the Select Command
            SqlCommand SelectCompanyNameCommand = new SqlCommand(query, myConnection);
            // set the parameters of @id to the ChosenCompanyId
            SelectCompanyNameCommand.Parameters.AddWithValue("@id", ChosenCompanyId);
            // create data reader from sql stream
            SqlDataReader reader = SelectCompanyNameCommand.ExecuteReader();
            // Load first result
            reader.Read();
            // Cast first result to record
            var record = (IDataRecord)reader;
            // Convert records (fields) and store them into instance variables
            ChosenCompanyName = record[0].ToString();
            ChosenCompanyEmployeeCount = Convert.ToInt32(record[1]);
            // Close SQL stream
            myConnection.Close();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // only submit the information if the page is valid
            if (Page.IsValid)
            {
                //get the values from the form
                String email = tbEmail.Text;
                String password = tbPassword.Text;
                String first = tbFirstName.Text;
                String last = tbLastName.Text;
                String phone = tbPhoneNumber.Text;
                String title = tbTitle.Text;
                String department = tbDepartment.Text;
                bool newsletter = cbNewsletter.Checked;
                // Create SQL connection
                myConnection.Open();
                // Create query
                const String query = "INSERT INTO users (email, password, firstName, lastName, phone, companyId, title, department, newsletter) VALUES (@email, @password, @firstName, @lastName, @phone, @companyId, @title, @department, @newsletter); SELECT SCOPE_IDENTITY()";
                // Create Insert Command
                SqlCommand InsertUserCommand = new SqlCommand(query, myConnection);
                // Add our parameters
                SqlParameterCollection Parameters = InsertUserCommand.Parameters;
                Parameters.AddWithValue("@email", email);
                Parameters.AddWithValue("@password", password);
                Parameters.AddWithValue("@firstName", first);
                Parameters.AddWithValue("@lastName", last);
                Parameters.AddWithValue("@phone", phone);
                Parameters.AddWithValue("@companyId", ChosenCompanyId);
                Parameters.AddWithValue("@title", title);
                Parameters.AddWithValue("@department", department);
                Parameters.AddWithValue("@newsletter", newsletter);
                // Execute command, creating the user, returns the id
                Int32 UserId = Convert.ToInt32(InsertUserCommand.ExecuteScalar());
                // Define the insert query for user interests
                const String userInterestsQuery = "INSERT INTO userInterests (userId, videoTopicId) VALUES (@userId, @videTopicId);";
                // Handle the user video interests preferences
                foreach (ListItem item in cblTrainingPreferences.Items)
                {
                    // only insert if the item is checked
                    if (item.Selected)
                    {
                        String selectedValue = item.Value;
                        // Create the sql command with our current connection and the above insert query
                        SqlCommand InsertUserInterests = new SqlCommand(userInterestsQuery, myConnection);
                        // Get our parameter list
                        SqlParameterCollection userInterestParameters = InsertUserInterests.Parameters;
                        // Add this user to query
                        userInterestParameters.AddWithValue("@userId", UserId);
                        // Add the selected value ( checked box) to the query
                        userInterestParameters.AddWithValue("@videoTopicId", selectedValue);
                    }
                }
                //Close our sql connection
                myConnection.Close();
            }

            //successfull response redirect
            Response.Redirect("~/clients.aspx");
            }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}