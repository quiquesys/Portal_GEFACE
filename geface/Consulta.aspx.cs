using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PGENL0001;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;



namespace Portal_GEFACE.geface
{
    public partial class Consulta : System.Web.UI.Page
    {
#region VARIABLES
        String _nombreArchivo;

        public String NombreArchivo
        {
            get { return _nombreArchivo; }
            set { _nombreArchivo = value; }
        }

        AccesoDatos _accesoDatos;

        public AccesoDatos AD
        {
            get { return _accesoDatos=new AccesoDatos(); }
        }
#endregion
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
                cargaTipoDoc();
                cargaCompanias();                
                Page.GetPostBackEventReference(btnBuscarDoc);
            }
            grvDetalleFac.Visible = false;
            grvDetalleNC.Visible = false;
            mVerificaIconos();
        }

        protected void mVerificaIconos()
        {
            #region VERIFICA ICONOS EXCEL
            if (!string.IsNullOrEmpty(hlExcel_FAC.NavigateUrl)) //no es nulo, tiene direccion de archivo
            {
                FileInfo tmp = new FileInfo(hlExcel_FAC.NavigateUrl);
                if (!tmp.Exists) //no existe el archivo
                {
                    hlExcel_FAC.ImageUrl = "~/img/xcel_disabled.png";
                    hlExcel_FAC.Enabled = false;
                }
                else //si existe el archivo
                {
                    hlExcel_FAC.ImageUrl = "~/img/xcel.png";
                    hlExcel_FAC.Enabled = true;
                }
            }
            else //es nulo, no tiene direccion de archivo
            {
                hlExcel_FAC.ImageUrl = "~/img/xcel_disabled.png";
                hlExcel_FAC.Enabled = false;
            }
            if (!string.IsNullOrEmpty(hlExcel_NCR.NavigateUrl)) //no es nulo, tiene direccion de archivo
            {
                FileInfo tmp = new FileInfo(hlExcel_NCR.NavigateUrl);
                if (!tmp.Exists) //no existe el archivo
                {
                    hlExcel_NCR.ImageUrl = "~/img/xcel_disabled.png";
                    hlExcel_NCR.Enabled = false;
                }
                else //si existe el archivo
                {
                    hlExcel_NCR.ImageUrl = "~/img/xcel.png";
                    hlExcel_NCR.Enabled = true;
                }
            }
            else //es nulo, no tiene direccion de archivo
            {
                hlExcel_NCR.ImageUrl = "~/img/xcel_disabled.png";
                hlExcel_NCR.Enabled = false;
            }
            #endregion          
        }               

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));

            Response.Cache.SetNoStore();
        }

        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //DataTable Compania = getDataSQLSvr(querys.Empresa_PDF);
            DataTable Compania = AD.SQLSvr_RealizaConsulta(querys.Empresa_PDF);
            DataTable temp = Compania.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Compañia...");
            if (Compania.Rows.Count > 0)
            {
                foreach (DataRow r in Compania.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlCompania.DataSource = temp;
            ddlCompania.DataValueField = "CODIGO";
            ddlCompania.DataTextField = "NOMBRE";
            ddlCompania.DataBind();
        }

        protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DataTable Sucursal = AD.SQLSvr_RealizaConsulta(String.Format(querys.Sucursal_PDF,ddlCompania.SelectedValue.ToString()));
            DataTable temp = Sucursal.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Sucursal...");
            if (Sucursal.Rows.Count > 0)
            {
                foreach (DataRow r in Sucursal.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlSucursal.DataSource = temp;
            ddlSucursal.DataValueField = "CODIGO";
            ddlSucursal.DataTextField = "NOMBRE";
            ddlSucursal.DataBind();
        }

        protected void ddlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string qry = "";
            if (ddlTipoDocumento.SelectedValue.ToString().Equals("1"))
            {
                qry = String.Format(querys.FacturaSerie_PDF, ddlCompania.SelectedValue.ToString(), ddlSucursal.SelectedValue.ToString());
            }
            if (ddlTipoDocumento.SelectedValue.ToString().Equals("2"))
            {
                qry = String.Format(querys.NotaCreditoSerie_PDF, ddlCompania.SelectedValue.ToString(), ddlSucursal.SelectedValue.ToString());
            }
            DataTable Serie = AD.SQLSvr_RealizaConsulta(qry);
            DataTable temp = Serie.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Serie...");
            if (Serie.Rows.Count > 0)
            {
                foreach (DataRow r in Serie.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlSerie.DataSource = temp;
            ddlSerie.DataValueField = "CODIGO";
            ddlSerie.DataTextField = "NOMBRE";
            ddlSerie.DataBind();
        }

        protected void btnBuscarDoc_Click(object sender, EventArgs e)
        {            
            if (ddlTipoDocumento.SelectedValue.Equals("1"))
            {
                ifacere.SSO_wsEFactura ws_ifacere = new ifacere.SSO_wsEFactura();
                Portal_GEFACE.ifacere.BusquedaFactura bf = new Portal_GEFACE.ifacere.BusquedaFactura();
                bf.EMPRESA = Convert.ToInt32(ddlCompania.SelectedValue.ToString());
                bf.SUCURSAL = Convert.ToInt32(ddlSucursal.SelectedValue.ToString());
                bf.SERIE = ddlSerie.SelectedValue.ToString();
                bf.NODOCUMENTO = Int64.Parse(txtNoDocumento.Text);
                ifacere.clsResponseGeneral respuesta = new Portal_GEFACE.ifacere.clsResponseGeneral();
                respuesta = ws_ifacere.RetornaDatosFactura_PDF(bf);
                if (respuesta.pResultado)
                {
                    this.ifrPDF.Attributes.Add("src", "Documento.aspx?EMP=" + bf.EMPRESA + "&SUC=" + bf.SUCURSAL + "&SER=" + bf.SERIE + "&DOC=" + bf.NODOCUMENTO + "&TIPO=1");
                    this.ifrPDF.Visible = true;
                    LimpiarDatos();
                }
                else
                {
                    string script = "$(function() { openDialog('dialog'); });";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "errorDocumento", script, true);
                    this.ifrPDF.Attributes.Add("src", null);
                    this.ifrPDF.Visible = false;
                }
            }
            if (ddlTipoDocumento.SelectedValue.Equals("2"))
            {
                ifacere.SSO_wsEFactura ws_ifacere = new ifacere.SSO_wsEFactura();
                Portal_GEFACE.ifacere.BusquedaNotaCredito bn = new Portal_GEFACE.ifacere.BusquedaNotaCredito();
                bn.EMPRESA = Convert.ToInt32(ddlCompania.SelectedValue.ToString());
                bn.SUCURSAL = Convert.ToInt32(ddlSucursal.SelectedValue.ToString());
                bn.SERIE = ddlSerie.SelectedValue.ToString();
                bn.NODOCUMENTO = Int64.Parse(txtNoDocumento.Text);
                ifacere.clsResponseGeneral respuesta = ws_ifacere.RetornaDatosNotaCredito_PDF(bn);
                if (respuesta.pResultado)
                {
                    this.ifrPDF.Attributes.Add("src", "Documento.aspx?EMP=" + bn.EMPRESA + "&SUC=" + bn.SUCURSAL + "&SER=" + bn.SERIE + "&DOC=" + bn.NODOCUMENTO + "&TIPO=2");
                    this.ifrPDF.Visible = true;
                    LimpiarDatos();
                }
                else
                {
                    string script = "$(function() { openDialog('dialog'); });";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", script, true);
                    this.ifrPDF.Attributes.Add("src", null);
                    this.ifrPDF.Visible = false;
                }
            }
        }

        private void LimpiarDatos()
        {
            ddlTipoDocumento.Items.Clear();
            ddlCompania.Items.Clear();
            ddlSucursal.Items.Clear();
            ddlSerie.Items.Clear();
            
            DataTable TipoDoc = AD.SQLSvr_RealizaConsulta(querys.TipoDoc_PDF);
            DataTable temp = TipoDoc.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (TipoDoc.Rows.Count > 0)
            {
                foreach (DataRow r in TipoDoc.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlTipoDocumento.DataSource = temp;
            ddlTipoDocumento.DataValueField = "TIPO";
            ddlTipoDocumento.DataTextField = "NOMBRE";
            ddlTipoDocumento.DataBind();
            txtNoDocumento.Text = "";
            ddlTipoDocumento.Focus();
        }

        private void cargaTipoDoc()
        {
            DataTable TipoDoc = AD.SQLSvr_RealizaConsulta(querys.TipoDoc_PDF);
            DataTable temp = TipoDoc.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (TipoDoc.Rows.Count > 0)
            {
                foreach (DataRow r in TipoDoc.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlTipoDocumento.DataSource = temp;
            ddlTipoDocumento.DataValueField = "TIPO";
            ddlTipoDocumento.DataTextField = "NOMBRE";
            ddlTipoDocumento.DataBind();
        }
        private void cargaCompanias()
        {
            AccesoDatos acd = new AccesoDatos();
            string qry = String.Format(querys.Companias_EFACE_AS400, Session["User"].ToString());
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
            ddlCiaFac.DataSource = temp;
            ddlCiaFac.DataValueField = "CODIGO";
            ddlCiaFac.DataTextField = "NOMBRE";
            ddlCiaFac.DataBind();
            ddlCiaNC.DataSource = temp;
            ddlCiaNC.DataValueField = "CODIGO";
            ddlCiaNC.DataTextField = "NOMBRE";
            ddlCiaNC.DataBind();
        }

        protected void ddlCiaFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos ad = new AccesoDatos();            
            DataTable Sucursal = AD.SQLSvr_RealizaConsulta(String.Format(querys.Sucursal_PDF, ddlCiaFac.SelectedValue.ToString()));
            DataTable temp = Sucursal.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Sucursal...");
            temp.Rows.Add("0", "TODAS");
            if (Sucursal.Rows.Count > 0)
            {
                foreach (DataRow r in Sucursal.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlSucursalFac.DataSource = temp;
            ddlSucursalFac.DataValueField = "CODIGO";
            ddlSucursalFac.DataTextField = "NOMBRE";
            ddlSucursalFac.DataBind();
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {            
            String compania = obtenerCompania(ddlCiaFac.SelectedValue);            
            //String qry = String.Format(querys.SeriesDocumento, compania, ddlTipoDocFac.SelectedValue);
            //DataTable seriesDT = acd.RealizaConsulta(qry);
            //string series = armaLista(seriesDT);

            if (ddlSucursalFac.SelectedValue.Equals("0"))
            {
                mCalculaTotalesTodas(compania);
            }
            else
            {
                mCalculaTotalesSucursal(compania);
            }
            grvBalance.Visible = true;                       

            Session["NombreArchivo"]=mGeneraNombreArchivo("4",(chkPorMes.Checked) ? ddlMeses.SelectedValue.ToString() : txtFechaFac.Text.Substring(3, 2), obtenerCompania(ddlCiaFac.SelectedValue)); 
        }
               
        protected void mCalculaTotalesTodas(string compania)
        {            
            if (chkPorMes.Checked)
            {
                string consulta = String.Format(querys.BalanceMes_FC_Total, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                if (Balance.Rows.Count > 0)
                {
                    grvBalance.DataSource = Balance;
                    grvBalance.DataBind();
                }
                else
                {
                    grvBalance.DataSource = null;
                    grvBalance.DataBind();
                }
                #region
                //////Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                string tipoDoc = "'FAC'";
                string qry_iva_mes = String.Format(querys.TotalIva_Todas_Mes, compania, ddlMeses.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio.SelectedValue.ToString().Substring(2, 2), tipoDoc);
                DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                for (int i = 0; i < grvBalance.Rows.Count; i++)
                {
                    grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                    grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                    grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                }
                #endregion
                string qry2 = String.Format(querys.DetalleMes_FC, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                DataTable DetalleFacturas = AD.SQLSvr_RealizaConsulta(qry2);
                grvDetalleFac.Visible = true;
                if (DetalleFacturas.Rows.Count > 0)
                {
                    grvDetalleFac.DataSource = DetalleFacturas;
                    grvDetalleFac.DataBind();
                }
                else
                {
                    grvDetalleFac.DataSource = null;
                    grvDetalleFac.DataBind();
                }
            }
            else
            {
                string consulta = String.Format(querys.BalanceFacturas_Total, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString());
                DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                if (Balance.Rows.Count > 0)
                {
                    grvBalance.DataSource = Balance;
                    grvBalance.DataBind();
                }
                else
                {
                    grvBalance.DataSource = null;
                    grvBalance.DataBind();
                }
                #region
                //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                string dia = txtFechaFac.Text.Substring(0, 2);
                string mes = txtFechaFac.Text.Substring(3, 2);
                string anio = txtFechaFac.Text.Substring(8, 2);
                string tipoDoc = "'FAC'";
                string qry_iva_fecha = String.Format(querys.TotalIva_Todas, compania, dia, mes, anio, tipoDoc);
                DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                for (int i = 0; i < grvBalance.Rows.Count; i++)
                {
                    grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                    grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                    grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                }
                #endregion
                string qry2 = String.Format(querys.DetalleFacturas_Resumen, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString());
                DataTable DetalleFacturas = AD.SQLSvr_RealizaConsulta(qry2);
                grvDetalleFac.Visible = true;
                if (DetalleFacturas.Rows.Count > 0)
                {
                    grvDetalleFac.DataSource = DetalleFacturas;
                    grvDetalleFac.DataBind();
                }
                else
                {
                    grvDetalleFac.DataSource = null;
                    grvDetalleFac.DataBind();
                }
            }
        }
        protected void mCalculaTotalesSucursal(string compania)
        {            
            if (chkPorMes.Checked)
            {
                string consulta = String.Format(querys.BalanceMes_FC_Suc, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlSucursalFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                if (Balance.Rows.Count > 0)
                {
                    grvBalance.DataSource = Balance;
                    grvBalance.DataBind();
                }
                else
                {
                    grvBalance.DataSource = null;
                    grvBalance.DataBind();
                }
                #region
                //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaFac.SelectedValue, ddlSucursalFac.SelectedValue.ToString());
                DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                string sucursalesAS = "'-1'";
                if (sucursalASDT.Rows.Count > 0)
                {
                    sucursalesAS = armaLista(sucursalASDT);
                }
                string tipoDoc = "'FAC'";
                string qry_iva_mes = String.Format(querys.DetalleIva_Suc_Mes, compania, ddlMeses.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio.SelectedValue.ToString().Substring(2, 2), sucursalesAS, tipoDoc);
                DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                if (tempIVA.Rows.Count > 0)
                {
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                }
                else
                {
                    grvBalance.Rows[0].Cells[5].Text = "0";
                    grvBalance.Rows[0].Cells[6].Text = "0.00";
                    grvBalance.Rows[0].Cells[7].Text = "0.00";
                }
                #endregion
            }
            else
            {
                string consulta = String.Format(querys.BalanceFacturas_Suc, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString(), ddlSucursalFac.SelectedValue.ToString());
                DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                if (Balance.Rows.Count > 0)
                {
                    grvBalance.DataSource = Balance;
                    grvBalance.DataBind();
                }
                else
                {
                    grvBalance.DataSource = null;
                    grvBalance.DataBind();
                }
                #region
                //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaFac.SelectedValue, ddlSucursalFac.SelectedValue.ToString());
                DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                string sucursalesAS = "'-1'";
                if (sucursalASDT.Rows.Count > 0)
                {
                    sucursalesAS = armaLista(sucursalASDT);
                }
                string dia = txtFechaFac.Text.Substring(0, 2);
                string mes = txtFechaFac.Text.Substring(3, 2);
                string anio = txtFechaFac.Text.Substring(8, 2);
                string tipoDoc = "'FAC'";
                string qry_iva_fecha = String.Format(querys.DetalleIva_Suc, compania, dia, mes, anio, sucursalesAS, tipoDoc);
                DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                if (tempIVA.Rows.Count > 0)
                {
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                }
                else
                {
                    grvBalance.Rows[0].Cells[5].Text = "0";
                    grvBalance.Rows[0].Cells[6].Text = "0.00";
                    grvBalance.Rows[0].Cells[7].Text = "0.00";
                }
                #endregion
            }
        }
        protected void ddlCiaNC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Sucursal = AD.SQLSvr_RealizaConsulta(String.Format(querys.Sucursal_PDF, ddlCiaNC.SelectedValue.ToString()));
            DataTable temp = Sucursal.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Sucursal...");
            temp.Rows.Add("0", "TODAS");
            if (Sucursal.Rows.Count > 0)
            {
                foreach (DataRow r in Sucursal.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlSucursalNC.DataSource = temp;
            ddlSucursalNC.DataValueField = "CODIGO";
            ddlSucursalNC.DataTextField = "NOMBRE";
            ddlSucursalNC.DataBind();
        }

        protected void btnCalcularNC_Click(object sender, EventArgs e)
        {            
            String compania = obtenerCompania(ddlCiaNC.SelectedValue);            
            //String qry = String.Format(querys.SeriesDocumento, compania, ddlTipoDocNC.SelectedValue);
            //DataTable seriesDT = acd.RealizaConsulta(qry);
            //string series = armaLista(seriesDT);

            if (ddlSucursalNC.SelectedValue.Equals("0"))
            {
                mCalculaTotalesTodasNC(compania);
            }
            else
            {
                mCalculaTotalesSucursalNC(compania);            
            }
            grvBalanceNC.Visible = true;
            Session["NombreArchivo"] = mGeneraNombreArchivo("5", (chkPorMes2.Checked) ? ddlMeses2.SelectedValue.ToString() : txtFechaNC.Text.Substring(3, 2), obtenerCompania(ddlCiaNC.SelectedValue)); 
        }
        protected void mCalculaTotalesTodasNC(string compania)
        {            
            if (chkPorMes2.Checked)
                {
                    string consulta = String.Format(querys.BalanceMes_NC_Total, ddlMeses2.SelectedValue.ToString(), ddlCiaNC.SelectedValue.ToString(), ddlAnio2.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    if (Balance.Rows.Count > 0)
                    {
                        grvBalanceNC.DataSource = Balance;
                        grvBalanceNC.DataBind();
                    }
                    else
                    {
                        grvBalanceNC.DataSource = null;
                        grvBalanceNC.DataBind();
                    }
                    #region
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    string tipoDoc = "'NCR','APF'";
                    string qry_iva_mes = String.Format(querys.TotalIva_Todas_Mes, compania, ddlMeses2.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio2.SelectedValue.ToString().Substring(2, 2), tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                    for (int i = 0; i < grvBalanceNC.Rows.Count; i++)
                    {
                        //grvBalanceNC.Rows[i].Cells[4].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                        grvBalanceNC.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalanceNC.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalanceNC.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                    #endregion
                    string qry2 = String.Format(querys.DetalleMes_NC, ddlMeses2.SelectedValue.ToString(), ddlCiaNC.SelectedValue.ToString(), ddlAnio2.SelectedValue.ToString());
                    DataTable DetalleNotas = AD.SQLSvr_RealizaConsulta(qry2);
                    grvDetalleNC.Visible = true;
                    if (DetalleNotas.Rows.Count > 0)
                    {
                        grvDetalleNC.DataSource = DetalleNotas;
                        grvDetalleNC.DataBind();
                    }
                    else
                    {
                        grvDetalleNC.DataSource = null;
                        grvDetalleNC.DataBind();
                    }
                }
                else
                {
                    string consulta = String.Format(querys.BalanceNotaCredito_Total, txtFechaNC.Text, ddlCiaNC.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    if (Balance.Rows.Count > 0)
                    {
                        grvBalanceNC.DataSource = Balance;
                        grvBalanceNC.DataBind();
                    }
                    else
                    {
                        grvBalanceNC.DataSource = null;
                        grvBalanceNC.DataBind();
                    }
                    #region
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    string dia = txtFechaNC.Text.Substring(0, 2);
                    string mes = txtFechaNC.Text.Substring(3, 2);
                    string anio = txtFechaNC.Text.Substring(8, 2);
                    string tipoDoc = "'NCR','APF'";
                    string qry_iva_fecha = String.Format(querys.TotalIva_Todas, compania, dia, mes, anio, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                    if (tempIVA.Rows.Count > 0)
                    {
                        for (int i = 0; i < grvBalanceNC.Rows.Count; i++)
                        {
                            grvBalanceNC.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                            grvBalanceNC.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                            grvBalanceNC.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                        }
                    }
                    else
                    {
                        grvBalanceNC.Rows[0].Cells[5].Text ="0";
                        grvBalanceNC.Rows[0].Cells[6].Text = "0.00";
                        grvBalanceNC.Rows[0].Cells[7].Text = "0.00";
                    }
                    #endregion
                    string qry2 = String.Format(querys.DetalleNotas_Resumen, txtFechaNC.Text, ddlCiaNC.SelectedValue.ToString());
                    DataTable DetalleNotas = AD.SQLSvr_RealizaConsulta(qry2);
                    grvDetalleNC.Visible = true;
                    if (DetalleNotas.Rows.Count > 0)
                    {
                        grvDetalleNC.DataSource = DetalleNotas;
                        grvDetalleNC.DataBind();
                    }
                    else
                    {
                        grvDetalleNC.DataSource = null;
                        grvDetalleNC.DataBind();
                    }
                }
        }
        protected void mCalculaTotalesSucursalNC(string compania)
        {           
            if (chkPorMes2.Checked)
                {
                    string consulta = String.Format(querys.BalanceMes_NC_Suc, ddlMeses2.SelectedValue.ToString(), ddlCiaNC.SelectedValue.ToString(), ddlSucursalNC.SelectedValue.ToString(), ddlAnio2.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    if (Balance.Rows.Count > 0)
                    {
                        grvBalanceNC.DataSource = Balance;
                        grvBalanceNC.DataBind();
                    }
                    else
                    {
                        grvBalanceNC.DataSource = null;
                        grvBalanceNC.DataBind();
                    }
                    #region
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaNC.SelectedValue, ddlSucursalNC.SelectedValue.ToString());
                    DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                    string sucursalesAS = "'-1'";
                    if (sucursalASDT.Rows.Count > 0)
                    {
                        sucursalesAS = armaLista(sucursalASDT);
                    }
                    string tipoDoc = "'NCR','APF'";
                    string qry_iva_mes = String.Format(querys.DetalleIva_Suc_Mes, compania, ddlMeses2.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio2.SelectedValue.ToString().Substring(2, 2), sucursalesAS, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                    for (int i = 0; i < grvBalanceNC.Rows.Count; i++)
                    {
                        grvBalanceNC.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalanceNC.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalanceNC.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                    #endregion
                }
                else
                {
                    string consulta = String.Format(querys.BalanceNotaCredito_Suc, txtFechaNC.Text, ddlCiaNC.SelectedValue.ToString(), ddlSucursalNC.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    if (Balance.Rows.Count > 0)
                    {
                        grvBalanceNC.DataSource = Balance;
                        grvBalanceNC.DataBind();
                    }
                    else
                    {
                        grvBalanceNC.DataSource = null;
                        grvBalanceNC.DataBind();
                    }
                    #region
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaNC.SelectedValue, ddlSucursalNC.SelectedValue.ToString());
                    DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                    string sucursalesAS = "'-1'";
                    if (sucursalASDT.Rows.Count > 0)
                    {
                        sucursalesAS = armaLista(sucursalASDT);
                    }
                    string dia = txtFechaNC.Text.Substring(0, 2);
                    string mes = txtFechaNC.Text.Substring(3, 2);
                    string anio = txtFechaNC.Text.Substring(8, 2);
                    string tipoDoc = "'NCR','APF'";
                    string qry_iva_fecha = String.Format(querys.DetalleIva_Suc, compania, dia, mes, anio, sucursalesAS, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                    if (tempIVA.Rows.Count > 0)
                    {
                        for (int i = 0; i < grvBalanceNC.Rows.Count; i++)
                        {
                            grvBalanceNC.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                            grvBalanceNC.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                            grvBalanceNC.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                        }
                    }
                    else
                    {
                        grvBalanceNC.Rows[0].Cells[5].Text = "0";
                        grvBalanceNC.Rows[0].Cells[6].Text = "0.00";
                        grvBalanceNC.Rows[0].Cells[7].Text = "0.00";
                    }
                    #endregion
                }
        }
        protected void ddlSucursalFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            String compania = obtenerCompania(ddlCiaFac.SelectedValue);                        
            String qry = String.Format(querys.TipoDoc_fac, compania);
            DataTable TipoDocumento = AD.RealizaConsulta(qry);
            DataTable temp = TipoDocumento.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (TipoDocumento.Rows.Count > 0)
            {
                foreach (DataRow r in TipoDocumento.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlTipoDocFac.DataSource = temp;
            ddlTipoDocFac.DataValueField = "TIPO";
            ddlTipoDocFac.DataTextField = "NOMBRE";
            ddlTipoDocFac.DataBind();
        }

        protected void ddlSucursalNC_SelectedIndexChanged(object sender, EventArgs e)
        {
            String compania = obtenerCompania(ddlCiaNC.SelectedValue);                        
            String qry = String.Format(querys.TipoDoc_nc, compania);
            DataTable TipoDocumento = AD.RealizaConsulta(qry);
            DataTable temp = TipoDocumento.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (TipoDocumento.Rows.Count > 0)
            {
                foreach (DataRow r in TipoDocumento.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlTipoDocNC.DataSource = temp;
            ddlTipoDocNC.DataValueField = "TIPO";
            ddlTipoDocNC.DataTextField = "NOMBRE";
            ddlTipoDocNC.DataBind();
        }

        private String armaLista(DataTable param)
        {
            String lista = "";
            foreach (DataRow r in param.Rows)
            {
                lista = lista + "'"+r[0].ToString() + "',";
            }
            lista = lista.Remove(lista.LastIndexOf(","), 1);
            return lista;
        }

        protected void chkPorMes_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkPorMes.Checked)
            {
                txtFechaFac.Dispose();
                txtFechaFac.Enabled = false;
                txtFechaFac.Visible = false;
                ddlMeses.Enabled = true;
                ddlMeses.Visible = true;
                ddlMeses.Focus();
                ddlAnio.Enabled = true;
                ddlAnio.Visible = true;
                chkPorMes.Checked = true;
                RequiredFieldValidator6.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
                RequiredFieldValidator14.Enabled = true;
                RequiredFieldValidator15.Enabled = true;
                lblFacCuadre.Text = "Fecha por Mes";
                listaAnios();
                listaMeses();
                grvBalance.Visible = false;
                return;
            }
            if (chkPorMes.Checked == false)
            {
                ddlMeses.Dispose();
                ddlMeses.Enabled = false;
                ddlMeses.Visible = false;
                ddlAnio.Dispose();
                ddlAnio.Enabled = false;
                ddlAnio.Visible = false;
                txtFechaFac.Enabled = true;
                txtFechaFac.Visible = true;
                chkPorMes.Checked = false;
                RequiredFieldValidator6.Enabled = true;
                RegularExpressionValidator2.Enabled = true;
                RequiredFieldValidator14.Enabled = false;
                RequiredFieldValidator15.Enabled = false;
                lblFacCuadre.Text = "Fecha por día";
                grvBalance.Visible = false;
            }
            
        }

        private void listaMeses()
        {
            ddlMeses.Items.Clear();
            ddlMeses2.Items.Clear();
            DataTable meses = new DataTable();
            meses.Columns.Add("ID");
            meses.Columns.Add("MES");
            meses.Rows.Add("0", "Seleccione Mes...");
            meses.Rows.Add("1", "ENERO");
            meses.Rows.Add("2", "FEBRERO");
            meses.Rows.Add("3", "MARZO");
            meses.Rows.Add("4", "ABRIL");
            meses.Rows.Add("5", "MAYO");
            meses.Rows.Add("6", "JUNIO");
            meses.Rows.Add("7", "JULIO");
            meses.Rows.Add("8", "AGOSTO");
            meses.Rows.Add("9", "SEPTIEMBRE");
            meses.Rows.Add("10", "OCTUBRE");
            meses.Rows.Add("11", "NOVIEMBRE");
            meses.Rows.Add("12", "DICIEMBRE");
            ddlMeses.DataSource = meses;
            ddlMeses.DataValueField = "ID";
            ddlMeses.DataTextField = "MES";
            ddlMeses.DataBind();
            ddlMeses2.DataSource = meses;
            ddlMeses2.DataValueField = "ID";
            ddlMeses2.DataTextField = "MES";
            ddlMeses2.DataBind();
        }

        private void listaAnios()
        {
            ddlAnio.Items.Clear();
            ddlAnio2.Items.Clear();
            DataTable anio = new DataTable();
            anio.Columns.Add("ID");
            anio.Columns.Add("ANIO");
            anio.Rows.Add("-1", "Seleccione Año...");
            for (int i = 2012; i < System.DateTime.Now.Year+1; i++)
            {
                anio.Rows.Add(i, i);
            }
            ddlAnio.DataSource = anio;
            ddlAnio.DataValueField = "ID";
            ddlAnio.DataTextField = "ANIO";
            ddlAnio.DataBind();
            ddlAnio2.DataSource = anio;
            ddlAnio2.DataValueField = "ID";
            ddlAnio2.DataTextField = "ANIO";
            ddlAnio2.DataBind();
        }

        protected void chkPorMes2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPorMes2.Checked)
            {
                txtFechaNC.Dispose();
                txtFechaNC.Enabled = false;
                txtFechaNC.Visible = false;
                ddlMeses2.Enabled = true;
                ddlMeses2.Visible = true;
                ddlMeses2.Focus();
                ddlAnio2.Enabled = true;
                ddlAnio2.Visible = true;
                chkPorMes2.Checked = true;
                RequiredFieldValidator11.Enabled = false;
                RegularExpressionValidator3.Enabled = false;
                RequiredFieldValidator16.Enabled = true;
                RequiredFieldValidator17.Enabled = true;
                lblNCCuadre.Text = "Fecha por Mes";
                listaAnios();
                listaMeses();
                grvBalanceNC.Visible = false;
                return;
            }
            if (chkPorMes2.Checked == false)
            {
                ddlMeses2.Dispose();
                ddlMeses2.Enabled = false;
                ddlMeses2.Visible = false;
                ddlAnio2.Dispose();
                ddlAnio2.Enabled = false;
                ddlAnio2.Visible = false;
                txtFechaNC.Enabled = true;
                txtFechaNC.Visible = true;
                chkPorMes2.Checked = false;
                RequiredFieldValidator11.Enabled = true;
                RegularExpressionValidator3.Enabled = true;
                RequiredFieldValidator16.Enabled = false;
                RequiredFieldValidator17.Enabled = false;
                lblFacCuadre.Text = "Fecha por día";
                grvBalanceNC.Visible = false;
            }
        }
        /// <summary>
        /// Arma los cuadros para comparar datos para el cuadre
        /// </summary>
        protected void armaCuadro(string nCia, string mes, string anio, string tipoDoc, string td, string mesReporte, string tCia)
        {               
            DataTable dtEface = new DataTable();
            DataTable dtVentas = new DataTable();
            DataTable dtDatos = new DataTable();
            DataTable dtDatos2 = new DataTable();
            String strQry_Eface = "";
            String strQry_Ventas = "";
            bool condicionPeriodo = tipoDoc.Equals("4") ? chkPorMes.Checked : chkPorMes2.Checked;
            String fecha = tipoDoc.Equals("4") ? txtFechaFac.Text : txtFechaNC.Text;
            string fechaReporte = (condicionPeriodo)?"":String.Format("{0}-{1}-{2}",fecha.Substring(0,2),fecha.Substring(3,2),fecha.Substring(6,4));
            String periodo = (condicionPeriodo) ? "<> -1" : string.Format(" = {0}", fecha.Substring(0, 2));
            String sucursal = tipoDoc.Equals("4") ? ddlSucursalFac.SelectedValue : ddlSucursalNC.SelectedValue;
            String gsucod = (int.Parse(sucursal) < 1) ? "<>-1" : string.Format(" = {0}", sucursal);
            //datos reporte
            NombreArchivo = "REPORTE " + (condicionPeriodo ? obtenerMes(mes) : fechaReporte) + (tipoDoc.Equals("4") ? " FACTURAS " : " NOTAS ") + tCia + " [" + Session["User"].ToString() + "]";
            //nombreArchivo = "REPORTE " + (condicionPeriodo ? obtenerMes(mes) : fechaReporte) + (tipoDoc.Equals("4") ? " FACTURAS " : " NOTAS ") + tCia + " [" + Session["User"].ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "]";
            strQry_Eface = string.Format(tipoDoc.Equals("4") ? querys.CuadroEfaceFAC : querys.CuadroEfaceNC, mes, anio, nCia, tipoDoc, periodo, gsucod);
            strQry_Ventas = string.Format(querys.CuadroVentas, tCia, (int.Parse(mes) < 10) ? String.Format("0{0}", int.Parse(mes).ToString()) : mes, anio.Substring(2, 2), td, periodo, gsucod);
            dtEface = AD.SQLSvr_RealizaConsulta(strQry_Eface);
            dtVentas = AD.RealizaConsulta(strQry_Ventas);
            GeneraExcell ge = new GeneraExcell();
            ge.depurarDatos(ref dtEface, ref dtVentas);
            //dtDatos = ge.UneTablas(dtEface, dtVentas);
            dtDatos2 = ge.UneTablas2(dtEface, dtVentas);
            //ge.DoExcell(AppDomain.CurrentDomain.BaseDirectory.ToString()+"nuevo_file.html",mes);
            ge.DoExcell(AppDomain.CurrentDomain.BaseDirectory.ToString() +"/reporte/"+ NombreArchivo+".xls", NombreArchivo,dtDatos2);
//            mDownloadFile(ge.DoExcell(NombreArchivo,dtDatos2),"diferencias.xls");
            
        }       
        protected void btnReporteDiferenciasFacturas_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hlExcel_FAC.NavigateUrl))
            {
                FileInfo tmp = new FileInfo(hlExcel_FAC.NavigateUrl);
                if (tmp.Exists)
                    tmp.Delete();
            }
            armaCuadro(ddlCiaFac.SelectedValue.ToString(), (chkPorMes.Checked) ? ddlMeses.SelectedValue.ToString() : txtFechaFac.Text.Substring(3, 2), (chkPorMes.Checked) ? ddlAnio.SelectedValue.ToString() : txtFechaFac.Text.Substring(6, 4), "4", "'FAC'", (chkPorMes.Checked) ? ddlMeses.SelectedItem.ToString() : obtenerMes(txtFechaFac.Text.Substring(3, 2)), obtenerCompania(ddlCiaFac.SelectedValue));
            hlExcel_FAC.ImageUrl = "~/img/xcel.png";
            hlExcel_FAC.NavigateUrl = "~/reporte/" + NombreArchivo + ".xls";
            hlExcel_FAC.Visible = true;
            hlExcel_FAC.Enabled = true;            
        }
        /// <summary>
        /// Obtiene las iniciales de la compania a partir de su codigo
        /// </summary>
        /// <param name="codCompania">codigo de la compania (ej. 45,66,130)</param>
        /// <returns>retorna las iniciales de la compania (ej. cs,ac,rc)</returns>
        private string obtenerCompania(string codCompania)
        {
            string compania = "";
            switch (codCompania)
            {
                case "45": compania = "CS";
                    break;
                case "66": compania = "AC";
                    break;
                case "130": compania = "RC";
                    break;
                case "192": compania = "RE";
                    break;
                case "199": compania = "AA";
                    break;
                case "280": compania = "CA";
                    break;
                case "281": compania = "SF";
                    break;
                case "282": compania = "NA";
                    break;
                case "283": compania = "VL";
                    break;
                case "284": compania = "SA";
                    break;
                case "CS": compania = "45";
                    break;
                case "AC": compania = "66";
                    break;
                case "RC": compania = "130";
                    break;
                case "RE": compania = "192";
                    break;
                case "AA": compania = "199";
                    break;
                case "CA": compania = "280";
                    break;
                case "SF": compania = "281";
                    break;
                case "NA": compania = "282";
                    break;
                case "VL": compania = "283";
                    break;
                case "SA": compania = "284";
                    break;          
            }
            return compania;
        }
        private string obtenerMes(string codMes)
        {
            string strMes = "";
            switch (int.Parse(codMes))
            {
                case 1: strMes = "ENERO"; break;
                case 2: strMes = "FEBRERO"; break;
                case 3: strMes = "MARZO"; break;
                case 4: strMes = "ABRIL"; break;
                case 5: strMes = "MAYO"; break;
                case 6: strMes = "JUNIO"; break;
                case 7: strMes = "JULIO"; break;
                case 8: strMes = "AGOSTO"; break;
                case 9: strMes = "SEPTIEMBRE"; break;
                case 10: strMes = "OCTUBRE"; break;
                case 11: strMes = "NOVIEMBRE"; break;
                case 12: strMes = "DICIEMBRE"; break;
            }
            return strMes;
        }

        protected void btnReporteDiferenciasNCR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hlExcel_NCR.NavigateUrl))
            {
                FileInfo tmp = new FileInfo(hlExcel_NCR.NavigateUrl);
                if (tmp.Exists)
                    tmp.Delete();
            }
            armaCuadro(ddlCiaNC.SelectedValue.ToString(), (chkPorMes2.Checked) ? ddlMeses2.SelectedValue.ToString() : txtFechaNC.Text.Substring(3, 2), (chkPorMes2.Checked) ? ddlAnio2.SelectedValue.ToString() : txtFechaNC.Text.Substring(6, 4), "5", "'NCR','APF'", (chkPorMes2.Checked) ? ddlMeses2.SelectedItem.ToString() : obtenerMes(txtFechaNC.Text.Substring(3, 2)), obtenerCompania(ddlCiaNC.SelectedValue));
            hlExcel_NCR.ImageUrl = "~/img/xcel.png";
            hlExcel_NCR.NavigateUrl = "~/reporte/" + NombreArchivo + ".xls";
            hlExcel_NCR.Visible = true;
            hlExcel_NCR.Enabled = true;            
        }
        /// <summary>
        /// Genera el nombre del archivo
        /// </summary>
        /// <param name="tipoDoc">Indica si es Factura o Nota</param>
        /// <param name="mes">mes correspondiente a la constancia</param>
        /// <param name="tCia">Nombre de la compañia de la constancia</param>
        /// <returns>Nombre generado para el archivo</returns>
        protected string mGeneraNombreArchivo(string tipoDoc,string mes,string tCia)
        {
            string sRespuesta = "";
            string anioReporte = tipoDoc.Equals("4") ? ddlAnio.SelectedValue : ddlAnio2.SelectedValue;
            bool condicionPeriodo = tipoDoc.Equals("4") ? chkPorMes.Checked : chkPorMes2.Checked;
            string fecha = tipoDoc.Equals("4") ? txtFechaFac.Text : txtFechaNC.Text;
            string fechaReporte = (condicionPeriodo) ? "" : String.Format("{0}-{1}-{2}", fecha.Substring(0, 2), fecha.Substring(3, 2), fecha.Substring(6, 4));
            string periodo = (condicionPeriodo) ? "<> -1" : string.Format(" = {0}", fecha.Substring(0, 2));
            string sucursal = tipoDoc.Equals("4") ? ddlSucursalFac.SelectedValue : ddlSucursalNC.SelectedValue;
            string gsucod = (int.Parse(sucursal) < 1) ? "<>-1" : string.Format(" = {0}", sucursal);
            //datos reporte
            sRespuesta = "CONSTANCIA " + (condicionPeriodo ? obtenerMes(mes) + " " + anioReporte : fechaReporte) + (tipoDoc.Equals("4") ? " FACTURAS " : " NOTAS ") + tCia + " [" + Session["User"].ToString() + "]";
            //sRespuesta = "REPORTE " + (condicionPeriodo ? obtenerMes(mes) + " " + anioReporte : fechaReporte) + (tipoDoc.Equals("4") ? " FACTURAS " : " NOTAS ") + tCia;
            return sRespuesta;
        }       
        protected void btnGeneraConstanciaFac_Click(object sender, EventArgs e)
        {
            if (grvBalance.Rows.Count == 0)
            {
                btnCalcular_Click(null, null);
            }
            string strNombreArchivo = mGeneraNombreArchivo("4", (chkPorMes.Checked) ? ddlMeses.SelectedValue.ToString() : txtFechaFac.Text.Substring(3, 2), obtenerCompania(ddlCiaFac.SelectedValue));
            NombreArchivo = strNombreArchivo.Trim();
            mCreaPDF(grvBalance,grvDetalleFac);            
            // mCreaPDF2();
            //hlPDF_FAC.Enabled = true;
            //hlPDF_FAC.ImageUrl = "~/img/pdf.png";
            //hlPDF_FAC.NavigateUrl = "~/constancia/constancia.pdf";            

            ifConstanciaFAC.Attributes.Add("src", "Documento.aspx?pNombreArchivo="+strNombreArchivo);
            ifConstanciaFAC.Visible = true;
        }

        protected void btnGeneraConstanciaNCR_Click(object sender, EventArgs e)
        {
            if (this.grvBalanceNC.Rows.Count == 0)
            {
                btnCalcularNC_Click(null, null);                
            }
            string strNombreArchivo = mGeneraNombreArchivo("5", (chkPorMes.Checked) ? ddlMeses.SelectedValue.ToString() : txtFechaFac.Text.Substring(3, 2), obtenerCompania(ddlCiaFac.SelectedValue));
            NombreArchivo = strNombreArchivo.Trim();
            mCreaPDF(grvBalanceNC, grvDetalleNC);           

            ifConstanciaNCR.Attributes.Add("src", "Documento.aspx?pNombreArchivo=" + strNombreArchivo);
            ifConstanciaNCR.Visible = true;
        }
       
        protected void mCreaPDF(GridView gvMaestro, GridView gvDetalle)
        {
            MemoryStream tmp = new MemoryStream();
            try
            {
                //Dimensiones del Docuemnto
                //Document documento = new Document(PageSize.LETTER, 50, 50, 80, 50);
                Document documento = new Document(PageSize.LETTER);
                
                // step 2: creamos el documento            
                 //pdf.PdfWriter.GetInstance(Documento, New FileStream("Demo.pdf", FileMode.Create)) '
                //PdfWriter writerPdf = PdfWriter.GetInstance(documento, tmp);
                string ruta = AppDomain.CurrentDomain.BaseDirectory.ToString()+"/constancia/"+NombreArchivo+".pdf";
                PdfWriter writerPdf = PdfWriter.GetInstance(documento, new FileStream(ruta, System.IO.FileMode.Create,FileAccess.ReadWrite));
                //PdfWriter writerPdf = PdfWriter.GetInstance(documento, tmp);
                itsEvents ev = new itsEvents();
                ev.USUARIO = Session["User"].ToString();
                ev.CREACION = DateTime.Now;
                writerPdf.PageEvent = ev;
                //writerPdf.SetEncryption(PdfWriter.STANDARD_ENCRYPTION_128, null, null, PdfWriter.AllowPrinting);
                
                #region FUENTES Y TEXTOS DE ARCHIVO
                Font fontFirmas = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, Font.BOLD, BaseColor.BLACK);
                Font font20B = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, Font.BOLD, BaseColor.DARK_GRAY);
                Font font8B = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, Font.BOLD, BaseColor.DARK_GRAY);
                Font LetraTituloTabla = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, Font.BOLDITALIC);
                Font LetraContenidoTabla = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);
                Phrase Titulo = new Phrase("CONSTANCIA DE RESGUARDO", font20B);
                Phrase SubTitulo = new Phrase(Session["NombreArchivo"].ToString(), font8B);
                Phrase SubTitulo2 = new Phrase("DETALLE POR SUCURSAL", LetraTituloTabla);
                #endregion
                // step 3: abrimos el documento
                documento.Open();
                #region ENCABEZADO                
                
                ////agregar imagen 
                //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/img/cofiño_stahl.jpg");
                ////jpg.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                //jpg.ScalePercent(25f);

                ////We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
                //Phrase p1Header = new Phrase("Facturación Electrónica", FontFactory.GetFont("verdana", 14));
                //Phrase p2Header = new Phrase(DateTime.Now.ToLongDateString(), FontFactory.GetFont("verdana", 8));

                ////create iTextSharp.text Image object using local image path
                //iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + "\\img\\cofiño_stahl.jpg");
                //imgPDF.ScalePercent(25f);
                ////Create PdfTable object
                //PdfPTable pdfTab = new PdfPTable(3);
                ////We will have to create separate cells to include image logo and 2 separate strings
                //PdfPCell pdfCell1 = new PdfPCell(imgPDF);
                //PdfPCell pdfCell2 = new PdfPCell(p1Header);
                //PdfPCell pdfCell3 = new PdfPCell(p2Header);
                ////set the alignment of all three cells and set border to 0
                //pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                //pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                //pdfCell3.HorizontalAlignment = Element.ALIGN_LEFT;
                //pdfCell1.Border = 0;
                //pdfCell2.Border = 0;
                //pdfCell3.Border = 0;
                //pdfCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                //pdfCell3.VerticalAlignment = Element.ALIGN_BOTTOM;
                ////establecer anchos
                //float[] withsHead = new float[] { 14f, 49f, 21f };
                ////add all three cells into PdfTable
                //pdfTab.AddCell(pdfCell1);
                //pdfTab.AddCell(pdfCell2);
                //pdfTab.AddCell(pdfCell3);
                //pdfTab.SetWidthPercentage(withsHead, documento.PageSize);
                //pdfTab.TotalWidth = documento.PageSize.Width - 30;
                ////call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                ////first param is start row. -1 indicates there is no end row and all the rows to be included to write
                ////Third and fourth param is x and y position to start writing
                //pdfTab.WriteSelectedRows(0, -1, 30, documento.PageSize.Height - 15, writerPdf.DirectContent);
                ////set pdfContent value
                //PdfContentByte pdfContent = writerPdf.DirectContent;
                ////Move the pointer and draw line to separate header section from rest of page
                //pdfContent.MoveTo(30, documento.PageSize.Height - 45);
                //pdfContent.LineTo(documento.PageSize.Width - 40, documento.PageSize.Height - 45);
                //pdfContent.Stroke();

                //documento.Add(new Phrase(Chunk.NEWLINE));
                //documento.Add(new Phrase(Chunk.NEWLINE));
                //documento.Add(new Phrase(Chunk.NEWLINE));
                #endregion

                #region TITULO Y SUBTITULO
                Paragraph pTitulo = new Paragraph(Titulo);
                pTitulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(pTitulo);

                Paragraph pSubTitulo = new Paragraph(SubTitulo);
                pSubTitulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(pSubTitulo);

                documento.Add(new Phrase(Chunk.NEWLINE));
                #endregion

                #region MAESTRO
                //Creacion de la tabla que se mostrara en el Pdf
                PdfPTable table = new PdfPTable(8);
                //Cremos las cabeceras de la tabla                               
                PdfPCell compania = new PdfPCell(new Phrase("Compañia", LetraTituloTabla));
                PdfPCell tipoDocumento = new PdfPCell(new Phrase("Tipo Documento", LetraTituloTabla));
                PdfPCell cantidadDocumentos = new PdfPCell(new Phrase("Cantidad de Documentos", LetraTituloTabla));
                PdfPCell totalEFACE = new PdfPCell(new Phrase("Total EFACE", LetraTituloTabla));
                PdfPCell ivaEFACE = new PdfPCell(new Phrase("IVA EFACE", LetraTituloTabla));
                PdfPCell cantidadDocumentosVentas = new PdfPCell(new Phrase("Cantidad Documentos Ventas", LetraTituloTabla));
                PdfPCell ivaVentas = new PdfPCell(new Phrase("IVA Ventas", LetraTituloTabla));
                PdfPCell totalVentas = new PdfPCell(new Phrase("Total Ventas", LetraTituloTabla));

                compania.HorizontalAlignment = Element.ALIGN_CENTER;
                tipoDocumento.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidadDocumentos.HorizontalAlignment = Element.ALIGN_CENTER;
                totalEFACE.HorizontalAlignment = Element.ALIGN_CENTER;
                ivaEFACE.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidadDocumentosVentas.HorizontalAlignment = Element.ALIGN_CENTER;
                ivaVentas.HorizontalAlignment = Element.ALIGN_CENTER;
                totalVentas.HorizontalAlignment = Element.ALIGN_CENTER;

                //Adicionamos las cabeceras a la tabla
                table.AddCell(compania);
                table.AddCell(tipoDocumento);
                table.AddCell(cantidadDocumentos);
                table.AddCell(totalEFACE);
                table.AddCell(ivaEFACE);
                table.AddCell(cantidadDocumentosVentas);
                table.AddCell(ivaVentas);
                table.AddCell(totalVentas);
                
                // recorremos todos las filas del Datatable

                foreach (GridViewRow fila in gvMaestro.Rows)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        PdfPCell ctmp;
                        if (k>2 && k<8 && k!=5)
                            ctmp = new PdfPCell(new Phrase("Q. "+fila.Cells[k].Text, LetraContenidoTabla));
                        else
                            ctmp = new PdfPCell(new Phrase((fila.Cells[k].Text.Contains("&#209;")) ? fila.Cells[k].Text.Replace("&#209;", "Ñ") : fila.Cells[k].Text, LetraContenidoTabla));
                        if (k > 1)
                            ctmp.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(ctmp);
                    }
                }
                table.WidthPercentage = 100;
                //table.TotalWidth = 1000;
                //table.WriteSelectedRows(0, -1, 50, 700, writerPdf.DirectContent);

                documento.Add(table);
                documento.Add(new Phrase(Chunk.NEWLINE));
                #endregion

             
                #region DETALLE
                PdfPTable table2 = new PdfPTable(5);
                PdfPCell compania2 = new PdfPCell(new Phrase("Compañia", LetraTituloTabla));
                PdfPCell tipoDocumento2 = new PdfPCell(new Phrase("Tipo Documento", LetraTituloTabla));
                PdfPCell sucursal = new PdfPCell(new Phrase("Sucursal", LetraTituloTabla));
                PdfPCell cantidad = new PdfPCell(new Phrase("Cantidad", LetraTituloTabla));
                PdfPCell totalEFACE2 = new PdfPCell(new Phrase("Total EFACE", LetraTituloTabla));

                float[] withs = new float[] { 8f, 8f, 8f, 3f, 6f };
                table2.SetWidths(withs);
                compania2.HorizontalAlignment = Element.ALIGN_CENTER;
                tipoDocumento2.HorizontalAlignment = Element.ALIGN_CENTER;
                sucursal.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                totalEFACE2.HorizontalAlignment = Element.ALIGN_CENTER;
                //Adicionamos las cabeceras a la tabla
                table2.AddCell(compania2);
                table2.AddCell(tipoDocumento2);
                table2.AddCell(sucursal);
                table2.AddCell(cantidad);
                table2.AddCell(totalEFACE2);

                // for (int j = 0; j < 50;j++ )
                // recorremos todos las filas del Datatable
                int iCantidad = 0;
                double iTotal = 0;
                foreach (GridViewRow fila in gvDetalle.Rows)
                {                    
                    for (int k = 0; k < 5; k++)
                    {
                        PdfPCell ctmp2;
                        if (k == 3)
                            iCantidad += int.Parse(fila.Cells[k].Text);                        
                        if (k == 4)
                        {
                            iTotal += double.Parse(fila.Cells[k].Text);
                            ctmp2 = new PdfPCell(new Phrase("Q. " + fila.Cells[k].Text, LetraContenidoTabla));
                        }
                        else
                            ctmp2 = new PdfPCell(new Phrase((fila.Cells[k].Text.Contains("&#209;")) ? fila.Cells[k].Text.Replace("&#209;", "Ñ") : fila.Cells[k].Text, LetraContenidoTabla));
                        if (k > 2)
                            ctmp2.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table2.AddCell(ctmp2);
                    }                    
                }
                PdfPCell tmpEspacioCelda = new PdfPCell();
                tmpEspacioCelda.Colspan = 3;
                table2.AddCell(tmpEspacioCelda);                
                PdfPCell tmpCantidad = new PdfPCell();
                PdfPCell tmpTotal = new PdfPCell();
                tmpCantidad = new PdfPCell(new Phrase(iCantidad.ToString(), LetraContenidoTabla));
                //string aux = String.Format("{0:n}", iTotal);
                tmpTotal = new PdfPCell(new Phrase("Q. " + String.Format("{0:n}",iTotal), LetraContenidoTabla));
                tmpCantidad.HorizontalAlignment = Element.ALIGN_RIGHT;
                tmpTotal.HorizontalAlignment = Element.ALIGN_RIGHT;                                
                table2.AddCell(tmpCantidad);                
                table2.AddCell(tmpTotal);

                table2.WidthPercentage = 100;
                //table2.WriteSelectedRows(0, -1, 50, 900, writerPdf.DirectContent);
                Paragraph pSubTitulo2 = new Paragraph(SubTitulo2);
                pSubTitulo.Alignment = Element.ALIGN_LEFT;
                documento.Add(pSubTitulo2);
                documento.Add(table2);
                mEspacio(6, documento);
                #endregion
                    


                #region FIRMA
                //tabla de firmas
                PdfPTable tFirmas = new PdfPTable(3);
                PdfPCell cFirma1 = new PdfPCell();
                PdfPCell cFirma2 = new PdfPCell();
                PdfPCell cEspacio = new PdfPCell();                
                Paragraph pFirma1 = new Paragraph("WALTER CANU", fontFirmas);                
                string operador = AD.RealizaConsulta(String.Format(querys.NombreUsuario, Session["User"].ToString())).Rows[0][0].ToString();
                Paragraph pFirma2 = new Paragraph(operador.Trim(), fontFirmas);
                Phrase pEspacio = new Phrase("     ");
                pFirma1.Alignment = Element.ALIGN_TOP;
                pFirma2.Alignment = Element.ALIGN_TOP;
                pFirma1.Alignment = Element.ALIGN_CENTER;
                pFirma2.Alignment = Element.ALIGN_CENTER;
                cFirma1.AddElement(pFirma1);
                cFirma2.AddElement(pFirma2);
                cFirma1.HorizontalAlignment = Element.ALIGN_CENTER;
                cFirma1.VerticalAlignment = Element.ALIGN_TOP;
                cFirma2.HorizontalAlignment = Element.ALIGN_CENTER;
                cFirma2.VerticalAlignment = Element.ALIGN_TOP;
                cFirma1.Border = 1;
                cFirma2.Border = 1;
                cEspacio.Border = 0;
                tFirmas.AddCell(cFirma1);
                tFirmas.AddCell(cEspacio);
                tFirmas.AddCell(cFirma2);
                float[] widthFirmas = new float[] { 45, 10, 45 };
                tFirmas.SetWidths(widthFirmas);

                documento.Add(tFirmas);
                #endregion
                mEspacio(5, documento);                                
                
                // step 4: Cerramos el Documento
                documento.Close();
            }
            catch (DocumentException de)
            {
                Debug.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
            }
            #region DESCARGAR CONSTANCIA PDF        

            //mDownloadFile(tmp,"constancia.pdf");

            #endregion
        }
        /// <summary>
        /// Metodo para descargar el archivo
        /// </summary>
        /// <param name="pTmp"></param>
        /// <param name="pNE"></param>
        protected void mDownloadFile(MemoryStream pTmp, string pNE)
        {
            
            if (pTmp != null)
            {
                Byte[] byteArray = pTmp.ToArray();
                pTmp.Flush();
                pTmp.Close();
                Response.BufferOutput = true;
                // Clear all content output from the buffer stream
                Response.Clear();
                //to fix the “file not found” error when opening excel file
                //See http://www.aspose.com/Community/forums/ShowThread.aspx?PostID=61444
                Response.ClearHeaders();
                // Add a HTTP header to the output stream that specifies the default filename
                // for the browser’s download dialog                    
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}",pNE));
                // Set the HTTP MIME type of the output stream
                Response.ContentType = "application/octet-stream";
                // Write the data
                Response.BinaryWrite(byteArray);
                Response.End();
            }

        }

        protected void mObtenerMaestro()
        {            
            String compania = obtenerCompania(ddlCiaFac.SelectedValue);            

            if (ddlSucursalFac.SelectedValue.Equals("0"))
            {
                if (chkPorMes.Checked)
                {
                    string consulta = String.Format(querys.BalanceMes_FC_Total, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);                    
                    
                    //////Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    string tipoDoc = "'FAC'";
                    string qry_iva_mes = String.Format(querys.TotalIva_Todas_Mes, compania, ddlMeses.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio.SelectedValue.ToString().Substring(2, 2), tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                    
                    string qry2 = String.Format(querys.DetalleMes_FC, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                    DataTable DetalleFacturas = AD.SQLSvr_RealizaConsulta(qry2);                    
                }
                else
                {
                    string consulta = String.Format(querys.BalanceFacturas_Total, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    string dia = txtFechaFac.Text.Substring(0, 2);
                    string mes = txtFechaFac.Text.Substring(3, 2);
                    string anio = txtFechaFac.Text.Substring(8, 2);
                    string tipoDoc = "'FAC'";
                    string qry_iva_fecha = String.Format(querys.TotalIva_Todas, compania, dia, mes, anio, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[5].Text = tempIVA.Rows[i][2].ToString();
                        grvBalance.Rows[i].Cells[6].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][1]);
                        grvBalance.Rows[i].Cells[7].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }
                    
                    string qry2 = String.Format(querys.DetalleFacturas_Resumen, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString());
                    DataTable DetalleFacturas = AD.SQLSvr_RealizaConsulta(qry2);
                    
                }
            }
            else
            {
                if (chkPorMes.Checked)
                {
                    string consulta = String.Format(querys.BalanceMes_FC_Suc, ddlMeses.SelectedValue.ToString(), ddlCiaFac.SelectedValue.ToString(), ddlSucursalFac.SelectedValue.ToString(), ddlAnio.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);
                    
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaFac.SelectedValue, ddlSucursalFac.SelectedValue.ToString());
                    DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                    string sucursalesAS = "'-1'";
                    if (sucursalASDT.Rows.Count > 0)
                    {
                        sucursalesAS = armaLista(sucursalASDT);
                    }
                    string tipoDoc = "'FAC'";
                    string qry_iva_mes = String.Format(querys.DetalleIva_Suc_Mes, compania, ddlMeses.SelectedValue.ToString().PadLeft(2, '0'), ddlAnio.SelectedValue.ToString().Substring(2, 2), sucursalesAS, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_mes);
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[4].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    }                    
                }
                else
                {
                    string consulta = String.Format(querys.BalanceFacturas_Suc, txtFechaFac.Text, ddlCiaFac.SelectedValue.ToString(), ddlSucursalFac.SelectedValue.ToString());
                    DataTable Balance = AD.SQLSvr_RealizaConsulta(consulta);                    
                    
                    //Seccion Agregada para mostrar el Valor del IVA y compararlo con el de EFACE
                    String qry_sucAS = String.Format(querys.SucFAC_AS, ddlCiaFac.SelectedValue, ddlSucursalFac.SelectedValue.ToString());
                    DataTable sucursalASDT = AD.RealizaConsulta(qry_sucAS);
                    string sucursalesAS = "'-1'";
                    if (sucursalASDT.Rows.Count > 0)
                    {
                        sucursalesAS = armaLista(sucursalASDT);
                    }
                    string dia = txtFechaFac.Text.Substring(0, 2);
                    string mes = txtFechaFac.Text.Substring(3, 2);
                    string anio = txtFechaFac.Text.Substring(8, 2);
                    string tipoDoc = "'FAC'";
                    string qry_iva_fecha = String.Format(querys.DetalleIva_Suc, compania, dia, mes, anio, sucursalesAS, tipoDoc);
                    DataTable tempIVA = AD.RealizaConsulta(qry_iva_fecha);
                    for (int i = 0; i < grvBalance.Rows.Count; i++)
                    {
                        grvBalance.Rows[i].Cells[4].Text = String.Format("{0:#,#.##}", tempIVA.Rows[i][0]);
                    } 
                }
            }
        }
        protected void mEspacio(int pNumEspacio, Document pDocumento)
        {
            Font fEspacio = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, Font.NORMAL, BaseColor.WHITE);
            Phrase Titulo = new Phrase(".", fEspacio);
            for (int k=0; k<pNumEspacio; k++)
            {
                Paragraph pTitulo = new Paragraph(Titulo);                
                pDocumento.Add(pTitulo);
            }                
        }      

        protected void ibConstanciaFAC_Click(object sender, ImageClickEventArgs e)
        {
            this.ifConstanciaFAC.Attributes.Add("src", "Documento.aspx");
            this.ifConstanciaFAC.Visible = true;
        }

    }
}