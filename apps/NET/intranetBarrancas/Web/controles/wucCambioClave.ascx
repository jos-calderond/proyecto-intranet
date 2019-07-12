<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCambioClave.ascx.vb" Inherits="wucClave" %>
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
            <div class="navbar-brand" href="#" style="color: white; font-weight: bold; text-transform: uppercase;">Cambio de clave</div>
          </div>          
        </div>
      </nav>
      <!-- Cuerpo -->
      <div style="padding-top: 0px;">
        <div class="panel panel-default">
          <div class="panel-heading">
            <h4 class="panel-title">
              <b>&nbsp;DATOS DEL USUARIO</b>
            </h4>
          </div>
        <div class="panel-body">
          <div class="row">
            <div class="col-md-4">
              <div class="form-group">
                <label for="">
                  Nombre Usuario</label>
                <input type="text" id="txtUsuario" name="txtUsuario" class="form-control uppercase"
                  readonly="readonly" />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-4">
              <div class="form-group">
                <label for="">
                  Clave Actual</label>
                <input type="password" id="txtClaveActual" name="txtClaveActual" class="form-control" />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-4">
              <div class="form-group">
                <label for="">
                  Clave Nueva</label>
                <input type="password" id="txtClaveNueva" name="txtClaveNueva" class="form-control" />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-4">
              <div class="form-group">
                <label for="">
                  Repetición Clave Nueva</label>
                <input type="password" id="txtRepClaveNueva" name="txtRepClaveNueva" class="form-control" />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12" style="text-align: right;">
              <div class="form-group" style="margin-bottom: 0px;">
                <button type="button" id="btnModificar" class="btn-lg btn-primary" tabindex="9">
                  <i class="fa fa-floppy-o"></i>&nbsp;Modificar
                </button>
              </div>
            </div>
          </div>
        </div>
        </div>
      </div>
    </div>
  </div>
</div>