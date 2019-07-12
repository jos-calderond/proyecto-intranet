/*
05/06/2019 rtorreblanca: Creación.
*/
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

    cargarAnosLicencias();

    $("#divLista").show();
    $("#divMantenedor").hide();

    $("#btnVerLista").click(function (e) {
        $("#divLista").show();
        $("#divMantenedor").hide();
        $("#divDescripcionLicencia").hide();
    });

    $('#cmbDinamico').change(function (e) {
        var periodo = $('#cmbDinamico').val();
        periodo = periodo.concat("0101");
        jscrollListaDeLicencias(periodo);
    });
});

function jscrollListaDeLicencias(periodo) {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollLicencias.aspx";
    link.scrollname = "listaDeLicencias";
    link.setparameter("periodo",periodo);
    link.setparameter("accion", "consultaMasiva");
    link.getlink();
}

function jscrollLista3Meses(fecini_lic) {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollLicencias.aspx";
    link.scrollname = "lista3Meses";
    link.setparameter("fecini_lic", fecini_lic);
    link.setparameter("accion", "consulta3Meses");
    link.getlink();
}

function jScrollLicenciasRowClick(data, opener) {
    var data = gGetRowData(data);
    var  numlic = data[0];
    var fecini_lic = data[1];

    cargarRegistro(numlic);
    jscrollLista3Meses(fecini_lic);
    consultarPromedio(fecini_lic);
    $("#divLista").hide();
    $("#divMantenedor").show();
}

function cargarRegistro(numlic) {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $("#txtNumeroLicencia").val(data.NUMLIC_LIC);
            $("#txtEstado").val(data.GESTLIC);
            $("#txtFechaAccidente").val(gFormatDate(data.FECACC_LIC));
            $("#txtFechaEmision").val(gFormatDate(data.FECEMI));
            $("#txtNumeroDias").val(data.NRODIA_LIC);
            $("#txtFechaInicio").val(gFormatDate(data.FECINI_LIC));
            $("#txtFechaTermino").val(gFormatDate(data.FECTER_LIC));
            $("#txtFechaRecepcion").val(gFormatDate(data.FECRECLIC));
            $("#txtFechaTerminoControl").val(gFormatDate(data.FECTER_CON));
            $("#txtFechaInicioControl").val(gFormatDate(data.FECINI_CON));
            $("#txtDiagnostico").val(data.GCODOCU);
            $("#txtCodigoDiagnostico").val(data.CODLICEN);
            $("#txtActividadLaboral").val(data.GACTLAB);
            $("#txtOcupacion").val(data.GCODOCU);
            $("#txtTipoLicencia").val(data.GLOTIPLIC);
            $("#txtTipoReposo").val(data.GLOJORNA);
            $("#txtLugarReposo").val(data.GCODEST);
            $("#txtCalle").val(data.CALLE_LIC);
            $("#txtNumero").val(data.NCALLE_LIC);
            $("#txtAclaratoria").val(data.ACLARA_LIC);
            $("#txtComuna").val(data.COMUNA_LIC);
            $("#txtTelefono").val(data.FONO_LIC);

            if (data.RUTHIJ == "") {
                $("#divDatosHijo").hide();
            } else {
                $("#divDatosHijo").show();
            }

            $("#txtFechaNacimientoHijo").val(gFormatDate(data.FECNAC));
            $("#txtRutHijo").val(data.RUTHIJ);
            $("#txtMesConcepcion").val(data.MESCON);
            $('#txtNumeroLicencia').prop("disabled", true);
            $("#txtRutMedico").val(data.RUTMED);
            $("#txtTipoMedico").val(data.GTIPMED);
            var nombreCompletoMedico = data.NOMMED_LIC + " " + data.APEPATM;
            $("#txtNombreMedico").val(nombreCompletoMedico);
            $("#txtCalleMedico").val(data.CALLEM);
            $("#txtNumeroMedico").val(data.NUMEROM);
            $("#txtComunaMedico").val(data.COMUNAM);
            $("#txtAclaratoriaMedico").val(data.ACLARAM);
            $("#txtTelefonoMedico").val(data.FONOMED);
            $("#txtObservaciones").val(data.OBSERV_LIC);
            $("#txtTipoSubsidio").val(data.GTIPSUB);
            $("#txtInstSalud").val(data.GCODISA);
            $("#txtFechaAfp").val(data.FEC1AFP);
            $("#txtFechaIngresoServicio").val(data.FECINI_C);
            $("#txtFechaResolucion").val(data.FECRESL);
            $("#txtResolucion").val(data.RESSAL);
            $("#txtCorrelativo").val(data.CORRELA);
            $("#txtReembolso").val(data.VALREMB);
            $("#divDescripcionLicencia").show();
        }
    };
    var licencia = new sLicencias();
    licencia.callback = callback;
    licencia.consultar(numlic);
}

function consultarPromedio(fecini_lic) {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {

            var total1 = data.REMNET1;
            var total2 = data.REMNET2;
            var total3 = data.REMNET3;
            var suma;
            var promedio;
            var div = 0;

            if (total1 > 0) { div = div + 1; }
            if (total2 > 0) { div = div + 1; }
            if (total3 > 0) { div = div + 1; }

            suma = parseInt(total1) + parseInt(total2) + parseInt(total3);
            var monto = 0
            if (div > 0) {
                promedio = Math.round((suma / div), 1);
                monto = separador(promedio)
                $("#txtPromedio").val();
                $("#txtPromedio").val(monto);
            }
        }
    };
    var licencia = new sLicencias();
    licencia.callback = callback;
    licencia.consultar3Meses(fecini_lic);
}

function separador(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    }
    return x1 + x2;
}

function cargarAnosLicencias() {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $('#cmbDinamico').empty();
            $.each(data, function (i, p) {
                $('#cmbDinamico').append($('<option></option>').val(p).html(p));
            });
            var ano = $('#cmbDinamico').val();
            ano = ano.concat("0101");
            jscrollListaDeLicencias(ano);
        }
    };
    var licencia = new sLicencias();
    licencia.callback = callback;
    licencia.cargarAnosLicencias();
}
