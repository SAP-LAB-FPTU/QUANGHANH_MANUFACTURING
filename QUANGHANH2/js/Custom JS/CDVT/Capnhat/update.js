$(document).ready(function () {
    $("#xacnhan").click(function () {
        sessionStorage.setItem('xn','xn');
    });
    if (sessionStorage.getItem('xn') == 'xn') {
        $("#conf").html("Đã xử lí xong");
    }
});