var id;
$(document).on("click", ".open-UpdateModal", function () {
    id = $(this).data('documentary-id').toString();
    $('#reason_edit').val($(this).closest('tr').children().eq(4).text());
    $('#out_in_come_edit').val($(this).closest('tr').children().eq(5).text());
});

$("#myupdateform").submit(function (e) {
    $("#pre-load").show();
    $.ajax({
        type: "POST",
        url: "/phong-cdvt/quyet-dinh/update",
        dataType: "json",
        success: function (data) {
            if (data.success == true) {
                dataTable.ajax.reload();
                successAlert('Cập nhật quyết định thành công', '');
            }
            else {
                errorAlert('Lỗi', data.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $('#pre-load').hide();

            errorAlert('Lỗi', XMLHttpRequest.responseText);
        },
        data: {
            documentary_id: id,
            documentary_code: $('#documentary_code_edit').val(),
            reason: $('#reason_edit').val(),
            out_in_come: $('#out_in_come_edit').val()
        },
        cache: false
    }).done(function () {
        $('#pre-load').hide();
        $('#exit-update-button').click();
    })
    return false;
});

$("#Delete").click(function () {
    $("#pre-load").show();
    $.ajax({
        type: "POST",
        url: '/phong-cdvt/quyet-dinh/delete',
        data: {
            documentary_id: id
        },
        dataType: "json",
        success: function (data) {
            if (data.success == true) {
                dataTable.ajax.reload();
                successAlert(data.message);
                $('#exit-update-button').click();
            }
            else {
                errorAlert(data.message);
            }
            $("#pre-load").hide();
        },
        cache: false
    });
});