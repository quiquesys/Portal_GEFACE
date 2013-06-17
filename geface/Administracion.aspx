<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Portal_GEFACE.geface.Administracion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
        <title>.:: Portal - EFACE ::.</title>
        
        <link rel="stylesheet" type="text/css" href="../css/styles.css" />
        <link href="../css/eggplant/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css" />       
        <!--[if IE]>
        
        <style type="text/css">
        .clear {
          zoom: 1;
          display: block;
        }
        </style>

        
        <![endif]-->
        <link href="../css/dcmegamenu.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
        <script type='text/javascript' src="../js/jquery.hoverIntent.minified.js"></script>
        <script type='text/javascript' src="../js/jquery.dcmegamenu.1.3.3.js"></script>
        <script src="../js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>
        <script src="../js/jquery.ui.datepicker-es.js" type="text/javascript"></script>
        <script src="../js/PreventDoubleClick.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript">
            javascript: window.history.forward(-1);
        </script>
    
    <script type="text/javascript">
            // increase the default animation speed to exaggerate the effect
            $.fx.speeds._default = 500;
//            $(function() {
            $(document).ready(function() {
                $("#dialog").dialog({
                    autoOpen: false,
                    show: "blind",
                    hide: "explode",
                    resizable: false,
                    draggable: false
                });

                $("#opener").click(function() {
                    $("#dialog").dialog("open");
                    return false;
                });
                
	            $("#dialog-confirm").dialog({
	                resizable: false,
	                autoOpen: false,
	                height: 180,
	                draggable: false,
	                show: "clip",
	                hide: "explode",
	                modal: true,
	                buttons: {
	                    "Ok": function() {
	                        window.location.href="../geface/Login.aspx";
	                    },
	                    "No": function() {
	                        $(this).dialog("close");
	                    }
	                }
	            });
	            $("#opener2").click(function() {
	                $("#dialog-confirm").dialog("open");
	                return false;
	            });
	            $("#salida").dialog({
	                resizable: false,
	                autoOpen: false,
	                height: 180,
	                draggable: false,
	                show: "blind",
	                hide: "explode",
	                modal: false,
	                buttons: {
	                    "Ok": function() {
	                        window.location.href="http://informatica/";
	                    },
	                    "No": function() {
	                        $(this).dialog("close");
	                    }
	                }
	            });
	            $("#linksalida").click(function() {
	                $("#salida").dialog("open");
	                return false;
	            });

	            $("#loading").dialog({
	                autoOpen: false,
	                show: "blind",
	                hide: "explode",
	                resizable: false,
	                draggable: false
	            });
	            $("#tabs").tabs({ fx: { opacity: 'toggle' },
	            spinner: "Obteniendo data...",
	            show: function() {
                            var selectedTab = $('#tabs').tabs('option', 'selected');
                            $("#<%= hdnSelectedTab.ClientID %>").val(selectedTab);
                                 },
                selected: <%= hdnSelectedTab.Value %>
	            });
	            $.datepicker.setDefaults($.datepicker.regional["es"]);
	            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    $("#txtFechaFac").datepicker({ dateFormat: "dd/mm/yy" });
                    $("#txtFechaNC").datepicker({ dateFormat: "dd/mm/yy" });
                }
	            $("#txtFechaFac").datepicker({ dateFormat: "dd/mm/yy" });
	            $("#txtFechaNC").datepicker({ dateFormat: "dd/mm/yy" });
	            
	        });
	        function openDialog(id) {
	            $("#" + id).dialog("open");
	        }
	        function closeDialog(id) {
	            $("#" + id).dialog("close");
	        }
	        
	</script>
    
    <script type="text/javascript">
           
        $(document).ready(function($) {
            $('#mega-menu-1').dcMegaMenu({
                rowItems: '3',
                speed: 0,
                effect: 'slide',
                event: 'click',
                fullWidth: true
            });
            $('#mega-menu-2').dcMegaMenu({
                rowItems: '1',
                speed: 'fast',
                effect: 'fade',
                event: 'click'
            });
            $('#mega-menu-3').dcMegaMenu({
                rowItems: '2',
                speed: 'fast',
                effect: 'fade'
            });
            $('#mega-menu-4').dcMegaMenu({
                rowItems: '3',
                speed: 'fast',
                effect: 'fade'
            });
            $('#mega-menu-5').dcMegaMenu({
                rowItems: '4',
                speed: 'fast',
                effect: 'fade'
            });
            $('#mega-menu-6').dcMegaMenu({
                rowItems: '3',
                speed: 'slow',
                effect: 'slide',
                event: 'click',
                fullWidth: true
            });
            $('#mega-menu-7').dcMegaMenu({
                rowItems: '3',
                speed: 'fast',
                effect: 'slide'
            });
            $('#mega-menu-8').dcMegaMenu({
                rowItems: '3',
                speed: 'fast',
                effect: 'fade'
            });
            $('#mega-menu-9').dcMegaMenu({
                rowItems: '3',
                speed: 'fast',
                effect: 'fade'
            });
        });
    </script>
    <link href="../css/skins/black.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/grey.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/blue.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/green.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/light_blue.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/orange.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/red.css" rel="stylesheet" type="text/css" />
    <link href="../css/skins/white.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="0" />
    <div class="section" id="page"> <!-- Defining the #page section with the section tag -->
    
            <div class="header"> <!-- Defining the header section of the page with the appropriate tag -->
                <br />
                <div class="titulo">
                <h1>EFACE</h1>
                <h3>Administración Factura Electrónica</h3>
                </div>
                <div class="logo"> 
                    <img src="../img/logo_cs.png" alt="logo"/>
                </div>
                
                <div class="line"></div>
                
                <div class="white">  
                    <ul id="mega-menu-4" class="mega-menu">
	                    <li><a href="../Default.aspx">Inicio</a></li>
                        <li><a href="#" id="opener2">Salir</a></li>
                    </ul>
                </div>
            
            </div>
    
     <div class="section" id="articles"> <!-- A new section with the articles -->
     <!-- Article 1 start -->
                
                <div class="article" id="article1"> <!-- The new article tag. The id is supplied so it can be scrolled into view. -->
                    <h3>Administraci&oacute;n</h3>
                    
                    <div class="line">
                    </div>
                    
                    <div class="articleBody clear">
                    
                        <div id="tabs" >
                            <ul>
                                <li><a href="#tabs-1">Diferencia Documentos Enviados</a></li>
                                <li><a href="#tabs-2">Verifica caja</a></li>
                                <li><a href="#tabs-3">Verifica detalle</a></li>
                            </ul>
                            <div id="tabs-1">
                             <table align="center" style="width:100%;" width="100%">
                             <tr>
                             <td align="left" valign="middle" width="30%">
                             Compañia
                                 <asp:UpdatePanel ID="upEnterprise" runat="server">
                                     <ContentTemplate>
                                         <asp:DropDownList ID="ddlEnterpriseDDE" runat="server">
                                         </asp:DropDownList>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                </td>
                                <td align="left" valign="middle" width="30%">
                             Tipo Documento
                                 <asp:UpdatePanel ID="upTypeDocument" runat="server">
                                     <ContentTemplate>
                                         <asp:DropDownList ID="ddlTypeDocumentDDE" runat="server">
                                         </asp:DropDownList>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                </td>
                                <td align="left" valign="middle" width="30%">
                             Mes
                                 <asp:UpdatePanel ID="upMonth" runat="server">
                                     <ContentTemplate>
                                         <asp:DropDownList ID="ddlMonthDDE" runat="server">
                                         </asp:DropDownList>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                </td>
                                <td align="left" valign="middle" width="30%">
                             Año
                                 <asp:UpdatePanel ID="upYear" runat="server">
                                     <ContentTemplate>
                                         <asp:DropDownList ID="ddlYearDDE" runat="server">
                                         </asp:DropDownList>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                </td>
                                <td align="right" valign="middle" width="30%">
                                    <asp:Button ID="btnVerDiferenciasDDE" runat="server" Text="Procesar" 
                                        CssClass="medium button verde" onclick="btnVerDiferenciasDDE_Click" /></td>
                                </tr>
                                </table>
                                <br/>
                                DOCUMENTOS EFACE
                                <asp:UpdatePanel ID="upResultEFACEDDE" runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvResultEFACEDDE" EmptyDataText="** SIN DATOS **">
                                    </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                DOCUMENTOS AS400
                                 <asp:UpdatePanel ID="upResult" runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvResultAS400DDE" EmptyDataText="** SIN DATOS **">
                                    </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </div>
                            <div id="tabs-2">
                            </div>
                            <div id="tabs-3">
                            </div>
                            </div>
                            </div>
                            </div>                                     
     </div>
      
            <div class="ui-dialog">
                    <div id="dialog-confirm" title="Salir del Sitio">
	                    <p>Esta seguro de salir del sitio?</p>
	                </div>
             </div>
             <div class="ui-dialog">
                    <div id="salida" title="Abandonar p&aacute;gina">
	                    <p>Esta seguro de abandonar el sitio actual?</p>
                    </div>
             </div>
             <div class="ui-dialog">
                    <div id="dialog" title="Error!">
	                    <p>Documento No Encontrado.</p>
                    </div>
             </div>
             <div class="ui-dialog">
                    <div id="loading" title="Procesando Informaci&oacute;n">
                        <br />
	                    <p>Por favor Espere. Cargando...</p>
	                    <br />
	                    <center><p><img alt="cargando" src="../img/ajax-loader.gif" /></p></center>
                    </div>
             </div>

        <div class="footer"> <!-- Marking the footer section -->

          <div class="line"></div>
           
           <p>Todos los derechos reservados</p> <!-- Change the copyright notice -->
           
           <a href="#" class="up">Volver Arriba</a>
           <a href="#" id="linksalida" class="by">Cofal División Informática</a>
           

        </div>
            
		</div> <!-- Closing the #page section -->
    </form>
</body>
</html>
