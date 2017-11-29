using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LdapAuthAD
{
    public partial class logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Path to you LDAP directory server.
            string adPath = "LDAP://BRDIESMSDC01.lnties.com";
            ldapAuthentication adAuth = new ldapAuthentication(adPath);
            try
            {
                if (true == adAuth.IsAuthenticated(txtDomain.Text,
                                                  txtUser.Text,
                                                  txtPassword.Text))
                {
                    // Retrieve the user's groups
                    string groups = adAuth.GetGroups();
                    // Create the authetication ticket
                    FormsAuthenticationTicket authTicket =
                        new FormsAuthenticationTicket(1,  // version
                                                      txtUser.Text,
                                                      DateTime.Now,
                                                      DateTime.Now.AddMinutes(60),
                                                      false, groups);
                    // Now encrypt the ticket.
                    string encryptedTicket =
                      FormsAuthentication.Encrypt(authTicket);
                    // Create a cookie and add the encrypted ticket to the
                    // cookie as data.
                    HttpCookie authCookie =
                                 new HttpCookie(FormsAuthentication.FormsCookieName,
                                                encryptedTicket);
                    // Add the cookie to the outgoing cookies collection.
                    Response.Cookies.Add(authCookie);

                    // Redirect the user to the originally requested page
                    Response.Redirect(
                              FormsAuthentication.GetRedirectUrl(txtUser.Text,
                                                                 false));
                    Response.Redirect("LDAP://BRDIESMSDC01.lnties.com");
                }
                else
                {
                    lblError.Text =
                         "User Mismatch, check username and password.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Authentication Fail. " + ex.Message;
            }
        }
    }
}