using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal_GEFACE
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!(bool)Session["Autentica"])
                    {
                        Response.Redirect("/geface/Login.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("/geface/Login.aspx");
                }
                lblUsuario.Text = "Bienvenido: " + Session["User"].ToString();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));

            Response.Cache.SetNoStore();
        }
    }
}
