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

    cargarRegistro();


    $('#btnModificar').click(function (e) {
        e.preventDefault();

        var actual = $("#txtClaveActual").val();
        var nueva = $("#txtClaveNueva").val();
        var confirma = $("#txtRepClaveNueva").val();

        if ( nueva == "" || confirma  == "" || actual == "" ) {
            bootbox.alert({
                title: "<p><b>Atención</b></p>", message: "Todo los campos son requeridos", size: 'small'
            });
        } else {
            if (nueva != confirma) {
                bootbox.alert({
                    title: "<p><b>Atención</b></p>", message: "Las claves no coinciden", size: 'small'
                });
            } else {
                cambioClave(actual, nueva, confirma);
                
            }
        }

   });

});

function cargarRegistro() {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {

            $("#txtUsuario").val(data.NOMBRES + " " + data.APEPAT + " " + data.APEMAT);

        }
    };
    var datos = new sCambioClave();

    datos.callback = callback;
    datos.consultar();
}

function cambioClave(actual, nueva, confirma) {
    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {

            window.location.href = '../Default.aspx?Close=1';
        }
    };
    var datos = new sCambioClave();

    datos.callback = callback;
    datos.cambioClave(actual, nueva, confirma);
}


