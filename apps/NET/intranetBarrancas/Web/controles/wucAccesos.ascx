<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucAccesos.ascx.vb" Inherits="wucAccesos" %>
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
            <div id="divNavbarBrand" class="navbar-brand" href="#">ADMINISTRACIÓN</div>
          </div>
        </div>
      </nav>
            <!-- Cuerpo -->
            <div style="padding-top: 0px;">
                <div id="divLista" class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <b>&nbsp;ACCESOS MENU POR FUNCIONARIO</b></h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtRut">
                                        Rut Funcionario</label>
                                    <input type="text" name="txtRut" id="txtRut" class="form-control uppercase" tabindex="1"
                                        maxlength="10" />
                                </div>
                            </div>
                        </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align: right;">
                            <div class="form-group" style="margin-bottom: 0px;">
                                <button type="button" id="btnBuscar" class="btn-lg btn-primary" tabindex="5" style="display: none">
                                    <i class="fa fa-search"></i>&nbsp;Buscar
                                </button>
                                <button type="button" id="btnGuardar" class="btn-lg btn-primary" tabindex="5"
                                    style="display: none">
                                    <i class="fa fa-print"></i>&nbsp;Guardar
                                </button>
                            </div>
                        </div>
                    </div>
                    <br />
                     <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div id="listaDePermisos">
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
        </div>
    </div>
</div>
