<%@ Page Title="Página principal" Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb"
  Inherits="_Default" %>

<!DOCTYPE html>
<html lang="es">
<head>
  <title id="PageTitle" runat="server"></title>
  <link rel="shortcut icon" href="img/favicon.ico" />
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <meta name="description" content="" />
  <meta name="author" content="" />
  <!-- Bootstrap Core CSS -->
  <link href="./css/bootstrap.min.css?v=<%=scriptVersion %>" rel="stylesheet" />
  <link href="./css/jquery-ui.min.css?v=<%=scriptVersion %>" rel="stylesheet" />
  <link href="./css/jquery.datetimepicker.css?v=<%=scriptVersion %>" rel="stylesheet" />
  <link href="./css/proexsi-style.css?v=<%=scriptVersion %>" rel="stylesheet" />
  <link href="./css/lc-style.css?v=<%=scriptVersion %>" rel="stylesheet" />
</head>
<body style="background-image: url('./img/logo-agua.png'); background-repeat: repeat-x;
  background-attachment: fixed; background-position: center; background-position-y: center;
  background-size: 500px 500px;">
  <form runat="server" id="aspnetForm">
  <!-- Modal -->
  <div class="modal fade" id="dialogo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-danger">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            &times;</button>
          <h4 class="modal-title" id="myModalLabel">
            <asp:Label ID="lblDialogTitulo" runat="server" /></h4>
        </div>
        <div class="modal-body">
          <asp:Label ID="lblDialogMsg" runat="server" /></div>
      </div>
      <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
  </div>
   <div class="modal fade" id="dialogo2" tabindex="-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-info">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            &times;</button>
          <h4 class="modal-title" id="myModalLabel2">
            <asp:Label ID="lblDialogTitulo2" runat="server" /></h4>
        </div>
        <div class="modal-body">
          <asp:Label ID="lblDialogMsg2" runat="server" /></div>
      </div>
      <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
  </div>
  <!-- /.modal -->
  <div class="container">
    <div class="row" align="center">
      <span class="span-login-titulo-sistema"><b id="bSistemaNombre" runat="server"></b>
      </span>
    </div>
    <div class="row" id="divIngreso" runat="server">
      <div class="col-md-4 col-md-offset-4">
        <div class="login-panel panel panel-default" style="margin-top: 100px;">
          <div class="panel-heading">
            <h3 class="panel-title">
              Ingreso</h3>
          </div>
          <div class="panel-body">
            <fieldset>
              <legend></legend>
              <div class="form-group">
                <label for="txtUsuario">
                  Usuario</label>
                <input type="text" id="txtUsuario" name="txtUsuario" class="form-control" tabindex="1"
                  maxlength="10" runat="server" autofocus="autofocus" />
              </div>
              <div class="form-group">
                <label for="txtPassword">
                  Password</label>
                <input type="password" id="txtPassword" name="txtPassword" class="form-control" tabindex="3"
                  runat="server" />
              </div>
              <asp:Button ID="btnIngresarServer" runat="server" class="btn btn-lg btn-primary btn-block"
                Text="Ingresar" OnClick="btnIngresarClick" ClientIDMode="Static" Enabled="false" />
              <br />
              <div class="form-group">
                <a id="aRecuperarClave" name="aRecuperarClave" class="success" href="#">¿ Recuperar contraseña ?</a>
              </div>
            </fieldset>
          </div>
        </div>
      </div>
    </div>
    <div id="divRecordarClave" style="display: none;">
      <div class="row" align="center">
        <span class="span-login-titulo-sistema"><b id="b1" runat="server"></b></span>
      </div>
      <div class="row">
        <div class="col-md-4 col-md-offset-4">
          <div class="login-panel panel panel-default" style="margin-top: 100px;">
            <div class="panel-heading">
              <h3 class="panel-title">
                Recuperar contraseña</h3>
            </div>
            <div class="panel-body">
              <fieldset>
                <legend></legend>
                <div class="form-group">
                  <label for="txtRut">
                    Usuario</label>
                  <input type="text" id="txtRut" name="txtRut" class="form-control" tabindex="2" runat="server" />
                </div>
                <div class="form-group">
                  <label for="txtFecha">
                    Fecha de nacimiento</label>
                  <input type="text" id="txtFecha" name="txtFecha" class="form-control" tabindex="2"
                    runat="server" clientidmode="Static" />
                </div>
                <asp:Button ID="btnRecuperarClave" runat="server" class="btn btn-lg btn-primary btn-block"
                  Text="Recuperar" OnClick="btnRecuperaClick" ClientIDMode="Static" Enabled="false" />
              </fieldset>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <script src="js/jquery-1.12.3.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/jquery.validate.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/jquery-ui-1.11.4.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/bootstrap.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/bootbox/bootbox.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/jquery.datetimepicker.full.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/loadingoverlay/src/loadingoverlay.min.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/generales.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  <script src="js/default.js?v=<%=scriptVersion %>" type="text/javascript"></script>
  </form>
</body>
</html>
