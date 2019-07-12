
function sLiquidacion() {

  this.source = '../services/sLiquidacion.aspx';

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

this.anoIni = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "anoIni"
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

  this.detalleLiquidacion = function (rut, institucion, tipoLiquidacion, ano, mes) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "detalleLiquidacion",
        rut: rut,
        institucion: institucion,
        tipoLiquidacion: tipoLiquidacion,
        ano: ano,
        mes: mes
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

  this.consultarDetalle = function (rut, institucion, tipoLiquidacion, ano, mes) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultarDetalle",
        rut: rut,
        institucion: institucion,
        tipoLiquidacion: tipoLiquidacion,
        ano: ano,
        mes: mes
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

this.listaAños = function (anoIni) {
    var _data = "";
    var that = this;

    $.ajax({
        url: this.source,
        data: {
            accion: "listaAños",
            anoIni: anoIni
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

this.imprimirLiquidacion = function (ano, mes, afp, salud, pactado, diasTrabajados, horas) {

    var p = new gCreatePost();

    p.page = "../services/cLiquidacionSueldo.aspx";
    p.setparameter("accion", "Liquidacion");
    p.setparameter("ano",ano)
    p.setparameter("mes", mes)
    p.setparameter("afp", afp)
    p.setparameter("salud", salud)
    p.setparameter("pactado", pactado)
    p.setparameter("diasTrabajados", diasTrabajados)
    p.setparameter("horas", horas)
    p.submitform();
}; 
}