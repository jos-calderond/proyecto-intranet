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
    <form runat="server" id="aspnetForm" action="?" method="post">
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
                            Consultar</h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                            <legend></legend>
                            <div class="form-group">
                                <label for="txtCodigo">
                                    Número de Documento</label>
                                <input type="text" id="txtCodigo" name="txtCodigo" class="form-control" tabindex="1"
                                    maxlength="30" runat="server" autofocus="autofocus" />
                            </div>
                            <div class="form-group">
                                <label for="txtConfirma">
                                    Confirma Que Eres Humano</label>
                                <div class="g-recaptcha" data-sitekey="6LdazaoUAAAAALGHJA0jAiv3PlGdLSZebGgkw07h">
                                </div>
                            </div>
                            <asp:Button ID="btnConsultar" runat="server" class="btn btn-lg btn-primary btn-block"
                                Text="Consultar Documento" OnClick="btnConsultarClick"   />
                        </fieldset>
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
    <script src="https://www.google.com/recaptcha/api.js" type="text/javascript"></script>
    </form>
</body>
</html>
