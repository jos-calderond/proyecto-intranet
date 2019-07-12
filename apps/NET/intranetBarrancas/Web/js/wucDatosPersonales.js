/*
29/05/2019 jcalderon: Creación.
*/

/*Document Ready*/
$(document).ready(function () {

  $(document).ajaxStart(function () {
    $.LoadingOverlay("show");
  });
  $(document).ajaxStop(function () {
    $.LoadingOverlay("hide");
  });

  $("#aspnetForm").validate({ highlight: function (element) { $(element).closest('.form-group').addClass('has-error'); }, unhighlight: function (element) { $(element).closest('.form-group').removeClass('has-error'); }, errorClass: 'help-block' });

  $.validator.addMethod('sinEspacio', function (value, element) { return gValidatextoSinEspacio(value); }, 'No puede contener espacios');
  $.validator.addMethod('noVacio', function (value, element) { return gValidatextoNoVacio(value); }, 'no puede contener espacios.');

  (function ($) { $.each(['show', 'hide'], function (i, ev) { var el = $.fn[ev]; $.fn[ev] = function () { this.trigger(ev); return el.apply(this, arguments); }; }); })(jQuery);

  $('#aModificar').click(function (e) {
    $("#Fr_Datos3Data").collapse("toggle");
    $("#txtCorreoIntra").focus();
  });

  cargarRegistro();
  consultarCorreoIntranet()

  $('#aModificar').show();

  $('#btnModificarCorreo').click(function (e) {
    e.preventDefault();
    var correoACambiar = $("#txtCorreoIntra").val();
    modificarCorreoIntranet(correoACambiar);
  });

});

function consultarCorreoIntranet() {
  gClearValidations();

  var callback = function (data) {
    if (gValidateData(data)) {

      $("#txtCorreoIntra").val(data);
      $("#btnAgregar").hide();
    }
  };

  var datos = new sDatosPersonales();

  datos.callback = callback;
  datos.consultarCorreoIntranet();
}

function cargarRegistro(rut, menu, mant) {

  gClearValidations();

  var callback = function (data) {
    if (gValidateData(data)) {

      $("#txtRut").val(data.RUTFUN);
      $("#txtNombre").val(data.NOMBRE_FUN);
      $("#txtApellidoPaterno").val(data.APEPAT_FUN);
      $("#txtApellidoMaterno").val(data.APEMAT_FUN);

      if (data.ESTCIV_FUN == "s" || data.ESTCIV_FUN == "S") {
        $("#txtEstadoCivil").val("SOLTERO");
      } else if (data.ESTCIV_FUN == "c" || data.ESTCIV_FUN == "C") {
        $("#txtEstadoCivil").val("CASADO");
      } else {
        $("#txtEstadoCivil").val("VIUDO");
      }

      if (data.SEXO == "M" || data.SEXO == "m") {
        $("#txtSexo").val("MASCULINO");
      } else if (data.SEXO == "F" || data.SEXO == "f") {
        $("#txtSexo").val("FEMENINO");
      }

      $("#txtFecNacimiento").val(gFormatDate(data.FECNAC_FUN));
      $("#txtTelefono").val(data.TELEFO_FUN);
      $("#txtTeleContacto").val(data.TELEFO_CON);
      $("#txtNombreContac").val(data.NOMBRE_CON);
      $("#txtCorreoPerso").val(data.MAIL_PER);
      $("#txtDireccion").val(data.CALLE_FUN);
      $("#txtAClaratoria").val(data.ACLARA_FUN + " " + data.NCALLE_FUN);
      $("#txtComuna").val(data.COMUNA_FUN);
      $("#txtCtaCorriente").val(data.CTACTE);
      $("#txtMedioPago").val(data.GLOMEDPAG);
      $("#txtBanco").val(data.GLOCODBAN);
      $("#txtActivo").val(data.ACTIVO);

      if (data.ACTIVO == "s" || data.ACTIVO == "S") {
        $("#txtActivo").val("SI");
      } else if (data.ACTIVO == "n" || data.ACTIVO == "N") {
        $("#txtActivo").val("NO");
      } else {
        $("#txtActivo").val("SIN DATOS");
      }

      $("#txtHorario").val(data.HORARIO + " " + data.GHORARIO);
      $("#txtAfp").val(data.CODAFP + " " + data.GCODAFP);
      $("#txtIsapre").val(data.CODISA + " " + data.GCODISA);
      $("#txtFecIngreso").val(data.FINGGA_FUN);
      $("#txtFecCumpliBie").val(data.FECBIE_FUN);
      $("#txtMovCambio").val(data.OBSERVA);
      $("#txtNumroBienio").val(data.NROBIE_FUN);
      $("#txtFecIngreAdmiPublica").val(data.FADMPU_FUN);
      $("#txtFecIngreCargo").val(data.FINGCA_FUN);
      $("#txtMarcaTarj").val(data.MARCA_TAR);
      $("#txtFecPrimeAfp").val(data.FEC1AFP);
      $("#txtIngreServEscala").val(data.FSERES_FUN);
      $("#txtFecIngreServ").val(data.FINGSE_FUN);
      $("#btnAgregar").hide();
    }
  };
  var datos = new sDatosPersonales();

  datos.callback = callback;
  datos.consultar();
}

function consultarCorreoIntranet() {
  gClearValidations();

  var callback = function (data) {
    if (gValidateData(data)) {

      $("#txtCorreoIntra").val(data);
      $("#btnAgregar").hide();
    }
  };

  var datos = new sDatosPersonales();

  datos.callback = callback;
  datos.consultarCorreoIntranet();
}

function modificarCorreoIntranet(correoACambiar) {
  gClearValidations();

  var callback = function (data) {
    if (gValidateData(data)) {
        consultarCorreoIntranet()
    }
  };
  var datos = new sDatosPersonales();
  
  datos.callback = callback;
  datos.modificarCorreoIntranet(correoACambiar);
}
