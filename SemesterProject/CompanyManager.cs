using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace SemesterProject
{
    public class CompanyManager
    {
        private static SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        public static int SUCCESS = 1;
        public static int FAILURE = 0;

        public static int UpdateCompany(int companyId, int employeeCount, string companyName)
        {
            try
            {

                // create update query string
                string UpdateCompanyQuery = "UPDATE companies SET name = @name, employeeCount = @count where id = @id;";
                // Create command
                SqlCommand UpdateCompanyCommand = new SqlCommand(UpdateCompanyQuery, CTSDatabase);
                // Add parameters
                SqlParameterCollection parameters = UpdateCompanyCommand.Parameters;
                parameters.AddWithValue("@name", companyName);
                parameters.AddWithValue("@count", employeeCount);
                parameters.AddWithValue("@id", companyId);
                // Open connection and execute 
                CTSDatabase.Open();
                int RowsAffected = UpdateCompanyCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {
                    return SUCCESS;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Number of rows affected was: " + RowsAffected);
                    return FAILURE;
                }
            }
            catch (SqlException sex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Exception: " + sex.Message);
                System.Diagnostics.Debug.WriteLine("SQL Error Code: " + sex.ErrorCode);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("General Exception: " + ex.Message);
            }
            finally
            {
                CTSDatabase.Close();
            }
            // If we reached this line we have failed.
            System.Diagnostics.Debug.WriteLine("Reached end of Update Company, failure");
            return FAILURE;
        }
    }
}