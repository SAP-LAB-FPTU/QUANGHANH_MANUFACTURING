// 0 is watch by month
// 1 is watch by day
var StateSelected = 0;
// 0 for all departments
var DepartmentSelected = 0; 

function urlDetection(url) {    

}


$(window).ready(() => {
    var url = window.location.href;
    $("a.dropdown-child-px").click(function () {
        select = $(this).attr("name");
        if (select == 'All') {
            $("#px").html("Tất cả");
            DepartmentSelected = 0;
        } else {
            DepartmentSelected = 1;
        }
        //
        if (select == 'DL3') {
            $("#px").html("Đào lò 3");
        }
        if (select == 'DL5') {
            $("#px").html("Đào lò 5");
        }
        if (select == 'DL7') {
            $("#px").html("Đào lò 7");
        }
        if (select == 'DL8') {
            $("#px").html("Đào lò 8");
        }
        if (select == 'KT1') {
            $("#px").html("Khai thác 1");
        }
        if (select == 'KT2') {
            $("#px").html("Khai thác 2");
        }
        if (select == 'KT3') {
            $("#px").html("Khai thác 3");
        }
        if (select == 'KT4') {
            $("#px").html("Khai thác 4");
        }
        if (select == 'KT5') {
            $("#px").html("Khai thác 5");
        }
        if (select == 'KT6') {
            $("#px").html("Khai thác 6");
        }
        if (select == 'KT7') {
            $("#px").html("Khai thác 7");
        }
        if (select == 'KT8') {
            $("#px").html("Khai thác 8");
        }
        if (select == 'KT9') {
            $("#px").html("Khai thác 9");
        }
        if (select == 'KT10') {
            $("#px").html("Khai thác 10");
        }
        if (select == 'KT11') {
            $("#px").html("Khai thác 11");
        }
        if (select == 'VTL1') {
            $("#px").html("Vận tải 1");
        }
        if (select == 'VTL2') {
            $("#px").html("Vận tải 2");
        }
        //if (select2 == 'day' && select == 'VTL1') {
        //    $('a').attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay');
        //}
        //if (select2 == 'month' && select == 'VTL1') {
        //    $('a').attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-ngay-trong-thang');
        //}
        //if (select2 == 'month' && select == 'All') {
        //    $('a').attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-thang');
        //}
        $('.dropdown-trigger').dropdown('close');
    });
    //
    $("a.dropdown-child-time").click(function () {
        select2 = $(this).attr("name");
        if (select2 == 'day') {
            $("#time").html("Xem theo ngày");
            StateSelected = 1;
        }
        if (select2 == 'month') {
            $("#time").html("Xem theo tháng");

        }
        if (StateSelected == 0) {
            // if department is all then load all else load mothly vtl1
            if (DepartmentSelected == 0) {
                $("a.dropdown-child-time").attr('href','/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-thang')
            } else {
                $("a.dropdown-child-time").attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-ngay-trong-thang')
            }
        } else {
            // 
            if (DepartmentSelected == 0) {
                $("a.dropdown-child-time").attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay')
            } else {
                $("a.dropdown-child-time").attr('href', '/phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay-vtl1')
            }
        }
        $('.dropdown-trigger').dropdown('close');
    });
})