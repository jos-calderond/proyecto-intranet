
function sAccesos() {

  this.source = '../services/sAccesos.aspx';

  this.callback = null;
  this.extra = null;

  this.cambioPermiso = function (rut,numero,cambio) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "cambioPermiso",
        rut: rut,
        numero:numero,
        cambio:cambio
      },
      success: function (data) {
        _data = jQuery.parseJSON(data);
        if (that.callback) that.callback(_data, that.extra);
      },
      error: function () {
        alert("error!");
      },
      async: true
    });
};

}