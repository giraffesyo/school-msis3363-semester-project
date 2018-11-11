using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace SemesterProject
{
    public partial class login : System.Web.UI.Page
    {
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                //get typed in username
                String inputtedEmail = tbUsername.Text;
                String inputtedPassword = tbPassword.Text;
                //Select the password from the database using the inputted email as our where clause
                const String query = "SELECT password from users where email = @email";
                SqlCommand SelectPassword = new SqlCommand(query, myConnection);
                SelectPassword.Parameters.AddWithValue("@email", inputtedEmail);
                // Get the password from the database, convert it to string or null if the username doesn't exist in the db
                String password = SelectPassword.ExecuteScalar()?.ToString();
                //Validate credentials by comparing the database password with our passowrd
                if (password == null)
                {
                    //the username did not exist in the database
                    //System.Diagnostics.Debug.WriteLine("Invalid username");
                    //Show "invalid password" so we don't reveal accounts existence or non existence
                    loginMessage.Text = "Incorrect Passowrd";
                }
                else if (password == inputtedPassword)
                {
                    //we're dealing with an authorized user
                    System.Diagnostics.Debug.WriteLine("Valid password");
                    // Redirect the user to the logged in page...
                    FormsAuthentication.RedirectFromLoginPage(inputtedEmail, true);
                }
                else
                {
                    // the password was incorrect
                    //System.Diagnostics.Debug.WriteLine("Invalid password");
                    // Show incorrect message message
                    loginMessage.Text = "Incorrect Password";
                }
                //Response.Redirect("~/loggedin.aspx");
            }
            catch (SqlException sex)
            {
                //print out sql related messages to console
                System.Diagnostics.Debug.WriteLine("Sql Error Number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("Sql Error Message: " + sex.Message);
            }
            catch (Exception err)
            {
                //print out non sql messages
                System.Diagnostics.Debug.WriteLine("General error: " + err.Message);
            }
            finally
            {
                //close sql connection here
                myConnection.Close();
            }
        }

        protected void lbRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChooseCompany.aspx");
        }
    }
}