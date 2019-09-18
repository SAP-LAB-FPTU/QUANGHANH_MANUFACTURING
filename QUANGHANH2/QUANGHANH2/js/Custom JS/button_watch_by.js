var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;
var select;
var select1;
var select2;
var selectOld;
var select2Old;
var selectCa;
var selectCaOld;
var elem;
var instance;
$(document).ready(function () {
    selectOld = $("#px").attr("name");
    select2Old = $("#thoigian").attr("name");
    select = $("#px").attr("name");
    select2 = $("#thoigian").attr("name");
    selectCaOld = $("#ca").attr("name");
    selectCa = $("#ca").attr("name");

    elem = document.querySelector('.dropdown-trigger');
    instance = M.Dropdown.getInstance(elem);

    $("#dropdown_ca").on("click", ".dropdown-child-ca", function () {
        selectCa = $(this).attr("name");

        if (selectCa == "ca1") {
            $("#ca").html("CA 1");
            $("#ca").attr("name", "ca1");
        }
        if (selectCa == "ca2") {
            $("#ca").html("CA 2");
            $("#ca").attr("name", "ca2");
        }
        if (selectCa == "ca3") {
            $("#ca").html("CA 3");
            $("#ca").attr("name", "ca3");
        }

        $('.dropdown-trigger').dropdown('close');
    });

    $("#dropdown_px").on("click", ".dropdown-child-px", function () {
        select = $(this).attr("name");

        if (select == 'All') {
            $("#px").html("Tất cả");
            $("#px").attr("name", "All");
        }
        if (select == 'DL3') {
            $("#px").html("Đào lò 3");
            $("#px").attr("name", "DL3");
        }
        if (select == 'DL5') {
            $("#px").html("Đào lò 5");
            $("#px").attr("name", "DL5");
        }
        if (select == 'DL7') {
            $("#px").html("Đào lò 7");
            $("#px").attr("name", "DL7");
        }
        if (select == 'DL8') {
            $("#px").html("Đào lò 8");
            $("#px").attr("name", "DL8");
        }
        if (select == 'KT1') {
            $("#px").html("Khai thác 1");
            $("#px").attr("name", "KT1");
        }
        if (select == 'KT2') {
            $("#px").html("Khai thác 2");
            $("#px").attr("name", "KT2");
        }
        if (select == 'KT3') {
            $("#px").html("Khai thác 3");
            $("#px").attr("name", "KT3");
        }
        if (select == 'KT4') {
            $("#px").html("Khai thác 4");
            $("#px").attr("name", "KT4");
        }
        if (select == 'KT5') {
            $("#px").html("Khai thác 5");
            $("#px").attr("name", "KT5");
        }
        if (select == 'KT6') {
            $("#px").html("Khai thác 6");
            $("#px").attr("name", "KT6");
        }
        if (select == 'KT7') {
            $("#px").html("Khai thác 7");
            $("#px").attr("name", "KT7");
        }
        if (select == 'KT8') {
            $("#px").html("Khai thác 8");
            $("#px").attr("name", "KT8");
        }
        if (select == 'KT9') {
            $("#px").html("Khai thác 9");
            $("#px").attr("name", "KT9");
        }
        if (select == 'KT10') {
            $("#px").html("Khai thác 10");
            $("#px").attr("name", "KT10");
        }
        if (select == 'KT11') {
            $("#px").html("Khai thác 11");
            $("#px").attr("name", "KT11");
        }
        if (select == 'VTL1') {
            $("#px").html("Vận tải 1");
            $("#px").attr("name", "VTL1");
        }
        if (select == 'VTL2') {
            $("#px").html("Vận tải 2");
            $("#px").attr("name", "VTL2");
        }

        $('.dropdown-trigger').dropdown('close');
    });

    $("#dropdown_time").on("click", ".dropdown-child-time", function () {
        select2 = $(this).attr("name");

        if (select2 == 'day') {
            $("#thoigian").html("Xem theo ngày");
            $("#thoigian").attr("name", "day");
        }
        if (select2 == 'month') {
            $("#thoigian").html("Xem theo tháng");
            $("#thoigian").attr("name", "month");
        }
        $('.dropdown-trigger').dropdown('close');
    });

    //Xac nhan xem theo 2 options da chon
    $("#xacnhan").click(function () {

        if (select == selectOld && select2 == select2Old && selectCa == selectCaOld) {

        } else {

            if (select2 == 'day' && select == 'VTL1') {
                var url = $("#loader-chi-tiet-vtl1-trong-ngay").data('request-url');
                $('a').attr('href', url);
            }
            if (selectCa == "ca1") {
                var url = $("#loader-chi-tiet-ca1-vtl1-trong-ngay").data('request-url');
                $('a').attr('href', url);
            }
            if (selectCa == "ca2") {
                var url = $("#loader-chi-tiet-ca2-vtl1-trong-ngay").data('request-url');
                $('a').attr('href', url);
            }
            if (selectCa == "ca3") {
                var url = $("#loader-chi-tiet-ca3-vtl3-trong-ngay").data('request-url');
                $('a').attr('href', url);
            }
            if (select2 == 'day' && select == 'All') {
                var url = $("#loader-cac-px-trong-ngay").data('request-url');
                $('a').attr('href', url);
            }
            if (select2 == 'month' && select == 'VTL1') {
                var url = $("#loader-cac-ngay-trong-thang-vtl1").data('request-url');
                $('a').attr('href', url);
            }
            if (select2 == 'month' && select == 'All') {
                var url = $("#loader-cac-px-trong-thang").data('request-url');
                $('a').attr('href', url);
            }

        }
    });
});
