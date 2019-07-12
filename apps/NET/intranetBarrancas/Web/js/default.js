
$(document).ready(function () {

    $(document).ajaxStart(function () { $.LoadingOverlay("show"); }); $(document).ajaxStop(function () { $.LoadingOverlay("hide"); });

    $("#aspnetForm").validate({ highlight: function (element) { $(element).closest('.form-group').addClass('has-error'); }, unhighlight: function (element) { $(element).closest('.form-group').removeClass('has-error'); }, errorClass: 'help-block' });
    $.validator.addMethod('fecha', function (value, element) { return gValidaFechaDDMMAAAA(value); }, 'Valor debe ser una fecha.');

    $('#txtFecha').datepicker({ 'dateFormat': 'yy/mm/dd', changeMonth: true, changeYear: true, yearRange: '-70:+10' });

    $.validator.addMethod('rut', function (value, element) {
        var valid = gValidaRut(value);
        return valid;
    }
  , 'Valor debe ser un rut válido.');

    $('#txtUsuario').rules('add', { required: true, rut: true, messages: { required: '* Requerido.'} });

    $('#txtPassword').keyup(function (e) {

        var valid = ($("#txtUsuario").valid() && $('#txtPassword').valid());
        if (e.which != 13) {
            $('#btnIngresarServer').prop("disabled", !valid);
        }
        else {
            $('#btnIngresarServer').prop("disabled", !valid);
            $('#btnIngresarServer').trigger("click");
        }
    });

    $('#txtRut').rules('add', { required: true, rut: true, messages: { required: '* Requerido.'} });

    $('#txtFecha').change(function (e) {
        if ($("#txtRut").valid() && $('#txtFecha').valid()) {
            $('#btnRecuperarClave').prop("disabled", false);
            $('#btnRecuperarClave').trigger("click");
        }
    });

    $('#btnIngresarServer').click(function (e) {
        $('#divRecordarClave').hide();
        $('#divIngreso').show();
    });

    $('#aRecuperarClave').click(function (e) {
        $('#divRecordarClave').show();
        $("#txtRut").val("");
        $("#txtFecha").val("");
        $('#divIngreso').hide();
    });

    $('#txtUsuario').change(function (e) {

        e.preventDefault();

        var rut = gCompletaRut($(this).val());
        $(this).val(rut);

        if ($("#txtUsuario").valid()) {

        }
        else
            $('#btnIngresarServer').prop("disabled", true);
    });

    if ($('#txtUsuario').val() != "") $('#txtUsuario').trigger("change");

    $(this).find('[autofocus]').focus();
});