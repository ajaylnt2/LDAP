using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

namespace LdapAuthAD
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_Authentication()
        {
            // Extract the forms authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];

            if (null == authCookie)
            {
                // There is no authentication cookie.
                return;
            }
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                // Log exception details (omitted for simplicity)
                return;
            }

            if (null == authTicket)
            {
                // Cookie failed to decrypt.
                return;
            }
            // When the ticket was created, the UserData property was assigned a
            // pipe delimited string of group names.
            String[] groups = authTicket.UserData.Split(new char[] { '|' });
            // Create an Identity object
            GenericIdentity id = new GenericIdentity(authTicket.Name,
                                                     "LdapAuthentication");

            // This principal will flow throughout the request.
            GenericPrincipal principal = new GenericPrincipal(id, groups);
            // Attach the new principal object to the current HttpContext object
            Context.User = principal;
        }
    }
}