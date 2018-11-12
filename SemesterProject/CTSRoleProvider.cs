using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;

namespace SemesterProject
{
    //most of these we don't need so for now they will throw not implemented
    public class CTSRoleProvider : RoleProvider
    {
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] adminRole = new string[] { "admin" };
            string[] userRole = new string[] { "user" };
            try
            {// get roles for given user
                myConnection.Open();
                string query = "SELECT administrator from users where email = @email";
                SqlCommand SelectAdministratorBit = new SqlCommand(query, myConnection);
                SelectAdministratorBit.Parameters.AddWithValue("@email", username);
                bool administrator = (bool)SelectAdministratorBit.ExecuteScalar();
                if (administrator)
                {
                    myConnection.Close();
                    // Return role of admin
                    return adminRole;
                }
            }

            finally
            {
                // If we make it here we should close the connection 
                myConnection.Close();
            }
            // if we make it here we should return the user role
            return userRole;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            //this function must return a bool telling if we're in the given role or note
            //since this application only cares about admins or not admins, we're returning false if the roleName isn't admin
            if (roleName != "admin")
            {
                return false;
            }
            try
            {
                myConnection.Open();
                string query = "SELECT administrator from users where email = @email";
                SqlCommand SelectAdministratorBit = new SqlCommand(query, myConnection);
                SelectAdministratorBit.Parameters.AddWithValue("@email", username);
                bool administrator = (bool)SelectAdministratorBit.ExecuteScalar();
                if (administrator)
                {
                    myConnection.Close();
                    return true;
                }
                else
                {
                    myConnection.Close();
                    return false;
                }

            }
            catch (SqlException sex)
            {
                //log out errors so we know what happened
                System.Diagnostics.Debug.WriteLine("Sql Exception Number: " + sex.Number);
                System.Diagnostics.Debug.WriteLine("Sql Exception Message: " + sex.Message);

            }
            catch (Exception ex)
            {
                //Log out error
                System.Diagnostics.Debug.WriteLine("General exception: " + ex.Message);

            }
            finally
            {
                myConnection.Close();
            }
            //if we make it here we should return false, because we're not sure of the users role.
            //(perhaps we had an error connecting to the sql database)
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}