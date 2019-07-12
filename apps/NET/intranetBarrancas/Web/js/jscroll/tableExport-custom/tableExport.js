/*The MIT License (MIT)

Copyright (c) 2014 https://github.com/kayalshri/

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

(function ($) {
  $.fn.extend({
    tableExport: function (options) {
      var defaults = {
        separator: ',',
        ignoreColumn: [],
        tableName: 'yourTableName',
        type: 'csv',
        pdfFontSize: 10,
        pdfLeftMargin: 12,
        escape: 'true',
        htmlContent: 'false',
        consoleLog: 'false'
      };

      var options = $.extend(defaults, options);
      var el = this;
      var downloadURI = function downloadURI(name, defaults, base64data) {

        var link = document.createElement("a");
        link.download = name;
        link.href = 'data:application/' + defaults.type + ';' + base64data;
        link.click();
      };

      if (defaults.type == 'csv' || defaults.type == 'txt') {

        // Header
        var tdData = "";
        $(el).find('thead').find('tr').each(function () {
          tdData += "\n";
          $(this).filter(':visible').find('th').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                tdData += '"' + parseString($(this)) + '"' + defaults.separator;
              }
            }

          });
          tdData = $.trim(tdData);
          tdData = $.trim(tdData).substring(0, tdData.length - 1);
        });

        // Row vs Column
        $(el).find('tbody').find('tr').each(function () {
          tdData += "\n";
          $(this).filter(':visible').find('td').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                tdData += '"' + parseString($(this)) + '"' + defaults.separator;
              }
            }
          });
          //tdData = $.trim(tdData);
          tdData = $.trim(tdData).substring(0, tdData.length - 1);
        });

        //output
        if (defaults.consoleLog == 'true') {
          console.log(tdData);
        }

        /*
        ORIGINAL

        var base64data = "base64," + $.base64.encode(tdData);
        window.open('data:application/' + defaults.type + ';filename=exportData;' + base64data); */

        var base64data = "base64," + $.base64.encode(tdData);
        var filename = jQuery.now() + '.' + defaults.type;
        downloadURI(filename, defaults, base64data);


      } else if (defaults.type == 'sql') {

        // Header
        var tdData = "INSERT INTO `" + defaults.tableName + "` (";
        $(el).find('thead').find('tr').each(function () {

          $(this).filter(':visible').find('th').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                tdData += '`' + parseString($(this)) + '`,';
              }
            }

          });
          tdData = $.trim(tdData);
          tdData = $.trim(tdData).substring(0, tdData.length - 1);
        });
        tdData += ") VALUES ";
        // Row vs Column
        $(el).find('tbody').find('tr').each(function () {
          tdData += "(";
          $(this).filter(':visible').find('td').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                tdData += '"' + parseString($(this)) + '",';
              }
            }
          });

          tdData = $.trim(tdData).substring(0, tdData.length - 1);
          tdData += "),";
        });
        tdData = $.trim(tdData).substring(0, tdData.length - 1);
        tdData += ";";

        //output
        //console.log(tdData);

        if (defaults.consoleLog == 'true') {
          console.log(tdData);
        }

        /*
        ORIGINAL
        var base64data = "base64," + $.base64.encode(tdData);
        window.open('data:application/sql;filename=exportData;' + base64data);*/

        var base64data = "base64," + $.base64.encode(tdData);
        var filename = jQuery.now() + '.' + defaults.type;
        downloadURI(filename, defaults, base64data);


      } else if (defaults.type == 'json') {

        var jsonHeaderArray = [];
        $(el).find('thead').find('tr').each(function () {
          var tdData = "";
          var jsonArrayTd = [];

          $(this).filter(':visible').find('th').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                jsonArrayTd.push(parseString($(this)));
              }
            }
          });
          jsonHeaderArray.push(jsonArrayTd);

        });

        var jsonArray = [];
        $(el).find('tbody').find('tr').each(function () {
          var tdData = "";
          var jsonArrayTd = [];

          $(this).filter(':visible').find('td').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                jsonArrayTd.push(parseString($(this)));
              }
            }
          });
          jsonArray.push(jsonArrayTd);

        });

        var jsonExportArray = [];
        jsonExportArray.push({ header: jsonHeaderArray, data: jsonArray });

        //Return as JSON
        //console.log(JSON.stringify(jsonExportArray));

        //Return as Array
        //console.log(jsonExportArray);
        if (defaults.consoleLog == 'true') {
          console.log(JSON.stringify(jsonExportArray));
        }
        /* ORIGINAL
                
        var base64data = "base64," + $.base64.encode(JSON.stringify(jsonExportArray));
        window.open('data:application/json;filename=exportData;' + base64data);*/

        var base64data = "base64," + $.base64.encode(JSON.stringify(jsonExportArray));
        var filename = jQuery.now() + '.' + defaults.type;
        downloadURI(filename, defaults, base64data);


      } else if (defaults.type == 'xml') {

        var xml = '<?xml version="1.0" encoding="utf-8"?>';
        xml += '<tabledata><fields>';

        // Header
        $(el).find('thead').find('tr').each(function () {
          $(this).filter(':visible').find('th').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                xml += "<field>" + parseString($(this)) + "</field>";
              }
            }
          });
        });
        xml += '</fields><data>';

        // Row Vs Column
        var rowCount = 1;
        $(el).find('tbody').find('tr').each(function () {
          xml += '<row id="' + rowCount + '">';
          var colCount = 0;
          $(this).filter(':visible').find('td').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                xml += "<column-" + colCount + ">" + parseString($(this)) + "</column-" + colCount + ">";
              }
            }
            colCount++;
          });
          rowCount++;
          xml += '</row>';
        });
        xml += '</data></tabledata>'

        if (defaults.consoleLog == 'true') {
          console.log(xml);
        }

        /* ORIGINAL
                
        var base64data = "base64," + $.base64.encode(xml);
        window.open('data:application/xml;filename=exportData;' + base64data);*/

        var base64data = "base64," + $.base64.encode(xml);
        var filename = jQuery.now() + '.' + defaults.type;
        downloadURI(filename, defaults, base64data);


      } else if (defaults.type == 'excel' || defaults.type == 'doc' || defaults.type == 'powerpoint') {
        //console.log($(this).html());
        var excel = "<table>";
        // Header
        $(el).find('thead').find('tr').each(function () {
          excel += "<tr>";
          $(this).find('.jscroll-th').each(function (index, data) {
            if (($(this).css('display') != "none") && (defaults.ignoreColumn.indexOf(index) == -1) && ($(this).attr('is-text') == 'true')) {
              excel += "<td>" + parseString($(this)) + "</td>";
            }
          });
          excel += '</tr>';
        });

        // Row Vs Column
        var rowCount = 1;
        $(el).find('tbody').find('.jscroll-tr').each(function () {
          excel += "<tr>";
          var colCount = 0;
          $(this).find('.jscroll-td').each(function (index, data) {
            if (($(this).css('display') != "none") && (defaults.ignoreColumn.indexOf(index) == -1) && ($(this).attr('is-text') == 'true')) {
              excel += "<td>" + parseString($(this)) + "</td>";
            }
            colCount++;
          });
          rowCount++;
          excel += '</tr>';
        });
        excel += '</table>'

        if (defaults.consoleLog == 'true') {
          console.log(excel);
        }

        var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:" + defaults.type + "' xmlns='http://www.w3.org/TR/REC-html40'>";
        excelFile += "<head>";
        excelFile += "<!--[if gte mso 9]>";
        excelFile += "<xml>";
        excelFile += "<x:ExcelWorkbook>";
        excelFile += "<x:ExcelWorksheets>";
        excelFile += "<x:ExcelWorksheet>";
        excelFile += "<x:Name>";
        excelFile += "{worksheet}";
        excelFile += "</x:Name>";
        excelFile += "<x:WorksheetOptions>";
        excelFile += "<x:DisplayGridlines/>";
        excelFile += "</x:WorksheetOptions>";
        excelFile += "</x:ExcelWorksheet>";
        excelFile += "</x:ExcelWorksheets>";
        excelFile += "</x:ExcelWorkbook>";
        excelFile += "</xml>";
        excelFile += "<![endif]-->";
        excelFile += "</head>";
        excelFile += "<body>";
        excelFile += excel;
        excelFile += "</body>";
        excelFile += "</html>";

        //window.open('data:application/vnd.ms-' + defaults.type + ';filename=exportData.doc;' + base64data);
        var downloadMSURI = function downloadMSURI(name, defaults, base64data) {

          var link = document.createElement("a");
          link.download = name;
          link.href = 'data:application/vnd.ms-' + defaults.type + ';' + base64data;

          // For firefox
          document.body.appendChild(link);
          
          link.click();

          // For firefox
          link.remove();
        };

        var base64data = "base64," + $.base64.encode(excelFile);
        var filename = jQuery.now() + '.xls';
        downloadMSURI(filename, defaults, base64data);


      } else if (defaults.type == 'png') {
        html2canvas($(el), {
          onrendered: function (canvas) {
            var img = canvas.toDataURL("image/png");
            window.open(img);


          }
        });
      } else if (defaults.type == 'pdf') {

        var doc = new jsPDF('p', 'pt', 'a4', true);
        doc.setFontSize(defaults.pdfFontSize);

        // Header
        var startColPosition = defaults.pdfLeftMargin;

        // Column Width
        var columnWidth = 0;

        $(el).find('thead').find('tr').each(function () {
          var colNum = $(this).filter(':visible').find('th').length;
          // Obtiene cantidad de columnas.
          $(this).filter(':visible').find('th').each(function (index, data) {
            //colNum;
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) != -1)
                colNum--;
              if ($(this).find("input")[0] != null) {
                colNum--;
                defaults.ignoreColumn.push(index);
              }
            }
            else
              colNum--;
          });

          // Establece los títulos.
          columnWidth = Math.round((210 - startColPosition) / colNum);
          var pos = 0;
          $(this).filter(':visible').find('th').each(function (index, data) {
            //colNum;
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                var colPosition = startColPosition + (pos * columnWidth);
                doc.text(colPosition, 20, parseString($(this)));
                pos++;
              }
              else
                colNum--;
            }
            else
              colNum--;
          });
        });

        // Row Vs Column
        doc.setFontSize(defaults.pdfFontSize - 2);
        var startRowPosition = 20; var page = 1; var rowPosition = 0;
        $(el).find('tbody').find('tr').each(function (index, data) {
          rowCalc = index + 1;
          if (rowCalc % 26 == 0) {
            doc.addPage(); page++; startRowPosition = startRowPosition + 10;
          }
          rowPosition = (startRowPosition + (rowCalc * 10)) - ((page - 1) * 280);
          var pos = 0;
          $(this).filter(':visible').find('td').each(function (index, data) {
            if ($(this).css('display') != 'none') {
              if (defaults.ignoreColumn.indexOf(index) == -1) {
                var colPosition = startColPosition + (pos * columnWidth);
                var columnWidthReal = columnWidth / 2;
                if (parseString($(this)).length > columnWidthReal) {
                  var columnValues = parseString($(this)).match(new RegExp('.{1,' + Math.round(columnWidthReal) + '}', 'g'));
                  doc.text(colPosition, rowPosition, columnValues[0]);
                  pos++;
                }
                else {
                  doc.text(colPosition, rowPosition, parseString($(this)));
                  pos++;
                }
              }
            }
          });
        });
        // Output as Data URI
        // doc.output('datauri');
        var download = new Object();
        download.filename = jQuery.now() + '.pdf';
        doc.output('datauri', download);
      }

      function parseString(data) {
        if (defaults.htmlContent == 'true')
          content_data = data.html().trim();
        else
          content_data = data.text().trim();
        if (defaults.escape == 'true')
          content_data = escape(content_data);
        return content_data;
      }
    }
  });
})(jQuery);
        
