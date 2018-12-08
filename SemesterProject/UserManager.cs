using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

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
                CheckEmailCommand.Parameters.AddWithValue("@email", email);
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
                Parameters.AddWithValue("@email", email);
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
                        userInterestParameters.AddWithValue("@userId", UserId);
                        // Add the selected value ( checked box) to the query
                        userInterestParameters.AddWithValue("@videoTopicId", selectedValue);
                        InsertUserInterests.ExecuteScalar();
                    }
                }
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


        public static int updateUser(int id, string currentEmail, string email, string firstName, string lastName, string phone, string title, string department, bool newsletter, CheckBoxList cblTrainingPreferences)
        {
            // first check that the email that we're changing to is not in use
            // the checkemail call is intentionally on the right side for short circuit evaluation (only called if usernames arent equal)
            if(currentEmail != email && !checkEmail(email))
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
                parameters.AddWithValue("@email", email);
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
                CTSDatabase.Close();
                if( rowsAffected == 1 )
                {
                    // we successfully updated the users profile
                    return SUCCESS;
                } else
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