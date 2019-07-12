
function sCambioClave() {

  this.source = '../services/sCambioClave.aspx';

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

  this.cambioClave = function (actual,nueva,confirma) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "cambioClave",
        actual: actual,
        nueva: nueva,
        confirma:confirma
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