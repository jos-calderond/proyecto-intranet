/*
17/05/2019 xbravo: Modificación (se agrega función gValidaRangoEdad).
*/

var __PAGEFADESPEED = 500;

function gBootboxAlertModal(message) {
  var alerta = bootbox.alert({ message: message });
  alerta.on('hidden.bs.modal', function (e) { if ($('.modal.in')) { $('body').addClass('modal-open'); } });
}

function gCurrentDate() {
  var d = new Date();
  var month = d.getMonth() + 1;
  var day = d.getDate();
  var year = d.getFullYear();
  month = (('' + month).length < 2 ? '0' : '') + month;
  day = (('' + day).length < 2 ? '0' : '') + day;
  return day + "/" + month + '/' + year;
}

function gBootboxConfirmModal(message, callback, isSubmodal) {
  var confirm = bootbox.confirm({
    message: message,
    buttons: {
      confirm: {
        label: 'Sí',
        className: 'btn-success'
      },
      cancel: {
        label: 'No',
        className: 'btn-danger'
      }
    },
    callback: function (result) {
      callback(result);
    }
  });
  if (isSubmodal)
    confirm.on('hidden.bs.modal', function (e) { if ($('.modal.in')) { $('body').addClass('modal-open'); } });
}

function gFilterCombobox(comboid, attr, value) {

  $("#" + comboid + " option").each(function () {
    if ($(this).attr('region') != value)
      $(this).hide();
    else
      $(this).show();
  });
}

function gClearValidations() {
  $('.has-error').each(function (i) {
    $(this).removeClass('has-error');
  });
  $('.help-block').each(function (i) {
    $(this).remove();
  });
}

function gAddTimeToDate(fecha, cantidad, tipo) {

  var fechaaux = gFormatDate(fecha);

  if (fechaaux == "" || cantidad == 0 || $.isNumeric(cantidad) == false || tipo == "")
    return "";
  else {
    var fechaarr = fechaaux.split("/");

    var dia = parseInt(fechaarr[0]);
    var mes = parseInt(fechaarr[1]);
    var año = parseInt(fechaarr[2]);
    var auxdate = new Date(año, mes, dia);

    switch (tipo) {

      case "DAY":
        {
          auxdate.setDay(auxdate.getDate() + cantidad);

          break;
        }
      case "MONTH":
        {
          auxdate.setMonth(auxdate.getMonth() + cantidad);

          break;
        }
      case "YEAR":
        {
          auxdate.setFullYear(auxdate.getFullYear() + cantidad);

          break;
        }
    }

    dia = gPadleft(auxdate.getDate(), "0", 2);
    mes = gPadleft(auxdate.getMonth(), "0", 2);
    año = auxdate.getFullYear();

    return dia + "/" + mes + "/" + año;

  }
}

function gMessage(message) {
  bootbox.alert({ title: "<p><b>Atención</b></p>", message: message, size: 'small' });
}

function gMessage2(message) {
  bootbox.alert({ title: "<p><b>Atención</b></p>", message: message, size: 'medium' });
}

function gValidateData(data) {
  if (data.timeouterror) { eval(data.timeouterror.Message); return false; }
  if (data.error) {
    var datr = $.trim(data.error.Message.toUpperCase().replace('ERROR: ERROR ', ''));
    var t = datr.indexOf('MULTIPLE ERRORS RETURNED ......');
    if (t > 0) {
      var msg = $.trim(datr.substr(t + 38));
      msg = msg.split('ERROR ');
      datr = 'MÚLTIPLES ERRORES DETECTADOS:<br>';
      msg.forEach(function (val) {
        if ($.trim(val).length > 0)
          datr = datr + '* ' + $.trim(val) + '.<br>';
      });

    }
    bootbox.alert({ title: "<p><b>Atención</b></p>", message: $.trim(datr), size: 'small' });
    return false;
  }
  return true;
}

function gValidateEmail(email) {
  var emailReg = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
  var valid = emailReg.test(email);

  if (!valid) {
    return false;
  } else {
    return true;
  }
}

function gLoadComboWithDictionaryData(comboid, dictionary) {
  $("#" + comboid + "").append('<option value="">Seleccione...</option>');
  for (var key in dictionary) $("#" + comboid + "").append('<option value="' + key + '">' + dictionary[key] + '</option>');
}

function gEnableDivContent(divid, state) {
  var nodes = document.getElementById(divid).getElementsByTagName('*');
  for (var i = 0; i < nodes.length; i++) nodes[i].disabled = !state;
}

function gGetRowData(o) {
  var a = [];
  var text = "";
  $(o).find('td').each(function (index, data) {
    if ($(data).context.className != "selection") {
      text = $.trim($(data).html());
      if (text == "&nbsp;") text = "";
      a.push(text);
    }
  });
  return a;
}

function gPadleft(str, char, max) {
  if (str == null) str = "";
  str = str.toString();
  return str.length < max ? gPadleft(char + str, char, max) : str;
}

function gPadright(str, char, max) {
  if (str == null) str = "";
  str = str.toString();
  return str.length < max ? gPadright(str + char, char, max) : str;
}

function gConvertDateToNumber(fecha) {
  fecha = $.trim(fecha);
  return fecha.replace(/\//g, '');
}

function convertIntToFullTime(stringTime) {
  if (stringTime == null) return "";
  stringTime = $.trim(stringTime);
  if (stringTime.length != 8) return "";
  if (!jQuery.isNumeric(stringTime)) return "";
  stringTime = stringTime.substring(0, 2) + ":" + stringTime.substring(2, 4) + ":" + stringTime.substring(4, 6) + ":" + stringTime.substring(6, 8);
  return stringTime;
}

function convertToInt(stringNumber) {
  if (stringNumber == null) return 0;
  stringNumber = $.trim(stringNumber);
  stringNumber = stringNumber.replace(/\./g, "");
  var nparts = stringNumber.split(",");
  if (jQuery.isNumeric(nparts[0]))
    return nparts[0];
  else
    return 0;
}

function gMcpFormatDate(fecha, format) {
  try {
    if ($.trim(format) == "") return "";
    if ($.trim(format) != "DDMMAAAA" && $.trim(format) != "AAAAMMDD") return "";
    var ffecha = gFormatDate(fecha);
    var dia = ffecha.substr(0, 2);
    var mes = ffecha.substr(3, 2);
    var año = ffecha.substr(6, 4);
    switch (format) {
      case 'DDMMAAAA':
        {
          ffecha = "";
          ffecha = dia;
          ffecha = ffecha.concat(mes);
          ffecha = ffecha.concat(año);
          break;
        }
      case 'AAAAMMDD':
        {
          ffecha = "";
          ffecha = año;
          ffecha = ffecha.concat(mes);
          ffecha = ffecha.concat(dia);
          break;
        }
    }
    return ffecha;
  } catch (e) {
    return "";
  }
}

function gFormatTime(time, format) {
  try {
    if ($.isNumeric(time)) {

      if (time == 0) return "";

      time = time.toString();

      if (time.length < 3 || time.length > 8)
        return "";

      if (time.length == 3) {
        time = gPadleft(time, "0", 4);
        time = gPadright(time, "0", 8);
      }
      if (time.length == 5) {
        time = gPadleft(time, "0", 6);
        time = gPadright(time, "0", 8);
      }

      if (time.length == 7)
        time = gPadleft(time, "0", 8);

      var HH = time.substring(0, 2);
      var MM = time.substring(2, 4);
      var SS = time.substring(4, 6);
      if (SS == "") SS = "0";

      var MS = time.substring(6, 8);
      if (MS == "") MS = "0";

      var iHH = parseInt(HH);
      var iMM = parseInt(MM);
      var iSS = parseInt(SS);
      var iMS = parseInt(MS);

      if (iHH > 23) return "";
      if (iMM > 59) return "";
      if (iSS > 59) return "";
      if (iMS > 59) return "";

      switch (format) {

        case "HHMMSS":
          {
            time = HH.concat(MM);
            time = time.concat(SS);
            break;
          }
        case "HH:MM":
          {
            time = HH + ":" + MM;
            break;
          }
        case "HH:MM:SS":
          {
            time = HH + ":" + MM + ":" + SS;
            break;
          }
        case "HH:MM:SS:MS":
          {
            time = HH + ":" + MM + ":" + SS + ":" + MS;
            break;
          }
        default:
          {
            time = HH + ":" + MM;
            break;
          }
      }
      return time;
    }
    else {
      if (time.indexOf(":") == -1) return "";
      time = time.replace(/\:/g, '');
      time = gFormatTime(time, format);
      return time;
    }
  } catch (e) {
    return "";
  }
}

function gFormatDateMMAAAA(fecha) {
  /* Ej: 201701 */

  try {
    fecha = $.trim(fecha);
    if (fecha.length != 6) {
      return "";
    }

    fecha = fecha.concat("01");
    fecha = gFormatDate(fecha);

    var mes = fecha.substr(3, 2);
    var año = fecha.substr(6, 4);

    fecha = "";
    fecha = fecha.concat(mes);
    fecha = fecha.concat("/");
    fecha = fecha.concat(año);

    return fecha;

  } catch (e) {
    return "";
  }
}

function gFormatDate(fecha) {
  try {
    if ($.isNumeric(fecha)) {
      fecha = $.trim(fecha);
      if (fecha.length != 8) {
        if (fecha.length == 7) {
          fecha = gPadleft(fecha, "0", 8);
        } else {
          return "";
        }
      }

      // DDMMAAAA
      var dia = fecha.substr(0, 2);
      var mes = fecha.substr(2, 2);
      var año = fecha.substr(4, 4);
      var idia = parseInt(dia);
      var imes = parseInt(mes);
      var iaño = parseInt(año);
      if ((idia < 1 || idia > 31) || (imes < 1 || imes > 12) || (iaño < 1700 || iaño > 2999)) {
        // AAAAMMDD
        dia = fecha.substr(6, 2);
        mes = fecha.substr(4, 2);
        año = fecha.substr(0, 4);
        idia = parseInt(dia);
        imes = parseInt(mes);
        iaño = parseInt(año);
        if ((idia < 0 || idia > 31) || (imes < 0 || imes > 12) || (iaño < 1700 || iaño > 2099))
          return "";
        else {
          fecha = "";
          fecha = fecha.concat(dia);
          fecha = fecha.concat("/");
          fecha = fecha.concat(mes);
          fecha = fecha.concat("/");
          fecha = fecha.concat(año);
          return fecha;
        }
      }
      else {
        fecha = "";
        fecha = fecha.concat(dia);
        fecha = fecha.concat("/");
        fecha = fecha.concat(mes);
        fecha = fecha.concat("/");
        fecha = fecha.concat(año);
        return fecha;
      }
    }
    else {
      if (fecha.indexOf("/") == -1) return "";
      fecha = fecha.replace(/\//g, '');
      fecha = gFormatDate(fecha);
      return fecha;
    }
  } catch (e) {
    return "";
  }
}

function gHHMMSSTime() {
  var d = new Date();
  var datetext = d.toTimeString();
  datetext = datetext.split(' ')[0];
  datetext = datetext.replace(/\:/g, '');
  return datetext;
}

function gCurrentTime() {
  var d = new Date();
  var datetext = d.toTimeString();
  datetext = datetext.split(' ')[0];
  return datetext;
}

function gSetCurrentDateTime(wrapper) {
  var now = gCurrentDate();
  var fecha = gMcpFormatDate(now, 'AAAAMMDD');
  var datetime = '' + gDiaSem(now) + ',' + gFechaEnPalabrasAAAAMMDD(fecha) + ' ' + gCurrentTime();
  $(wrapper).val(datetime);
  setTimeout('gSetCurrentDateTime("' + wrapper + '");', '1000');
}

function gCurrentDate() {
  var d = new Date();
  var month = d.getMonth() + 1;
  var day = d.getDate();
  var year = d.getFullYear();
  month = (('' + month).length < 2 ? '0' : '') + month;
  day = (('' + day).length < 2 ? '0' : '') + day;
  return day + "/" + month + '/' + year;
}

function gValidaFechaMMAAAA(fecha) {
  fecha = $.trim(fecha);
  if (fecha == '') return '';
  if (fecha.length == 0) return false;
  if (fecha.length != 7) return false;
  if (fecha.split("/").length != 2) return false;
  fecha = "01/" + fecha;
  return gValidaFechaDDMMAAAA(fecha);
}

function gValidaFechaDDMMAAAA(fecha) {
  var dtCh = "/";
  var minYear = 1900;
  var maxYear = 2100;
  function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
      var c = s.charAt(i);
      if (((c < "0") || (c > "9"))) return false;
    }
    return true;
  }
  function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    for (i = 0; i < s.length; i++) {
      var c = s.charAt(i);
      if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
  }
  function daysInFebruary(year) {
    return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
  }
  function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
      this[i] = 31;
      if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30; }
      if (i == 2) { this[i] = 29; }
    }
    return this
  }
  function isDate(dtStr) {
    var daysInMonth = DaysArray(12);
    var pos1 = dtStr.indexOf(dtCh);
    var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
    var strDay = dtStr.substring(0, pos1);
    var strMonth = dtStr.substring(pos1 + 1, pos2);
    var strYear = dtStr.substring(pos2 + 1);
    strYr = strYear;
    if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1);
    if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1);
    for (var i = 1; i <= 3; i++) {
      if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1);
    }
    month = parseInt(strMonth);
    day = parseInt(strDay);
    year = parseInt(strYr);
    if (pos1 == -1 || pos2 == -1) {
      return false;
    }
    if (strMonth.length < 1 || month < 1 || month > 12) {
      return false;
    }
    if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
      return false;
    }
    if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
      return false;
    }
    if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
      return false;
    }
    return true;
  }
  if (isDate(fecha)) {
    return true;
  } else {
    return false;
  }
}

function gOnlyNumbers(e) {
  if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190, 188]) !== -1 ||
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
    return;
  }
  if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
    e.preventDefault();
  }
}

function gOnlyNumbersNoFormat(e) {
  if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
    return;
  }
  if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
    e.preventDefault();
  }
}

function gFormatNumber(value, intLength, decLength) {
  if ($.trim(value) == '') return '';
  intLength = intLength - decLength;
  var nparts = [];
  nparts = value.split(",");
  if (nparts.length != 1 && nparts.length != 2) return "";
  var p1 = "";
  var p2 = "";
  if (nparts.length == 2)
    if ($.trim(nparts[0]) == "" || $.trim(nparts[1]) == "") return "";
  if (nparts.length == 1 || nparts.length == 2) {
    p1 = $.trim(nparts[0].replace(/\D/g, ""));
    if (p1.length > intLength) p1 = p1.substring(0, intLength);
    p1 = p1.replace(/\B(?=(\d{3})+(?!\d))/g, ".");
  }
  if (nparts.length == 1) {
    if ($.trim(value) == "") p1 = "0";
    if (decLength > 0) return p1 + "," + gPadright(p2, "0", decLength);
    else return p1;
  }
  if (nparts.length == 2) {
    p2 = nparts[1];
    if (p2.length > decLength) p2 = p2.substring(0, decLength);
    p2 = gPadright(p2, "0", decLength);
  }
  return p1 + "," + p2;
}

function gDecimalValidator(value) {
  var text = $.trim(value);
  text = text.replace(/\./g, "");
  var nparts = [];
  nparts = text.split(",");
  if (nparts.length != 1 && nparts.length != 2) return false;
  if (nparts.length == 1)
    if (!$.isNumeric(nparts[0])) return false;
  if (nparts.length == 2)
    if (!$.isNumeric(nparts[0]) || !$.isNumeric(nparts[1])) return false;
  return true;
}

function gNumberConverter(value, intLength, decLength) {
  intLength = intLength - decLength;
  var text = $.trim(value);
  text = text.replace(/\./g, "");
  var nparts = [];
  nparts = text.split(",");
  if (nparts.length != 1 && nparts.length != 2) return "";
  if (nparts.length == 1) {
    if (text.length == intLength) {
      if (decLength > 0) return text + ",";
      else return text;
    }
    else return text.substring(0, intLength);
  }
  if (nparts.length == 2) {
    var p1 = nparts[0];
    var p2 = nparts[1];
    if (p2.length > decLength) {
      p2 = p2.substring(0, decLength);
      return p1 + "," + p2;
    }
  }
  return value;
}

/* Completa el guión y el dígito verificador de un rut. */
function gCompletaRut(campo) {

  campo = $.trim(campo);

  if (campo.split("-").length == 2) {
    return campo;
  }

  if (!$.isNumeric(campo)) return "";

  var suma = 0;
  var caracteres = "1234567890kK";
  var contador = 0;
  for (var i = 0; i < campo.length; i++) {
    u = campo.substring(i, i + 1);
    if (caracteres.indexOf(u) != -1)
      contador++;
  }
  if (contador == 0) { return false; }

  var rut = campo.substring(0, campo.length - 1);
  var drut = campo.substring(campo.length - 1);

  var dvr = '0';
  var mul = 2;
  for (i = rut.length - 1; i >= 0; i--) {
    suma = suma + rut.charAt(i) * mul;
    if (mul == 7) mul = 2;
    else mul++;
  }
  res = suma % 11;
  if (res == 1) dvr = 'k';
  else if (res == 0) dvr = '0';
  else {
    dvi = 11 - res;
    dvr = dvi + "";
  }
  if (dvr != drut.toLowerCase()) { return ""; }
  else { return rut + "-" + dvr; }
}

function gValidaRut(campo) {

  campo = $.trim(campo);

  if (campo.length == 0) return false;
  if (campo.split("-").length != 2) return false;

  campo = campo.replace('-', '');
  campo = campo.replace(/\./g, '');
  var suma = 0;
  var caracteres = "1234567890kK";
  var contador = 0;
  for (var i = 0; i < campo.length; i++) {
    u = campo.substring(i, i + 1);
    if (caracteres.indexOf(u) != -1)
      contador++;
  }
  if (contador == 0) { return false; }
  var rut = campo.substring(0, campo.length - 1);
  var drut = campo.substring(campo.length - 1);
  var dvr = '0';
  var mul = 2;
  for (i = rut.length - 1; i >= 0; i--) {
    suma = suma + rut.charAt(i) * mul;
    if (mul == 7) mul = 2;
    else mul++;
  }
  res = suma % 11;
  if (res == 1) dvr = 'k';
  else if (res == 0) dvr = '0';
  else {
    dvi = 11 - res;
    dvr = dvi + "";
  }
  if (dvr != drut.toLowerCase()) { return false; }
  else { return true; }
}

function gCreatelink() {
  this.page = null;
  this.parameters = [];
  this.setparameter = function (name, value) { this.parameters.push(name + "=" + encodeURIComponent(value)); };
  this.getlink = function () {
    var link = this.page + "?";
    for (var p in this.parameters) {
      if (p != this.parameters.length - 1) link = link + this.parameters[p] + '&'; else link = link + this.parameters[p];
    }
    return link;
  };
}

function gCreatePost() {
  this.page = null;
  this.parameters = [];
  this.target = null;
  this.setparameter = function (name, value) {
    var input_text = document.createElement('INPUT');
    input_text.type = 'TEXT';
    input_text.name = name;
    input_text.value = value;
    this.parameters.push(input_text);
  };

  this.submitform = function () {
    var f = document.createElement("form");
    f = document.createElement('FORM');
    f.name = 'tmpForm';
    f.style.display = 'none';
    f.method = 'POST';
    f.action = this.page;
    if (this.target == null)
      f.target = '_blank';
    else
      f.target = this.target;
    for (var p in this.parameters) {
      f.appendChild(this.parameters[p]);
    }

    document.body.appendChild(f);

    f.submit();

    document.body.removeChild(f);
  };
}

function gFechaEnPalabrasAAAAMMDD(aaaammdd) {
  try {
    aaaammdd = $.trim(aaaammdd);
    if (aaaammdd.length != 8)
      return "";

    var dia = aaaammdd.substr(6, 2);
    var mes = parseInt(aaaammdd.substr(4, 2));
    var año = aaaammdd.substr(0, 4);
    var meses = [12];
    var text = "";
    meses[0] = "";
    meses[1] = "Enero";
    meses[2] = "Febrero";
    meses[3] = "Marzo";
    meses[4] = "Abril";
    meses[5] = "Mayo";
    meses[6] = "Junio";
    meses[7] = "Julio";
    meses[8] = "Agosto";
    meses[9] = "Septiembre";
    meses[10] = "Octubre";
    meses[11] = "Noviembre";
    meses[12] = "Diciembre";
    text = dia + ' de ' + meses[mes] + ' de ' + año;
    return text;
  } catch (e) {
    console.log("Error en gFechaEnPalabrasAAAAMMDD : " + e.message);
    return "";
  }
}

function gFechaEnPalabras(ddmmaaaa) {
  try {
    ddmmaaaa = $.trim(ddmmaaaa);
    if (ddmmaaaa.length != 8) {
      if (ddmmaaaa.length == 7) {
        ddmmaaaa = "0".concat(ddmmaaaa);
      } else
        return "";
    }
    var dia = ddmmaaaa.substr(0, 2);
    var mes = parseInt(ddmmaaaa.substr(2, 2));
    var año = ddmmaaaa.substr(4, 4);
    var meses = [12];
    var text = "";
    meses[0] = "";
    meses[1] = "Enero";
    meses[2] = "Febrero";
    meses[3] = "Marzo";
    meses[4] = "Abril";
    meses[5] = "Mayo";
    meses[6] = "Junio";
    meses[7] = "Julio";
    meses[8] = "Agosto";
    meses[9] = "Septiembre";
    meses[10] = "Octubre";
    meses[11] = "Noviembre";
    meses[12] = "Diciembre";
    text = dia + ' de ' + meses[mes] + ' de ' + año;
    return text;
  } catch (e) {
    console.log("Error en gFechaEnPalabras : " + e.message);
    return "";
  }
}

function gDiaSem(fecha) {
  try {
    fecha = $.trim(fecha);
    fecha = gMcpFormatDate(fecha, "DDMMAAAA");
    var dias = ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"];
    var dt = new Date(fecha.substr(2, 2) + ' ' + fecha.substr(0, 2) + ', ' + fecha.substr(4) + ' 12:00:00');
    var diaSem = dias[dt.getUTCDay()];
    return diaSem;

  } catch (e) {
    console.log("Error en gDiaSem : " + e.message);
    return "";
  }
}

function gValidatextoSinEspacio(valor) {
  try {
    if (valor.indexOf(" ") < 0 && valor !== "") {
      return true;
    } else {
      return false;
    }
  } catch (e) {
    console.log("Error en gValidatextoSinEspacio : " + e.message);
    return "";
  }
}

function gValidatextoNoVacio(valor) {
  try {
    if ($.trim(valor) !== "" || $.trim(valor).length > 0) {
      return true;
    } else {
      return false;
    }
  } catch (e) {
    console.log("Error en gValidatextoNoVacio : " + e.message);
    return "";
  }
}

function gValidaRangoEdad(edades) {
  var edadReg = new RegExp("^([0-9]){1,2}-([0-9]){1,2}$");
  var valid = edadReg.test(edades);
  if (!valid) {
    return false;
  } else {
    var guion = edades.indexOf("-");
    var edad1 = edades.substring(0, guion);
    var edad2 = edades.substring(guion + 1, edades.length);
    if (parseInt(edad1) > parseInt(edad2)) {
      return false;
    }
    else {
      return true;
    }
  }
}

//$(document).ready(function () {
//    $(document).everyTime(60000, function () {
//        $.ajax({
//            url: '../acciones/actSession.aspx',
//            success: function (data) { }
//        });
//    });
//});