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
    public partial class careers : System.Web.UI.Page
    {
        SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitApplication_Click(object sender, EventArgs e)
        {
            // ensure that the page is valid
            if (Page.IsValid)
            {
                // retrieve the values from the form
                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string email = tbEmail.Text;
                string phone = tbPhoneNumber.Text;
                string resumeURL = tbResumeLink.Text;
                string linkedinURL = tbLinkedIn.Text;

                string submitQuery = "insert into applicants (firstName, lastName, email, phone, resumeURL, linkedinURL) VALUES (@firstName, @lastName, @email, @phone, @resumeURL, @linkedinURL); select scope_identity()";
                SqlCommand submitApplicationCommand = new SqlCommand(submitQuery, CTSDatabase);

                // Add form values as parameters to command
                SqlParameterCollection parameters = submitApplicationCommand.Parameters;
                parameters.AddWithValue("@firstName", firstName);
                parameters.AddWithValue("@lastName", lastName);
                parameters.AddWithValue("@email", email);
                parameters.AddWithValue("@phone", phone);
                parameters.AddWithValue("@resumeURL", resumeURL);
                parameters.AddWithValue("@linkedinURL", linkedinURL);

                try
                {
                    // open connection
                    CTSDatabase.Open();
                    // Run command
                    int id = Convert.ToInt32(submitApplicationCommand.ExecuteScalar());
                    // successfully added application, we should process their job interests
                    AddApplicantInterests(id, cblPreferences);
                    // Now we should show a thank you message
                    ScriptManager.RegisterStartupScript(CareersUpdatePanel, CareersUpdatePanel.GetType(), "thankyou", "thankyou()", true);

                }
                catch (SqlException sex)
                {
                    System.Diagnostics.Debug.WriteLine("Failed with SQL Exception: " + sex.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Failed with general exception: " + ex.Message);
                }
                finally
                {
                    CTSDatabase.Close();
                }

            }
        }


        private void AddApplicantInterests(int applicantId, CheckBoxList cblApplicantInterests)
        {
            try
            {
                // Create SQL connection if it doesnt exist, note whether or not it existed
                bool connectionWasOpen = CTSDatabase.State == System.Data.ConnectionState.Open;
                if (!connectionWasOpen)
                {
                    CTSDatabase.Open();
                }

                // Define the insert query for user interests
                const String userInterestsQuery = "INSERT INTO applicantInterests (applicantId, careerTopicId) VALUES (@applicantId, @topicId);";
                // Handle the user video interests preferences
                foreach (ListItem item in cblApplicantInterests.Items)
                {
                    // only insert if the item is checked
                    if (item.Selected)
                    {
                        String selectedValue = item.Value;
                        // Create the sql command with our current connection and the above insert query
                        SqlCommand InsertUserInterests = new SqlCommand(userInterestsQuery, CTSDatabase);
                        // Get our parameter list
                        SqlParameterCollection userInterestParameters = InsertUserInterests.Parameters;
                        // Add this user to query
                        userInterestParameters.AddWithValue("@applicantId", applicantId);
                        // Add the selected value ( checked box) to the query
                        userInterestParameters.AddWithValue("@topicId", selectedValue);
                        InsertUserInterests.ExecuteScalar();
                    }
                }
                // Close connection to SQL Database IF we opened it
                if (!connectionWasOpen)
                {
                    CTSDatabase.Close();
                }
            }
            catch (SqlException sex)
            {
                //sql exceptions
                System.Diagnostics.Debug.WriteLine("Sql Exception: " + sex.Message);
                System.Diagnostics.Debug.WriteLine("Sql Error Code: " + sex.ErrorCode);
            }
            catch (Exception ex)
            {
                //General exceptions
                System.Diagnostics.Debug.WriteLine("General exception: " + ex.Message);
            }
        }
    }
}