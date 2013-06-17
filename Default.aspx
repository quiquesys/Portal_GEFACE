<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Portal_GEFACE._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
        <title>.:: Portal - EFACE ::.</title>
        
        <link rel="stylesheet" type="text/css" href="css/styles.css" />
        <link href="../css/eggplant/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css" />       
        <!--[if IE]>
        
        <style type="text/css">
        .clear {
          zoom: 1;
          display: block;
        }
        </style>

        
        <![endif]-->
        <script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
        <script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>
        <script type='text/javascript' src="../js/jquery.hoverIntent.minified.js"></script>
        <script type='text/javascript' src="../js/jquery.dcmegamenu.1.3.3.js"></script>
        <script src="../js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>      
    
    
        <script type="text/javascript" language="javascript">
            javascript:window.history.forward(-1);
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
                        window.location.href("http://informatica/");
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

        });
	</script>
    </head>
    
    <body>
    	<div class="section" id="page"> <!-- Defining the #page section with the section tag -->
    
            <div class="header"> <!-- Defining the header section of the page with the appropriate tag -->

                <div class="titulo">
                <h1>EFACE</h1>
                <h3>Administraci&oacute;n Factura Electr&oacute;nica</h3>                
                </div>
                <div class="logo"> 
                    <img src="img/logo_cs.png" alt="logo"/>
                </div>
                
                <div class="line"></div>  <!-- Dividing line -->
                <div class="titulo"><u><a href="#" id="opener2" style="font-size:14pt;color:#fcfcfc;"><asp:Label ID="lblUsuario" data-intro="Click para cerrar sesión." runat="server"></asp:Label></a></u></div>
                <div class="nav clear"> <!-- The nav link semantically marks your main site navigation -->
                    <ul>
                        <li><a href="#article1">Lote Facturas</a></li>
                        <li><a href="#article2">Ingreso Individual</a></li>
                        <li><a href="#article3">Consulta</a></li>
                        <%if (Session["User"].ToString().ToUpper().Equals("BRIVERA"))
                          {%>
                        <li><a href="#article4">Administración</a></li>
                        <%} %>                  
                    </ul>
                </div>
            
            </div>
            <br />
            <br />
            <div class="section" id="articles"> <!-- A new section with the articles -->

				<!-- Article 1 start -->
                
                <div class="article" id="article1"> <!-- The new article tag. The id is supplied so it can be scrolled into view. -->
                    <h2>Ingreso de Documentos por Lote</h2>
                    
                    <div class="line"></div>
                    
                    <div class="articleBody clear">
                    
                    	<div class="figure"> <!-- The figure tag marks data (usually an image) that is part of the article -->
	                    	<a href="../geface/Lote.aspx"><img src="img/img3hd.jpg" width="620" height="340" alt="Facturas Lote" /></a>
                        </div>
                        
                        <p>En esta secci&oacute;n se presenta la opci&oacute;n para realizar el Ingreso de un Lote nuevo de Facturas.</p>
                        <p>Se solicita la Empresa, Tipo de Factura y un Rango de Fechas a cargar.</p>
                    </div>
                </div>
                
				<!-- Article 1 end -->


				<!-- Article 2 start -->

                <div class="line"></div>
                
                <div class="article" id="article2">
                    <h2>Ingreso Individual de Documentos</h2>
                    
                    <div class="line"></div>
                    
                    <div class="articleBody clear">
                    	<div class="figure">
	                    	<a href="../geface/Factura.aspx"><img src="img/img2hd.jpg" width="620" height="340" alt="Factura Individual" /></a>
                        </div>
                        
                        <p>Esta opci&oacute;n se debe de utilizar, cuando por algun inconveniente o error, no se pudo ingresar una factura en especifico.</p>
                        <p>En este caso, se pide la Empresa, Tipo de factura y el n&uacute;mero de documento a cargar. </p>
                        
                    </div>
                </div>
                
				<!-- Article 2 end -->

				<!-- Article 3 start -->

                <div class="line"></div>
                
                <div class="article" id="article3">
                    <h2>Consulta de Documentos Ingresados</h2>
                    
                    <div class="line"></div>
                    
                    <div class="articleBody clear">
                    	<div class="figure">
	                    	<a href="../geface/Consulta.aspx"><img src="img/img1hd.jpg" width="620" height="340" alt="Busqueda Factura" /></a>
                        </div>
                        
                        <p>En esta &aacute;rea se presenta la opci&oacute;n de poder realizar la consulta de documentos previamente cargados, y visualizar la factura electr&oacute;nica generada en PDF.</p>
                        
                    </div>
                </div>
                
				<!-- Article 3 end -->
				
				<div class="line"></div>
				<%if (Session["User"].ToString().ToUpper().Equals("BRIVERA"))
      {%>
				<!-- Article 4 start -->
				 <div class="article" id="article4">
                    <h2>Administración EFACE</h2>
                    
                    <div class="line"></div>
                    
                    <div class="articleBody clear">
                    	<div class="figure">
	                    	<a href="../geface/Administracion.aspx"><img src="img/admin.jpg" width="620" height="340" alt="Busqueda Factura" /></a>
                        </div>
                        
                        <p>En esta &aacute;rea se presenta la opci&oacute;n de poder realizar la administraci&oacute;n de 
                            documentos previamente cargados.</p>
                        
                    </div>
                </div>
				<!-- Article 4 end -->
            <%} %>

            </div>
            
            <div class="ui-dialog">
                    <div id="salida" title="Abandonar p&aacute;gina">
	                    <p>Esta seguro de abandonar el sitio actual?   <div class="ui-dialog">
                    <div id="dialog-confirm" title="Cierre de Sesi&oacute;n">
	                    <p>Esta seguro de Cerrar Sesi&oacute;n?</p>
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
        
        <%--<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>--%>
        <%--<script type="text/javascript" src="jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="js/script.js"></script>--%>
    </body>
</html>
