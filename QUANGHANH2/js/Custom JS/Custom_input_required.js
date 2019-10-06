$(document).ready(function () {
    $('input[required]').each(function myfunction() {
        $(this).attr("oninvalid", "setCustomValidity('Không được bỏ trống ô này')");
        $(this).attr("oninput", "this.setCustomValidity('')");
    })
})