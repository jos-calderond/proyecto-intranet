<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucLiquidacion.ascx.vb"
  Inherits="wucLiquidacion" %>
<div class="row">
  <div class="col-sm-12 col-md-12 main">
    <div class="panel panel-primary">
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
              LIQUIDACIÓN</div>
          </div>
          <div class="navbar-collapse collapse" id="myNavbar" aria-expanded="false">
            <ul class="navbar-right" style="margin-top: 15px;">
              <li style="list-style-type: none;"><a id="aDropdownToogle" class="dropdown-toggle"
                data-toggle="dropdown" href="#" aria-expanded="false" style="display:none;"><span class="navbar-menu">MENU</span>&nbsp<span class="caret"></span> </a>
                <ul class="dropdown-menu dropdown-menu-size">
                  <li><a href="#" id="aImprimir" name="aImprimir" style="display: none;"><span class="fa fa-print"></span>&nbsp Imprimir
                  </a></li>
                </ul>
                   </li>
            </ul>
          </div>
        </div>
      </nav>
      <!-- Cuerpo -->
      <div style="padding-top: 0px;">
        <!-- Panel datos de busqueda de liquidación -->
        <div id="divBuscarLiquidacion" class="panel panel-default" style="display: none;">
          <div class="panel-heading">
            <h4 class="panel-title">
              <b>&nbsp;CONSULTA LIQUIDACIÓN DE SUELDO</b>
            </h4>
          </div>
          <div class="panel-body">
            <div class="row">
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtRut">
                    RUT</label>
                  <input type="text" name="txtRut" id="txtRut" class="form-control uppercase" tabindex="1"
                    maxlength="10" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtNombre">
                    Nombre</label>
                  <input type="text" name="txtNombre" id="txtNombre" class="form-control uppercase"
                    tabindex="2" maxlength="30" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtAnoLiqui">
                    Seleccione año</label>
                  <select id="cbAnoLiqui" name="cbAnoLiqui" class="form-control uppercase" tabindex="3">
                   
                  </select>
                </div>
              </div>
            </div>
            <!--Listado meses liquidacion-->
            <div id="divLista">
              <div>
                <div class="row">
                  <div class="col-md-12">
                    <div class="form-group">
                      <div id="listaDeLiquidaciones">
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- Botonera -->
          <div class="row">
            <div class="col-md-12" style="text-align: right;">
              <div class="form-group" style="margin-bottom: 0px;">
                <button type="button" id="btnNuevo" class="btn-lg btn-primary" tabindex="3" style="display: none;">
                  <i class="fa fa-file"></i>&nbsp;Nuevo
                </button>
                <button type="button" id="btnAgregar" class="btn-lg btn-primary" tabindex="4" style="display: none">
                  <i class="fa fa-plus"></i>&nbsp;Agregar
                </button>
                <button type="button" id="btnModificar" class="btn-lg btn-primary" tabindex="5" style="display: none">
                  <i class="fa fa-edit"></i>&nbsp;Modificar
                </button>
                <button type="button" id="btnEliminar" class="btn-lg btn-primary" tabindex="6" style="display: none;">
                  <i class="fa fa-trash"></i>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!--Lista de detalle Liquidaciones-->
      <div id="divDetalle" class="panel panel-default" style="display: none;">
        <div class="panel-heading">
          <h4 class="panel-title">
            <b>&nbsp;DETALLE DE LIQUIDACIÓN</b>
            <button type="button" id="btnVerLista" class="navbar-right btn-md btn-default" tabindex="0">
              <i class="fa fa-arrow-left"></i>&nbsp;Nueva busqueda</button>
          </h4>
        </div>
        <div id="divDetalleSueldo" class="panel-body" style="display: none;">
          <legend>DETALLES</legend>
          <div id="detalleSueldo" class="panel-collapse">
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtTipoLiqui">
                    Tipo&nbsp;Liquidación</label>
                  <input type="text" name="txtTipoLiqui" id="txtTipoLiqui" class="form-control uppercase"
                    tabindex="7" maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtMes">
                    Mes</label>
                  <input type="text" name="txtMes" id="txtMes" class="form-control uppercase" tabindex="8"
                    maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtAno">
                    Año</label>
                  <input type="text" name="txtAno" id="txtAno" class="form-control uppercase" tabindex="9"
                    maxlength="20" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtPlanta">
                    Planta</label>
                  <input type="text" name="txtPlanta" id="txtPlanta" class="form-control uppercase"
                    tabindex="10" maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtTotImpo">
                    Total&nbsp;Imponible</label>
                  <input type="text" name="txtTotImpo" id="txtTotImpo" class="form-control uppercase"
                    tabindex="11" maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtDiasTraba">
                    Días&nbsp;Trabajados</label>
                  <input type="text" name="txtDiasTraba" id="txtDiasTraba" class="form-control uppercase"
                    tabindex="12" maxlength="2" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtHoras">
                    Horas</label>
                  <input type="text" name="txtHoras" id="txtHoras" class="form-control uppercase" tabindex="13"
                    maxlength="4" disabled />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtAfp">
                    AFP</label>
                  <input type="text" name="txtAfp" id="txtAfp" class="form-control uppercase" tabindex="14"
                    maxlength="20" disabled />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label for="txtIsapre">
                    Isapre</label>
                  <input type="text" name="txtIsapre" id="txtIsapre" class="form-control uppercase"
                    tabindex="15" maxlength="40" disabled />
                </div>
              </div>
              <div class="col-md-2">
                <div class="form-group">
                  <label for="txtPlanMonto">
                    Plan&nbsp;y&nbsp;Monto</label>
                  <input type="text" name="txtPlanMonto" id="txtPlanMonto" class="form-control uppercase"
                    tabindex="16" maxlength="40" disabled />
                </div>
              </div>
            </div>
          </div>
        </div>
        <%--<div id="divDetall">--%>
        <div class="panel-body">
          <div class="row">
            <div class="col-md-12">
              <div class="form-group">
                <div id="listaDetalleLiquidaciones">
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-body">
            <legend>TOTALES</legend>
          <div id="Fr_Datos3Data" class="panel-collapse">
            <div class="row">
              <div class="col-md-3">
                <div class="form-group">
                  <label for="txtTotHaberes">
                    Total&nbsp;Haberes</label>
                  <input type="text" name="txtTotHaberes" id="txtTotHaberes" class="form-control uppercase"
                    tabindex="17" maxlength="10" disabled style="text-align: right" />
                </div>
              </div>
              <div class="col-md-3">
                <div class="form-group">
                  <label for="txtTotDescLegales">
                    Total&nbsp;Descuentos&nbsp;Legales</label>
                  <input type="text" name="txtTotDescLegales" id="txtTotDescLegales" class="form-control uppercase"
                    tabindex="18" maxlength="10" disabled style="text-align: right" />
                </div>
              </div>
              <div class="col-md-3">
                <div class="form-group">
                  <label for="txtTotDescVarios">
                    Total&nbsp;Descuentos&nbsp;Varios</label>
                  <input type="text" name="txtTotDescVarios" id="txtTotDescVarios" class="form-control uppercase"
                    tabindex="19" maxlength="10" disabled style="text-align: right" />
                </div>
              </div>
              <div class="col-md-3">
                <div class="form-group">
                  <label for="txtTotPagar">
                    Total&nbsp;a&nbsp;Pagar</label>
                  <input type="text" name="txtTotPagar" id="txtTotPagar" class="form-control uppercase"
                    tabindex="20" maxlength="10" disabled style="text-align: right" />
                </div>
              </div>
            </div>
            <!-- Botonera -->
            <div class="row">
              <div class="col-md-12" style="text-align: right;">
                <div class="form-group" style="margin-bottom: 0px;">
                  <button type="button" id="btnImprimir" class="btn-lg btn-primary" tabindex="5" style="display: none">
                    <i class="fa fa-print"></i>&nbsp;Imprimir
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <br />
  </div>
</div>
