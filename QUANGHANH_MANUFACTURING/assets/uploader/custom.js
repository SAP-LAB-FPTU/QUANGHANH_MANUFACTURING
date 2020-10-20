//Create by TUANKQ
Dropzone.options.myAwesomeDropzone = {
    paramName: "file", // The name that will be used to transfer the file
    maxFilesize: 2, // MB
    addRemoveLinks: true,
    dictRemoveFile: 'Hủy',
    clickable: true,
    acceptedFiles: 'application/xls,.xlsx',
    maxFiles: '1',
    uploadMultiple: false,
    parallelUploads: 1,
    init: function () {
        this.on("addedfile", function () {
            if (this.files[1] != null) {
                this.removeFile(this.files[0]);
            }
        });
        var myDropzone = this;
        // Update selector to match your button
        $("#btnUpload").click(function (e) {
            e.preventDefault();
            myDropzone.processQueue();
        });
        //this.on("processing", function (file) {
           
        //});
        this.on('sending', function (file, xhr, formData) {
                //append file to formdata
                formData.append("file", file);
                //show pre-loader
                $("#pre-load").show("slow", function () {
                });
                //set timeout for processing
            //close modal
            $("#modal1").modal('close');
            //clear in queue
            myDropzone.removeFile(file);
            //ajax process
            $.ajax({
                type: "POST",
                url: "/phong-kcs/importKCS",
                statusCode: {
                    404: function (responseObject, textStatus, jqXHR) {
                        toastr.warning('Lỗi!', 'Hệ thống');
                    },
                    503: function (responseObject, textStatus, errorThrown) {
                        toastr.warning('Lỗi mạng!', 'Hệ thống');
                    }
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (!data.success) {
                        toastr.warning(data.message, 'Hệ thống');
                    } else {
                        var i = 0;
                        var j = 0;
                        for (var i = 0; i < 23; i++) {
                            $(".editable").eq(j++).text(data.list[i].tondauki_sl);
                            $(".editable").eq(j++).text(data.list[i].tondauki_ak);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_thansx_sl);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_thansx_percent);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_thansx_ak);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_noibo_sl);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_noibo_ak);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_phatron_sl);
                            $(".editable").eq(j++).text(data.list[i].nhaptrongki_phatron_ak);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_tieuthu_sl);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_tieuthu_ak);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_noibo_sl);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_noibo_ak);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_phatron_sl);
                            $(".editable").eq(j++).text(data.list[i].xuattrongki_phatron_ak);
                            $(".editable").eq(j++).text(data.list[i].toncuoiki_sl);
                            $(".editable").eq(j++).text(data.list[i].toncuoiki_ak);
                        }
                         //show toast
                        toastr.success('Upload thành công!', 'Hệ thống');
                    }
                },
                error: function (data) {
                    //$('#dvData').html(e.responseText);
                    toastr.warning('Lỗi!', 'Hệ thống'+data);
                }
            }).done(function () {
                //hide pre-loader
                $("#pre-load").hide("slow", function () {
                });
            });
        });
    },
    dictResponseError: "Lỗi (Code: {{statusCode}})",
    dictFileTooBig: "Kích cỡ file quá lớn ({{filesize}}MB). Kích cỡ file tối đa: {{maxFilesize}}MB ",
    dictInvalidFileType: "File không hợp lệ. Hãy chọn một file Excel (xls, xlsx)",
    autoProcessQueue: false,
};
