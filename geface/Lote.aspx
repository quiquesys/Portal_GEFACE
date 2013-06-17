<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lote.aspx.cs" Inherits="Portal_GEFACE.geface.Lote" %>

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
        $(function() {
            $("#dialog").dialog({
                autoOpen: false,
                show: "blind",
                hide: "explode",
                resizable: false,
                draggable: false
            });
            $("#dialog").dialog().parent().appendTo("form1");

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
                        window.location.href = "../geface/Login.aspx";
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
                        window.location.href = "http://informatica/";
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
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $("#txtFechaInicio").datepicker({ dateFormat: "dd/mm/yy" });
            $("#txtFechaFin").datepicker({ dateFormat: "dd/mm/yy" });            
            $("#respuestaWS").dialog({
                autoOpen: false,
                show: "blind",
                hide: "explode",
                resizable: false,
                draggable: false
            });
            $("#loading").dialog({
                autoOpen: false,
                show: "blind",
                hide: "explode",
                resizable: false,
                draggable: false
            });

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                    <h3>Ingreso de Documentos por Lote</h3>
                    
                    <div class="line"></div>
                    
                    <div class="articleBody clear">
                        
                    <table align="center" style="width:100%;" width="100%">
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td align="left" valign="middle" width="30%">
                                Compa&ntilde;ia</td>
                            <td align="left" width="30%">
                                Tipo Documento</td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td align="left" valign="middle" width="30%">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="ddlCompania" runat="server" AutoPostBack="True" 
                                    Width="242px" CausesValidation="True" 
                                    onselectedindexchanged="ddlCompania_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="ddlCompania" ErrorMessage="Debe seleccionar una compañia." 
                                    Font-Size="Large" InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="middle" width="30%">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="True" 
                                    Width="241px" CausesValidation="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="ddlTipoDocumento" 
                                    ErrorMessage="Debe seleccionar tipo de documento." Font-Size="Large" 
                                    InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td align="left" valign="middle" width="30%">
                                Fecha Inicio</td>
                            <td align="left" valign="middle" width="30%">
                                Fecha Fin</td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td align="left" valign="middle" width="30%">
                                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtFechaInicio" 
                                    ErrorMessage="Debe ingresar fecha de inicio." Font-Size="Large" 
                                    ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtFechaInicio" 
                                    ErrorMessage="Formato Incorrecto de Fecha Inicio." Font-Size="Large" 
                                    ValidationExpression="([0-9]{2})/([0-9]{2})/([0-9]{4})" 
                                    ValidationGroup="Requeridos">*</asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="middle" width="30%">
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtFechaFin" ErrorMessage="Debe ingresar fecha de fin." 
                                    Font-Size="Large" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" 
                                    ErrorMessage="La Fecha Fin debe ser mayor o igual a Fecha Inicial." 
                                    Font-Size="Large" Operator="GreaterThanEqual" Type="Date" 
                                    ValidationGroup="Requeridos">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtFechaFin" ErrorMessage="Formato Incorrecto de Fecha Fin." 
                                    Font-Size="Large" ValidationExpression="([0-9]{2})/([0-9]{2})/([0-9]{4})" 
                                    ValidationGroup="Requeridos">*</asp:RegularExpressionValidator>
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td width="30%">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ValidationGroup="Requeridos" />
                            </td>
                            <td width="30%">
                                &nbsp;</td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                            <td align="left" valign="middle" width="30%">
                                <asp:Button ID="btnCargaLote" runat="server" Text="Cargar Lote" Width="141px" 
                                    CssClass="button medium verde" ValidationGroup="Requeridos" 
                                    onclick="btnCargaLote_Click" OnClientClick="disableBtn2(this.id, 'Cargando...')"/>
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                        </tr>
                    </table>
                        
                    </div>
                </div>
                
				<!-- Article 1 end -->

            </div>
            
            <div class="ui-dialog">
                    <div id="dialog-confirm" title="Salir de Sitio">
	                    <p>Esta seguro de salir del sitio?</p>
                    </div>
             </div>
             <div class="ui-dialog">
                    <div id="salida" title="Abandonar p&aacute;gina">
	                    <p>Esta seguro de abandonar el sitio actual?</p>
                    </div>
             </div>
             <div class="ui-dialog">
                    <div id="loading" title="Procesando Informaci&oacute;n">
                        <br />
	                    <p>Por favor Espere. Cargando...</p>
	                    <br />
	                    <p><center><img alt="cargando" src="../img/ajax-loader.gif" /></center></p>
                    </div>
             </div>
             <div class="ui-dialog">
                    <div id="respuestaWS" title="Mensaje Web">
	                    <p>Documentos han sido procesados.</p>
	                    <p><br />
                        <asp:Label ID="lblErrors" runat="server" 
                            Visible="True"></asp:Label></p>
                    </div>
             </div>
             

        <div class="footer"> <!-- Marking the footer section -->

          <div class="line"></div>
           
           <p>Todos los derechos reservados</p> <!-- Change the copyright notice -->
           
           <a href="#" class="up">Volver Arriba</a>
           <a href="#" id="linksalida" class="by">Cofal Divisi&oacute;n Inform&aacute;tica</a>
           

        </div>
            
		</div> <!-- Closing the #page section -->
        
        <!-- JavaScript Includes -->
        
        <%--<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>--%>
        <%--<script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>--%>
        </form>
    </body>
</html>
