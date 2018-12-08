using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace SemesterProject
{
    public partial class preferences : System.Web.UI.Page
    {
        // user id is set on page load using User.Identity.Name in our select statement
        private int userid;
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // we want to get the initial values of the form when the page **first** loads.
            if (!IsPostBack)
            {
                //get current user
                string loggedInUser = User.Identity.Name;
                //Create query for selecting all of user's information
                string SelectUserQuery = "select c.name, u.firstName, u.lastName, u.phone, u.title, u.department, u.newsletter, u.id from users u INNER JOIN companies c ON u.companyId = c.id where u.email = @loggedInUser;";
                // Build command from that query and the connection
                SqlCommand SelectUserCommand = new SqlCommand(SelectUserQuery, myConnection);
                // Add the value of our logged in user to our parameters
                SelectUserCommand.Parameters.AddWithValue("@loggedInUser", loggedInUser);
                // Execute the query and store the results, we can assume none of the data will be null since that is a database requirement
                try
                {
                    //Open connection to the database
                    myConnection.Open();
                    //Execute command and store to a reader object
                    SqlDataReader reader = SelectUserCommand.ExecuteReader();
                    //Read first line (there will only be one line)
                    reader.Read();
                    //Grab the information out of the reader
                    // 0 = company name
                    string companyName = reader[0].ToString();
                    // 1 = first name
                    string firstName = reader[1].ToString();
                    // 2 = last name
                    string lastName = reader[2].ToString();
                    // 3 = phone
                    string phoneNumber = reader[3].ToString();
                    // 4 = title
                    string title = reader[4].ToString();
                    // 5 = department
                    string department = reader[5].ToString();
                    // 6 = newsletter
                    bool newsletter = (bool)reader[6];
                    // 7 = user id
                    // we set this to an instance variable so we can access it later in the data bound function
                    // of the checkboxlist for the video preferences
                    userid = Convert.ToInt32(reader[7]);
                    //Close this reader
                    reader.Close();
                    //Now we need to assign these to the form
                    lblCompanyName.Text = companyName;
                    tbEmail.Text = loggedInUser;
                    tbFirstName.Text = firstName;
                    tbLastName.Text = lastName;
                    tbPhoneNumber.Text = phoneNumber;
                    tbTitle.Text = title;
                    tbDepartment.Text = department;
                    cbNewsletter.Checked = newsletter;

                    //We fill out the check box list in the data bound function for that control
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
                    myConnection.Close();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clients.aspx");
        }

        protected void btnSavePreferences_Click(object sender, EventArgs e)
        {
            // get the values from the form
            string formEmail = tbEmail.Text;
            string formFirstName = tbFirstName.Text;
            string formLastName = tbLastName.Text;
            string formPhoneNumber = tbPhoneNumber.Text;
            string formJobTitle = tbTitle.Text;
            string formDepartment = tbDepartment.Text;
            bool formNewsletter = cbNewsletter.Checked;
            // get the topics the user is interested in

            // call the update function with the information gathered from the form
            int updateResponse = UserManager.updateUser(userid, User.Identity.Name, formEmail, formFirstName, formLastName, formPhoneNumber, formJobTitle, formDepartment, formNewsletter, cblTrainingPreferences);
            System.Diagnostics.Debug.WriteLine("Update response: " + updateResponse);
            //Response.Redirect("~/clients.aspx");
        }

        protected void cblTrainingPreferences_DataBound(object sender, EventArgs e)
        {
            // we need to get the checked user interests from the database
            try
            {
                myConnection.Open();
                const string SelectUserInterestsQuery = "SELECT videoTopicId FROM userInterests where userId = @userId;";
                SqlCommand SelectUserInterests = new SqlCommand(SelectUserInterestsQuery, myConnection);
                SelectUserInterests.Parameters.AddWithValue("@userId", userid);
                SqlDataReader userInterests = SelectUserInterests.ExecuteReader();

                while (userInterests.Read())
                {
                    //Get current item that IS selected
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
                myConnection.Close();
            }
        }
    }
}