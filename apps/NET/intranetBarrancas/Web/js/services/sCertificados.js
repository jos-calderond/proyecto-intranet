
function sCertificados() {

  this.source = '../services/sCertificados.aspx';

  this.callback = null;
  this.extra = null;

  this.consultar = function (numero) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultar",
        numero: numero
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

this.imprimirCertAntiguedad = function () {

    var p = new gCreatePost();

    p.page = "../services/cCertAntiguedad.aspx";
    p.setparameter("accion", "AntiguedadLaboral");
    p.submitform();
};

this.imprimirCertAntiguedadRenta = function (ano, mes) {

    var p = new gCreatePost();

    p.page = "../services/cCertAntiguedadRenta.aspx";
    p.setparameter("accion", "AntiguedadLaboralRenta");
    p.setparameter("ano", ano);
    p.setparameter("mes", mes);
    p.submitform();
};

this.imprimirCertLey19 = function (para) {

    var p = new gCreatePost();

    p.page = "../services/cCertLey19.aspx";
    p.setparameter("accion", "Ley19");
    p.setparameter("para",para);
    p.submitform();
};

this.consultaAnos = function () {
    var _data = "";
    var that = this;

    $.ajax({
        url: this.source,
        data: {
            accion: "consultaAnos"
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

this.consultaMeses = function (ano) {
    var _data = "";
    var that = this;

    $.ajax({
        url: this.source,
        data: {
            accion: "consultaMeses",
            ano:ano
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