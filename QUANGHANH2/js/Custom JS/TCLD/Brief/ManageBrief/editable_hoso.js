$(document).ready(function () {
    $("#btn-save").hide();
    $("td").css("color", "gray");
    $("td").attr("contenteditable", "false");
    $("input#checkbox_hoso").attr("disabled","disabled");
    //var bq = $("td#bq").text();     
    //for (var i = 0; i < bq.length; i++) {
    //    alert(bq);
    //} 
    $("td#bq").css("background-color", "#f78181");
    $("#btn-fix").click(function () {        
        $("#btn-save").show();
        $("#btn-fix").hide();
        $("td").css("color", "black");
        $("td").attr("contenteditable", "true");
        $("td#bq").css("background-color", "#f03e3e");
        $("input#checkbox_hoso").removeAttr("disabled");
    });   
    $("#btn_agrr").click(function () {                
        $("td").css("color", "gray");
        $("#btn-fix").show();
        $("#btn-save").hide();
        $("td").attr("contenteditable", "false");
        $("td#bq").css("background-color", "#f78181");
        $("input#checkbox_hoso").attr("disabled", "disabled");
    });     
});