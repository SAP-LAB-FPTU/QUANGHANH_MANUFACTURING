$('input.autocomplete_MNV').autocomplete({
    data: {
        "2179-Nguyễn Xuân Thoàng": null,
        "7751-Nguyễn Văn Hùng": null,
        "3506-Nguyễn Văn Hùng": null,
        "2041-Nguyễn Văn Hưng": null,
        "4472-Nguyễn Văn Hoa": null,
        "7430-Đông Văn Đai": null,
        "7564-Nguyễn Văn Sơn": null,
        "7598-Đăng Tung": null,
        "5132-Lệnh Văn Hương": null,
        "3352-Phạm Văn Phú": null,
        "6771-Nguyễn Hữu Thinh": null,
        "7962-Nguyễn Tiền Nhật": null,
        "1674-Nguyễn Văn Hùng": null,
        "4075-Trần Văn Thương": null,
        "8742-Vũ Ba Chơ": null,
        "8747-Vũ Tiến Đạt": null,
        "4475-Nguyễn Văn Hợp": null,
        "615-Ban Văn Nghị": null,
        "5229-Nguyễn Quang Chinh": null,
        "5445-Nguyễn Duy Hiệp": null,
        "8111-Hoang Văn Tinh": null,
        "2126-Nguyễn Đức Tạo": null,
        "4775-Lục Văn Nhay": null,
        "7834-Đỗ Văn Chinh": null,
        "2005-Nguyễn Văn Bầy": null,
        "2080-Nguyễn Văn Trai": null,
        "5213-Lê Ánh Ngọc": null,
        "7494-Trần Trọng Thi": null,
        "4789-Nguyễn Văn Thư": null
    },
});

$('input.autocomplete_Name').autocomplete({
    data: {
        "Nguyễn Xuân Thoàng": null,
        "Nguyễn Văn Hùng": null,
        "Nguyễn Văn Hùng": null,
        "Nguyễn Văn Hưng": null,
        "Nguyễn Văn Hoa": null,
        "Đông Văn Đai": null,
        "Nguyễn Văn Sơn": null,
        "Đăng Tung": null,
        "Lệnh Văn Hương": null,
        "Phạm Văn Phú": null,
        "Nguyễn Hữu Thinh": null,
        "Nguyễn Tiền Nhật": null,
        "Nguyễn Văn Hùng": null,
        "Trần Văn Thương": null,
        "Vũ Ba Chơ": null,
        "Vũ Tiến Đạt": null,
        "Nguyễn Văn Hợp": null,
        "Ban Văn Nghị": null,
        "Nguyễn Quang Chinh": null,
        "Nguyễn Duy Hiệp": null,
        "Hoang Văn Tinh": null,
        "Nguyễn Đức Tạo": null,
        "Lục Văn Nhay": null,
        "Đỗ Văn Chinh": null,
        "Nguyễn Văn Bầy": null,
        "Nguyễn Văn Trai": null,
        "Lê Ánh Ngọc": null,
        "Trần Trọng Thi": null,
        "Nguyễn Văn Thư": null,
    },
})

$("input.autocomplete_MNV").change(function () {
     var name = $('input.autocomplete_MNV').val();
     var strName = name.split('-');
    $("input.autocomplete_MNV").val(strName[0]);
    $("input.autocomplete_Name").val(strName[1]);
})

/*function fixSizeInput() {
    if ($(window).width() > 1050) {
        $("#fixSize_Name").html('<input type="text" placeholder="Tìm kiếm theo tên nhân viên" class="form-control autocomplete_Name" id="searchArea fixSize_Name" style="width:1711111111111px!important" multiple />');
        $("#gender").html('style = "margin-left: 23px !important;width: 127px !important;"');
    }
}
fixSizeInput();
*/
