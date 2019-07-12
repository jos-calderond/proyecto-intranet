function cModalRoles(div_modal_id) {

  var div_principal = "divModalRoles_" + div_modal_id;
  var div_principal_txt_busqueda = "txtModalRolesBusqueda_" + div_modal_id;
  var div_principal_btn_busqueda = "btnModalRolesBuscar_" + div_modal_id;
  var div_principal_btn_obtener_seleccionados = "btnModalRolesObtenerSeleccionados_" + div_modal_id;
  var div_principal_txt_seleccionados = "txtModalRolesSeleccionados_" + div_modal_id;
  var div_principal_jscroll = "scrollRoles_" + div_modal_id;
  var div_principal_jscroll_link = "scrollRoleInit_" + div_modal_id;
  var div_principal_opener = "jscrolltarget_" + div_principal_jscroll;
  var div_principal_link_href = "../acciones/jScrollRol.aspx";
  var div_principal_title = "Consulta masiva de roles";

  var div_principal_html = '<div id="' + div_principal + '" class="modal fade" role="dialog">' +
        '<div class="modal-dialog modal-xlg">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal">&times;</button>' +
                    '<h4 class="modal-title">' + div_principal_title + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                    '<div class="panel-body panel-body-modal">' +
                        '<div class="row container4">' +
                            '<div id="' + div_principal_opener + '" style="display:none;"></div>' +
                            '<div id="' + div_principal_jscroll + '"></div>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
                '<div class="modal-footer">' +
                    '<input type="hidden" id="' + div_principal_txt_seleccionados + '" />' +
                    '<button type="button" id="' + div_principal_btn_obtener_seleccionados + '" class="btn btn-default" tabindex="1">Obtener Marcados</button>' +
                    '<button type="button" class="btn btn-default" data-dismiss="modal" tabindex="2" autofocus >Cerrar</button>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>';
  $("#" + div_modal_id + "").html("");
  $("#" + div_modal_id + "").append(div_principal_html);

  var div_principal_jscroll_getlink = function () {
    var link = new jscroll_set_link();

    link.page = div_principal_link_href;
    link.id = div_principal_jscroll_link;
    link.scrollname = div_principal_jscroll;
    link.esmodal = true;
    link.esseleccionmultiple = that.esseleccionmultiple;

    link.setparameter("target", div_principal_opener);
    link.setparameter("accion", "consultaMasiva");

    link.getlink();
  };

  var rolesRowClick = function (o) {
    var data = gGetRowData(o);

    this.codigo = $.trim(data[0]);
    this.nombre = $.trim(data[1]);
    this.diasPassword = $.trim(data[2]);

    $('#' + div_principal).modal('toggle');
  };

  this.init = function () {
    div_principal_jscroll_getlink();
    return false;
  };

  this.rolRowClick = rolesRowClick;

  this.codigo = null;
  this.nombre = null;
  this.diasPassword = null;

  this.esseleccionmultiple = false;
  this.openModal = function (e) {
    if (!this.esseleccionmultiple) $("#" + div_principal_btn_obtener_seleccionados).hide();
    $("#" + div_principal_opener).html(e.currentTarget.id);
    $('#' + div_principal).modal('show');
  };

  this.selectedRowsJson = function (e) {
    var seleccionados = $("#" + div_principal_txt_seleccionados + '').val();
    if ($.trim(seleccionados) != "")
      seleccionados = jQuery.parseJSON(seleccionados);
    return seleccionados;
  };

  $("#" + div_principal_btn_obtener_seleccionados + '').click(function (e) {
    $("#" + div_principal_txt_seleccionados + '').val(__jscroll_get_selected_rows(div_principal_jscroll));
    $('#' + div_principal).modal('toggle');
  });

  $('.modal').on('shown.bs.modal', function () {
    $(this).find('[autofocus]').focus();
  });

  var that = this;
  return this;
}