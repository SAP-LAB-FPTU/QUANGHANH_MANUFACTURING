$('.minDate').datepicker({
    language: 'vi',
    minDate: new Date() // Now can select only dates, which goes after today
})

$(document).ready(function () {
    $('.datepicker-inline').remove();
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var today = dd + '/' + mm + '/' + yyyy;
    $(".minDate").each(function () {
        $(this).val(today);
    });
})