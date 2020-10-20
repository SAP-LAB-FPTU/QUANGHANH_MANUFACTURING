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
    var dem = $("#dem").text();

    $("#them").click(function () {
        
        dem++;
        alert("abc");
        $("#TableABC").append("<tr><td>" + dem + "</td><td><input type='text' class='form-control' placeholder='Tên đặc tính' /></td><td><input type='number' class='form-control' placeholder='Thông số' /></td><td><input type='text' class='form-control' placeholder='ĐVT' /></td></tr>");
    });

    var dem2 = $("#dem2").text();

    $("#them2").click(function () {
        dem2++;
        $("#TableABCD").append("<tr><td>" + dem2 + "</td><td><input type='text' class='form-control' placeholder='Mã thuộc tính' /></td><td><input type='number' class='form-control' placeholder='Tên thuôc tính' /></td><td><input type='text' class='form-control' placeholder='Thông số' /></td><td><input type='text' class='form-control' placeholder='ĐVT' /></td></tr>");
    });

    elem = document.querySelector('.dropdown-trigger');
    instance = M.Dropdown.getInstance(elem);
    var d = new Date();
    if (d.getMonth() >= 0 && d.getMonth < 10)
        var month = '0';
    var strDate = d.getDate() + "/" + (month + 1) + "/" + d.getFullYear();
    $("#date").attr('value', strDate);
    if ($("#manhom").val() == 'Thêm mã nhóm mới') {
        $("#buttonf").attr('href', '#nhomthietbi');
        $("#buttonf").attr('class', 'btn blue darken-2 modal-close save-category modal-trigger');
    }
    $("#manhom").change(function () {
        if ($("#manhom").val() == 'Thêm mã nhóm mới') {
            $("#buttonf").attr('href', '#nhomthietbi');
            $("#buttonf").attr('class', 'btn blue darken-2 modal-close save-category modal-trigger');
        }
    });
    $("#check").click(function () {
        $("#buttonf").removeAttr('href');
    });
    $("#check1").click(function () {
        $("#buttonf").removeAttr('href');
    });
    $("a.dropdown-child").click(function () {
        select = $(this).attr("name");
        if (select == '001') {
            $('#Table2 > tbody ').remove();
            var mylineTable = "<table id='Table2'></table>";
            $("#mywrap").html(mylineTable);
            $("#mywrap").append("<tr style='border-bottom:none'><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='#myadd'>Thêm</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/huy-dong'>Danh sách chung</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/thiet-bi/nhom'>Xem tất cả</a></td></tr>");

            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>2</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>3</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>4</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>5</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
        }
        if (select == '007') {
            $('#Table2 > tbody ').remove();
            var mylineTable = "<table id='Table2'></table>";
            $("#mywrap").html(mylineTable);
            $("#mywrap").append("<tr style='border-bottom:none'><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='#myadd'>Thêm</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/huy-dong'>Danh sách chung</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/thiet-bi/nhom'>Xem tất cả</a></td></tr>");

            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='007' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>2</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='007' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>3</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='007' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>4</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='007' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>5</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='007' href='#'>001</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
        }

        if (select == '014') {
            $('#Table2 > tbody ').remove();
            var mylineTable = "<table id='Table2'></table>";
            $("#mywrap").html(mylineTable);
            $("#mywrap").append("<tr style='border-bottom:none'><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='#myadd'>Thêm</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/huy-dong'>Danh sách chung</a></td><td><a class='waves-effect waves-light btn-small blue modal-trigger' href='/phong-cdvt/thiet-bi/nhom'>Xem tất cả</a></td></tr>");

            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>014</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>2</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>014</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>3</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>014</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>4</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>014</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
            $("#body-table-wrapper2").append("<tr><td>5</td><td>SFC</td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td><a class='dropdown-child' name='001' href='#'>014</a></td><td>15.01</td><td>TC MOTOR</td><td>04-05-2019</td><td>Phân xưởng 1</td><td>Phân xưởng lộ thiên</td><td>Cấp mới</td><td style='text-align: center'><a href='/phong-cdvt/thiet-bi' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chi tiết</a></td></tr>");
        }

        if (select == 'sausc') {
            $("#filter").html("Danh sách thiết bị sau sửa chữa");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td><a href='/phong-cdvt/thiet-bi/nhom'>SFC</a></td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td>001</td><td>15.01</td><td>A</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>04-12-2018</td><td>120.000.000</td><td>12%</td><td>104.000.000</td><td>24</td><td>10-12-2018</td><td>04-05-2019</td><td>324 giờ</td><td>Phân xưởng lộ thiên</td><td>Sau sửa chữa</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }

        if (select == 'thanhly') {
            $("#filter").html("Danh sách thiết bị đã thanh lý");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td><a href='/phong-cdvt/thiet-bi/nhom'>SFC</a></td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td>001</td><td>15.01</td><td>A</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>04-12-2018</td><td>120.000.000</td><td>12%</td><td>104.000.000</td><td>24</td><td>10-12-2018</td><td>04-05-2019</td><td>324 giờ</td><td>Phân xưởng lộ thiên</td><td>Đã thanh lý</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>2</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS</a></td><td>Băng tải B1000</td><td>MS4203</td><td>002</td><td>15.02</td><td>B</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td>15%</td><td>112.000.000</td><td>24</td><td>20-03-2019</td><td>21-08-2019</td><td>267 giờ</td><td>Lò than 1</td><td>Đã thanh lý</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'lothien') {
            $("#filter").html("Danh sách thiết bị lộ thiên");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td><a href='/phong-cdvt/thiet-bi/nhom'>SFC</a></td><td>Máy khoan Atlas Copco</td><td>ECM660-IV</td><td>001</td><td>15.01</td><td>A</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>04-12-2018</td><td>120.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>2</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS</a></td><td>Băng tải B1000</td><td>MS4203</td><td>002</td><td>15.02</td><td>B</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>2</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DOC</a></td><td>Xe cẩu</td><td>14M-1464</td><td>002</td><td>15.02</td><td>C</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>22-07-2018</td><td>220.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>3</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DOC1</a></td><td>Xe cẩu</td><td>14M-1465</td><td>010</td><td>15.10</td><td>A</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>4</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS18</a></td><td>Băng tải B1010</td><td>MS4210</td><td>011</td><td>15.11</td><td>A</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>5</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS10</a></td><td>Băng tải B1112</td><td>MS4254</td><td>245</td><td>15.17</td><td>C</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>12-03-2019</td><td>220.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>6</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS15</a></td><td>Băng tải B1114</td><td>MS4261</td><td>245</td><td>15.18</td><td>C</td><td>TC MOTOR</td><td>Khai thác lộ thiên</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'hamlo') {
            $("#filter").html("Danh sách thiết bị hầm lò");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>1</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS</a></td><td>Băng tải B1000</td><td>MS4203</td><td>002</td><td>15.02</td><td>B</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>2</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS3</a></td><td>Băng tải B1001</td><td>MS4204</td><td>006</td><td>15.06</td><td>A</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>3</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS2</a></td><td>Băng tải B1002</td><td>MS4205</td><td>007</td><td>15.07</td><td>A</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>4</td><td><a href='/phong-cdvt/thiet-bi/nhom'>SFC1</a></td><td>Máy khoan Atlas Copco</td><td>ECM660-I</td><td>008</td><td>15.08</td><td>B</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>120.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>5</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS5</a></td><td>Băng tải B1019</td><td>MS4250</td><td>012</td><td>15.12</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>6</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS6</a></td><td>Băng tải B1020</td><td>MS4220</td><td>013</td><td>15.13</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>7</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS12</a></td><td>Băng tải B1100</td><td>MS4241</td><td>014</td><td>15.14</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>8</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS13</a></td><td>Băng tải B1210</td><td>MS4260</td><td>017</td><td>15.17</td><td>A</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>8</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS16</a></td><td>Băng tải B1190</td><td>MS4267</td><td>018</td><td>15.18</td><td>A</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'dieudong') {
            $("#filter").html("Danh sách hết bảo hiểm");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>6</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS6</a></td><td>Băng tải B1020</td><td>MS4220</td><td>013</td><td>15.13</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>6</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS6</a></td><td>Băng tải B1020</td><td>MS4220</td><td>013</td><td>15.13</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'thuhoi') {
            $("#filter").html("Danh sách thu hồi");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>5</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS5</a></td><td>Băng tải B1019</td><td>MS4250</td><td>012</td><td>15.12</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
            $("#body-table-wrapper2").append("<tr><td>6</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS6</a></td><td>Băng tải B1020</td><td>MS4220</td><td>013</td><td>15.13</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'suachua') {
            $("#filter").html("Danh sách sửa chữa");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>7</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS12</a></td><td>Băng tải B1100</td><td>MS4241</td><td>014</td><td>15.14</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td>15%</td><td>112.000.000</td><td>0</td><td>20-03-2019</td><td>21-08-2019</td><td>267 giờ</td><td>Phân xưởng phục vụ</td><td>Sửa chữa</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'capmoi') {
            $("#filter").html("Danh sách cấp mới");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>7</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS12</a></td><td>Băng tải B1100</td><td>MS4241</td><td>014</td><td>15.14</td><td>C</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td>15%</td><td>112.000.000</td><td>0</td><td>20-03-2019</td><td>21-08-2019</td><td>267 giờ</td><td>Phân xưởng phục vụ</td><td>Cấp mới</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'suco') {
            $("#filter").html("Danh sách đang gặp sự cố");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
            $("#body-table-wrapper2").append("<tr><td>8</td><td><a href='/phong-cdvt/thiet-bi/nhom'>DAS16</a></td><td>Băng tải B1190</td><td>MS4267</td><td>018</td><td>15.18</td><td>A</td><td>TC MOTOR</td><td>Khai thác hầm lò</td><td>12-03-2019</td><td>130.000.000</td><td>15%</td><td>112.000.000</td><td>5</td><td>20-03-2019</td><td>21-08-2019</td><td>267 giờ</td><td>Phân xưởng hầm lo</td><td>Sự cố</td><td style='text-align: center'><a href='#myedit' class='waves-effect waves-light btn blue darken-1 modal-trigger'>Chỉnh&nbspsửa</a></td><td style='text-align: center'><a href='#myaleart' class='waves-effect waves-light btn red modal-trigger'>Xoá</a></td></tr >");
        }
        if (select == 'kiemdinh') {
            $("#filter").html("Danh sách đang kiểm định");
            $('#Table > tbody ').remove();
            $("#pagi").remove();
            var outlineTable = "<table id='Table' class='striped table-responsive centered table-bordered mytable'><thead><tr><th class='center-align'>STT</th><th class='center-align'>Mã</th><th class='center-align'>Tên</th><th class='center-align'>Số hiệu</th><th class='center-align'>Mã TSCĐ</th><th class='center - align'>Số chế tạo</th><th class='center - align'>Loại chất lượng</th><th class='center - align'>Nhà cung cấp</th><th class='center - align'>Loại thiết bị</th><th class='center - align'>Ngày nhập</th><th class='center - align'>Nguyên giá</th><th colspan='2'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            $("#table-wrapper2").html(outlineTable);
        }
        $('.dropdown-trigger').dropdown('close');
    });
});