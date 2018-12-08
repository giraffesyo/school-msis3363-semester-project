using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SemesterProject
{
    //This class provides methods to modify users
    public class UserManager
    {

        public const int SUCCESS = 1;
        public const int GENERAL_FAILURE = -1;
        public const int SQL_FAILURE = -2;
        public const int EMAIL_IN_USE = -3;

        private static SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        ///<summary>Returns true if this email is OK to use</summary>
        public static bool checkEmail(string email)
        {
            try
            {
                string checkEmailQuery = "SELECT COUNT(email) from users where email = @email";
                SqlCommand CheckEmailCommand = new SqlCommand(checkEmailQuery, CTSDatabase);
                CheckEmailCommand.Parameters.AddWithValue("@email", email.ToLower());
                CTSDatabase.Open();
                int NumberOfAccounts = Convert.ToInt32(CheckEmailCommand.ExecuteScalar());
                return NumberOfAccounts == 0;
            }
            catch (SqlException sex)
            {
                //Log out any SQL Exceptions
                System.Diagnostics.Debug.WriteLine("SQL exception number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("SQL exception message: " + sex.Message);

            }
            catch (Exception ex)
            {
                //General exceptions
                System.Diagnostics.Debug.WriteLine("General exception: " + ex.Message);
            }
            finally
            {
                //Ensure we close the connection
                CTSDatabase.Close();

            }
            // If we got here there was an error before we got to the return statement, check logs
            return false;
        }

        public static int RegisterUser(string email, string password, string first, string last, string phone, int ChosenCompanyId, string title, string department, bool newsletter, CheckBoxList cblTrainingPreferences)
        {
            try
            {

                // Create query
                const String query = "INSERT INTO users (email, password, firstName, lastName, phone, companyId, title, department, newsletter) VALUES (@email, @password, @firstName, @lastName, @phone, @companyId, @title, @department, @newsletter); SELECT SCOPE_IDENTITY()";
                // Create Insert Command
                SqlCommand InsertUserCommand = new SqlCommand(query, CTSDatabase);
                // Add our parameters
                SqlParameterCollection Parameters = InsertUserCommand.Parameters;
                Parameters.AddWithValue("@email", email.ToLower());
                Parameters.AddWithValue("@password", password);
                Parameters.AddWithValue("@firstName", first);
                Parameters.AddWithValue("@lastName", last);
                Parameters.AddWithValue("@phone", phone);
                Parameters.AddWithValue("@companyId", ChosenCompanyId);
                Parameters.AddWithValue("@title", title);
                Parameters.AddWithValue("@department", department);
                Parameters.AddWithValue("@newsletter", newsletter);
                // Create SQL connection
                CTSDatabase.Open();
                // Execute command, creating the user, returns the id
                Int32 UserId = Convert.ToInt32(InsertUserCommand.ExecuteScalar());
                // Process the users training preferences
                AddUserInterests(UserId, cblTrainingPreferences);
                // Close connection to SQL Database and return the user id
                CTSDatabase.Close();
                return UserId;
            }
            catch (SqlException sex)
            {
                //Log out any SQL Exceptions
                System.Diagnostics.Debug.WriteLine("SQL exception number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("SQL exception message: " + sex.Message);

            }
            catch (Exception ex)
            {
                //General exceptions
                System.Diagnostics.Debug.WriteLine("General exception: " + ex.Message);
            }
            finally
            {
                //Ensure we close the connection
                CTSDatabase.Close();

            }
            // bad value means that registration failed
            return GENERAL_FAILURE;
        }

        private static void AddUserInterests(int userId, CheckBoxList cblTrainingPreferences)
        {
            try
            {
                // Create SQL connection if it doesnt exist, note whether or not it existed
                bool connectionWasOpen = CTSDatabase.State == System.Data.ConnectionState.Open;
                if (!connectionWasOpen)
                {
                    CTSDatabase.Open();
                }
                // first wipe out the interests if they exist
                const String removeInterestQuery = "DELETE FROM userInterests where userId = @userId";
                SqlCommand removeInterestsCommand = new SqlCommand(removeInterestQuery, CTSDatabase);
                removeInterestsCommand.Parameters.AddWithValue("@userId", userId);
                removeInterestsCommand.ExecuteNonQuery();

                // Define the insert query for user interests
                const String userInterestsQuery = "INSERT INTO userInterests (userId, videoTopicId) VALUES (@userId, @videoTopicId);";
                // Handle the user video interests preferences
                foreach (ListItem item in cblTrainingPreferences.Items)
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
                        userInterestParameters.AddWithValue("@userId", userId);
                        // Add the selected value ( checked box) to the query
                        userInterestParameters.AddWithValue("@videoTopicId", selectedValue);
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

        public static int updateUser(int id, string currentEmail, string email, string firstName, string lastName, string phone, string title, string department, bool newsletter, CheckBoxList cblTrainingPreferences)
        {
            // first check that the email that we're changing to is not in use
            // the checkemail call is intentionally on the right side for short circuit evaluation (only called if usernames arent equal)
            bool changingEmail = currentEmail.ToLower() != email.ToLower();

            if (changingEmail && !checkEmail(email))
            {
                return EMAIL_IN_USE;
            }

            try
            {
                // create update query string
                string UpdateUserQuery = "UPDATE users SET email = @email, firstName = @firstName, lastName = @lastName, phone = @phone, title = @title, department = @department, newsletter = @newsletter WHERE id = @userId;";
                //instantiate command with above query and our database as its connection
                SqlCommand UpdateUserCommand = new SqlCommand(UpdateUserQuery, CTSDatabase);
                SqlParameterCollection parameters = UpdateUserCommand.Parameters;
                //set paremeters based off of method paremeters
                parameters.AddWithValue("@email", email.ToLower());
                parameters.AddWithValue("@firstName", firstName);
                parameters.AddWithValue("@lastName", lastName);
                parameters.AddWithValue("@phone", phone);
                parameters.AddWithValue("@title", title);
                parameters.AddWithValue("@department", department);
                parameters.AddWithValue("@newsletter", newsletter);
                parameters.AddWithValue("@userId", id);
                // Open connection
                CTSDatabase.Open();
                //Execute command
                int rowsAffected = UpdateUserCommand.ExecuteNonQuery();
                // last thing is to update their training preferences
                AddUserInterests(id, cblTrainingPreferences);
                if (rowsAffected == 1)
                {
                    // if we changed the users email we need to update their cookie
                    if (changingEmail)
                    {
                        FormsAuthentication.SetAuthCookie(email, true);
                    }
                    // we successfully updated the users profile
                    return SUCCESS;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Rows affected was: " + rowsAffected);
                    return GENERAL_FAILURE;
                }
            }
            catch (SqlException sex)
            {
                //Log out any SQL Exceptions
                System.Diagnostics.Debug.WriteLine("SQL exception number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("SQL exception message: " + sex.Message);

            }
            catch (Exception ex)
            {
                //General exceptions
                System.Diagnostics.Debug.WriteLine("General exception: " + ex.Message);
            }
            finally
            {
                //Ensure we close the connection
                CTSDatabase.Close();

            }
            return GENERAL_FAILURE;
        }
    }
}