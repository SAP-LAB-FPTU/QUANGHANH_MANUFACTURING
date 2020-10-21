function productsAdd() {
    var i = 0;

    for (i = 1; i <= 40; i++) {
        var name = ["Nam", "Sang", "Định", "Quyết", "Tài", "Đức", "Núi", "Quân", "Biên", "Hưng", "Thái", "Hùng", "Phương", "Tiến"];
        var surname = ["Đức", "Thế", "Hữu", "Văn", "Mạnh", "Duy"];
        var firstname = ["Lương", "Nguyễn", "Trần", "Phạm", "Lê", "Bùi"]
        var randname = Math.floor(Math.random() * 14);
        var randsur = Math.floor(Math.random() * 6);
        var randfirst = Math.floor(Math.random() * 6);
        var rand = Math.floor(Math.random() * 6000) + 1000;
        var rand2 = Math.floor(Math.random() * 2000) + 1000;
        var rand3 = Math.floor(Math.random() * 2000) + 1000;
        $("#data tbody").append(
            "<tr>" +
            "<td>00" + i + "</td>" +
            "<td>" + rand + "</td>" +
            "<td>0</td>" +
            "<td>" + firstname[randfirst] + " " + surname[randsur] + " " + name[randname] + "</td>" +
            "<td>-</td>" +
            "<td>-</td>" +
            "<td>x</td>" +
            "<td>-</td>" +
            "</tr >"
        );    
    $("#data2 tbody").append(
        "<tr>" +
        "<td>" + rand2 + "</td>" +
        "<td>10/21/2003</td>" +
        "<td>10/23/2003</td>" +
        "<td>" + rand3 + "</td>" +
        "<td>10/30/2019</td>" +
        "<td>11/1/2019</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>265,123</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "<td>-</td>" +
        "</tr >"
        );
    }; 
}

$(document).ready(function () {
    if ($("#data tbody").length == 0) {
        $("#data").append("<tbody></tbody>");
    }

    if ($("#data2 tbody").length == 0) {
        $("#data2").append("<tbody></tbody>");
    }
    productsAdd();

    /*Editable*/
    $("#btn-save").hide();
    $("td").css("color", "gray");
    $("td").attr("contenteditable", "false");    
    $("td#bq").css("background-color", "#f78181");
    $("#btn-fix").click(function () {
        $("#btn-save").show();
        $("#btn-fix").hide();
        $("td").css("color", "black");
        $("td").attr("contenteditable", "true");
        $("td#bq").css("background-color", "#f03e3e");
    });
    $("#btn_agrr").click(function () {
        $("td").css("color", "gray");
        $("#btn-fix").show();
        $("#btn-save").hide();
        $("td").attr("contenteditable", "false");
        $("td#bq").css("background-color", "#f78181");
    });  
});