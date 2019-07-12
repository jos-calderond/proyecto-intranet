/*
16/05/2019 croman: Creación. Clase para manejar la carga, descarga y listado de archivos desde un FTP.
*/
function cArchivos() {

  this.callback = null;

  this.getFiles = function (folder) {
    var _data = null;
    var call = this.callback;
    $.ajax({
      url: '../controles/cArchivos.aspx',
      data: { folder: folder, action: 'getFiles' },
      success: function (data) {
        if (data == "")
          _data = null;
        else
          _data = jQuery.parseJSON(data);
        if (call) call(_data);
      },
      async: true
    });
  };

  this.deleteFile = function (folder, filename) {
    var _data = null;
    var call = this.callback;
    $.ajax({
      url: '../controles/cArchivos.aspx',
      data: {
        folder: folder,
        filename: filename,
        action: 'deleteFile'
      },
      success: function (data) {
        if (call) call(_data);
      },
      async: true
    });
};

this.upload = function (file) {
    var _data = null;
    var call = this.callback;
    $.ajax({
        url: '../controles/cArchivos.aspx',
        data: {
            file: file,
            action: 'upload'
        },
        success: function (data) {
            if (call) call(_data);
        },
        async: true
    });
};

  this.openFile = function (folder, filename) {
    var p = new gCreatePost();
    p.page = '../controles/cArchivos.aspx';
    p.setparameter("action", "openfile");
    p.setparameter("folder", folder);
    p.setparameter("filename", filename);
    p.submitform();
  };
}