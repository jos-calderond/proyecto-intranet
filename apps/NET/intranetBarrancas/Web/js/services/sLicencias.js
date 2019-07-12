
function sLicencias() {

  this.source = '../services/sLicencias.aspx';

  this.callback = null;
  this.extra = null;

  this.consultar = function (numlic) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultar",
        numlic: numlic
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

  this.listAnos = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "listAnos"
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

this.cargarAnosLicencias = function () {
    var _data = "";
    var that = this;

    $.ajax({
        url: this.source,
        data: {
            accion: "cargarAnosLicencias"
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

this.consultar3Meses = function (fecini_lic) {
    var _data = "";
    var that = this;

    $.ajax({
        url: this.source,
        data: {
            accion: "consultar3Meses",
            fecini_lic: fecini_lic
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

