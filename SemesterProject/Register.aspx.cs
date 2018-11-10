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
                // Get the company name from the database, using our Company ID 
                ChosenCompanyName = GetCompanyName();
                // Set label to our company name
                lblCompanyName.Text = ChosenCompanyName;
            }
        }
        //returns the company name from the sql database
        private String GetCompanyName()
        {
            //open stream 
            myConnection.Open();
            // Define select query with parameters inline
            const String query = "Select name from companies where id = @id";
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
            // Convert record to String
            String CompanyName = record[0].ToString();
            // Close SQL stream
            myConnection.Close();
            // Return String
            return CompanyName;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //check the information is valid
            //Send the information to the database
            //if successfull response redirect
            Response.Redirect("~/clients.aspx");
            //if were unsuccesful, send an error message to the client
            // set label to error
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}