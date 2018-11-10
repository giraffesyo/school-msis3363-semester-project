using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace SemesterProject
{
    public partial class RegisterCompany : System.Web.UI.Page
    {
        
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //check the information is valid
            if (Page.IsValid)
            {
                //Send the information to the database
                String CompanyName = tbCompanyName.Text;
                Int32 NumberOfEmployees = Convert.ToInt32(tbNumberOfEmployees.Text);
                myConnection.Open();
                const String query = "INSERT INTO companies (name, employeeCount) VALUES (@name, @count)";
                SqlCommand InsertCommand = new SqlCommand(query, myConnection);
                InsertCommand.Parameters.AddWithValue("@name", CompanyName);
                InsertCommand.Parameters.AddWithValue("@count", NumberOfEmployees);
                InsertCommand.ExecuteNonQuery();
                myConnection.Close();
                //when successfull response redirect
                Response.Redirect("~/ChooseCompany.aspx");

                //TODO: if were unsuccesful, send an error message to the client
                // set label to error

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}