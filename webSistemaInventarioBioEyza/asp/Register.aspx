<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="webSistemaInventarioBioEyza.Html.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Css/Register.css" rel="stylesheet" />
    <link rel="icon" href="../img/ICON BIOOOOO.png" type="image/x-icon"/>
    <link rel="stylesheet" href="../Css/bootstrap.min.css" />
<!-- style css -->
<link rel="stylesheet" href="../Css/style.css" />
    <title>Registro</title>
</head>
<body>
    <form id="registerForm" runat="server">
        <div class="register-container">
            <h2 class="register-title">Registro</h2>
            <div class="register-form">
                <asp:Label runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="register-input" placeholder="Ingrese su nombre" required></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="register-input" TextMode="Password" placeholder="Ingrese su contraseña" required></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Confirmar contraseña:"></asp:Label>
                <asp:TextBox runat="server" ID="txtConfirmPass" CssClass="register-input" TextMode="Password" placeholder="Confirme su contraseña" required></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnRegistrar" CssClass="submit-button" Text="Registrar" OnClick="btnRegistrar_Click" />
                <br />
                <br />
                <asp:Button ID="btnInicio" runat="server" Text="Regresar al Inicio" OnClientClick="window.location.href='index.aspx'; return false;" CssClass="btn btn-success" />

            </div>
        </div>
    </form>
</body>
</html>
