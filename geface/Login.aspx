﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portal_GEFACE.geface.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
        <title>.:: Portal - EFACE ::.</title>
        
        <link rel="stylesheet" type="text/css" href="../css/styles.css" />
               
        <!--[if IE]>
        
        <style type="text/css">
        .clear {
          zoom: 1;
          display: block;
        }
        </style>

        
        <![endif]-->
        <link href="../css/dcmegamenu.css" rel="stylesheet" type="text/css" />
        <link href="../css/eggplant/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css" />
        
        <%--<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>--%>
        <script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
        <script type='text/javascript' src="../js/jquery.hoverIntent.minified.js"></script>
        <script type='text/javascript' src="../js/jquery.dcmegamenu.1.3.3.js"></script>
        <script src="../js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>
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
	                show: "blind",
	                hide: "explode",
	                modal: false,
	                buttons: {
	                    "Ok": function() {
	                        window.location.href= "http://informatica/";
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
	            
            });
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

    	<div class="section" id="page"> <!-- Defining the #page section with the section tag -->
    
            <div class="header"> <!-- Defining the header section of the page with the appropriate tag -->
                <br />
                <div class="titulo">
                <h1>EFACE</h1>
                <h3>Administraci&oacute;n Factura Electr&oacute;nica</h3>
                </div>
                <div class="logo"> 
                    <img src="../img/logo_cs.png" alt="logo"/>
                </div>
                
                <div class="line"></div>
            
            </div>
            
            <div class="section" id="articles"> <!-- A new section with the articles -->

				<!-- Article 1 start -->
                
                <div class="article" id="article1"> <!-- The new article tag. The id is supplied so it can be scrolled into view. -->
                    <h3>Bienvenido</h3>
                    
                    <div class="line"></div>
                    
                    <div class="control" style="width:230px; height:330px; margin:auto">
                            <asp:Login ID="LoginFace" runat="server" TextLayout="TextOnTop" 
                                onauthenticate="LoginFace_Authenticate" onloggingin="LoginFace_LoggingIn" 
                                onloginerror="LoginFace_LoginError" DisplayRememberMe="False" 
                                UserNameLabelText="Usuario:">
                                <LoginButtonStyle CssClass="button medium verde" />
                                <ValidatorTextStyle Font-Bold="True" />
                                <TitleTextStyle Font-Size="Large" />
                            </asp:Login>
                            <br />
                    </div>
                </div>
				<!-- Article 1 end -->
            </div>
            
            <div class="ui-dialog">
                    <div id="dialog-confirm" title="Abandonar p&aacute;gina">
	                    <p>Esta seguro de abandonar el sitio actual?</p>
                    </div>
             </div>
             
        <div class="footer"> <!-- Marking the footer section -->

          <div class="line"></div>
           
           <p>Todos los derechos reservados</p> <!-- Change the copyright notice -->
           
           <a href="#" class="up">Volver Arriba</a>
           <a href="#" id="opener2" class="by">Cofal Divisi&oacute;n Inform&aacute;tica</a>
           

        </div>
            
		</div> <!-- Closing the #page section -->
        
        <!-- JavaScript Includes -->
        
        <%--<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>--%>
        <%--<script type="text/javascript" src="../jquery.scrollTo-1.4.2/jquery.scrollTo-min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>--%>
        </form>
    </body>
</html>
