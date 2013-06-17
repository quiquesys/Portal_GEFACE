<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="Portal_GEFACE.geface.Documento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["pNombreArchivo"].Equals(""))
            {
                string sRutaPdf = AppDomain.CurrentDomain.BaseDirectory.ToString() + "/constancia/" + Request.QueryString["pNombreArchivo"] .ToString()+ ".pdf";//Request.QueryString["rutaPdf"].ToString().Trim();
                Response.Clear();
                //Abrimos primero el pdf 
                Response.ContentType = "Application/pdf";
                //Con inline -> Abre el pdf en el explorador sin preguntar al cliente si quiere o no abrirlo o guardarlo en disco 
                //Con attachment -> Funciona como un archivo adjunto,se pregunta al cliente si quiere abrir el archivo o prefiere guardarlo en disco. 
                Response.AddHeader("Content-disposition", "inline; filename=" + sRutaPdf);
                Response.TransmitFile(sRutaPdf);
                Response.Flush(); 
            }
            else
            {

                if (!Request.QueryString["DOC"].Equals("") && !Request.QueryString["EMP"].Equals("") && !Request.QueryString["SUC"].Equals("") && !Request.QueryString["SER"].Equals("") && !Request.QueryString["TIPO"].Equals(""))
                {
                    Portal_GEFACE.ifacere.SSO_wsEFactura ws_ifacere = new Portal_GEFACE.ifacere.SSO_wsEFactura();
                    Portal_GEFACE.ifacere.clsResponseGeneral respuesta = new Portal_GEFACE.ifacere.clsResponseGeneral();
                    if (Request.QueryString["TIPO"].Equals("1"))
                    {
                        Portal_GEFACE.ifacere.BusquedaFactura bf = new Portal_GEFACE.ifacere.BusquedaFactura();
                        bf.EMPRESA = Convert.ToInt32(Request.QueryString["EMP"]);
                        bf.SUCURSAL = Convert.ToInt32(Request.QueryString["SUC"]);
                        bf.SERIE = Request.QueryString["SER"];
                        bf.NODOCUMENTO = Int64.Parse(Request.QueryString["DOC"]);
                        respuesta = ws_ifacere.RetornaDatosFactura_PDF(bf);
                    }
                    if (Request.QueryString["TIPO"].Equals("2"))
                    {
                        Portal_GEFACE.ifacere.BusquedaNotaCredito bn = new Portal_GEFACE.ifacere.BusquedaNotaCredito();
                        bn.EMPRESA = Convert.ToInt32(Request.QueryString["EMP"]);
                        bn.SUCURSAL = Convert.ToInt32(Request.QueryString["SUC"]);
                        bn.SERIE = Request.QueryString["SER"];
                        bn.NODOCUMENTO = Int64.Parse(Request.QueryString["DOC"]);
                        respuesta = ws_ifacere.RetornaDatosNotaCredito_PDF(bn);
                    }
                    byte[] documento = (byte[])respuesta.pRespuesta;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline;filename=" + Request.QueryString["SER"].ToString() + Request.QueryString["DOC"].ToString() + ".pdf");
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(documento);
                    Response.End();
                }

            }
            
            
        }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
