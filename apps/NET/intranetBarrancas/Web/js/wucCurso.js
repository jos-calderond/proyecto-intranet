/*
09/05/2019 rtorreblanca: Creación.
16/05/2019 croman: Se elimina utilización de servicio sCurso.
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

  cargarJuntaVecino();
  $("#divMantenedor").show();

  $("#btnConsultar").click(function (e) {
    jscrollListaDeCursos();
    $("#divLista").show();
  });

  $("#selEstado").change(function (e) {
    jscrollListaDeCursos();
  });

});
/*Fin document Ready*/
function jscrollListaDeCursos() {
  var link = new jscroll_set_link();

  link.page = "../acciones/jScrollCurso.aspx";
  link.scrollname = "listaDeCursos";
  link.setparameter("tiporden", "B");
  link.setparameter("programa", $("#selPrograma").val());
  link.setparameter("ano_b", $("#selAno").val());
  link.setparameter("periodo", $("#txtPeriodo").val());
  link.setparameter("estado", $("#selEstado").val());
  link.setparameter("jveci", $("#txtJuntaVecinos").val());
  link.setparameter("accion", "consultar");
  link.getlink();
}

function cargarJuntaVecino() {
  gClearValidations();

  var callback = function (data) {
    if (gValidateData(data)) {
      $("#txtJuntaVecinos").val(data.junta.codigo);
      $("#txtGlosaJuntaVecinos").val(data.junta.nombre);
      $('#txtJuntaVecinos').prop("disabled", true);
    }
  };
  var login = new sLogin();
  login.callback = callback;
  login.login();
}
