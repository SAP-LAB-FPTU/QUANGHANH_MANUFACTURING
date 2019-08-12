
$(document).ready(function() {
  // var panelOne = $('.form-panel.two').height(),
  //   panelTwo = $('.form-panel.two')[0].scrollHeight;

  // $('.form-panel.two').not('.form-panel.two.active').on('click', function(e) {
  //   e.preventDefault();

  //   $('.form-toggle').addClass('visible');
  //   $('.form-panel.one').addClass('hidden');
  //   $('.form-panel.two').addClass('active');
  //   $('.form').animate({
  //     'height': panelTwo
  //   }, 200);
  // });

  // $('.form-toggle').on('click', function(e) {
  //   e.preventDefault();
  //   $(this).removeClass('visible');
  //   $('.form-panel.one').removeClass('hidden');
  //   $('.form-panel.two').removeClass('active');
  //   $('.form').animate({
  //     'height': panelOne
  //   }, 200);
  // });

    $('#loginButton').click(() => {
        var e = document.getElementById("ddlViewBy");
        var strUser = e.options[e.selectedIndex].value;
        var url      = window.location.href;
        var re = /[0-9]+/
        var host = url.match(re)
        $('#loginButton').attr('href', 'https://localhost:'+host[0]+strUser);
    });
});



