// $(document).ready(function () {
//     $('#loginButton').click(() => {
//         //var url = "https://localhost:5001/Login#";
//         var url = window.location.href;
//         //var url = "http://103.28.36.119/plesk-site-preview/www.thanquanghanh.com.vn/?fbclid=IwAR3zsj8yh5rJMu6Obx-qHqkWFLf5zWPMNzjm4mbLAvEC3DJr68ItaLyZkXc"
//         var host = url.split(/[/#]+/)
//         console.log(host)
//         if (host[host.length - 1].length === 0) {
//             host = host.slice(0, host.length - 1)
//         }
//         if (host[host.length - 1].endsWith('Login')) {
//             host = host.slice(0, host.length - 1)
//         }
//         if (host[host.length - 1].endsWith('#')) {
//             host = host.slice(0, host.length - 1)
//         }
//         if (host[host.length - 1].startsWith('?fbclid')) {
//             host = host.slice(0, host.length - 1)
//         }
//         var link = host[0] + "//" + host[1];
//         for (let i = 2; i <= host.length - 1; i++) {
//             if (host[i].length > 0) {
//                 link += '/' + host[i];
//             }
//         }

//         var username = $('#username').val();
//         var password = $('#password').val();

//         // $('#loginButton').attr('href', '#');
//         myFunction();

//     });

//     document.getElementById("login-form").addEventListener("submit", myFunction);

//     function myFunction() {
//         var username = $('#username').val();
//         switch (username) {
//             case 'tcld':
//                 window.location.href = link + '/phong-tcld';
//                 break;
//             case 'dk':
//                 window.location.href = link + '/phong-dieu-khien';
//                 break;
//             case 'cdvt':
//                 window.location.href = link + '/phong-cdvt';
//                 break;
//             case 'kcs':
//                 window.location.href = link + '/phong-kcs';
//                 break;
//             case 'pxkt':
//                 window.location.href =link + '/phan-xuong-khai-thac';
//                 break;
//             case 'bgd':
//                 window.location.href = link + '/ban-giam-doc';
//                 break;
//             default:
//                 window.location.href = link + '/phong-tcld';
//         }
//     }
// });

(function ($) {
    "use strict";

    var input = $('.validate-input .input100');

    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input) {
        var username = $('#username').val();
        var password = $('#password').val();
        if (username == "" && password == "") {
            document.getElementById("Notification").innerText = "Vui lòng nhập tên đăng nhập và mật khẩu!"
        }else
        if (username == "") {
            document.getElementById("Notification").innerText = "Vui lòng nhập tên đăng nhập!"
        }else
        if (password == "") {
            document.getElementById("Notification").innerText = "Vui lòng nhập mật khẩu!"
        }
        
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }


    var url = window.location.href;
    //var url = "http://103.28.36.119/plesk-site-preview/www.thanquanghanh.com.vn/?fbclid=IwAR3zsj8yh5rJMu6Obx-qHqkWFLf5zWPMNzjm4mbLAvEC3DJr68ItaLyZkXc"
    var host = url.split(/[/#]+/)
    console.log(host)
    if (host[host.length - 1].length === 0) {
        host = host.slice(0, host.length - 1)
    }
    if (host[host.length - 1].endsWith('Login')) {
        host = host.slice(0, host.length - 1)
    }
    if (host[host.length - 1].endsWith('#')) {
        host = host.slice(0, host.length - 1)
    }
    if (host[host.length - 1].startsWith('?fbclid')) {
        host = host.slice(0, host.length - 1)
    }
    var link = host[0] + "//" + host[1];
    for (let i = 2; i <= host.length - 1; i++) {
        if (host[i].length > 0) {
            link += '/' + host[i];
        }
    }

    

    //document.getElementById("login-form").addEventListener("submit", myFunction);
    //function myFunction() {
    //    var username = $('#username').val();
    //    switch (username) {
    //        case 'tcld':
    //            window.location.href = link + '/phong-tcld';
    //            break;
    //        case 'dk':
    //            window.location.href = link + '/phong-dieu-khien';
    //            break;
    //        case 'cdvt':
    //            window.location.href = link + '/phong-cdvt';
    //            break;
    //        case 'kcs':
    //            window.location.href = link + '/phong-kcs';
    //            break;
    //        case 'pxkt':
    //            window.location.href = link + '/phan-xuong-khai-thac';
    //            break;
    //        case 'bgd':
    //            window.location.href = link + '/ban-giam-doc';
    //            break;
    //        case 'longcdvt':
    //            window.location.href = link + '/phong-cdvt/long/oto/huy-dong';
    //            break;
    //        case 'px':
    //            window.location.href = link + '/phan-xuong';
    //            break;
    //        case 'hoc_tcld':
    //            window.location.href = link + '/phong-tcld/nguyenvanhoc/?mnv=hq234';
    //            break;
    //        case 'long_tcld':
    //            window.location.href = link + '/phong-tcld/nguyenvanlong/?mnv=sd223';
    //            break;
    //        case 'vuong_tcld':
    //            window.location.href = link + '/phong-tcld/nguyenbavuong/?mnv=lk523';
    //            break;
    //        case 'hoa_tcld':
    //            window.location.href = link + '/phong-tcld/nguyenthihoa/?mnv=rt953';
    //            break;
    //        default:
    //            window.location.href = link + '/phong-tcld';
    //    }
    //}
})(jQuery);