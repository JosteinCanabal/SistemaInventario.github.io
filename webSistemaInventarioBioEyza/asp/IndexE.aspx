%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="webSistemaInventarioBioEyza.asp.Index" %>
<!--Index para empleados -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


   <title></title>
   <link href="../Css/index.css" rel="stylesheet" />
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    
   <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet"/>
   <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/>

       <!-- bootstrap css -->
   <link rel="stylesheet" href="../Css/bootstrap.min.css"/>
   <!-- style css -->
   <link rel="stylesheet" href="../Css/style.css"/>
   <!-- Responsive-->
   <link rel="stylesheet" href="../Css/responsive.css"/>
   <!-- fevicon -->
   <link rel="icon" href="images/fevicon.png" type="image/gif" />
   <!-- Scrollbar Custom CSS -->
   <link rel="stylesheet" href="../Css/jquery.mCustomScrollbar.min.css"/>
   <!-- Tweaks for older IEs-->
   <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css"/>
   <!-- stylesheets -->
   <link rel="stylesheet" href="../Css/owl.carousel.min.css"/>
   <link rel="stylesheet" href="../Css/owl.theme.default.min.css"/>
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen"/>

    <style>
    /* Estilos adicionales */
    .navbar {
        background-color: #a0e000c3; 
        border-bottom: 6px solid #a0e000c3; 
    }

    .navbar-nav .nav-link:hover {
        background-color: #27650c;
        border-radius: 10px;
        cursor: pointer;
        transition: background-color 1s ease;
    }

    .navbar-nav .nav-link:hover {
        color: #000000;
    }
</style>


</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="logo">
                <a href="index.aspx">
                 <img src="../img/icon_BIO-removebg-preview.png" /></a>
            </div>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="registroCaja.aspx" style="font-size: 14px; padding-top:20px;">Agregar Caja</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="editarCaja.aspx" style="font-size: 14px; padding-top:20px;">Editar caja</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="mostrarInventario.aspx" style="font-size: 14px; padding-top:20px;">Mostrar Inventario</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="retirarCajas.aspx" style="font-size: 14px; padding-top:20px;">Retirar Cajas</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="consultarRetiros.aspx" style="font-size: 14px; padding-top:20px;">Consultar Cajas</a>
                    </li>
                    <li class="nav-item active">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesión_Click" CssClass="button-cerrar-sesion" />
                    </li>
                </ul>
            </div>
        </nav>

    </form>

    <div class="header_section">
        <!-- header end -->
        <!-- banner -->
        <div id="main_slider" class="carousel slide" data-ride="carousel" />
        <div class="carousel-inner" style="background-color: #a4db82">
            <div class="carousel-item active">
                <div class="banner_section">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-6">
                                <h1 class="banner_taital" style="color: #4cff00;">Bienvenido
                                        <br />
                                    <span style="color: #151515;">al sistema de inventario BioEyza</span></h1>
                                <p class="banner_text">Con muchas funcionalidades para facilitar su trabajo!</p>
                                <div class="btn_main">
                                    <div class="more_bt"><a href="registroCaja.aspx" style="background-color: #4cff00">Agregar caja</a></div>
                                    <div class="contact_bt"><a href="mostrarInventario.aspx">Mostrar Inventario</a></div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="image_1">
                                    <img src="../img/Wall-200.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="health_section layout_padding">
        <div class="container">
            <h1 class="health_taital">¿Para que sirve este sistema?</h1>
            <p class="health_text">Este sistema tiene como funcionalidad facilitar el inventario de bodega, en el cual tiene varias funcionalidades como agregar,mostrar inventario,retirar y consultar las salidas.</p>
            <div class="health_section layout_padding">
                <div class="row">
                    <div class="col-sm-7">
                        <div class="image_main">
                            <div class="main">
                                <img src="../img/image00003.jpeg" alt="Avatar" class="image" style="width: 625px; height: 450px">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <div class="image_main_1">
                            <div class="main">
                                <img src="../img/image00002 (3).jpeg" alt="Avatar" class="image" style="width: 100%" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- footer -->
    <div class="footer_section layout_padding">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-3 col-sm-6 text-center">
                <h1 class="adderss_text">Contactanos</h1>
                <div class="map_icon">
                    <img src="../img/hoja (1).ico"/><span class="paddlin_left_0">bioeyza.com</span>
                </div>
                <div class="map_icon">
                    <img src="../img/pngtree-whatsapp-icon-png-image_3584844.ico"/><span class="paddlin_left_0">3164974471</span>
                </div>
                <div class="map_icon">
                    <img src="../img/gmail_mail_google_mint_icon_134941.ico"/><span class="paddlin_left_0">BioEyza@gmail.com</span>
                </div>
            </div>
            <div class="col-lg-3 col-sm-6 text-center">
                <h1 class="adderss_text">BIOYEZA S.A.S</h1>
                <div class="hiphop_text_1">Somos fabricantes y distribuidores de productos elaborados a base de pulpa de bagazo de caña de azúcar para reemplazar el uso de plásticos e icopor, por una opción amigable con el medio ambiente, 100% reciclable y biodegradable.</div>
            </div>
            <div class="col-lg-3 col-sm-6 text-center">
                <div class="social_icon">
                    <ul>
                        <li><a href="https://www.facebook.com/bio.eyza">
                            <img src="../img/78c012e7678761400082c6130487a463.ico"/></a></li>
                        <li><a href="https://www.instagram.com/bioeyza">
                            <img src="../img/images.ico"/></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>


    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>