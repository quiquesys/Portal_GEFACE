using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PGENL0001;
using System.Data;

namespace Portal_GEFACE.geface
{
    public partial class Lote : System.Web.UI.Page
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
                AccesoDatos acd = new AccesoDatos();
                string qry = String.Format(querys.Companias,Session["User"].ToString());
                DataTable empresas = acd.RealizaConsulta(qry);
                DataTable temp = empresas.Clone();
                temp.Columns["NOMBRE"].MaxLength = 100;
                temp.Rows.Add("-1", "Seleccione Compañia...");
                if (empresas.Rows.Count > 0)
                {
                    foreach (DataRow r in empresas.Rows)
                    {
                        temp.Rows.Add(r[0].ToString(), r[1].ToString());
                    }
                }
                ddlCompania.DataSource = temp;
                ddlCompania.DataValueField = "CODIGO";
                ddlCompania.DataTextField = "NOMBRE";
                ddlCompania.DataBind();
                Page.GetPostBackEventReference(btnCargaLote);
            }
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));

            Response.Cache.SetNoStore();
        }

        protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos acd = new AccesoDatos();
            string qry = String.Format(querys.TipoDocumentos, ddlCompania.SelectedValue);
            DataTable documentos = acd.RealizaConsulta(qry);
            DataTable temp = documentos.Clone();
            temp.Columns["NOMBRE"].MaxLength = 100;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (documentos.Rows.Count > 0)
            {
                foreach (DataRow r in documentos.Rows)
                {
                    temp.Rows.Add(r[0], r[1]);
                }
            }
            ddlTipoDocumento.DataSource = temp;
            ddlTipoDocumento.DataTextField = "NOMBRE";
            ddlTipoDocumento.DataValueField = "TIPO";
            ddlTipoDocumento.DataBind();
        }

        protected void btnCargaLote_Click(object sender, EventArgs e)
        {
            PFACW0001.wsFacturaElectronica wsface = new PFACW0001.wsFacturaElectronica();
            PFACW0001.RespuestaGeneral respuesta = new PFACW0001.RespuestaGeneral();
            wsface.Timeout = 42300000;
            respuesta = wsface.RegistraLoteDocumentos(ddlTipoDocumento.SelectedValue,ddlCompania.SelectedValue,"",txtFechaInicio.Text.Replace("/",""),txtFechaFin.Text.Replace("/",""),Session["User"].ToString());
            if (respuesta.Resultado)
            {
                lblErrors.Text = respuesta.Mensaje;
                string script = "$(function() { openDialog('respuestaWS'); });";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "successWS", script, true);
                LimpiarDatos();
            }
            else
            {
                lblErrors.Text = respuesta.Mensaje;
                string script = "$(function() { openDialog('respuestaWS'); });";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "errorWS", script, true);
            }
        }

        private void LimpiarDatos()
        {
            ddlTipoDocumento.Items.Clear();
            ddlCompania.Items.Clear();
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            AccesoDatos acd = new AccesoDatos();
            string qry = String.Format(querys.Companias, Session["User"].ToString());
            DataTable empresas = acd.RealizaConsulta(qry);
            DataTable temp = empresas.Clone();
            temp.Columns["NOMBRE"].MaxLength = 100;
            temp.Rows.Add("-1", "Seleccione Compañia...");
            if (empresas.Rows.Count > 0)
            {
                foreach (DataRow r in empresas.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlCompania.DataSource = temp;
            ddlCompania.DataValueField = "CODIGO";
            ddlCompania.DataTextField = "NOMBRE";
            ddlCompania.DataBind();
            ddlCompania.Focus();
        }
    }
}
