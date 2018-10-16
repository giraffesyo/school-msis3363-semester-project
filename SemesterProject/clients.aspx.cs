using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SemesterProject
{
    public partial class clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Maintain "clients.aspx" page name for the logged in page by using the Server.Transfer method
            Server.Transfer("~/loggedin.aspx");
        }

        protected void lbRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}