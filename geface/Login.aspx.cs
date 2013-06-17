using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal_GEFACE.geface
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.Add("Autentica", false);
                Session.Add("User", "");
                Session.Add("NombreArchivo", "");
            }
            LoginFace.Focus();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));

            Response.Cache.SetNoStore();
        }

        protected void LoginFace_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            CDIProvider.MembershipService provider = new CDIProvider.MembershipService();
            string user = LoginFace.UserName;
            
            string autoriza = LoginFace.Password;

            bool valida = provider.ValidateUser(user, autoriza);            
            if (valida)
            {
                Session["Autentica"] = true;
            }
            else
            {
                Session["Autentica"] = false;
            }
        }

        protected void LoginFace_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if ((bool)Session["Autentica"])
            {
                RoleService.RoleService rsp = new RoleService.RoleService();
                if (rsp.IsUserInRole(LoginFace.UserName, "w03"))
                {
                    e.Authenticated = true;
                    Session["User"] = LoginFace.UserName.ToUpper();
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    e.Authenticated = true;
                    Response.Redirect("../geface/SinPermiso.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void LoginFace_LoginError(object sender, EventArgs e)
        {
            string valor = LoginFace.FailureText;
            //ClientScript.RegisterStartupScript(e.GetType(), "LoginError", String.Format("alert('{0}');", LoginFace.FailureText.Replace("'", "\'")), true);
            LoginFace.Dispose();
        }
        
    }
}
