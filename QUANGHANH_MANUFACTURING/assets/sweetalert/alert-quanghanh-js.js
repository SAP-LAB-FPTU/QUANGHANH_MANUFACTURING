    
    function successAlert(title,text){
        Swal.fire({
            title: title,
            text: text,
            type: 'success',
            confirmButtonText: 'Đóng'
        })
    }
   
    function errorAlert(title,text) {
        Swal.fire({
            title: title,
            text: text,
            type: 'error',
            confirmButtonText: 'Đóng'
        })
    };

    function reloadAlert(title,timer) {
        let timerInterval
        Swal.fire({
            title: title,
            html: 'Đang tải lại trang',
            type: 'success',
            timer: timer,//cài đặt thời gian chuyển trang mili giây
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
                timerInterval = setInterval(() => {
                    Swal.getContent().querySelector('strong')
                        .textContent = Swal.getTimerLeft()
                }, 100)
            },
            onClose: () => {
                    location.reload();
            }
        }).then((result) => {
            if (
                result.dismiss === Swal.DismissReason.timer
            ) {
                location.reload();
            }
        })
    }

    function redirectAlert(title,url) {
        let timerInterval
        Swal.fire({
            title: title,
            html: 'Đang chuyển trang',
            type: 'success',
            timer: 3000,//cài đặt thời gian chuyển trang mili giây
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
                timerInterval = setInterval(() => {
                }, 100)
            },
            onClose: () => {
                    window.location.href=url;
            }
        }).then((result) => {
            window.location.href=url;
        })
    }

    function confirmAlert(title,text,func) {
        var a= Swal.fire({
            title: title,
            text: text,
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d63ab616',
            cancelButtonColor: '#979993',
            cancelButtonText: 'Hủy',
            confirmButtonText: 'Đồng ý'
        }).then((result) => {
            if (result.value) {
               func();
            }else{
               
            }
        });
    }

function submitSingle(title, confirmButtonText, func) {
    Swal.fire({
        title: title,
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: confirmButtonText,
        showLoaderOnConfirm: true,
        preConfirm: (info) => {
            if (info.trim() === "") {
                Swal.showValidationMessage(
                    `Lỗi: hãy kiểm tra lại thông tin`
                )
            }
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        //alert(result.value);
        if (result.value.trim() !== "") {
            func(result.value);
        }
    })
}
    