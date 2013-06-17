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
    public partial class Administracion : System.Web.UI.Page
    {
        Informacion info = new Informacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!(bool)Session["Autentica"] )
                    {
                        Response.Redirect("../geface/Login.aspx");
                    }
                    else if (!(Session["User"].ToString().ToUpper().Equals("BRIVERA")))
                    {
                        Response.Redirect("../geface/SinPermiso.aspx");
                    }                    
                }
                catch
                {                    
                    Response.Redirect("../geface/Login.aspx");
                }
                info.Usuario = Session["User"].ToString();
                info.mCargaCompanias(ref ddlEnterpriseDDE);
                info.ListMonths(ref ddlMonthDDE);
                info.ListYears(ref ddlYearDDE,2012,2013);
                info.mCargaTipoDocumento(ref ddlTypeDocumentDDE);
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));

            Response.Cache.SetNoStore();
        }

        protected void btnVerDiferenciasDDE_Click(object sender, EventArgs e)
        {            
            armaCuadro(ddlEnterpriseDDE.SelectedValue.ToString(), ddlMonthDDE.SelectedValue.ToString(), ddlYearDDE.SelectedValue.ToString(), "4", "'FAC'", ddlMonthDDE.SelectedItem.ToString() ,info.obtenerCompania(ddlEnterpriseDDE.SelectedValue));
        }
        protected void armaCuadro(string nCia, string mes, string anio, string tipoDoc, string td, string mesReporte, string tCia)
        {
            AccesoDatos ad = new AccesoDatos();
            DataTable dtEface = new DataTable();
            DataTable dtVentas = new DataTable();
            DataTable dtDatos = new DataTable();
            DataTable dtDatos2 = new DataTable();
            String strQry_Eface = "";
            String strQry_Ventas = "";                        
            String periodo = "<> -1";            
            String gsucod =  "<>-1";                        
            strQry_Eface = string.Format(tipoDoc.Equals("4") ? querys.CuadroEfaceFAC : querys.CuadroEfaceNC, mes, anio, nCia, tipoDoc, periodo, gsucod);
            strQry_Ventas = querys.LoteTotalCofal;//string.Format(querys.CuadroVentas, tCia, (int.Parse(mes) < 10) ? String.Format("0{0}", int.Parse(mes).ToString()) : mes, anio.Substring(2, 2), td, periodo, gsucod);
            dtEface = getDataSQLSvr(strQry_Eface);
            dtVentas = ad.RealizaConsulta(strQry_Ventas);
            GeneraExcell ge = new GeneraExcell();
            ge.depurarDatos2(ref dtEface, ref dtVentas);
            //dtDatos = ge.UneTablas(dtEface, dtVentas);
            //dtDatos2 = ge.UneTablas2(dtEface, dtVentas);
            gvResultEFACEDDE.DataSource = dtEface;
            gvResultEFACEDDE.DataBind();
            gvResultAS400DDE.DataSource = dtVentas;
            gvResultAS400DDE.DataBind();
            
        }
        private DataTable getDataSQLSvr(String pQuery)
        {
            DataTable retorno = new DataTable();
            System.Data.SqlClient.SqlConnection myConnection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLEXPRESS"].ConnectionString);
            try
            {
                myConnection.Open();
                string qry = pQuery;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(qry, myConnection);
                da.Fill(retorno);
            }

            catch (Exception err)
            {
                myConnection.Close();
                throw new Exception(err.Message); ;
            }
            finally
            {
                myConnection.Close();
            }
            return retorno;
        }

        
    
    }
}
