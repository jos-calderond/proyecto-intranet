$.datepicker.regional['es'] = {
  closeText: 'Cerrar',
  prevText: '< Ant',
  nextText: 'Sig >',
  currentText: 'Hoy',
  monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
  monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
  dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
  dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Juv', 'Vie', 'Sab'],
  dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
  weekHeader: 'Sm',
  dateFormat: 'dd/mm/yy',
  firstDay: 1,
  isRTL: false,
  showMonthAfterYear: false,
  yearSuffix: ''
};

$.datepicker.setDefaults($.datepicker.regional['es']);

$(function () {
  $('#menu').metisMenu();
  $('#menu').show();
});

$(document).ready(function () {
  $(document).everyTime("60000", function () {
    $.ajax({
      url: '../acciones/actSession.aspx',
      success: function (data) {
        if (data == "NOK") {
          $('#modalFinSesion').modal('show');
          $('#modalFinSesion').on('hidden.bs.modal', function () {
            window.location = ('../Default.aspx');
          });
        }
      }
    });
  });
});

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
  if (document.getElementById("myBtn") == null || document.getElementById("myBtn2") == null) return false;
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    document.getElementById("myBtn").style.display = "block";
    document.getElementById("myBtn2").style.display = "none";
  } else {
    document.getElementById("myBtn").style.display = "none";
    document.getElementById("myBtn2").style.display = "block";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  //  e.preventDefault();
  document.body.scrollTop = 0; // For Safari
  document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
  return false;
}

// When the user clicks on the button, scroll to the top of the document
function bottomFunction() {
  //  e.preventDefault();
  document.body.scrollTop = document.body.scrollHeight * 3; // For Safari
  document.documentElement.scrollTop = document.body.scrollHeight * 3; // For Chrome, Firefox, IE and Opera
  return false;
}