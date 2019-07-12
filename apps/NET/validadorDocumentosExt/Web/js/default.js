
$(document).ready(function () {

  $(document).ajaxStart(function () { $.LoadingOverlay("show"); }); $(document).ajaxStop(function () { $.LoadingOverlay("hide"); });

  $("#aspnetForm").validate({ highlight: function (element) { $(element).closest('.form-group').addClass('has-error'); }, unhighlight: function (element) { $(element).closest('.form-group').removeClass('has-error'); }, errorClass: 'help-block' });
 
});

   