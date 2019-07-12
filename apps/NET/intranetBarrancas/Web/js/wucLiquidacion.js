/*
28/05/2019 jcalderon: Creación.
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

    $("#btnImprimir").on('show', function () { $('#aImprimir').show(); });
    $("#btnImprimir").on('hide', function () { $('#aImprimir').hide(); });

    $('#aImprimir').click(function (e) { $("#btnImprimir").trigger("click"); });

    $("#aDropdownToogle").hide();

    cargarDatosUsuario();
    generarAnos();

    $("#divBuscarLiquidacion").show();

    $("#cbAnoLiqui").change(function (e) {
        var ano = $("#cbAnoLiqui").val();
        jScrollListaDeLiquidaciones(ano);
    });

    $("#btnVerLista").click(function (e) {
        $("#divDetalleSueldo").hide();
        $("#divDetalle").hide();
        $("#divBuscarLiquidacion").show();
    });

    $('#btnImprimir').click(function (e) {
        e.preventDefault();

        gClearValidations();
        var ano = $("#txtAno").val()
        var mes = $("#txtMes").val()
        var afp = $("#txtAfp").val()
        var salud = $("#txtIsapre").val()
        var pactado = $("#txtPlanMonto").val()
        var diasTrabajados = $("#txtDiasTraba").val()
        var horas = $("#txtHoras").val()

        if ($("#txtRut").valid()) {
            var ImpresionLiquidacion = new sLiquidacion();
            ImpresionLiquidacion.imprimirLiquidacion(ano, mes, afp, salud, pactado, diasTrabajados, horas);
        }
    });

});

function jScrollListaDeLiquidaciones(ano) {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollLiquidacion.aspx";
    link.scrollname = "listaDeLiquidaciones";
    link.setparameter("ano", ano);
    link.setparameter("accion", "consultarLiquidaciones");
    link.setparameter("institucion", "2");
    link.getlink();
}

function jScrollListaDetalleLiquidaciones(rut, institucion, tipoLiquidacion, ano, mes) {

    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollLiquidacion.aspx";
    link.scrollname = "listaDetalleLiquidaciones";
    link.setparameter("ano", ano);
    link.setparameter("accion", "consultarDetalleLiquidacion");
    link.setparameter("institucion", institucion);
    link.setparameter("rut", rut);
    link.setparameter("mes", mes);
    link.setparameter("tipoLiquidacion", tipoLiquidacion);
    link.getlink();

    $("#divDetalleSueldo").show();
    $("#divDetalle").show();
    $("#divBuscarLiquidacion").hide();
    $("#btnImprimir").show();
    $("#aDropdownToogle").show();
}

function jscrollListaDeUsuarios() {
    var link = new jscroll_set_link();

    link.page = "../acciones/jScrollUsuario.aspx";
    link.scrollname = "listaDeUsuarios";
    link.setparameter("estado", $("#selEstado").val());
    link.setparameter("accion", "consultaMasiva");
    link.setparameter("editable", 1);
    link.getlink();
}

function jScrollLiquidacionRowClick(data, opener) {
    var data = gGetRowData(data);
    var mes = data[0];
    var nomMes = data[1];
    var rut = $("#txtRut").val();
    var institucion = "02";
    var tipoLiquidacion = "99";
    var ano = $("#cbAnoLiqui").val();

    jScrollListaDetalleLiquidaciones(rut, institucion, tipoLiquidacion, ano, mes);
    cargarDetalleSueldo(rut, institucion, tipoLiquidacion, ano, mes, nomMes);
}

function generarAnos() {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $('#cbAnoLiqui').empty();
            $.each(data, function (i, p) {
                $('#cbAnoLiqui').append($('<option></option>').val(p).html(p));

            });
            jScrollListaDeLiquidaciones($('#cbAnoLiqui').val()); 
        }
    };
    var datos = new sLiquidacion();
    datos.callback = callback;
    datos.anoIni();
}

function cargarDatosUsuario() {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $("#txtRut").val(data.RUT_FUN);
            $("#txtNombre").val(data.NOMBRE_FUN);
        }
    };
    var datos = new sLiquidacion();
    datos.callback = callback;
    datos.consultar();
}

function cargarDetalleSueldo(rut, institucion, tipoLiquidacion, ano, mes, nomMes) {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            var monto = 0
            monto = separador(data.TOT_HAB)
            $("#txtTotHaberes").val(monto);
            monto = separador(data.TOT_DESL)
            $("#txtTotDescLegales").val(monto);
            monto = separador(data.TOT_DESV)
            $("#txtTotDescVarios").val(monto);
            monto = separador(data.VAL_PAGO)
            $("#txtTotPagar").val(monto);
            $("#txtTipoLiqui").val("LIQUIDACIÓN FINAL");
            $("#txtPlanta").val(data.GLOPLANTA);
            $("#txtTotImpo").val(data.VAL_IMPON);
            $("#txtMes").val(nomMes)
            $("#txtAno").val(ano)
            var afp = data.GLO_AFP + " - " + data.VAL_AFP + "%";
            $("#txtAfp").val(afp);
            var isapre = data.GLO_IS + " - " + data.POR_IS + "%";
            $("#txtIsapre").val(isapre);
            $("#txtPlanMonto").val(data.MONPLA);
            $("#txtDiasTraba").val(data.DIA_TRABAJ);
            $("#txtHoras").val(data.HORAS);
        }
    };
    var datos = new sLiquidacion();
    datos.callback = callback;
    datos.consultarDetalle(rut, institucion, tipoLiquidacion, ano, mes);
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


