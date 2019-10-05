var rowcount = 1;
$(document).ready(function () {
    $(".div_them3").on('click', '#buttonThem3', function () {
        rowcount++;
        //If there is no data then no row is added
        $("#table-gd").append('<tr><td id="col' + rowcount + '1"><select class="custom-select" id="gd"  name="giaDinh">' +
            '<option value="Bản thân">Bản thân</option><option value="Nhà vợ">Nhà vợ</option>' +
            '<option value="Nhà chồng">Nhà chồng</option></select ></td ><td id="col' + rowcount + '2">' +
            '<input id="input' + rowcount + '2" name="ngaySinhGiaDinh" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="dd/mm/yyyy" />' +
            '</td><td id="col' + rowcount + '3" class="editable"><input id="input' + rowcount + '3"  name="hoTen" style="border:none" /></td><td id="col' + rowcount + '4" class="editable"><input id="input' + rowcount + '4"  name="moiQuanHe" style="border:none" /></td>"' +
            '<td  id="col' + rowcount + '5" class="editable"><input id="input' + rowcount + '5"  name="lyLich" style="border:none" /></td></tr>');
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
        $.getScript('../../lib/datepicker_src/dist/js/datepicker.js', function () {
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
});
//
var rowcount2 = 1;
$(document).ready(function () {
    $(".div_them2").on('click', '#buttonThem2', function () {
        rowcount2++;
        //If there is no data then no row is added
        $.getScript('../../lib/datepicker_src/dist/js/datepicker.js', function () {
            $("#table-htlv2").append('<tr><td id="col' + rowcount2 + '1">' +
                '<div class="row"><div class="col l3"> <label class="custom-label">Từ:</label></div>' +
                '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
                '</div><div class="row" style="margin-top:5px">' +
                '<div class="col l3"> <label class="custom-label">Đến:</label></div>' +
                '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
                '</div></td>' + '<td contenteditable="true" id="col' + rowcount2 + '2" class="editable"></td>' +
                '<td contenteditable="true" id="col' + rowcount2 + '3" class="editable"></td>' +
                '<td contenteditable="true" id="col' + rowcount2 + '4" class="editable"></td></tr>'
            );
        });
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