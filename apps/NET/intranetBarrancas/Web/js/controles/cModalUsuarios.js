function cModalUsuarios(divModalId) {

  // Propiedad general.
  this.cName = function (controlName) { return divModalId + "_" + controlName; };

  var html = '<div id="' + this.cName('divPrincipal') + '" class="modal fade" role="dialog">' +
        '<div class="modal-dialog modal-xlg">' +
          '<div class="modal-content">' +
            '<div class="modal-header">' +
              '<button type="button" class="close" data-dismiss="modal">&times;</button>' +
              '<h4 class="modal-title">Consulta masiva de usuarios</h4>' +
            '</div>' +
            '<div class="modal-body">' +
              '<div class="panel-body panel-body-modal">' +
                '<div class="row" id="' + this.cName('divFiltro') + '" style="display:none;">' +
                  '<div class="col-md-4">' +
                    '<div class="form-group">' +
                      '<label for="' + this.cName('cmbVigencia') + '">Seleccionar</label>' +
                      '<select id="' + this.cName('cmbVigencia') + '" class="form-control uppercase" autofocus ><option value=" ">Vigentes</option><option value="N">No vigentes</option></select>' +
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

  /* Funciones privadas */
  this.__check = function () {

    return true;
  };

  this.__prepare = function () {

    if (that.filtro == true) $('#' + that.cName('divFiltro')).show();
    else $('#' + that.cName('divFiltro')).hide();
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

      that.listadeusuarios();

    };

    that.__load(callback);

  };

  this.edit = function () {
  };

  this.listadeusuarios = function () {
    var link = new jscroll_set_link();

    link.page = "../acciones/jScrollUsuario.aspx";
    link.scrollname = that.cName('divScroll');

    link.setparameter("estado", $("#" + this.cName('cmbVigencia')).val());
    link.setparameter("target", that.caller);
    link.setparameter("accion", "consultaMasiva");

    link.getlink();
  };

  $("#" + this.cName('cmbVigencia')).change(function (e) {
    that.listadeusuarios();
  });

  this.close = function () {

    if (that.onClose != null) that.onClose();

    $('#' + that.cName('divPrincipal')).modal('toggle');

  };

  /* Acciones */

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