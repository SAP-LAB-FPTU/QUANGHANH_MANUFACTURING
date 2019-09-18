var col1;
var col2;
var col3;
var col4;
var col5;
var x;
var rowcount = 0;
$(document).ready(function () {
    $("input.select-dropdown.dropdown-trigger").remove();
    $("ul.dropdown-content.select-dropdown").remove();
    $("svg.caret").remove();

    $("#buttonThem").on('click', function () {
        col1 = $("#gd").val();
        col2 = $("#hvt").val();
        col3 = $("#qhe").val();
        col4 = $("#ns").val();
        col5 = $("#lyl").val();
        x = $('#qh').text();
        rowcount++;        
        //If there is no data then no row is added
        if ((col2 != "" || col3 != "" || col4 != "" || col5 != "") && col3 != x) {
            //Remove atrr hidden of table 2
            $("#table2").removeAttr("hidden");
            //Add table when there is no table    
            var outlineTable = "<h3 class='center black-text'><b>THÊM HỒ SƠ</b></h3>"+
                "< hr /> <table id='myTable' class='responsive-table table-bordered'>" +
                "<thead>" +
                "<tr>" +
                "<th class='center'>Gia đình</th>" +
                "<th class='center'>Họ và tên</th>" +
                "<th class='center'>Mối quan hệ</th>" +
                "<th class='center'>Ngày sinh</th>" +
                "<th class='center'>Lý lịch</th>" +
                "<th class='center'></th><th class='center'></th></tr></thead><tbody id='body-table-wrapper2'></tbody>";
            var count = $("#table-wrapper2 > table").length;
            if (count == 0) {
                $("#table-wrapper2").html(outlineTable);
            }
            //Add data-table in to table          
            $("#body-table-wrapper2").append("<tr id='" + rowcount +
                "'><td class='center'>" + col1 + "</td><td class='center'>" + col2 +
                "</td><td class='center' id='qh'>" + col3 + "</td><td class='center'>" + col4 +
                "</td><td class='center'>" + col5 +
                "</td><td class='center'><button id='buttonSua' class='btn blue darken-2'>Sửa</button></td><td class='center'><button id='buttonXoa' class='btn red darken-2' value='"
                + rowcount + "'>Xóa</button></td></tr>");
            //Deletedata after press button "Thêm"        
            $("#hvt").val("");
            $("#qhe").val("");
            $("#ns").val("");
            $("#lyl").val("");
        }
        //if a relationship exist then can't add
        if (col3 == x && col3 !="") {
            alert('Mối quan hệ này đã tồn tại!!!');
            $("#qhe").val("");
        }   
        
        //remove the row clicked "Xóa"        
        $(document).on('click','#buttonXoa', function () {
            
            //remove the row clicked "Xóa"
            $('#myTable > tbody > tr').remove('#' + $(this).val());

            //invisible table if remove all row
            var count = $('#myTable > #body-table-wrapper2 > tr').length;
            if (count == 0) {
                $("#table-wrapper2").html("");
                $("#table2").attr('hidden', 'hidden');
            }
        });
    });
});