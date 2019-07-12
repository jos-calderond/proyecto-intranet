/*
05/06/2019 jCalderón: Creación.
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

    jscrollListaDeCertificados();

    $("#divLista").show();
    $("#divMantenedor").hide();

    $("#btnVerLista").click(function (e) {
        $("#divLista").show();
        $("#divMantenedor").hide();
    });

    $("#cmbAno").change(function (e) {
        var ano = $("#cmbAno").val();
        consultaMeses(ano);
    });

});

function jscrollListaDeCertificados() {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollCertificados.aspx";
    link.scrollname = "listaDeCertificados";
    link.setparameter("accion", "consultaOpciones");
    link.getlink();
}

$('#btnImprimir').click(function (e) {
    e.preventDefault();

    gClearValidations();

    if ($("#txtRut").valid()) {
        var Imprimir = new sCertificados();
        Imprimir.imprimirCertAntiguedad();
    }
});

$('#btnImprimirCertConRenta').click(function (e) {
    e.preventDefault();

    gClearValidations();


    if ($("#txtRut").valid()) {
        var Imprimir = new sCertificados();
        var ano = $("#cmbAno").val();
        var mes = $("#cmbMes").val();
        Imprimir.imprimirCertAntiguedadRenta(ano,mes);
    }
});

$('#btnImprimirCertLey19').click(function (e) {
    e.preventDefault();

    gClearValidations();


    if ($("#txtRut").valid()) {
        var Imprimir = new sCertificados();
        var para = $("#txtPara").val();
        Imprimir.imprimirCertLey19(para);
    }
});

function jScrollCertificadosRowClick(data, opener) {
    var data = gGetRowData(data);
    var numero = data[0];
    var nombre = data[1];

    cargarRegistro(numero, nombre);
    $("#divLista").hide();
    $("#divMantenedor").show();
}

function cargarRegistro(numero, nombre) {

    gClearValidations();
    var numero = numero;
    var nombre = nombre;
    var callback = function (data) {
        if (gValidateData(data)) {

            if (numero == 1) {
                $("#mesAno").hide();
                $("#destino").hide();
                $("#btnImprimir").show();
                $("#btnImprimirCertConRenta").hide();
                $("#btnImprimirCertLey19").hide();
                $("#btnImprimirCertCarga").hide();
            } else if (numero == 2) {
                $("#mesAno").show();
                $("#destino").hide();
                consultaAnos();
                $("#btnImprimirCertConRenta").show();
                $("#btnImprimir").hide();
                $("#btnImprimirCertLey19").hide();
                $("#btnImprimirCertCarga").hide();
            } else if (numero == 3) {
                $("#mesAno").hide();
                consultaAnos();
                $("#btnImprimirCertConRenta").hide();
                $("#btnImprimir").hide();
                $("#btnImprimirCertLey19").show();
                $("#btnImprimirCertCarga").hide();
                
            } else if (numero == 4) {

            } else if (numero == 5) {
                $("#mesAno").hide();
                consultaAnos();
                $("#btnImprimirCertConRenta").hide();
                $("#btnImprimir").hide();
                $("#btnImprimirCertLey19").hide();
                $("#btnImprimirCertCarga").show();
                
            }

            $("#txtCertificado").val(nombre);
            $("#txtRut").val(data.RUTFUN_C);
            $("#txtNombre").val(data.NOMBREFUN + " " + data.APEPATFUN + " " + data.APEMATFUN);
            var fecha = data.FINICON_P
            var ano = fecha.slice(0, 4)
            var mes = fecha.slice(4, 6)
            var dia = fecha.slice(6, 8)

            switch (mes) {
                case mes = "01":
                    mes = "ENERO";
                case mes = "02":
                    mes = "FEBRERO";
                case mes = "03":
                    mes = "MARZO";
                case mes = "04":
                    mes = "ABRIL";
                case mes = "05":
                    mes = "MAYO";
                case mes = "06":
                    mes = "JUNIO";
                case mes = "07":
                    mes = "JULIO";
                case mes = "08":
                    mes = "AGOSTO";
                case mes = "09":
                    mes = "SEPTIEMBRE";
                case mes = "10":
                    mes = "OCTUBRE";
                case mes = "11":
                    mes = "NOVIEMBRE";
                case mes = "12":
                    mes = "DICIEMBRE";

            }
            var codigo = data.CODAREA_P

            switch (codigo) {
                case codigo = "ADM":
                    codigo = "ADMINISTRACION";
                case codigo = "SAL":
                    codigo = "SALUD";
                case codigo = "EDU":
                    codigo = "EDUCACION";
            }
            var contrato = dia + " " + mes + " " + ano + "-" + codigo + " -" + data.TCONTRA_P;
            $('#txtContrato').val(contrato);
        }
    };
    var certificado = new sCertificados();
    certificado.callback = callback;
    certificado.consultar(numero);
}

function consultaAnos() {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $('#cmbAno').empty();
            $.each(data, function (i, p) {
                $('#cmbAno').append($('<option></option>').val(p).html(p));

            });
            consultaMeses($("#cmbAno").val())
        }
    };
    var datos = new sCertificados();
    datos.callback = callback;
    datos.consultaAnos();
}

function consultaMeses(ano) {

    gClearValidations();

    var callback = function (data) {
        if (gValidateData(data)) {
            $('#cmbMes').empty();
            $.each(data, function (i, p) {
                $('#cmbMes').append($('<option></option>').val(p).html(p));

            });
        }
    };
    var datos = new sCertificados();
    datos.callback = callback;
    datos.consultaMeses(ano);
}