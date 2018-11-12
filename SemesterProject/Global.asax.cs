using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Web.SessionState;

namespace SemesterProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {/*
            //set our auth cookie equal to the cookie stored by the FormsAuthentication class
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            // do nothing if the authCookie doesn't exist or is empty
            if (authCookie == null || authCookie.Value == "") return;

            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }catch
            {
                // we are unable to decrypt it, so it's invalid 
                return;
            }
            // retrieve the role, store in string array (for use in Generic Principal which accepts array of roles)
            String[] role = new String[]{ authTicket.UserData };

            // If we have a user add roles to them
            if (Context.User != null)
            {
                Context.User = new GenericPrincipal(Context.User.Identity, role);
            }*/
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}