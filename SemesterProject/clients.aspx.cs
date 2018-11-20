using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace SemesterProject
{
    public partial class clients : System.Web.UI.Page
    {
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["F18_ksmmcquadConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // we only want to make this call once, when the page is first loaded. 
            if (!IsPostBack)
            {
                try
                {
                    //get the current user from context
                    string currentUser = User.Identity.Name;
                    //Create the query
                    //This query returns all the video names and links for the given user
                    // this is based off the preferences they have set
                    const string SelectVideosQuery = "SELECT v.name, v.link from videos v INNER JOIN users u LEFT JOIN userInterests ui ON u.id = ui.userId ON v.topicId = ui.videoTopicId WHERE u.email = @loggedInUser";
                    // Create SQL Command with above query and myConnection declared at class level
                    SqlCommand SelectVideos = new SqlCommand(SelectVideosQuery, myConnection);
                    SelectVideos.Parameters.AddWithValue("@loggedInUser", currentUser);
                    myConnection.Open();
                    // Execute query and create buffer of query result
                    SqlDataReader reader = SelectVideos.ExecuteReader();
                    // iterate over all of the result set
                    while (reader.Read())
                    {
                        //Read the data into varialbes
                        string name = reader[0].ToString();
                        string link = reader[1].ToString();
                        //todo: set the video container to a message about no videos found if they don't have any preferences set
                        // Create a wrapper for our iframe
                        HtmlGenericControl iframeWrapper = new HtmlGenericControl("div");
                        // Add bootstrap responsive classes to it
                        iframeWrapper.Attributes["class"] = "embed-responsive embed-responsive-16by9 col-10 col-sm-3 iframe-wrapper";
                        // Create our iframe element
                        HtmlIframe iframe = new HtmlIframe();
                        // Set src property to our link
                        iframe.Src = link;
                        // Add bootstrap classes
                        iframe.Attributes["class"] = "embed-responsive-item";
                        //allow full screen
                        iframe.Attributes.Add("allowFullScreen", "true");
                        //Add our iframe to our wrapper
                        iframeWrapper.Controls.Add(iframe);
                        //Add our iframe wrapper to our video container
                        VideoContainer.Controls.Add(iframeWrapper);
                    }
                }
                catch (SqlException sex)
                {
                    //Log out the error
                    System.Diagnostics.Debug.WriteLine("SQL Error number: " + sex.Number);
                    System.Diagnostics.Debug.WriteLine("SQL Error message: " + sex.Message);
                }
                catch (Exception ex)
                {
                    //Log out general exception error
                    System.Diagnostics.Debug.WriteLine("General Exception: " + ex.Message);
                }
                finally
                {
                    //close sql connection if its open
                    myConnection.Close();
                }
            }
        }
    }
}