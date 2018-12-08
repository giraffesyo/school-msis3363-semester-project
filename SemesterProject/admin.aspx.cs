using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class admin : System.Web.UI.Page
    {

        struct Company
        {
            public int id, count;
            public string name;
        }


        SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);
        // create a list of companies
        static List<Company> companies;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize companies to list of 100 initial capacity, expands if necessary automatically
            companies = new List<Company>(100);
            // Load companies into our companies list and populate our table
            LoadCompanies();
        }


        private void LoadCompanies()
        {
            try
            {
                //create the query string
                string selectCompaniesQuery = "Select id,name, employeeCount from companies;";
                // create command from our connection and query
                SqlCommand selectCompaniesCommand = new SqlCommand(selectCompaniesQuery, CTSDatabase);
                //open the sql connection
                CTSDatabase.Open();
                // execute our query, which returns a reader holding our results
                SqlDataReader reader = selectCompaniesCommand.ExecuteReader();
                // Go through all elements of the buffer, adding them to an array
                // Create index for use on buttons to reference our company list elements
                int index = 0;
                while (reader.Read())
                {
                    Company company;
                    company.id = Convert.ToInt32(reader[0]);
                    company.count = Convert.ToInt32(reader[2]);
                    company.name = Convert.ToString(reader[1]);
                    // add company to the companies list
                    companies.Add(company);

                    // Add this company to the table
                    // Create the row
                    TableRow row = new TableRow();

                    // Create each cell
                    TableCell nameCell = new TableCell();
                    TableCell countCell = new TableCell();
                    TableCell employeesCell = new TableCell();
                    TableCell editCell = new TableCell();

                    // Add content to each cell
                    nameCell.Text = company.name;
                    countCell.Text = company.count.ToString();

                    //Create buttons
                    LinkButton lbUser = new LinkButton();
                    LinkButton lbEdit = new LinkButton();

                    // Add font awesome class in order for it to have the appropriate icon
                    lbUser.Attributes.Add("class", "fa fa-user");
                    lbEdit.Attributes.Add("class", "fa fa-pencil");

                    // Add data attributes to identify the buttons
                    lbUser.Attributes.Add("data-index", index.ToString());
                    lbEdit.Attributes.Add("data-index", index.ToString());

                    // Add data attributes necessary for bootstrap modal
                    //lbUser.Attributes.Add("data-toggle", "modal");
                    //lbUser.Attributes.Add("data-target", "#adminModal");
                    //lbEdit.Attributes.Add("data-toggle", "modal");
                    //lbEdit.Attributes.Add("data-target", "#adminModal");

                    // Add event listeners 
                    lbUser.Click += new EventHandler(this.viewUsersClicked);
                    lbEdit.Click += new EventHandler(this.editCompanyClicked);


                    // Add buttons to cells
                    employeesCell.Controls.Add(lbUser);
                    editCell.Controls.Add(lbEdit);

                    // Add cells to the row
                    row.Cells.Add(nameCell);
                    row.Cells.Add(countCell);
                    row.Cells.Add(employeesCell);
                    row.Cells.Add(editCell);

                    // Add row to table
                    companiesTable.Rows.Add(row);

                    //increment index
                    index++;
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
        }

        protected void editCompanyClicked(object sender, EventArgs e)
        {


            System.Diagnostics.Debug.WriteLine("test");
            LinkButton btn = (LinkButton)sender;
            int index = Convert.ToInt32(btn.Attributes["data-index"]);
            Company company = companies[index];
            adminModalTitle.Text = $"Editing {company.name}";
            tbCompanyName.Text = company.name;
            tbEmployeeCount.Text = company.count.ToString();
            ScriptManager.RegisterStartupScript(adminModalUpdatePanel, adminModalUpdatePanel.GetType(), "show", "$(function () { $('#adminModal').modal('show'); });", true);
            adminModalUpdatePanel.Update();
        }

        protected void viewUsersClicked(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session[""] = Convert.ToInt32(btn.Attributes["data-index"]);
        }

        protected void btnModalClose_Click(object sender, EventArgs e)
        {

        }
    }
}
