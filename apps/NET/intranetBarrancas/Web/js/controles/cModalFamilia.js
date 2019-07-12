/*
08/05/2019 rtorreblanca: Creación.
*/

function cModalFamilia(divModalId) {

  // Propiedad general.
  this.cName = function (controlName) { return divModalId + "_" + controlName; };

  var html = '<div id="' + this.cName('divPrincipal') + '" class="modal fade" role="dialog">' +
	'<div class="modal-dialog modal-xlg">' +
		'<div class="modal-content">' +
			'<div class="modal-header">' +
			  '<button type="button" class="close" data-dismiss="modal">&times;</button>' +
			  '<h4 class="modal-title">Consulta de familias</h4>' +
			'</div>' +
			'<div class="modal-body">' +
				'<div class="panel-body panel-body-modal">' +
					'<div class="row" id="' + this.cName('divFiltro') + '" style="display:none;">' +
						'<div class="col-md-3">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('selTiporden') + '">Seleccionar</label>' +
								'<select id="' + this.cName('selTiporden') + '" name="' + this.cName('selTiporden') + '" class="form-control uppercase" autofocus tabindex="1">' +
								  '<option value="A">Código Familiar</option>' +
                  '<option value="B">Dirección</option>' +
                  '<option value="C">RUT</option>' +
                  '<option value="D">Tipo de expediente</option>' +
                '</select>' +
							' </div>' +
						'</div>' +
						'<div id="' + this.cName('divRut') + '" name="' + this.cName('divRut') + '" class="col-md-2">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarRut') + '">Rut</label>' +
								'<input type="text" name="' + this.cName('txtBuscarRut') + '" id="' + this.cName('txtBuscarRut') + '" class="form-control uppercase" tabindex="2" maxlength="10" autofocus />' +
							'</div>' +
						'</div>' +
						'<div id="' + this.cName('divExpediente') + '" name="' + this.cName('divExpediente') + '" class="col-md-3">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarExpediente') + '">N° Expediente</label>' +
								'<input type="text" name="' + this.cName('txtBuscarExpediente') + '" id="' + this.cName('txtBuscarExpediente') + '" class="form-control uppercase" tabindex="6" maxlength="60" autofocus />' +
							'</div>' +
						'</div>' +
						'<div id="' + this.cName('divCalle') + '" name="' + this.cName('divCalle') + '" class="col-md-4">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarCalle') + '">Calle</label>' +
								'<input type="text" name="' + this.cName('txtBuscarCalle') + '" id="' + this.cName('txtBuscarCalle') + '" class="form-control uppercase" tabindex="4" maxlength="50" autofocus /><br />' +
							'</div>' +
						'</div>' +
            '<div id="' + this.cName('divDireccion') + '">' +
						  '<div  class="col-md-1">  ' +
							  '<div class="form-group">' +
								  '<label for="' + this.cName('txtBuscarNumero') + '">Número</label>' +
								  '<input type="text" name="' + this.cName('txtBuscarNumero') + '" id="' + this.cName('txtBuscarNumero') + '" class="form-control uppercase" tabindex="5" maxlength="5" autofocus />' +
							  '</div>' +
						  '</div>' +
						'</div>' +
						'<div id="' + this.cName('divCodfam') + '" name="' + this.cName('divCodfam') + '" class="col-md-2">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarCodFam') + '">Código&nbspFamiliar</label>' +
								'<input type="text" name="' + this.cName('txtBuscarCodFam') + '") id="' + this.cName('txtBuscarCodFam') + '" class="form-control uppercase" tabindex="6" maxlength="8" autofocus />' +
							'</div>' +
						'</div>' +
						'<div class="modal-footer">  ' +
							'<div class="form-group">' +
								'<button type="button" name="' + this.cName('btnBuscar') + '" id="' + this.cName('btnBuscar') + '" class="btn-lg btn-primary" title="Buscar">Buscar</button>' +
							'</div>' +
						'</div>' +
				  '</div>' +
          '<div id="' + this.cName('divScroll') + '"></div>' +
			  '</div>' +
         '<div class="modal-footer">' +
			    '<button type="button" id="' + this.cName('btnCerrar') + '" name="' + this.cName('btnCerrar') + '" class="btn btn-default" title="Cerrar">Cerrar</button>' +
		    '</div>' +
      '</div>' +
		'</div>' +
	'</div>' +
'</div>';

  $("#" + divModalId + "").html("");
  $("#" + divModalId + "").append(html);

  /* Atributos */
  this.caller = null;
  this.filtro = true;

  /* Eventos */
  this.onLoad = null;
  this.onClose = null;
  this.refreshParent = null;
  this.isSubmodal = false;

  //  /*validación*/

  $.validator.addMethod('rut', function (value, element) {
    return gValidaRut(value);
  }
  , 'Valor debe ser un rut válido.');

  $('#' + this.cName('txtBuscarRut')).rules('add', { required: true, rut: true, messages: { required: '* Requerido.'} });

  /* Funciones privadas */
  this.__check = function () {
    return true;
  };

  this.__prepare = function () {

    if (that.filtro == true) $('#' + that.cName('divFiltro')).show();
    else $('#' + that.cName('divFiltro')).hide();

    $('#' + that.cName('divExpediente')).hide();
    $('#' + that.cName('divRut')).hide();
    $('#' + that.cName('divCalle')).hide();
    $('#' + that.cName('divCodfam')).show();
    $('#' + that.cName('divDireccion')).hide();
  };

  this.__load = function (configurationCallback) {
    if (configurationCallback != null) configurationCallback();
    $('#' + that.cName('divPrincipal')).modal('show');
  };

  /* Funciones públicas */
  this.newone = function () {
  };

  this.open = function (e) {

    if (e) that.caller = e.currentTarget.id;

    that.accion = "consultar";

    if (!that.__check()) return false;

    that.__prepare();

    if (that.onLoad != null) that.onLoad();

    var callback = function () {
    };

    that.__load(callback);

  };

  this.edit = function () {
  };

  this.listadefamilias = function () {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollFamilia.aspx";
    link.scrollname = that.cName('divScroll');
    link.setparameter("calle", $("#" + this.cName('txtBuscarCalle')).val());
    link.setparameter("codfam", $("#" + this.cName('txtBuscarCodFam')).val());
    link.setparameter("expediente", $("#" + this.cName('txtBuscarExpediente')).val());
    link.setparameter("rut", $("#" + this.cName('txtBuscarRut')).val());
    link.setparameter("numero", $("#" + this.cName('txtBuscarNumero')).val());
    link.setparameter("opcion", $("#" + this.cName('selTiporden')).val());
    link.setparameter("target", that.caller);
    link.setparameter("accion", "consultaFamilia");
    link.getlink();
  };

  $("#" + this.cName('selTiporden')).change(function (e) {

    var tiporden = $("#" + that.cName('selTiporden')).val();
    $('#' + that.cName('divRut')).hide();
    $('#' + that.cName('divExpediente')).hide();
    $('#' + that.cName('divCalle')).hide();
    $('#' + that.cName('divCodfam')).hide();
    $('#' + that.cName('divDireccion')).hide();

    $("#" + that.cName('txtBuscarCalle')).val("");
    $("#" + that.cName('txtBuscarCodFam')).val("");
    $("#" + that.cName('txtBuscarExpediente')).val("");
    $("#" + that.cName('txtBuscarRut')).val("");
    $("#" + that.cName('txtNumero')).val("");
    $("#" + that.cName('txtDepto')).val("");

    switch (tiporden) {
      case "C":
        $('#' + that.cName('divRut')).show();
        break;
      case "D":
        $('#' + that.cName('divExpediente')).show();
        break;
      case "B":
        $('#' + that.cName('divCalle')).show();
        $('#' + that.cName('divDireccion')).show();
        break;
      case "A":
        $('#' + that.cName('divCodfam')).show();
        break;
    }
  });

  this.close = function () {
    if (that.onClose != null) that.onClose();
    $('#' + that.cName('divPrincipal')).modal('toggle');
  };

  /* Acciones */
  $("#" + this.cName('btnBuscar')).click(function (e) {
    that.listadefamilias();
  });

  $("#" + this.cName('btnCerrar')).click(function (e) {

    if (that.onClose != null) that.onClose();

    $('#' + that.cName('divPrincipal')).modal('toggle');

  });

  $('.modal').on('shown.bs.modal', function () {
    $(this).find('[autofocus]').focus();
  });

  $('#' + this.cName('divPrincipal')).on('hidden.bs.modal', function (e) {
    if (that.isSubmodal) {
      $('body').addClass("modal-open");
    }
  });

  var that = this;
  return this;
}