
function sLogin() {

  this.source = '../services/sLogin.aspx';

  this.callback = null;
  this.extra = null;

  this.login = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
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

function sLoginSync() {

  var data_ = null;

  this.source = '../services/sLogin.aspx';
  this.data = function () { return data_; };

  this.usuarioRut = function () { return data_.usuario.rut; };
  this.usuarioNombre = function () { return data_.usuario.nombre; };
  this.usuarioCodsis = function () { return data_.usuario.codsis; };

  this.login = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
      },
      success: function (data) {
        _data = jQuery.parseJSON(data);
        data_ = _data;
      },
      error: function () {
        alert("error!");
      },
      async: false
    });
  };
}