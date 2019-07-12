<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucLicencias.ascx.vb"
    Inherits="wucLicencias" %>
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
            <div id="divNavbarBrand" class="navbar-brand" href="#">Licencias médicas</div>
          </div>
        </div>
      </nav>
            <!-- Cuerpo -->
            <div style="padding-top: 0px;">
                <!-- Lista de Usuarios -->
                <div id="divLista" class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <b>&nbsp;CONSULTA LICENCIAS MÉDICAS</b></h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="cmbDinamico">
                                        Seleccione Año</label>
                                    <select id="cmbDinamico" name="cmbDinamico" class="form-control uppercase">
                                        
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div id="listaDeLicencias">
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
                            <b>&nbsp;Detalle De Licencia Médica</b>
                            <button type="button" id="btnVerLista" class="navbar-right btn-md btn-default" tabindex="1">
                                <i class="fa fa-arrow-left"></i>&nbsp;Ver Lista</button>
                        </h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNumeroLicencia">
                                        N° Licencia</label>
                                    <input type="text" name="txtNumeroLicencia" id="txtNumeroLicencia" class="form-control uppercase"
                                        tabindex="2" maxlength="8" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtEstado">
                                        Estado</label>
                                    <input type="text" name="txtEstado" id="txtEstado" class="form-control uppercase"
                                        tabindex="3" maxlength="12" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaAccidente">
                                        Fecha&nbsp;Accidente</label>
                                    <input type="text" name="txtFechaAccidente" id="txtFechaAccidente" class="form-control uppercase"
                                        tabindex="4" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNumeroDias">
                                        N°&nbsp;Días&nbsp;de&nbsp;reposo&nbsp;</label>
                                    <input type="text" name="txtNumeroDias" id="txtNumeroDias" class="form-control uppercase"
                                        tabindex="5" maxlength="3" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaInicio">
                                        Fecha Inicio</label>
                                    <input type="text" name="txtFechaInicio" id="txtFechaInicio" class="form-control"
                                        tabindex="6" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaTermino">
                                        Fecha&nbsp;Término</label>
                                    <input type="text" name="txtFechaTermino" id="txtFechaTermino" class="form-control uppercase"
                                        tabindex="7" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaEmision">
                                        Fecha&nbsp;Emisión</label>
                                    <input type="text" name="txtFechaEmision" id="txtFechaEmision" class="form-control uppercase"
                                        tabindex="8" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaRecepcion">
                                        Fecha&nbsp;Recepción</label>
                                    <input type="text" name="txtFechaRecepcion" id="txtFechaRecepcion" class="form-control uppercase"
                                        tabindex="9" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaInicioControl">
                                        Fecha&nbsp;Inicio&nbsp;control</label>
                                    <input type="text" name="txtFechaInicioControl" id="txtFechaInicioControl" class="form-control uppercase"
                                        tabindex="10" maxlength="10" disabled />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaTerminoControl">
                                        Fecha&nbsp;Término&nbsp;control</label>
                                    <input type="text" name="txtFechaTerminoControl" id="txtFechaTerminoControl" class="form-control uppercase"
                                        tabindex="11" maxlength="10" disabled />
                                </div>
                            </div>
                        </div>
                        <!-- Mantenedor Descripción licencia -->
                        <br />
                        <div id="divDescripcionLicencia" style="display: none;">
                            <legend>Descripción De Licencia Médica</legend>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtDiagnostico">
                                                Diagnóstico</label>
                                            <input type="text" name="txtDiagnostico" id="txtDiagnostico" class="form-control uppercase"
                                                tabindex="12" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="txtCodigoDiagnostico">
                                                Código</label>
                                            <input type="text" name="txtCodigoDiagnostico" id="txtCodigoDiagnostico" class="form-control uppercase"
                                                tabindex="13" maxlength="2" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtActividadLaboral">
                                                Actividad&nbsp;Laboral</label>
                                            <input type="text" name="txtActividadLaboral" id="txtActividadLaboral" class="form-control uppercase"
                                                tabindex="14" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtOcupacion">
                                                Ocupación</label>
                                            <input type="text" name="txtOcupacion" id="txtOcupacion" class="form-control uppercase"
                                                tabindex="15" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtTipoLicencia">
                                                Tipo&nbsp;Licencia</label>
                                            <input type="text" name="txtTipoLicencia" id="txtTipoLicencia" class="form-control uppercase"
                                                tabindex="16" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtTipoReposo">
                                                Tipo&nbsp;Reposo</label>
                                            <input type="text" name="txtTipoReposo" id="txtTipoReposo" class="form-control uppercase"
                                                tabindex="17" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtLugarReposo">
                                                Lugar&nbsp;Reposo</label>
                                            <input type="text" name="txtLugarReposo" id="txtLugarReposo" class="form-control uppercase"
                                                tabindex="18" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="txtTelefono">
                                                Teléfono</label>
                                            <input type="text" name="txtTelefono" id="txtTelefono" class="form-control uppercase"
                                                tabindex="19" maxlength="15" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtCalle">
                                                Calle</label>
                                            <input type="text" name="txtCalle" id="txtCalle" class="form-control uppercase" tabindex="21"
                                                maxlength="20" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label for="txtNumero">
                                                Número</label>
                                            <input type="text" name="txtNumero" id="txtNumero" class="form-control uppercase"
                                                tabindex="21" maxlength="6" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtComuna">
                                                Comuna</label>
                                            <input type="text" name="txtComuna" id="txtComuna" class="form-control uppercase"
                                                tabindex="22" maxlength="15" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtAclaratoria">
                                                Aclaratoria</label>
                                            <input type="text" name="txtAclaratoria" id="txtAclaratoria" class="form-control uppercase"
                                                tabindex="23" maxlength="40" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div id="divDatosHijo" class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="txtFechaNacimientoHijo">
                                                Fecha&nbsp;Nacimiento&nbsp;hijo(a)</label>
                                            <input type="text" name="txtFechaNacimientoHijo" id="txtFechaNacimientoHijo" class="form-control uppercase"
                                                tabindex="24" maxlength="10" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="txtRutHijo">
                                                RUT Hijo(a)</label>
                                            <input type="text" name="txtRutHijo" id="txtRutHijo" class="form-control uppercase"
                                                tabindex="25" maxlength="10" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label for="txtMesConcepcion">
                                                Mes Concepción</label>
                                            <input type="text" name="txtMesConcepcion" id="txtMesConcepcion" class="form-control uppercase"
                                                tabindex="26" maxlength="2" disabled />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Datos del Médico -->
                        <a id="aDatosMedico" name="aDatosMedico" data-toggle="collapse" data-parent="#Fr_DatosMedico"
                            href="#divDatosMedico"><legend><i id="i_aDatosMedico" class="fa fa-plus"></i>&nbsp;Datos&nbsp;del&nbsp;médico</legend>
                        </a>
                        <div id="divDatosMedico" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtRutMedico">
                                                RUT</label>
                                            <input type="text" name="txtRutMedico" id="txtRutMedico" class="form-control uppercase"
                                                tabindex="27" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtTipoMedico">
                                                Tipo</label>
                                            <input type="text" name="txtTipoMedico" id="txtTipoMedico" class="form-control uppercase"
                                                tabindex="28" maxlength="2" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label for="txtNombreMedico">
                                                Nombre Médico</label>
                                            <input type="text" name="txtNombreMedico" id="txtNombreMedico" class="form-control uppercase"
                                                tabindex="29" maxlength="24" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtCalleMedico">
                                                Calle</label>
                                            <input type="text" name="txtCalleMedico" id="txtCalleMedico" class="form-control uppercase"
                                                tabindex="30" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label for="txtNumeroMedico">
                                                Número</label>
                                            <input type="text" name="txtNumeroMedico" id="txtNumeroMedico" class="form-control uppercase"
                                                tabindex="31" maxlength="6" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtComunaMedico">
                                                Comuna</label>
                                            <input type="text" name="txtComunaMedico" id="txtComunaMedico" class="form-control uppercase"
                                                tabindex="32" maxlength="15" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtAclaratoriaMedico">
                                                Aclaratoria</label>
                                            <input type="text" name="txtAclaratoriaMedico" id="txtAclaratoriaMedico" class="form-control uppercase"
                                                tabindex="33" maxlength="40" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtTelefonoMedico">
                                                Teléfono</label>
                                            <input type="text" name="txtTelefonoMedico" id="txtTelefonoMedico" class="form-control uppercase"
                                                tabindex="34" maxlength="40" disabled />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Anexos Licencia-->
                        <a id="aAnexo" name="aAnexo" data-toggle="collapse" data-parent="#Fr_DatosMedico"
                            href="#divAnexoLicencia"><legend><i id="iaAnexo" class="fa fa-plus"></i>&nbsp;Anexo&nbsp;Licencia</legend>
                        </a>
                        <div id="divAnexoLicencia" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtObservaciones">
                                                Observaciones</label>
                                            <input type="text" name="txtObservaciones" id="txtObservaciones" class="form-control uppercase"
                                                tabindex="35" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtTipoSubsidio">
                                                Tipo&nbsp;Subsidio</label>
                                            <input type="text" name="txtTipoSubsidio" id="txtTipoSubsidio" class="form-control uppercase"
                                                tabindex="36" maxlength="10" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtInstSalud">
                                                Institución&nbsp;de&nbsp;Salud</label>
                                            <input type="text" name="txtInstSalud" id="txtInstSalud" class="form-control uppercase"
                                                tabindex="37" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtAfp">
                                                AFP</label>
                                            <input type="text" name="txtAfp" id="txtAfp" class="form-control uppercase" tabindex="38"
                                                maxlength="6" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtFechaAfp">
                                                Fecha&nbsp;de&nbsp;Afiliación&nbsp;AFP</label>
                                            <input type="text" name="txtFechaAfp" id="txtFechaAfp" class="form-control uppercase"
                                                tabindex="39" maxlength="30" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtFechaIngresoServicio">
                                                Fecha&nbsp;Ingreso&nbsp;Servicio</label>
                                            <input type="text" name="txtFechaIngresoServicio" id="txtFechaIngresoServicio" class="form-control uppercase"
                                                tabindex="40" maxlength="24" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtCaja">
                                                Caja</label>
                                            <input type="text" name="txtCaja" id="txtCaja" class="form-control uppercase" tabindex="41"
                                                maxlength="30" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtFechaResolucion">
                                                Fecha Resolución</label>
                                            <input type="text" name="txtFechaResolucion" id="txtFechaResolucion" class="form-control uppercase"
                                                tabindex="42" maxlength="6" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtResolucion">
                                                Resolución</label>
                                            <input type="text" name="txtResolucion" id="txtResolucion" class="form-control uppercase"
                                                tabindex="43" maxlength="15" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtCorrelativo">
                                                Correlativo</label>
                                            <input type="text" name="txtCorrelativo" id="txtCorrelativo" class="form-control uppercase"
                                                tabindex="44" maxlength="40" disabled />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtReembolso">
                                                Reembolso</label>
                                            <input type="text" name="txtReembolso" id="txtReembolso" class="form-control uppercase"
                                                tabindex="45" maxlength="40" disabled />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- 3 meses licencias comunes-->
                        <a id="a3Meses" name="a3Meses" data-toggle="collapse" data-parent="#Fr_Datos3Meses"
                            href="#div3meses"><legend><i id="i_a3Meses" class="fa fa-plus"></i>&nbsp;3&nbsp;Meses&nbsp;Lic&nbsp;Común</legend>
                        </a>
                        <div id="div3meses" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div id="lista3Meses">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtPromedio">
                                                Promedio Remuneración Neta</label>
                                            <input type="text" name="txtPromedio" id="txtPromedio" class="form-control uppercase"
                                                tabindex="46" maxlength="40" disabled />
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
