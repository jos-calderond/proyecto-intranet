/*
08/05/2019 rtorreblanca: Creación.
09/05/2019 rtorreblanca: Modificación. tipo de busqueda. seltiporden
*/

function cModalCalles(divModalId) {

  // Propiedad general.
  this.cName = function (controlName) { return divModalId + "_" + controlName; };

  var html = '<div id="' + this.cName('divPrincipal') + '" class="modal fade" role="dialog">' +
	'<div class="modal-dialog modal-lg">' +
		'<div class="modal-content">' +
			'<div class="modal-header">' +
			  '<button type="button" class="close" data-dismiss="modal">&times;</button>' +
			  '<h4 class="modal-title">Consulta de tabla calles v/s unidad vecinal</h4>' +
			'</div>' +
			'<div class="modal-body">' +
				'<div class="panel-body panel-body-modal">' +
					'<div class="row" id="' + this.cName('divFiltro') + '" style="display:none;">' +
          	'<div class="col-md-4">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('selTiporden') + '">Buscar por</label>' +
								'<select id="' + this.cName('selTiporden') + '" name="' + this.cName('selTiporden') + '" class="form-control uppercase" autofocus tabindex="1">' +
								'<option value="C">Calle</option><option value="U">Unidad vecinal</option></select>' +
							' </div>' +
						'</div>' +
						'<div id="' + this.cName('divCalle') + '" name="' + this.cName('divCalle') + '" class="col-md-4">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarCalle') + '">Calle</label>' +
								'<input type="text" name="' + this.cName('txtBuscarCalle') + '" id="' + this.cName('txtBuscarCalle') + '" class="form-control uppercase" tabindex="4" maxlength="50" autofocus />' +
							'</div>' +
						'</div>' +
            '<div id="' + this.cName('divUnivec') + '" name="' + this.cName('divUnivec') + '" class="col-md-2">  ' +
							'<div class="form-group">' +
								'<label for="' + this.cName('txtBuscarUnivec') + '">Unidad vecinal</label>' +
								'<input type="text" name="' + this.cName('txtBuscarUnivec') + '" id="' + this.cName('txtBuscarUnivec') + '" class="form-control uppercase" tabindex="4" maxlength="50" autofocus />' +
							'</div>' +
						'</div>' +
				  '</div>' +
          '<div class="col-md-offset-11 col-md-1">  ' +
							'<div class="form-group">' +
								'<button type="button" name="' + this.cName('btnBuscar') + '" id="' + this.cName('btnBuscar') + '" class="btn-lg btn-primary" title="Buscar">Buscar</button>' +
							'</div>' +
						'</div>' +
			  '</div>' +
			'<div id="' + this.cName('divScroll') + '">' +
      '</div>' +
      '<div class="modal-footer">' +
			  '<button type="button" id="' + this.cName('btnCerrar') + '" name="' + this.cName('btnCerrar') + '" class="btn btn-default" title="Cerrar">Cerrar</button>' +
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

  /* Funciones privadas */
  this.__check = function () {
    return true;
  };

  this.__prepare = function () {

    if (that.filtro == true) $('#' + that.cName('divFiltro')).show();
    else $('#' + that.cName('divFiltro')).hide();

    $('#' + that.cName('divUnivec')).hide();
    $('#' + that.cName('divCalle')).show();
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

  this.listadecalles = function () {
    var link = new jscroll_set_link();
    link.page = "../acciones/jScrollCalles.aspx";
    link.scrollname = that.cName('divScroll');
    link.setparameter("calle", $("#" + this.cName('txtBuscarCalle')).val());
    link.setparameter("univec", $("#" + this.cName('txtBuscarUnivec')).val());
    link.setparameter("tiporden", $("#" + this.cName('selTiporden')).val());
    link.setparameter("target", that.caller);
    link.setparameter("accion", "consultaModal");
    link.getlink();
  };

  $("#" + this.cName('selTiporden')).change(function (e) {

    var tiporden = $("#" + that.cName('selTiporden')).val();
    $('#' + that.cName('divCalle')).hide();
    $('#' + that.cName('divUnivec')).hide();
    $("#" + that.cName('txtBuscarCalle')).val("");
    $("#" + that.cName('txtBuscarUnivec')).val("");

    switch (tiporden) {
      case "C":
        $('#' + that.cName('divCalle')).show();
        break;
      case "U":
        $('#' + that.cName('divUnivec')).show();
        break;
    }
  });

  this.close = function () {
    if (that.onClose != null) that.onClose();
    $('#' + that.cName('divPrincipal')).modal('toggle');
  };

  /* Acciones */

  $("#" + this.cName('btnBuscar')).click(function (e) {
    that.listadecalles();
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