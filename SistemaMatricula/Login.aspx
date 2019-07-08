<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaMatricula.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <link href="Content/login.css" rel="stylesheet" />
   <link href='https://fonts.googleapis.com/css?family=Open+Sans:700,600' rel='stylesheet' type='text/css'>

<form method="post" runat="server">
<div class="box">
<h1>Login - Sistema Matricula</h1>

<asp:TextBox placeholder="Ingrese usuario" ID="txtUsuario" runat="server"  class="email" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');"></asp:TextBox>
    <asp:TextBox  placeholder="Ingrese password" ID="txtPassword"  runat="server" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" TextMode="Password"></asp:TextBox>
  
 
    <asp:Button Class="btn" ID="btnLogin" runat="server" Text="Iniciar Sesion" OnClick="btnLogin_Click" />
</div> <!-- End Box -->
  
</form>

<p>Forgot your password? <u style="color:#f1c40f;">Click Here!</u></p>
  
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js" type="text/javascript"></script>
</body>
</html>
