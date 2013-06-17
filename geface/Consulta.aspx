<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Portal_GEFACE.geface.Consulta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                    <h3>Consulta de Documentos</h3>
                    
                    <div class="line">
                    </div>
                    
                    <div class="articleBody clear">
                    
                        <div id="tabs" >
                            <ul>
                                <li><a href="#tabs-1">Visualizar PDF</a></li>
                                <li><a href="#tabs-2">Cuadrar Facturas</a></li>
                                <li><a href="#tabs-3">Cuadrar Notas de Crédito</a></li>
                            </ul>
                            <div id="tabs-1">
                                <table align="center" style="width:100%;" width="100%">
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" width="30%">
                                        Tipo Documento</td>
                                    <td align="left" width="30%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" width="30%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTipoDocumento" runat="server" 
                                            Width="168px" AutoPostBack="True" 
                                            onselectedindexchanged="ddlTipoDocumento_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="ddlTipoDocumento" 
                                            ErrorMessage="Seleccione tipo de documento." Font-Size="Large" 
                                            InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                     </ContentTemplate>
                                     </asp:UpdatePanel>
                                    </td>
                                    <td align="left" width="30%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="center" valign="middle" width="30%">
                                        &nbsp;</td>
                                    <td align="center" width="30%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" width="30%">
                                        Compañia</td>
                                    <td align="left" valign="middle"width="30%">
                                        Sucursal</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" width="30%">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCompania" runat="server" AutoPostBack="True" 
                                            Width="242px" onselectedindexchanged="ddlCompania_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="ddlCompania" ErrorMessage="Seleccione Compañia." 
                                            Font-Size="Large" InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </td>
                                    <td align="left" valign="middle" width="30%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSucursal" runat="server" AutoPostBack="True" 
                                            Width="242px" onselectedindexchanged="ddlSucursal_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="ddlSucursal" ErrorMessage="Seleccione sucursal." 
                                            Font-Size="Large" InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
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
                                        Serie</td>
                                    <td align="left" valign="middle" width="30%">
                                        No. Documento</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" width="30%">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSerie" runat="server" Width="150px" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="ddlSerie" ErrorMessage="Seleccione Serie." Font-Size="Large" 
                                            InitialValue="-1" ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </td>
                                    <td align="left" valign="middle" width="30%">
                                        <asp:TextBox ID="txtNoDocumento" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="txtNoDocumento" 
                                            ErrorMessage="Ingrese No. de Documento a Buscar." Font-Size="Large" 
                                            ValidationGroup="Requeridos">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txtNoDocumento" ErrorMessage="Debe ser un valor númerico." 
                                            Font-Size="Large" ValidationExpression="[0-9]+" ValidationGroup="Requeridos">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="30%">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ValidationGroup="Requeridos" /></td>
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
                                        <asp:Button ID="btnBuscarDoc" runat="server" Text="Buscar Documento" 
                                            Width="141px" CssClass="button medium verde" 
                                            ValidationGroup="Requeridos" onclick="btnBuscarDoc_Click" OnClientClick="disableBtn(this.id,null, 'Cargando...', 'Requeridos')"/>
                                    </td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                                <br />
                                <br />
                                <center>
                                <iframe id=ifrPDF style="WIDTH: 870px; HEIGHT: 1180px" runat="server" visible="false" frameborder="no"></iframe>
                                </center>
                            </div>
                            <div id="tabs-2">
                                <table align="center" style="width:100%;" width="100%">
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                Compañia</td>
            <td align="left" width="30%">
                Sucursal</td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlCiaFac" runat="server" AutoPostBack="True" 
                    Width="242px" onselectedindexchanged="ddlCiaFac_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="ddlCiaFac" ErrorMessage="Debe Seleccionar una Compañia." 
                    Font-Size="Large" InitialValue="-1" ValidationGroup="Obligatorios">*</asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="middle" width="30%">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlSucursalFac" runat="server" AutoPostBack="True" 
                    Width="242px" onselectedindexchanged="ddlSucursalFac_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="ddlSucursalFac" 
                    ErrorMessage="Debe Seleccionar Tipo de Documento." Font-Size="Large" 
                    InitialValue="-1" ValidationGroup="Obligatorios">*</asp:RequiredFieldValidator>
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
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblFacCuadre" runat="server" Text="Fecha por día"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlTipoDocFac" runat="server" Width="241px" Visible="False">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="ddlTipoDocFac" 
                    ErrorMessage="Debe Seleccionar Tipo de Documento." Font-Size="Large" 
                    InitialValue="-1" ValidationGroup="Obligatorios" Enabled="False">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="middle" width="30%">
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>    
                <asp:TextBox ID="txtFechaFac" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtFechaFac" 
                    ErrorMessage="Debe Ingresar una Fecha a calcular." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtFechaFac" ErrorMessage="Formato Incorrecto de Fecha." 
                        Font-Size="Large" ValidationExpression="([0-9]{2})/([0-9]{2})/([0-9]{4})" 
                        ValidationGroup="Obligatorios">*</asp:RegularExpressionValidator>
            
                <asp:DropDownList ID="ddlMeses" runat="server" Height="22px" 
                    Visible="False" Width="238px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="ddlMeses" 
                    ErrorMessage="Debe Seleccionar un Mes." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios" InitialValue="0">*</asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddlAnio" runat="server" Height="22px" 
                    Visible="False" Width="238px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                    ControlToValidate="ddlAnio" 
                    ErrorMessage="Debe Seleccionar un A&ntilde;o." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios" InitialValue="-1">*</asp:RequiredFieldValidator>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td width="20%">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                <asp:CheckBox ID="chkPorMes" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkPorMes_CheckedChanged" Text="Por Mes" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="30%">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                    ValidationGroup="Obligatorios" />
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
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnCalcular" runat="server" Text="Calcular Totales" Width="141px" 
                    CssClass="button medium verde" ValidationGroup="Obligatorios" 
                    onclick="btnCalcular_Click" 
                        onclientclick="disableBtn(this.id,'btnReporteDiferenciasFacturas','btnGeneraConstanciaFac','Calculando...', 'Obligatorios')"/>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upReporteDiferenciasFacturas" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnReporteDiferenciasFacturas" runat="server" 
                        Text="Diferencias" Width="141px" 
                    CssClass="button medium verde" onclick="btnReporteDiferenciasFacturas_Click" 
                        onclientclick="disableBtn(this.id,'btnCalcular','btnGeneraConstanciaFac','Generando...','Obligatorios')"/>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upConstanciaFac" runat="server">
                <ContentTemplate><asp:Button ID="btnGeneraConstanciaFac" runat="server" Text="Constancia" 
                                        CssClass="button medium verde" onclick="btnGeneraConstanciaFac_Click"                                         
                                            ValidationGroup="Obligatorios" Width="141px" OnClientClick="disableBtn(this.id,'btnCalcular','btnReporteDiferenciasFacturas','Generando...','Obligatorios')" />
                                          </ContentTemplate></asp:UpdatePanel>
            
            </td>
            <td width="20%">
            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                        <ContentTemplate>
                                            <asp:HyperLink ID="hlExcel_FAC" 
    runat="server" ImageUrl="~/img/xcel_disabled.png" Enabled="False">ReporteDiferencias.xls</asp:HyperLink>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
               
                &nbsp;</td>
        </tr>
       </table>
                               <%-- &nbsp;</td>
        </tr>
    </table>--%>
                                
    
                                <center>
                                <asp:UpdatePanel ID="updFacturas" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="grvBalance" runat="server" AutoGenerateColumns="False" 
                                    EmptyDataText="** SIN DATOS **" Width="99%" CellPadding="10" CellSpacing="10">
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                    <Columns>
                                        <asp:BoundField DataField="Compania" HeaderText="Compañia" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Tipo_Doc" HeaderText="Tipo Documento" 
                                            NullDisplayText="N/D" ReadOnly="True" >
                                        <ItemStyle BorderStyle="Solid" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad de Documentos" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Total" HeaderText="Total EFACE" NullDisplayText="N/D" 
                                            ReadOnly="True" DataFormatString="{0:n}" />
                                        <asp:BoundField DataField="IVA_EFACE" DataFormatString="{0:n}" HeaderText="IVA EFACE" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Cantidad Documentos Ventas" NullDisplayText="N/D" />
                                        <asp:BoundField 
                                            HeaderText="IVA Ventas" NullDisplayText="N/D" ReadOnly="True" 
                                            DataFormatString="{0:n}" />
                                        <asp:BoundField DataFormatString="{0:n}" 
                                            HeaderText="Total Ventas" NullDisplayText="N/D" ReadOnly="True" >
                                        <HeaderStyle BorderStyle="Solid" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                <br />
                                <br />
                                <asp:GridView ID="grvDetalleFac" runat="server" AutoGenerateColumns="False" 
                                        EmptyDataText="** SIN DATOS **" Visible="False" Width="95%">
                                    <Columns>
                                        <asp:BoundField DataField="Compania" HeaderText="Compañia" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Tipo_Doc" HeaderText="Tipo Documento" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="sucursal" HeaderText="Sucursal" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total EFACE" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                    </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>                           
                                     
                                </center>                                
                                <br />
                              
                              <center>
                              <asp:UpdatePanel ID="upIfameFac" runat="server"><ContentTemplate>
                                <iframe id=ifConstanciaFAC style="WIDTH: 870px; HEIGHT: 1180px" runat="server" 
                                        visible="false" frameborder="no"></iframe>
                                        </ContentTemplate></asp:UpdatePanel>
                                </center>
                              
                            </div>
                            <div id="tabs-3">
                                <table align="center" style="width:100%;" width="100%">
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                Compañia Compañia</td>
            <td width="20%">
                Sucursal</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlCiaNC" runat="server" AutoPostBack="True" 
                    Width="242px" onselectedindexchanged="ddlCiaNC_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlCiaNC" ErrorMessage="Debe Seleccionar una Compañia." 
                    Font-Size="Large" InitialValue="-1" ValidationGroup="Obligatorios2">*</asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="middle" width="30%">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlSucursalNC" runat="server" AutoPostBack="True" 
                    Width="242px" onselectedindexchanged="ddlSucursalNC_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="ddlSucursalNC" 
                    ErrorMessage="Debe Seleccionar Tipo de Documento." Font-Size="Large" 
                    InitialValue="-1" ValidationGroup="Obligatorios2">*</asp:RequiredFieldValidator>
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
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblNCCuadre" runat="server" Text="Fecha por día"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="left" valign="middle" width="30%">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlTipoDocNC" runat="server" Width="241px" Visible="False">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="ddlTipoDocNC" 
                    ErrorMessage="Debe Seleccionar Tipo de Documento." Font-Size="Large" 
                    InitialValue="-1" ValidationGroup="Obligatorios2" Enabled="False" 
                        Visible="False">*</asp:RequiredFieldValidator>
                 </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td align="left" valign="middle" width="30%">
            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtFechaNC" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtFechaNC" 
                    ErrorMessage="Debe Ingresar una Fecha a calcular." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios2">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtFechaNC" ErrorMessage="Formato Incorrecto de Fecha." 
                        Font-Size="Large" ValidationExpression="([0-9]{2})/([0-9]{2})/([0-9]{4})" 
                        ValidationGroup="Obligatorios2">*</asp:RegularExpressionValidator>
                        
                        <asp:DropDownList ID="ddlMeses2" runat="server" Height="22px" 
                    Visible="False" Width="238px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                    ControlToValidate="ddlMeses2" 
                    ErrorMessage="Debe Seleccionar un Mes." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios2" InitialValue="0">*</asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddlAnio2" runat="server" Height="22px" 
                    Visible="False" Width="238px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                    ControlToValidate="ddlAnio2" 
                    ErrorMessage="Debe Seleccionar un A&ntilde;o." Font-Size="Large" 
                    Font-Strikeout="False" ValidationGroup="Obligatorios2" InitialValue="-1">*</asp:RequiredFieldValidator>
                        
            </ContentTemplate>            
            </asp:UpdatePanel> 
            </td>
            <td width="20%">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                <asp:CheckBox ID="chkPorMes2" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkPorMes2_CheckedChanged" Text="Por Mes" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="30%">
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                    ValidationGroup="Obligatorios2" />
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
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnCalcularNC" runat="server" Text="Calcular Totales" Width="141px" 
                    CssClass="button medium verde" ValidationGroup="Obligatorios2" 
                    onclick="btnCalcularNC_Click" 
                        
                        onclientclick="disableBtn(this.id,'btnReporteDiferenciasNCR', 'btnGeneraConstanciaNCR','Calculando...', 'Obligatorios2')" />
                </ContentTemplate>
                </asp:UpdatePanel>                                
                 <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnReporteDiferenciasNCR" runat="server" 
                        Text="Diferencias" 
                    CssClass="button medium verde" onclick="btnReporteDiferenciasNCR_Click" 
                        OnClientClick="disableBtn(this.id,'btnCalcularNC','btnGeneraConstanciaNCR', 'Generando...', 'Obligatorios2')" 
                        Width="141px"/>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upGeneraConstanciaNCR" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnGeneraConstanciaNCR" runat="server" 
                                        Text="Constancia" CssClass="button medium verde" 
                    Width="141px" onclick="btnGeneraConstanciaNCR_Click" 
                    onclientclick="disableBtn(this.id,'btnCalcularNC','btnReporteDiferenciasNCR', 'Generando...', 'Obligatorios2')" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
            </td>    
            <td width="20%">
            <asp:UpdatePanel ID="upReporteDiferencias" runat="server">
                                        <ContentTemplate>
                                            <asp:HyperLink ID="hlExcel_NCR" 
    runat="server" ImageUrl="~/img/xcel_disabled.png" Enabled="False">ReporteDiferencias.xls</asp:HyperLink>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                &nbsp;</td>
        </tr>
    </table>
                                <br />
                                <br />
                                <center>
                                <asp:UpdatePanel ID="updNotasCredito" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="grvBalanceNC" runat="server" AutoGenerateColumns="False" 
                                    EmptyDataText="** SIN DATOS **" Width="99%">
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:BoundField DataField="Compania" HeaderText="Compañia" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Tipo_Doc" HeaderText="Tipo Documento" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad de Documentos" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Total" HeaderText="Total EFACE" NullDisplayText="N/D" 
                                            ReadOnly="True" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="IVA_EFACE" DataFormatString="{0:n}" 
                                            HeaderText="IVA EFACE" NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Cantidad Documentos Ventas" NullDisplayText="N/D" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataFormatString="{0:n}" HeaderText="IVA Ventas" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataFormatString="{0:n}" HeaderText="Total Ventas" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                    </Columns>
                                </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="grvDetalleNC" runat="server" AutoGenerateColumns="False" 
                                        EmptyDataText="** SIN DATOS **" Visible="False" Width="95%">
                                    <Columns>
                                        <asp:BoundField DataField="Compania" HeaderText="Compañia" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Tipo_Doc" HeaderText="Tipo Documento" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="sucursal" HeaderText="Sucursal" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                        <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total EFACE" 
                                            NullDisplayText="N/D" ReadOnly="True" />
                                    </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>          
                                </center>
                                <br />
                                <center>
                              <asp:UpdatePanel ID="upIframeNotas" runat="server"><ContentTemplate>
                                <iframe id=ifConstanciaNCR style="WIDTH: 870px; HEIGHT: 1180px" runat="server" 
                                        visible="false" frameborder="no"></iframe>
                                        </ContentTemplate></asp:UpdatePanel>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                
				<!-- Article 1 end -->

            </div>
            
            <!--Posicion anterior de IFRAME-->    
            
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

        <!-- JavaScript Includes -->
        
        <%--<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>--%>
        <%--<script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>--%>
        </form>
    </body>
</html>
