/* 
*
* JScrollV2 - Infinite Scrolling / Lazy Loading
* rev.16 Trunk
*
*/

/* Configuración general */

var __jscroll_default_id = "scroll";
var __jscroll_default_tablesorter_esseleccionmultiple = { headers: { 0: { sorter: false}} };

/* Funciones generales */

function __jscroll_cmb_onchange(o, fun) {
  try {
    var value = $(o).val();
    if (fun == null) return false;
    var f = eval(fun);
    var row = $(o).closest("tr");
    var getRowData = function (o) {
      var selectedValue = "";
      var a = []; $(o).find('td').each(function (index, data) {
        if ($(data).context.className != "selection") {
          var obj = $(data).find("select")[0];
          if (obj != null) {
            selectedValue = $(obj).val();
          }
          else {
            selectedValue = $.trim($(data).html());
          }
          a.push(selectedValue);
        }
      });
      return a;
    };
    var data = getRowData(row);
    f(value, data, o);
  }
  catch (e) {
    console.log("Error in __jscroll_cmb_onchange : " + e.message);
  }
}

function __jscroll_checkuncheckall(o) {
  var tbody = $(o).closest("div").parent().parent();
  var tocheck = $(o).is(":checked");
  $(tbody).find('tr').each(function (index, data) {
    $(this).find('td').each(function (index, data) {
      if (index == 0) {
        var checkbox = $(this).find('input');
        if (tocheck) checkbox.prop("checked", true); else checkbox.prop("checked", false);
      }
    });
  });
}

function __jscroll_button_handler(div_id, type) {
  div_id = __jscroll_get_div_id(div_id);
  var s = jscroll_get_div_object(div_id);
  s.tableExport({ type: type, escape: 'false' });
}

function __jscroll_execute_dblclick_function(row, fun, opener) {
  try {
    var f = eval(fun);
    if (f) f(row, opener);
  } catch (e) { console.log("Error in __jscroll_execute_dblclick_function : " + e.message); }
}

function __jscroll_show_subgrid(scrollname, secuencia) {
  try {
    var subgrid = $("#subgrid_" + scrollname + "_" + secuencia);
    if (subgrid.length > 0) {
      if (subgrid.is(':visible'))
        subgrid.hide();
      else
        subgrid.show();
    }
  } catch (e) { console.log(e.message); }
}

function __jscroll_execute_delete_function(row, fun, opener) {
  try {
    var f = eval(fun);
    if (f) f(row, opener);
  } catch (e) { console.log("Error in __jscroll_execute_delete_function : " + e.message); }
}

// div_id : nombre del div del jscroll.
// optionalcolumnids : reemplazarán los nombres de las columnas.
function __jscroll_get_selected_rows(div_id, optionalcolumnids) {
  div_id = __jscroll_get_div_id(div_id);
  var scroll = jscroll_get_div_object(div_id);
  var arrayTitles = [];
  var array = [];
  scroll.find('tr').each(function (index, data) {
    $(data).find('th').each(function (index, datath) {
      var obj = $(datath).find("input")[0];
      if (obj == null) {
        if (optionalcolumnids != null) {
          if (optionalcolumnids.length > 0) {
            arrayTitles.push(optionalcolumnids[index - 1]);
          } else {
            arrayTitles.push($.trim($(datath).html()));
          }
        } else arrayTitles.push($.trim($(datath).html()));
      }
    });
  });
  scroll.find('tr').each(function (index, data) {
    var jitem = "";
    var checked = false;
    $(data).find('td').each(function (index, datatd) {
      if ($(datatd).context.className == "selection") {
        var obj = $(datatd).find("input")[0];
        if (obj != null) checked = obj.checked;
      }
      if (checked && index != 0) {
        var ajitem = '"' + arrayTitles[index - 1] + '"' + " : " + '"' + encodeURIComponent($.trim($(datatd).html())) + '"';
        if ((index - 1) == 0) jitem = ajitem; else jitem = jitem + ", " + ajitem;
      }
    });
    if ($.trim(jitem) != '') array.push("{ " + jitem + " }");
  });

  return jQuery.parseJSON("[" + array.join(", ") + "]");
}

function __jscroll_get_div_id(div_id) {
  if ($.trim(div_id) == "") return __jscroll_default_id;
  else return $.trim(div_id);
}

function jscroll_get_div_object(div_id) {
  if (div_id == "") div_id = __jscroll_default_id;
  if ($('#' + div_id).length == 0)
    return $('.' + div_id);
  else
    return $('#' + div_id);
}

function __jscroll_default_tablesorter_sortEnd(div_id, esseleccionmultiple) {
  try {
    if (esseleccionmultiple) {
      jscroll_get_div_object(div_id).find(".jscroll-table").tablesorter({ headers: { 0: { sorter: false}} }).bind("sortEnd", function (e, t) {
        __jscroll_reorganize_grids_and_subgrids(div_id);
      });
    }
    else {
      jscroll_get_div_object(div_id).find(".jscroll-table").tablesorter().bind("sortEnd", function (e, t) {
        __jscroll_reorganize_grids_and_subgrids(div_id);
      });
    }
  } catch (e) { console.log("Error in __jscroll_default_tablesorter_sortEnd : " + e.message); }
}

function __jscroll_reorganize_table(div_id, esseleccionmultiple, autotrigger, tsparams, smtsparams) {
  try {
    var valores = "";
    var tbody = jscroll_get_div_object(div_id).find(".jscroll-tbody");
    if (tbody.length > 1) {
      var length = tbody.length;
      var firsttable = tbody.first();
      var thead = '<thead class="jscroll-thead">' + jscroll_get_div_object(div_id).find(".jscroll-thead").html() + '</thead>';
      var dtbuttons = '<div class="dt-buttons" style="' + jscroll_get_div_object(div_id).find(".dt-buttons").attr("style") + '">' + jscroll_get_div_object(div_id).find(".dt-buttons").html() + '</div>';
      var lasttable = tbody.last();
      tbody.each(function (index, value) {
        valores += $(this).html() + "\n";
        if (length != index + 1)
          $(this).parent().parent().parent().remove();
      });
      lasttable.html(valores);
      lasttable.parent().prepend(thead).html();
      lasttable.parent().parent().prepend(dtbuttons).html();
    }
    if (esseleccionmultiple) {
      if (smtsparams == "") smtsparams = __jscroll_default_tablesorter_esseleccionmultiple;
      jscroll_get_div_object(div_id).find(".jscroll-table").tablesorter(smtsparams).bind("sortEnd", function (e, t) {
        __jscroll_reorganize_grids_and_subgrids(div_id);
      });
    }
    else {
      jscroll_get_div_object(div_id).find(".jscroll-table").tablesorter(tsparams).bind("sortEnd", function (e, t) {
        __jscroll_reorganize_grids_and_subgrids(div_id);
      });
    }
    if (!autotrigger && tbody.length > 1)
      $("#jscroll_" + div_id + "_alink").focus();
  } catch (e) { console.log("Error in __jscroll_reorganize_table : " + e.message); }
}

function __jscroll_reorganize_grids_and_subgrids(div_id) {
  try {
    var valores, grid, subgrid;
    var tbody = jscroll_get_div_object(div_id).find(".jscroll-tbody");
    valores = "";
    tbody.find(".jscroll-tr").each(function (index, value) {
      var attrs = $(value).attr('id').split('_');
      var searchedid = attrs[2];
      grid = $(value);
      valores += grid.wrap('<p/>').parent().html();
      grid.unwrap();
      grid.remove();
      subgrid = $("#subgrid_" + div_id + "_" + searchedid);
      valores += subgrid.wrap('<p/>').parent().html();
      subgrid.unwrap();
      subgrid.remove();
    });
    tbody.empty();
    tbody.html(valores);
    jscroll_get_div_object(div_id).find(".jscroll-table").trigger("update");
  } catch (e) {
    console.log("Error in __jscroll_reorganize_grids_and_subgrids : " + e.message);
  }
}

function jscroll_set_link() {
  this.page = '';
  this.esmodal = false;
  this.esseleccionmultiple = false;
  this.escarga = true;
  this.autotrigger = false;
  this.tsparams = '';
  this.smtsparams = '';
  this.id = '';
  this.scrollname = '';
  this.parameters = [];
  this.callback = null;
  this.setparameter = function (name, value) { this.parameters.push(name + "=" + encodeURIComponent(value)); };
  this.getlink = function () {
    try {
      if ($.trim(this.page) == "") {
        console.log("Error en jscroll_set_link : page not defined.");
        return false;
      }
      if ($.trim(this.scrollname) == "") {
        console.log("Error en jscroll_set_link : scrollname not defined.");
        return false;
      }
      if ($.trim(this.id) == "") {
        this.id = $.trim(this.scrollname) + 'Init';
      }
      var link = '<a id="' + this.id + '" href="' + this.page + "?";
      link = link + 'scrollname=' + this.scrollname + "&";
      link = link + 'escarga=' + (this.escarga ? 1 : 0) + "&";
      link = link + 'esmodal=' + (this.esmodal ? 1 : 0) + "&";
      link = link + 'autotrigger=' + (this.autotrigger ? 1 : 0) + "&";
      link = link + 'tsparams=' + this.tsparams + "&";
      link = link + 'smtsparams=' + this.smtsparams + "&";
      link = link + 'esseleccionmultiple=' + (this.esseleccionmultiple ? 1 : 0) + (this.parameters.length > 0 ? '&' : '');
      for (var p in this.parameters) {
        if (p != this.parameters.length - 1) link = link + this.parameters[p] + '&'; else link = link + this.parameters[p];
      }
      link = link + '"></a>';
      $('#' + this.scrollname).html(link);
      $('#' + this.scrollname).show();
      $('#' + this.scrollname).jscroll({ autoTrigger: this.autotrigger, callback: this.callback });
      $('#' + this.id).click();
    } catch (e) {
      console.log("Error in getlink : " + e.message);
    }
  };
  var that = this;
}

function __jscroll_filter(div_id, input_id) {
  try {
    var input, filter, table;
    input = $('#' + input_id);
    filter = input.val();
    table = jscroll_get_div_object(div_id).find(".jscroll-table");
    table.find('.jscroll-tr').each(function (index, data) {
      var found = false;
      $(data).find('[is-text=true]').each(function (index, datatd) {
        if ($(datatd).html().toUpperCase().indexOf(filter.toUpperCase()) > -1)
          found = true;
      });
      if (found == false) {
        $(this).hide();
        // Hides the subgrid if it exists
        var attrs = $(this).attr('id').split('_');
        var searchedid = attrs[2];
        var subgrid = $("#subgrid_" + div_id + "_" + searchedid);
        if (subgrid.length != 0) subgrid.hide();
      }
      else { $(this).show(); $(this).css("display", ""); }
    });
  } catch (e) {
    console.log("Error in __jscroll_filter : " + e.message);
  }
}