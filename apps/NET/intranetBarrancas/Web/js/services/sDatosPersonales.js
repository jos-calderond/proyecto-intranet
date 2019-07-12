
function sDatosPersonales() {

  this.source = '../services/sDatosPersonales.aspx';

  this.callback = null;
  this.extra = null;

  this.consultar = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultar"     
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

  this.consultarCorreoIntranet = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultarCorreoIntranet"
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

  this.validarLogin = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "validarLogin"
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

  this.modificarCorreoIntranet = function (correoACambiar) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "modificarCorreoIntranet",
        correoACambiar: correoACambiar
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