<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCertificados.ascx.vb"
    Inherits="wucCertificados" %>
<div class="row">
    <div class="col-sm-12 col-md-12 main">
        <!-- Cuerpo -->
        <div class="panel panel-primary">
            <!-- Cabecera -->
            <nav class="navbar navbar-default navbar-title">
        <div id="divTitleContainer" class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#myNavbar" aria-expanded="false">
              <span class="icon-bar" style="background-color: white;"></span>
              <span class="icon-bar" style="background-color: white;"></span>
              <span class="icon-bar" style="background-color: white;"></span>
            </button>
            <div id="divNavbarBrand" class="navbar-brand" href="#">MIS CERTIFICADOS</div>
          </div>
        </div>
      </nav>
            <!-- Cuerpo -->
            <div style="padding-top: 0px;">
                <!-- Lista de Usuarios -->
                <div id="divLista" class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <b>&nbsp;CERTIFICADOS</b></h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div id="listaDeCertificados">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Mantenedor de Licencia -->
                <div id="divMantenedor" class="panel panel-default" style="display: none;">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <b>&nbsp;Certificados</b>
                            <button type="button" id="btnVerLista" class="navbar-right btn-md btn-default" tabindex="1">
                                <i class="fa fa-arrow-left"></i>&nbsp;Ver Lista</button>
                        </h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtCertificado">
                                    Tipo Certificado</label>
                                    <input type="text" name="txtCertificado" id="txtCertificado" class="form-control uppercase"
                                        tabindex="2" maxlength="32" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtRut">
                                        Rut</label>
                                    <input type="text" name="txtRut" id="txtRut" class="form-control uppercase" tabindex="2"
                                        maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNombre">
                                        Nombre</label>
                                    <input type="text" name="txtNombre" id="txtNombre" class="form-control uppercase"
                                        tabindex="3" maxlength="12" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtContrato">
                                        Contrato Vigente</label>
                                    <input type="text" name="txtContrato" id="txtContrato" class="form-control uppercase"
                                        tabindex="3" maxlength="40" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row" id="mesAno">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="cmbAno">
                                        Año</label>
                                    <select id="cmbAno" name="cmbAno" class="form-control uppercase">
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="cmbMes">
                                        Mes</label>
                                    <select id="cmbMes" name="cmbMes" class="form-control uppercase">
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="row" id="destino">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtPara">
                                        Ingrese Destinatario</label>
                                    <input type="text" name="txtPara" id="txtPara" class="form-control uppercase" tabindex="9"
                                        maxlength="30" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: right;">
                                <div class="form-group" style="margin-bottom: 0px;">
                                    <button type="button" id="btnImprimir" class="btn-lg btn-primary" tabindex="5" style="display: none">
                                        <i class="fa fa-print"></i>&nbsp;Imprimir
                                    </button>
                                    <button type="button" id="btnImprimirCertConRenta" class="btn-lg btn-primary" tabindex="5" style="display: none">
                                        <i class="fa fa-print"></i>&nbsp;Imprimir
                                    </button>
                                    <button type="button" id="btnImprimirCertLey19" class="btn-lg btn-primary" tabindex="5" style="display: none">
                                        <i class="fa fa-print"></i>&nbsp;Imprimir
                                    </button>
                                    <button type="button" id="btnImprimirCertCarga" class="btn-lg btn-primary" tabindex="5" style="display: none">
                                        <i class="fa fa-print"></i>&nbsp;Imprimir
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
