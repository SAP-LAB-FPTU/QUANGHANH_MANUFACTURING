var rowcount = 1;

$(document).ready(function () {
    $('.btnSelect').click(function () {
        var data = document.getElementById("table-gd").rows.length;
        document.getElementById("table-gd").deleteRow(data - 1);
        rowcount--;
    });
    $('.btnSelect1').click(function () {
        var data = document.getElementById("table-htlv2").rows.length;
        document.getElementById("table-htlv2").deleteRow(data - 1);
        rowcount--;
    });
    $(".div_them3").on('click', '#buttonThem3', function () {
        rowcount++;
        //If there is no data then no row is added
        $("#table-gd").append('<tr> ' +
            ' <td id = "col' + rowcount + '1" > ' +
            ' <select class="custom-select" name="giaDinh"> ' +
            '    <option value="">Loại gia đình</option> ' +
            option_family +
            ' </select> ' +
            ' </td> ' +
            ' <td id="col' + rowcount + '2"> ' +
            '    <input name="ngaySinhGiaDinh" data-auto-close="true" id="input' + rowcount + '2" type="text" autocomplete="off" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="dd/mm/yyyy" /> ' +
            ' </td> ' +
            ' <td id="col13" class="editable"><input id="input' + rowcount + '3" autocomplete="off" name="hoTen" style="border:none" /></td> ' +
            ' <td id="col14" class="editable"><input id="input' + rowcount + '4" autocomplete="off" name="moiQuanHe" style="border:none" /></td> ' +
            ' <td id="col15" class="editable">' +
            ' <select class="custom-select" name="giaDinh"> ' +
            '    <option value="">Loại quan hệ</option> ' +
            option_relationship +
            ' </select> ' +
            '</td > ' +
            ' </tr >');
    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
});


//btn htvl1
var rowcount1 = 1;
$(document).ready(function () {
    $(".div_them").on('click', '#buttonThem1', function () {
        rowcount1++;
        //If there is no data then no row is added
        $("#table-htlv1").append('<tr><td id="col' + rowcount1 + '1 " class="editable"><input name="tenTruong" id="input' + rowcount1 + '1" style="border: none"/></td >' +
            '<td contenteditable="true" id="col' + rowcount1 + '2" class="editable"></td>' +
            '<td><div class="row"><div class="col l3"> <label class="custom-label">Từ:</label></div>' +
            '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
            '</div><div class="row" style="margin-top:5px">' +
            '<div class="col l3"> <label class="custom-label">Đến:</label></div>' +
            '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
            '</div></td>' +
            '<td contenteditable="true" id="col' + rowcount1 + '4" class="editable"></td>' +
            '<td contenteditable="true" id="col' + rowcount1 + '5" class="editable"></td></tr>"');
    });
});
//
var rowcount2 = 1;
$(document).ready(function () {
    $(".div_them2").on('click', '#buttonThem2', function () {
        rowcount2++;
        //If there is no data then no row is added
        $("#table-htlv2").append('<tr>' +
            '<td id = "col' + rowcount2 + '1" > <input id="input' + rowcount2 + '1" autocomplete="off" name="donVi" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '2"><input id="input' + rowcount2 + '2" autocomplete="off" name="chucDanh" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '3"><input id="input' + rowcount2 + '3" autocomplete="off" name="chucVu" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '4" class="editable"><input autocomplete="off" name="tuNgayDenNgay" id="input' + rowcount2 + '4" type="text" data-auto-close="true" data-range="true" placeholder="dd/mm/yyyy - dd/mm/yyyy" data-multiple-dates-separator=" - " data-language="vi" class="datepicker-here form-control" style="border:none" /></td>' +
            '</tr> '
        );
    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
});
var rowcount3 = 1;
$(document).ready(function () {
    $(".div_them4").on('click', '#buttonThem4', function () {
        rowcount3++;
        //If there is no data then no row is added
        $.getScript('../../lib/datepicker_src/dist/js/datepicker.js', function () {
            $("#qt-luong").append('<tr><td id="col' + rowcount3 + '1"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></td>' +
                '<td contenteditable="true" id="col' + rowcount3 + '2" class="editable"></td>' +
                '<td contenteditable="true" id="col' + rowcount3 + '3" class="editable"></td>' +
                '</tr>'
            );
        });
    });
});