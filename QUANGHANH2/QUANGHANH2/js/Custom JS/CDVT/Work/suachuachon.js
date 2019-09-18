$(document).ready(function () {
    var dem = $("#dem").text();
   
    $("#them").click(function () {
        dem++;
        $("#Table").append("<tr><td>"+dem+"</td><td><input type='text' class='form-control' placeholder='Tên thiết bị vật tư' /></td><td><input type='text' class='form-control' placeholder='ĐVT' /></td><td><input type='number' class='form-control' placeholder='SL' /></td><td>    <select class='form-control'>        <option>Mới 100%</option><option>Cũ qua sử dụng</option><option>Cũ qua sửa chữa</option></select></td><td><input type='text' class='form-control' placeholder='Nơi lĩnh'/></td></tr>");
    });
});