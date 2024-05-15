<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultarRetiros.aspx.cs" Inherits="webSistemaInventarioBioEyza.asp.consultarRetiros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Css/consultarSalidas.css" rel="stylesheet" />
    <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/> 
    <link rel="stylesheet" href="../Css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../Css/style.css"/>
        <!-- Agregar referencias a jQuery y jQuery UI -->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <!-- Script para inicializar el DatePicker -->
    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '< Ant',
            nextText: 'Sig >',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
        $(function () {
            $("#fecha2").datepicker();
        });
    $(document).ready(function () {
        $("#<%=txtFechaInicio.ClientID%>").datepicker({
            dateFormat: 'dd/mm/yy'
        });
    });
    </script>

    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '< Ant',
            nextText: 'Sig >',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
        $(function () {
            $("#fecha3").datepicker();
        });
        $(document).ready(function () {
            $("#<%=txtFechaFinal.ClientID%>").datepicker({
        dateFormat: 'dd/mm/yy'
    });
        });

    </script>

    <script type="text/javascript">
         function validarCodigoFactura() {
             var codigoFactura = document.getElementById('<%=txtCodigoFactura.ClientID%>').value;
             if (codigoFactura.trim() === "") {
                 alert("Por favor ingrese el código de factura.");
                 return false; // Evita que el formulario se envíe si el campo está vacío
             }
             return true; // Permite enviar el formulario si el campo tiene un valor
         }
     </script>

    <script type="text/javascript">

        function validarFechaInicio() {
            var codigoFactura = document.getElementById('<%=txtFechaInicio.ClientID%>').value;
            if (codigoFactura.trim() === "") {
                alert("Por favor ingrese la fecha de inicio.");
                return false; // Evita que el formulario se envíe si el campo está vacío
            }
            return true; // Permite enviar el formulario si el campo tiene un valor
        }

    </script>  
    
    <script type="text/javascript">

        function validarFechaFinal() {
            var codigoFactura = document.getElementById('<%=txtFechaFinal.ClientID%>').value;
            if (codigoFactura.trim() === "") {
                alert("Por favor ingrese la fecha final.");
                return false; // Evita que el formulario se envíe si el campo está vacío
            }
            return true; // Permite enviar el formulario si el campo tiene un valor
        }
    </script>  

</head>
<body>  
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="logo"><a href="index.aspx">
        <img src="../img/icon_BIO-removebg-preview.png" /></a></div>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">

            <li class="nav-item active">
                <a class="nav-link" href="index.aspx">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="registroCaja.aspx">Agregar Caja</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="mostrarInventario.aspx">Mostrar inventario</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="retirarCajas.aspx">Retirar Cajas</a>
            </li>
            <li class="nav-item">
               <a class="nav-link" href="editarCaja.aspx">Editar caja</a>
            </li>
            <li class="nav-item">
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesión_Click" CssClass="submit-button" />
            </li>
        </ul>
    </div>
</nav>
        
      <!--  <div class="container">
            <h2 style="text-align: center;">Consultar retiro de cajas</h2>

     Filtro por código de factura
            <div class="form-group">
            <label for="txtCodigoFactura">Código de Factura:</label>

            <asp:TextBox ID="txtCodigoFactura" runat="server"  ClientIDMode="Static"></asp:TextBox>
                <br />  
                <br />
            <asp:Button ID="btnFiltrarCodigoFactura" runat="server" Text="Filtrar por Código de Factura" CssClass="submit-button" OnClientClick="return validarCodigoFactura(); " OnClick="btnFiltrarCodigoFactura_Click" />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="nombreCaja" HeaderText="Nombre de la Caja" />
                    <asp:TemplateField HeaderText="Fecha de Salida">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("fechaSalida")).ToString("dd/MM/yyyy") %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cantidadRetirada" HeaderText="Cantidad Retirada" />
                    <asp:BoundField DataField="destinatario" HeaderText="Destinatario" />
                    <asp:BoundField DataField="codigoFactura" HeaderText="Código de Factura" />
                    <asp:BoundField DataField="etiquetaCaja" HeaderText="Etiqueta caja" />
                    <asp:BoundField DataField="comentario" HeaderText="Comentario (Opcional)" />
                    <asp:BoundField DataField="usuario_retirada" HeaderText="Usuario de Retiro" />
                    <asp:BoundField DataField="tipo_inventario" HeaderText="Tipo de Inventario" />
                </Columns>
            </asp:GridView>
        </div> 

            <br />-->
    <!-- Filtro por fecha -->
            <div class="form-group">
               <!--  -->
            </div>
            <br /> 

        <div class="container">

            <h2 style="text-align: center;">Consultar retiro de cajas</h2>
            <label for="txtBuscarCaja">Buscar caja por nombre o etiqueta: </label>
            <asp:TextBox ID="txtBuscarCaja" runat="server" CssClass="textbox" ClientIDMode="Static" placeholder="Buscar caja específica..."></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="search-button" OnClick="btnBuscar_Click" />

            <label for="txtBuscarCaja2">Buscar caja por codigo de factura: </label>
            <asp:TextBox ID="txtBuscarCaja2" runat="server" CssClass="textbox" ClientIDMode="Static" placeholder="Buscar caja específica..."></asp:TextBox>
            <asp:Button ID="btnBuscar2" runat="server" Text="Buscar" CssClass="search-button" OnClick="btnBuscar2_Click" />

                <label for="txtFechaInicio">Fecha de Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="textbox"></asp:TextBox>
                <label for="txtFechaFin">Fecha de Fin:</label>
                <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:Button ID="btnFiltrarFecha" runat="server" Text="Filtrar por Fecha"  OnClick="btnFiltrarFecha_Click"  CssClass="submit-button" OnClientClick="return validarFechaInicio() && validarFechaFinal();" />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="nombreCaja" HeaderText="Nombre de la Caja" />
                    <asp:TemplateField HeaderText="Fecha de Salida">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("fechaSalida")).ToString("dd/MM/yyyy") %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cantidadRetirada" HeaderText="Cantidad Retirada" />
                    <asp:BoundField DataField="destinatario" HeaderText="Destinatario" />
                    <asp:BoundField DataField="codigoFactura" HeaderText="Código de Factura" />
                    <asp:BoundField DataField="etiquetaCaja" HeaderText="Etiqueta caja" />
                    <asp:BoundField DataField="comentario" HeaderText="Comentario (Opcional)" />
                    <asp:BoundField DataField="usuario_retirada" HeaderText="Usuario de Retiro" />
                    <asp:BoundField DataField="tipo_inventario" HeaderText="Tipo de Inventario" />
                </Columns>
            </asp:GridView>
            <br />
            <div style="text-align: center;">
                <label for="dlTipoInventario">Tipo de Inventario:</label>

                    <asp:DropDownList ID="tipoInventario" runat="server" CssClass="textbox" ClientIDMode="Static">
                        <asp:ListItem Text="Bioeyza" Value="Bioeyza"></asp:ListItem>
                        <asp:ListItem Text="Lote" Value="Lote"></asp:ListItem>
                    </asp:DropDownList>
                <asp:Button ID="btnMostrarSalidas" runat="server" Text="Mostrar Salidas" CssClass="btn-asd"  OnClick="btnMostrarSalidas_Click" />
                <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar Excel" CssClass="btn-asd" OnClick="btnExportarExcel_Click" />
            </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
