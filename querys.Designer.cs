﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.5466
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal_GEFACE {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso con establecimiento inflexible de tipos, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o vuelva a generar su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class querys {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal querys() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Portal_GEFACE.querys", typeof(querys).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso con establecimiento inflexible de tipos.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad 
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and convert(Char(10),f.FechaEmisio [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceFacturas_Suc {
            get {
                return ResourceManager.GetString("BalanceFacturas_Suc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad, &apos;&apos; as vcantidad, &apos;&apos; as viva, &apos;&apos; as vtotal
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt; [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceFacturas_Total {
            get {
                return ResourceManager.GetString("BalanceFacturas_Total", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad 
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and month(f.FechaEmision) = {0} an [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceMes_FC_Suc {
            get {
                return ResourceManager.GetString("BalanceMes_FC_Suc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad, &apos;&apos; as vcantidad, &apos;&apos; as viva, &apos;&apos; as vtotal
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt; [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceMes_FC_Total {
            get {
                return ResourceManager.GetString("BalanceMes_FC_Total", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad 
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and month(f.FechaEmision) =  {0} and year(f.FechaEmision)  [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceMes_NC_Suc {
            get {
                return ResourceManager.GetString("BalanceMes_NC_Suc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad, &apos;&apos; as vcantidad, &apos;&apos; as viva, &apos;&apos; as vtotal
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and month(f.Fech [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceMes_NC_Total {
            get {
                return ResourceManager.GetString("BalanceMes_NC_Total", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad 
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and convert(Char(10), f.FechaEmision, 103) = &apos;{0}&apos; and d.I [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceNotaCredito_Suc {
            get {
                return ResourceManager.GetString("BalanceNotaCredito_Suc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA_EFACE, COUNT(d.NoDocumento) as cantidad 
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa and d.EstadoDocumento &lt;&gt; &apos;A&apos; 
        ///and convert(Char(10), f.FechaEmision, 103) = &apos;{0}&apos; and d.I [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string BalanceNotaCredito_Total {
            get {
                return ResourceManager.GetString("BalanceNotaCredito_Total", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap cofiño_stahl {
            get {
                object obj = ResourceManager.GetObject("cofiño_stahl", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select gcicod as codigo, gcinoc as nombre from intgen.fgen001
        ///where gcicod in (select distinct(gcicod) from cdifac.tfac046) and gcicod in ( select distinct(scicod) from intsec.fsec001 where suscod = &apos;{0}&apos;).
        /// </summary>
        internal static string Companias {
            get {
                return ResourceManager.GetString("Companias", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select t.fcisat as codigo, f.gcinoc as nombre from intgen.fgen001 f inner join (select distinct(gcicod) as gcicod, fcisat from cdifac.tfac046) t
        ///on f.gcicod = t.gcicod inner join  (select distinct(scicod) from intsec.fsec001 where suscod = &apos;{0}&apos;) fs
        ///on f.gcicod = fs.scicod.
        /// </summary>
        internal static string Companias_EFACE_AS400 {
            get {
                return ResourceManager.GetString("Companias_EFACE_AS400", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select DAY(f.FechaEmision) as dia,d.IdSucursal as sucursal, d.Serie + CAST(d.NoDocumento as varchar) as documento, f.iva, f.total, case d.EstadoDocumento when &apos;E&apos; then &apos;&apos;
        ///else d.EstadoDocumento
        ///end as EstadoDocumento
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa
        ///and month(f.FechaEmision) = {0} and year(f.FechaEmision [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string CuadroEfaceFAC {
            get {
                return ResourceManager.GetString("CuadroEfaceFAC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select DAY(f.FechaEmision) as dia,d.IdSucursal as sucursal, d.Serie + CAST(d.NoDocumento as varchar) as documento, f.iva, f.total, case d.EstadoDocumento when &apos;E&apos; then &apos;&apos;
        ///else d.EstadoDocumento end as EstadoDocumento
        ///from SSO_IFL_DOCUMENTO d   left join SSO_GFC_NC_NOTACREDITO f
        ///on f.IdSerie = d.Serie and f.NoNotaCredito = d.NoDocumento and month(f.FechaEmision)=month(d.FechaDocumento) and year(f.FechaEmision)=year(d.FechaDocumento) and f.Resolucion=d.Resolucion inner join SSO_SEG_EMPRESA emp
        ///on d.IdEmpr [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string CuadroEfaceNC {
            get {
                return ResourceManager.GetString("CuadroEfaceNC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select gfdopr as dia, gsucod as sucursal, xnudoc as documento, abs(givfac) as iva, abs(gvtfac) total, xflanu as estado
        ///from inttax.ltax001a 
        ///where gcicod = &apos;{0}&apos;
        ///and gfsopr = &apos;1&apos;
        ///and gfmopr = &apos;{1}&apos;
        ///and gfaopr = &apos;{2}&apos; 
        ///and xcotrn in ({3}) and gfdopr {4} and gsucod {5}
        ///order by gfdopr, xnudoc.
        /// </summary>
        internal static string CuadroVentas {
            get {
                return ResourceManager.GetString("CuadroVentas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, 
        ///SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA, 
        ///COUNT(d.NoDocumento) as cantidad, suc.Descripcion as sucursal
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo,
        ///SSO_SEG_SUCURSAL suc
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa 
        ///and d.IdEmpres [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string DetalleFacturas_Resumen {
            get {
                return ResourceManager.GetString("DetalleFacturas_Resumen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select abs(sum(gvtfac)) as vtotal, abs(sum(givfac)) as viva, abs(count(xnudoc)) as vcantidad from inttax.ltax001a where gcicod = &apos;{0}&apos;
        ///and gfsopr = &apos;1&apos;
        ///and gfdopr = &apos;{1}&apos;
        ///and gfmopr = &apos;{2}&apos;
        ///and gfaopr = &apos;{3}&apos;
        ///and gsucod in ({4})
        ///and xcotrn in ({5})
        ///and xflanu &lt;&gt; &apos;A&apos;
        ///group by gcicod, gsucod.
        /// </summary>
        internal static string DetalleIva_Suc {
            get {
                return ResourceManager.GetString("DetalleIva_Suc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select coalesce(abs(sum(gvtfac)),&apos;0.00&apos;) as vtotal , coalesce(abs(sum(givfac)),&apos;0.00&apos;) as viva, coalesce(abs(count(xnudoc)),&apos;0.00&apos;) as vcantidad
        ///from inttax.ltax001a a 
        ///where a.gcicod = &apos;{0}&apos;
        ///and a.gfsopr = &apos;1&apos;
        ///and a.gfmopr = &apos;{1}&apos;
        ///and a.gfaopr = &apos;{2}&apos;
        ///and a.gsucod in ({3})
        ///and a.xcotrn in ({4})
        ///and a.xflanu &lt;&gt; &apos;A&apos;
        ///group by a.gcicod, a.gsucod.
        /// </summary>
        internal static string DetalleIva_Suc_Mes {
            get {
                return ResourceManager.GetString("DetalleIva_Suc_Mes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, 
        ///SUM(f.descuento) as Descuento, SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA, 
        ///COUNT(d.NoDocumento) as cantidad, suc.Descripcion as sucursal
        ///from SSO_GFC_FAC_FACTURA f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, SSO_IFL_TIPODOCUMENTO tipo,
        ///SSO_SEG_SUCURSAL suc
        ///where f.IdSerie = d.Serie
        ///and f.NoFactura = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = emp.IdEmpresa 
        ///and d.IdEmpres [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string DetalleMes_FC {
            get {
                return ResourceManager.GetString("DetalleMes_FC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, 
        ///SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA, COUNT(d.NoDocumento) as cantidad, suc.Descripcion as sucursal 
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, 
        ///SSO_IFL_TIPODOCUMENTO tipo, SSO_SEG_SUCURSAL suc
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = suc.IdEmpresa
        ///and d.IdSucursal = suc.IdSucursal
        ///and  [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string DetalleMes_NC {
            get {
                return ResourceManager.GetString("DetalleMes_NC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select emp.Descripcion as Compania, tipo.Descripcion as Tipo_Doc, SUM(f.total) as Total, 
        ///SUM(f.Valorneto) as ValorNeto, SUM(f.iva) as IVA, COUNT(d.NoDocumento) as cantidad, suc.Descripcion as sucursal 
        ///from SSO_GFC_NC_NOTACREDITO f, SSO_IFL_DOCUMENTO d, SSO_SEG_EMPRESA emp, 
        ///SSO_IFL_TIPODOCUMENTO tipo, SSO_SEG_SUCURSAL suc
        ///where f.IdSerie = d.Serie
        ///and f.NoNotaCredito = d.NoDocumento
        ///and d.IdTipoDocumento = tipo.IdTipoDocumento
        ///and d.IdEmpresa = suc.IdEmpresa
        ///and d.IdSucursal = suc.IdSucursal
        ///and  [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string DetalleNotas_Resumen {
            get {
                return ResourceManager.GetString("DetalleNotas_Resumen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select IdEmpresa as codigo, Descripcion as nombre from SSO_SEG_EMPRESA.
        /// </summary>
        internal static string Empresa_PDF {
            get {
                return ResourceManager.GetString("Empresa_PDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select distinct(IdSerie) as codigo, IdSerie as nombre from SSO_GFC_FAC_SERIE where IdEmpresa = {0} and IdSucursal = {1}.
        /// </summary>
        internal static string FacturaSerie_PDF {
            get {
                return ResourceManager.GetString("FacturaSerie_PDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select 
        ///trim(fac.gnufac) as DOCUMENTO,  
        ///  fac.gfrimp as CORRELATIVO , 
        ///  caja.fsrfac as CAJA
        ///  from cdifac.tfac051 fac left join intfac.ffac007 caja 
        ///  on fac.gcicod=caja.gcicod and fac.gfrimp=caja.fcoprt
        ///  where fac.gfancr=&apos;{0}&apos; and fac.gcicod=&apos;{1}&apos; and (caja.fsrfac =&apos;&apos; OR CAJA.FSRFAC IS NULL).
        /// </summary>
        internal static string FaltaCaja {
            get {
                return ResourceManager.GetString("FaltaCaja", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select CASE (gfancr) WHEN &apos;1&apos; THEN &apos;FACTURA&apos; WHEN &apos;2&apos; THEN &apos;NOTA DE CREDITO&apos; END AS TIPO,gnufac as DOCUMENTO, (GFDFAC||&apos;-&apos;||GFMFAC||&apos;-&apos;||GFAFAC) as fecha from cdifac.tfac051 where gnufac not in(
        ///		select distinct(gnufac) as gnufac from cdifac.tfac052) ORDER BY GFANCR.
        /// </summary>
        internal static string FaltaDetalle {
            get {
                return ResourceManager.GetString("FaltaDetalle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select n.* from (SELECT cta.anudoc AS documento
        ///FROM intcta.fcta006 cta inner join vhl.vhlfc2 aut 
        ///on aut.vnufav=cta.anudoc and aut.vtiopr=atiopr
        ///where
        ///aut.vtidoc&lt;&gt;&apos;9&apos; and aut.vtiopr=&apos;1&apos; and aut.vcocio=&apos;CS&apos;
        ///and (cta.afddoc between &apos;01&apos; and &apos;28&apos; ) 
        ///and (cta.afmdoc between &apos;02&apos; and &apos;02&apos; ) 
        ///and (cta.afadoc between &apos;13&apos; and &apos;13&apos; ) 
        ///group by cta.anudoc,cta.afddoc,cta.afmdoc,cta.afadoc,aut.vstfc1 order by documento) n
        ///UNION all
        ///select u.* from (SELECT cta.anudoc AS documento
        ///FROM intcta.fcta006 cta inn [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string LoteTotalCofal {
            get {
                return ResourceManager.GetString("LoteTotalCofal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT f.NEMNOM FROM INTNOM.FNOM025 f INNER JOIN cdinom.cnom025 c
        ///on f.gcicod=c.GCICOD and f.nemcod=c.NEMCOD
        ///where c.ncousr=upper(&apos;{0}&apos;).
        /// </summary>
        internal static string NombreUsuario {
            get {
                return ResourceManager.GetString("NombreUsuario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select distinct(IdSerie) as codigo, IdSerie as nombre from SSO_GFC_NC_SERIE where IdEmpresa = {0} and IdSucursal = {1}.
        /// </summary>
        internal static string NotaCreditoSerie_PDF {
            get {
                return ResourceManager.GetString("NotaCreditoSerie_PDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT DISTINCT(IdSerie) AS SERIE FROM SSO_GFC_NC_SERIE
        ///UNION
        ///select DISTINCT(IdSerie) as SERIE from SSO_GFC_FAC_SERIE ORDER BY SERIE DESC.
        /// </summary>
        internal static string Series {
            get {
                return ResourceManager.GetString("Series", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select fsrdoc as serie from cdifac.tfac049 where gcicod = &apos;{0}&apos; and ftifac = &apos;{1}&apos;.
        /// </summary>
        internal static string SeriesDocumento {
            get {
                return ResourceManager.GetString("SeriesDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select gsucod, gcicod, fessat from cdifac.tfac046 where fcisat =&apos;{0}&apos; and fessat in ({1}).
        /// </summary>
        internal static string SucFAC_AS {
            get {
                return ResourceManager.GetString("SucFAC_AS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select distinct(IdSucursal) from SSO_GFC_FAC_SERIE where IdSerie in ({0}) and IdEmpresa =&apos;{1}&apos;.
        /// </summary>
        internal static string SucFac_EFACE {
            get {
                return ResourceManager.GetString("SucFac_EFACE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select IdSucursal as codigo, Descripcion as nombre from SSO_SEG_SUCURSAL where IdEmpresa = {0}.
        /// </summary>
        internal static string Sucursal_PDF {
            get {
                return ResourceManager.GetString("Sucursal_PDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select ftifac as tipo, fnotif as nombre from cdifac.tfac044 where gcicod = &apos;{0}&apos;
        ///and fnotif like &apos;FAC%&apos; order by fnotif asc.
        /// </summary>
        internal static string TipoDoc_fac {
            get {
                return ResourceManager.GetString("TipoDoc_fac", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select ftifac as tipo, fnotif as nombre from cdifac.tfac044 where gcicod = &apos;{0}&apos;
        ///and fnotif like &apos;NOT%&apos; order by fnotif asc.
        /// </summary>
        internal static string TipoDoc_nc {
            get {
                return ResourceManager.GetString("TipoDoc_nc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select IdTipoDocumento as tipo, Descripcion as nombre from SSO_IFL_TIPODOCUMENTO where IdTipoDocumento in (1,2).
        /// </summary>
        internal static string TipoDoc_PDF {
            get {
                return ResourceManager.GetString("TipoDoc_PDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select ftifac as tipo, fnotif as nombre from cdifac.tfac044 where gcicod = &apos;{0}&apos;
        ///order by fnotif asc.
        /// </summary>
        internal static string TipoDocumentos {
            get {
                return ResourceManager.GetString("TipoDocumentos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select abs(sum(gvtfac)) as vtotal, abs(sum(givfac)) as viva, abs(count(xnudoc)) as vcantidad from inttax.ltax001a where gcicod = &apos;{0}&apos;
        ///and gfsopr = &apos;1&apos;
        ///and gfdopr = &apos;{1}&apos;
        ///and gfmopr = &apos;{2}&apos;
        ///and gfaopr = &apos;{3}&apos;
        ///and xcotrn in ({4})
        ///and xflanu &lt;&gt; &apos;A&apos;
        ///group by gcicod.
        /// </summary>
        internal static string TotalIva_Todas {
            get {
                return ResourceManager.GetString("TotalIva_Todas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select abs(sum(gvtfac)) as vtotal, abs(sum(givfac)) as viva, abs(count(xnudoc)) as vcantidad from inttax.ltax001a where gcicod = &apos;{0}&apos;
        ///and gfsopr = &apos;1&apos;
        ///and gfmopr = &apos;{1}&apos;
        ///and gfaopr = &apos;{2}&apos;
        ///and xcotrn in ({3})
        ///and xflanu &lt;&gt; &apos;A&apos; 
        ///group by gcicod.
        /// </summary>
        internal static string TotalIva_Todas_Mes {
            get {
                return ResourceManager.GetString("TotalIva_Todas_Mes", resourceCulture);
            }
        }
    }
}