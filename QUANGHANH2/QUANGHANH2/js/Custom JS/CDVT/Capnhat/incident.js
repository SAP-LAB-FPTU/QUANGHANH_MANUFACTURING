var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;
var select;
var elem;
var instance;
$(document).ready(function () {
    elem = document.querySelector('.dropdown-trigger');
    instance = M.Dropdown.getInstance(elem);
    $("a.dropdown-child").click(function () {
        select = $(this).attr("name");
        if (select == 'truoc') {
            $("#filter").html("Chưa sửa chữa");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr class='highlight'><th class='text-center' rowspan ='2'>Mã thiết bị</th><th class='text-center'rowspan='2'>Tên thiết bị</th><th class='text-center'rowspan='2'>Vị trí</th><th class='text-center'rowspan='2'>Đơn vị chịu trách nhiệm</th><th class='text-center'colspan='4'>Nội dung sự cố</th></tr ><tr><th>Thời gian bắt đầu sự cố</th><th>Thời gian kết thúc sự cố</th><th>Lý do sự cố</th><th>Tình trạng sự cố</th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("tr><td><input type='text' placeholder='Mã thiết bị' value='SFC'/></td ><td>Xe tải</td><td><input type='text' placeholder='Vị trí' value='Lò DV - 110V7.3'/></td><td><input type='text' placeholder='Đơn vị' value='Khai thác 3' /></td><td>2:15AM 15/7/2019</td><td></td><td><input type='text' placeholder='Lý do'  value='' /></td><td>Chưa sửa chữa</td></tr>");
        }

        if (select == 'sau') {
            $("#filter").html("Đã sửa chữa");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr class='highlight'><th class='text-center' rowspan ='2'>Mã thiết bị</th><th class='text-center'rowspan='2'>Tên thiết bị</th><th class='text-center'rowspan='2'>Vị trí</th><th class='text-center'rowspan='2'>Đơn vị chịu trách nhiệm</th><th class='text-center'colspan='4'>Nội dung sự cố</th></tr ><tr><th>Thời gian bắt đầu sự cố</th><th>Thời gian kết thúc sự cố</th><th>Lý do sự cố</th><th>Tình trạng sự cố</th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("tr><td>SFC</td ><td>Xe tải</td><td>Lò DV-110V7.3</td><td>Khai thác 3</td><td>2:15AM 15/7/2019</td><td><input type='datetime' placeholder='Thời gian kết thúc' value='' /></td><td>Lệch trục xe</td><td> Đã sửa chữa</td></tr>");
        }
        $('.dropdown-trigger').dropdown('close');
    });
});