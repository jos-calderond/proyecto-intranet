/*
05/06/2019 jCalderon: Creacion.
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

    //$(function () { $('#chkPermiso').bootstrapToggle({ on: 'S', off: 'N' }); });

    $("#divLista").show();
    $("#btnBuscar").show();

    $('#btnBuscar').click(function (e) {
        var rut = $("#txtRut").val();
        jscrollListaDePermisos(rut);
    });

});

function jscrollListaDePermisos(rut) {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollAccesos.aspx";
    link.scrollname = "listaDePermisos";
    link.setparameter("accion", "consultaPermisos");
    link.setparameter("rut", rut);
    // link.esseleccionmultiple = "1";
    link.getlink();

}

function jScrollPermisosRowClick(data, opener) {
    var data = gGetRowData(data);
    var numero = data[0];
    var nombre = data[1];
    var permiso = data[2];
    var cambio = permiso.slice(68, 70);
    var rut = $("#txtRut").val();
    cambioPermiso(rut, numero, cambio);
}

function cambioPermiso(rut, numero, cambio) {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            var rut = data;
            jscrollListaDePermisos(rut);
        }
    };
    var datos = new sAccesos();
    datos.callback = callback;
    datos.cambioPermiso(rut, numero, cambio);
}
