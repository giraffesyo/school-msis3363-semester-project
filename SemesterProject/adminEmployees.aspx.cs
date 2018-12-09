using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SemesterProject
{
    public partial class adminEmployees : System.Web.UI.Page
    {
        SqlConnection CTSDatabase = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        int companyId;
        string companyName;
        List<Employee> employees;

        public struct Employee
        {
            public int id;
            public string email;
            public string firstName;
            public string lastName;
            public string phone;
            public string title;
            public string department;
            public bool newsletter;
            public bool administrator;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // load session variables
            companyId = Convert.ToInt32(Session["managingCompanyId"]);
            companyName = Convert.ToString(Session["managingCompanyName"]);
            // If either session variable isn't available we should redirect away from this page
            // Convert.ToInt32 returns 0 if provided null.
            // Convert.ToString returns Empty if provided null.
            // https://docs.microsoft.com/en-us/dotnet/api/system.convert.toint32?view=netframework-4.7.2#System_Convert_ToInt32_System_Single_
            if (companyId == 0 || string.IsNullOrWhiteSpace(companyName))
            {
                Response.Redirect("~/admin.aspx");
            }

            // set header to company name
            lblHeader.Text = $"Managing {companyName}";
            // Load the employees
            LoadEmployees();
        }


        private void LoadEmployees()
        {
            // Initialize employees to list of 100 initial capacity, expands if necessary automatically
            employees = new List<Employee>(100);
            try
            {
                //create the query string
                string SelectEmployeesQuery = "Select id, email, firstName, lastName, phone, title, department, newsletter, administrator FROM users where companyId = @companyId;";
                // create command from our connection and query
                SqlCommand SelectEmployeesCommand = new SqlCommand(SelectEmployeesQuery, CTSDatabase);
                SqlParameterCollection parameters = SelectEmployeesCommand.Parameters;
                parameters.AddWithValue("@companyId", companyId);

                //open the sql connection
                CTSDatabase.Open();
                // execute our query, which returns a reader holding our results
                SqlDataReader reader = SelectEmployeesCommand.ExecuteReader();
                // Go through all elements of the buffer, adding them to an array
                // Create index for use on buttons to reference our employee list elements
                int index = 0;
                while (reader.Read())
                {
                    Employee employee;

                    // gather all of the elements from reader into our employee object
                    employee.id = Convert.ToInt32(reader[0]);
                    employee.email = Convert.ToString(reader[1]);
                    employee.firstName = Convert.ToString(reader[2]);
                    employee.lastName = Convert.ToString(reader[3]);
                    employee.phone = Convert.ToString(reader[4]);
                    employee.title = Convert.ToString(reader[5]);
                    employee.department = Convert.ToString(reader[6]);
                    employee.newsletter = Convert.ToBoolean(reader[7]);
                    employee.administrator = Convert.ToBoolean(reader[8]);
                    // add employee to list of employees
                    employees.Add(employee);

                    // Add this employee to the table
                    // Create the row
                    TableRow row = new TableRow();

                    // Create each cell
                    TableCell emailCell = new TableCell();
                    TableCell firstNameCell = new TableCell();
                    TableCell lastNameCell = new TableCell();
                    TableCell editCell = new TableCell();
                    TableCell deleteCell = new TableCell();

                    // Add content to each cell
                    emailCell.Text = employee.email;
                    firstNameCell.Text = employee.firstName;
                    lastNameCell.Text = employee.lastName;

                    //Create buttons
                    LinkButton lbEdit = new LinkButton();
                    LinkButton lbDelete = new LinkButton();

                    // Add font awesome class in order for it to have the appropriate icon
                    lbEdit.Attributes.Add("class", "fa fa-pencil");
                    lbDelete.Attributes.Add("class", "fa fa-trash");


                    // Add data attributes to identify the buttons
                    lbEdit.Attributes.Add("data-index", index.ToString());
                    lbDelete.Attributes.Add("data-index", index.ToString());

                    // Add event listeners 
                    lbEdit.Click += new EventHandler(editEmployeeClicked);
                    lbDelete.Click += new EventHandler(deleteEmployeeClicked);

                    // Add buttons to cells
                    editCell.Controls.Add(lbEdit);
                    deleteCell.Controls.Add(lbDelete);

                    // Add cells to the row
                    row.Cells.Add(emailCell);
                    row.Cells.Add(firstNameCell);
                    row.Cells.Add(lastNameCell);
                    row.Cells.Add(editCell);
                    row.Cells.Add(deleteCell);

                    // Add row to table
                    employeesTable.Rows.Add(row);

                    //increment index
                    index++;
                }
                // If we had no entries then we should not just show a blank table
                if (index == 0)
                {
                    employeesTable.Visible = false;
                    adminEmployeesAlert.Visible = true;
                    adminEmployeesAlert.InnerText = $"Currently {companyName} doesn't have any employees.";
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
        protected void editEmployeeClicked(object sender, EventArgs e)
        {
            // Cast the sender as link button
            LinkButton btn = (LinkButton)sender;
            // Get index from the link button (index correpsonds to our employees list)
            int index = Convert.ToInt32(btn.Attributes["data-index"]);
            // get the employee from the employees list using the index
            Employee employee = employees[index];
            // save employee to session 
            Session["managingEmployee"] = employee;
            // redirect administrator to the edit user page
            Response.Redirect("~/edituser.aspx");
        }

        protected void deleteEmployeeClicked(object sender, EventArgs e)
        {
            // Cast the sender as link button
            LinkButton btn = (LinkButton)sender;
            // Get index from the link button (index correpsonds to our employees list)
            int index = Convert.ToInt32(btn.Attributes["data-index"]);
            // get the employee from the employees list using the index
            Employee employee = employees[index];
            // Set modal title
            deleteEmployeeTitle.Text = $"Deleting user {employee.email}";
            // Set modal body
            lblDeleteEmployeeBody.Text = $"Are you sure you want to delete {employee.firstName} {employee.lastName}'s account?";
            // set hidden value to employee's index in Employees List
            hiddenEmployeeIndex.Value = index.ToString();
            // Register script manager to show the modal
            ScriptManager.RegisterStartupScript(deleteEmployeeUpdatePanel, deleteEmployeeUpdatePanel.GetType(), "showDelete", "$(function () { $('#deleteEmployeeModal').modal('show'); });", true);
            deleteEmployeeUpdatePanel.Update();

        }

        protected void deleteEmployeeConfirmed(object sender, EventArgs e)
        {
            // The administrator confirmed they want to delete this user
            int index = Convert.ToInt32(hiddenEmployeeIndex.Value);
            int employeeId = employees[index].id;
            // Delete the user
            int Result = UserManager.DeleteUser(employeeId);

            if (Result == UserManager.SUCCESS)
            {
                // we successfully deleted the user, remove employee from the employee list
                employees.RemoveAt(index);
                // Remove the row from the table ( index+1 to compenate for the header row)
                employeesTable.Rows.RemoveAt(index + 1);
                // Refresh the Update Panel
                tableUpdatePanel.Update();
                // Hide modal
                ScriptManager.RegisterStartupScript(tableUpdatePanel, tableUpdatePanel.GetType(), "hideDelete", "$(function () { $('#deleteEmployeeModal').modal('hide'); });", true);
            }
            else
            {
                // there was a failure deleting the user, notify the administrator
                deleteEmployeeModalAlert.InnerText = "Failed to delete user";
                deleteEmployeeModalAlert.Visible = true;
            }
        }


    }
}