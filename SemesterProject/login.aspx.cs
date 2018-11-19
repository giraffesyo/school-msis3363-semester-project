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
            // Redirect logged in users to the portal page
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/clients.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                //get typed in username/email
                String inputtedEmail = tbUsername.Text;
                //Hash inputted password
                String inputtedPassword = Password.HashPassword(tbPassword.Text);
                //Select the password and administrator bit from the database using the inputted email as our where clause
                const String query = "SELECT password, administrator from users where email = @email";
                SqlCommand SelectPasswordAndAdministrator = new SqlCommand(query, myConnection);
                SelectPasswordAndAdministrator.Parameters.AddWithValue("@email", inputtedEmail);

                //Create SqlDataReader which is a buffer holding our Password string and Administrator bit
                SqlDataReader buffer = SelectPasswordAndAdministrator.ExecuteReader();
                // declare password and administrator then set them in below if statement
                String password;
                bool administrator;
                if (buffer.Read())
                {
                    // Get the password from the database, convert it to string or null if the username doesn't exist in the db
                    password = buffer[0]?.ToString();
                    // get administrator bit from second column returned
                    administrator = (bool)buffer[1];
                }
                else
                {
                    //default values
                    password = null;
                    administrator = false;
                }
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
                    //System.Diagnostics.Debug.WriteLine("Valid password");
                    //Create the authentication ticket for the user 
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(inputtedEmail, true, 30);
                    //Encrypt the ticket
                    String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    //Create an authorization cookie with the name decided by the FormsAuthentication class and the information we created above
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    //Add the cookie to the HTTP response
                    HttpContext.Current.Response.Cookies.Add(authCookie);
                    //Redirect the user to the logged in page...
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(inputtedEmail, true));
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