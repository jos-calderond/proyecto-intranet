<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucDatosPersonales.ascx.vb"
  Inherits="wucDatosPersonales" %>
<div class="row">
  <div class="col-sm-12 col-md-12 main">
    <!-- Cuerpo -->
    <div class="panel panel-primary">
      <!-- Cabecera -->
      <nav class="navbar navbar-default navbar-title">
        <div id="divTitleContainer" class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#myNavbar"
              aria-expanded="false">
              <span class="icon-bar" style="background-color: white;"></span><span class="icon-bar"
                style="background-color: white;"></span><span class="icon-bar" style="background-color: white;">
                </span>
            </button>
            <div id="divNavbarBrand" class="navbar-brand" href="#">
              ANTECEDENTES PERSONALES</div>
          </div>
          <div class="navbar-collapse collapse" id="myNavbar" aria-expanded="false">
            <ul class="navbar-right" style="margin-top: 15px;">
              <li style="list-style-type: none;"><a id="aDropdownToogle" class="dropdown-toggle"
                data-toggle="dropdown" href="#" aria-expanded="false"><span class="navbar-menu">MENU</span>&nbsp<span
                  class="caret"></span> </a>
                <ul class="dropdown-menu dropdown-menu-size">
                  <li><a href="#" id="aModificar" name="aModificar" style="display: none;"><span class="fa fa-edit">
                  </span>Modificar correo electrónico</a></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
    </nav>
      <!-- Cuerpo -->
      <div style="padding-top: 0px;">
        <div id="divDatosUsuario" class="panel panel-default">
          <div class="panel-heading">
            <h4 class="panel-title">
              <b>&nbsp;INFORMACIÓN PERSONAL</b>
            </h4>
          </div>
          <div class="panel-body">
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtRut">
                    RUT</label>
                  <input type="text" name="txtRut" id="txtRut" class="form-control uppercase" tabindex="1"
                    maxlength="10" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtNombre">
                    Nombre</label>
                  <input type="text" name="txtNombre" id="txtNombre" class="form-control uppercase"
                    tabindex="2" maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtApellidoPaterno">
                    Apellido&nbsp;Paterno</label>
                  <input type="text" name="txtApellidoPaterno" id="txtApellidoPaterno" class="form-control uppercase"
                    tabindex="3" maxlength="15" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtApellidoMaterno">
                    Apellido&nbsp;Materno</label>
                  <input type="text" name="txtApellidoMaterno" id="txtApellidoMaterno" class="form-control uppercase"
                    tabindex="4" maxlength="15" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtEstadoCivil">
                    <b>&nbsp;Estado&nbsp;Civil</b></label>
                  <input type="text" name="txtEstadoCivil" id="txtEstadoCivil" class="form-control uppercase"
                    tabindex="5" maxlength="8" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtSexo">
                    &nbsp;Sexo</label><br />
                  <input type="text" name="txtSexo" id="txtSexo" class="form-control uppercase" tabindex="6"
                    maxlength="9" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecNacimiento">
                    &nbsp;Fecha&nbsp;Nacimiento</label><br />
                  <input type="text" name="txtFecNacimiento" id="txtFecNacimiento" class="form-control uppercase"
                    tabindex="7" maxlength="10" disabled />
                </div>
              </div>
            </div>
            <a id="a3" name="a3" data-toggle="collapse" data-parent="#Fr_Datos3" href="#Fr_Datos3Data">
              <legend><i id="i_3" class="fa fa-plus"></i>&nbsp;DATOS DE CONTACTO</legend></a>
            <div id="Fr_Datos3Data" class="panel-collapse collapse">
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtTelefono">
                      <b>&nbsp;Teléfono</b></label>
                    <input type="text" name="txtTelefono" id="txtTelefono" class="form-control uppercase"
                      tabindex="8" maxlength="20" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtTeleContacto">
                      &nbsp;Telefono&nbsp;Contacto</label><br />
                    <input type="text" name="txtTeleContacto" id="txtTeleContacto" class="form-control uppercase"
                      tabindex="9" maxlength="20" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtNombreContac">
                      &nbsp;Nombre&nbsp;Contacto</label><br />
                    <input type="text" name="txtNombreContac" id="txtNombreContac" class="form-control uppercase"
                      tabindex="10" maxlength="15" disabled />
                  </div>
                </div>
              </div>
              <!-- -->
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtCorreoPerso">
                      <b>Correo&nbsp;Personal</b></label>
                    <input type="text" name="txtCorreoPerso" id="txtCorreoPerso" class="form-control uppercase"
                      tabindex="11" maxlength="50" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtCorreoIntra">
                      &nbsp;Correo&nbsp;Intranet</label><br />
                    <input type="text" name="txtCorreoIntra" id="txtCorreoIntra" class="form-control uppercase"
                      tabindex="12" maxlength="50" />
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-offset-4 col-md-2">
                  <div class="form-group">
                    <button type="button" name="btnModificarCorreo" id="btnModificarCorreo" class="btn-lg btn-primary"
                      tabindex="13">
                      <i class="fa fa-edit"></i>&nbsp;Modificar
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <!-- -->
            <a id="a2" name="a2" data-toggle="collapse" data-parent="#Fr_Datos2" href="#Fr_Datos2Data">
              <legend><i id="i_a2" class="fa fa-plus"></i>&nbsp;DIRECCIÓN</legend></a>
            <div id="Fr_Datos2Data" class="panel-collapse collapse">
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtDireccion">
                      Dirección</label>
                    <input type="text" name="txtDireccion" id="txtDireccion" class="form-control" tabindex="14"
                      maxlength="20" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtAClaratoria">
                      Aclaratoria</label>
                    <input type="text" name="txtAClaratoria" id="txtAClaratoria" class="form-control uppercase"
                      tabindex="15" maxlength="32" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtComuna">
                      Comuna</label>
                    <input type="text" name="txtComuna" id="txtComuna" class="form-control uppercase"
                      tabindex="16" maxlength="20" disabled />
                  </div>
                </div>
              </div>
            </div>
            <!-- -->
            <a id="a4" name="a4" data-toggle="collapse" data-parent="#Fr_Datos4" href="#Fr_Datos4Data">
              <legend><i id="i1" class="fa fa-plus"></i>&nbsp;DATOS BANCARIOS</legend></a>
            <div id="Fr_Datos4Data" class="panel-collapse collapse">
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtCtaCorriente">
                      &nbsp;Cuenta&nbsp;Corriente</label><br />
                    <input type="text" name="txtCtaCorriente" id="txtCtaCorriente" class="form-control uppercase"
                      tabindex="17" maxlength="22" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtMedioPago">
                      <b>Medio&nbsp;De&nbsp;Pago</b></label>
                    <input type="text" name="txtMedioPago" id="txtMedioPago" class="form-control uppercase"
                      tabindex="18" maxlength="30" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtBanco">
                      &nbsp;Banco</label><br />
                    <input type="text" name="txtBanco" id="txtBanco" class="form-control uppercase" tabindex="19"
                      maxlength="30" disabled />
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtActivo">
                      &nbsp;Activo</label><br />
                    <input type="text" name="txtActivo" id="txtActivo" class="form-control uppercase"
                      tabindex="20" maxlength="2" disabled />
                  </div>
                </div>
              </div>
            </div>
            <!-- -->
            <a id="a5" name="a5" data-toggle="collapse" data-parent="#Fr_Datos5" href="#Fr_Datos5Data">
              <legend><i id="i_5" class="fa fa-plus"></i>&nbsp;OTROS DATOS</legend></a>
            <div id="Fr_Datos5Data" class="panel-collapse collapse">
              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtHorario">
                      <b>Horario</b></label>
                    <input type="text" name="txtHorario" id="txtHorario" class="form-control uppercase"
                      tabindex="21" maxlength="35" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtAfp">
                      &nbsp;AFP</label><br />
                    <input type="text" name="txtAfp" id="txtAfp" class="form-control uppercase" tabindex="22"
                      maxlength="35" disabled />
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="txtIsapre">
                      &nbsp;Isapre</label><br />
                    <input type="text" name="txtIsapre" id="txtIsapre" class="form-control uppercase"
                      tabindex="23" maxlength="35" disabled />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <br />
        <div id="divIngreso" class="panel panel-default" style="display: none">
          <div class="panel-heading">
            <h4 class="panel-title">
              <!--Nombre del panel si aplica -->
            </h4>
          </div>
          <div class="panel-body">
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecIngreso">
                    Fecha&nbsp;Ingreso</label>
                  <input type="text" name="txtFecIngreso" id="txtFecIngreso" class="form-control uppercase"
                    tabindex="24" maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecCumpliBie">
                    Fecha&nbsp;Fecha Cumplimiento Bienios</label>
                  <input type="text" name="txtFecCumpliBie" id="txtFecCumpliBie" class="form-control uppercase"
                    tabindex="25" maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtMovCambio">
                    Motivo&nbsp;Del&nbsp;Cambio</label>
                  <input type="text" name="txtMovCambio" id="txtMovCambio" class="form-control uppercase"
                    tabindex="26" maxlength="30" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtNumroBienio">
                    N°&nbsp;De&nbsp;Bienios</label>
                  <input type="text" name="txtNumroBienio" id="txtNumroBienio" class="form-control uppercase"
                    tabindex="27" maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecIngreAdmiPublica">
                    Fecha&nbsp;Ingreso&nbsp;Administración&nbsp;Pública</label>
                  <input type="text" name="txtFecIngreAdmiPublica" id="txtFecIngreAdmiPublica" class="form-control uppercase"
                    tabindex="28" maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecIngreCargo">
                    Fecha&nbsp;Ingreso&nbsp;Cargo</label>
                  <input type="text" name="txtFecIngreCargo" id="txtFecIngreCargo" class="form-control uppercase"
                    tabindex="29" maxlength="10" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtMarcaTarj">
                    Marca&nbsp;Tarjeta</label>
                  <input type="text" name="txtMarcaTarj" id="txtMarcaTarj" class="form-control uppercase"
                    tabindex="30" maxlength="5" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecPrimeAfp">
                    Fecha&nbsp;1°&nbsp;Afp</label>
                  <input type="text" name="txtFecPrimeAfp" id="txtFecPrimeAfp" class="form-control uppercase"
                    tabindex="31" maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtIngreServEscala">
                    Ingreso&nbsp;Sistema&nbsp;Escalafón</label>
                  <input type="text" name="txtIngreServEscala" id="txtIngreServEscala" class="form-control uppercase"
                    tabindex="32" maxlength="10" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtFecIngreServ">
                    Fecha&nbsp;Ingreso&nbsp;Servicio</label>
                  <input type="text" name="txtFecIngreServ" id="txtFecIngreServ" class="form-control uppercase"
                    tabindex="33" maxlength="5" disabled />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <br />
    </div>
  </div>
