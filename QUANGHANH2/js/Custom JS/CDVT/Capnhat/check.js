$(document).on("click", "#complex_header tbody tr", function () {
    var DaXuLy = $("#complex_header tbody tr:nth-child(" + ($(this).index() + 1) + ") td:last-child button").prop("disabled");
    if (!DaXuLy) {
        $('#vattu').html("<a id='addcolumn' class='waves-effect waves-light btn blue darken-2 left'>Thêm</a><a id='submitvattu' class='waves-effect waves-light btn blue darken-2 modal-trigger'>Lưu</a><button class='btn light-blue lighten-1 modal-close' id='exit-button'>Thoát</button>");
        $('#vattu2').html("<a id='submitvattu' class='waves-effect waves-light btn blue darken-2 modal-trigger'>Lưu</a><button class='btn light-blue lighten-1 modal-close' id='exit-button'>Thoát</button>");
    }
    else {
        $('#vattu').html("<a class='btn light-blue lighten-1 modal-close' id='exit-button'>Thoát</a>");
        $('#vattu2').html("<a class='btn light-blue lighten-1 modal-close' id='exit-button'>Thoát</a>");
    }
})

$("#complex_header").on("click", ".buttonChon", function () {
    if ($(this).text() == "Chưa xử lý") {
        $(this).text('Đã xử lý')
    }
    else {
        $(this).text('Chưa xử lý')
    }
});