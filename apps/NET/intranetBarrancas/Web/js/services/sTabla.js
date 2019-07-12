/*
08/05/2019 rtorreblanca: Creación.
15/05/2019 xbravo: Modificación
*/

function sTabla() {

  this.source = '../services/sTabla.aspx';

  this.callback = null;
  this.extra = null;

  this.obtenerMesesVigentes = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerMesesVigentes"
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

  this.obtenerAnosLiqui = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerAnosLiqui"
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

  this.obtenerSituacionActual = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerSituacionActual"
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

  this.obtenerEstadoCivil = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerEstadoCivil"
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

  this.obtenerSituacionMilitar = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerSituacionMilitar"
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

  this.obtenerUnidadVecinal = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerUnidadVecinal"
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

  this.obtenerPoblacion = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerPoblacion"
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

  this.obtenerComunas = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerComunas"
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

  this.obtenerAreasSociales = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerAreasSociales"
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

  this.obtenerParentesco = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerParentesco"
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

  this.obtenerNivelEstudios = function () {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "obtenerNivelEstudios"
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

  this.consultar = function (codigo) {
    var _data = "";
    var that = this;

    $.ajax({
      url: this.source,
      data: {
        accion: "consultar",
        codigo: codigo
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