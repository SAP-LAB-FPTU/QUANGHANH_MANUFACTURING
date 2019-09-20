var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;
var flag = false;
$(document).ready(function () {
    if (!flag) {
        $("input.inputEdit").attr("disabled", "disabled");
        $("td.td-edit").attr("contenteditable", "false");
        $("select.sl-edit").attr("disabled", "disabled");
        $("input.select-dropdown.dropdown-trigger").remove();
        $("ul.dropdown-content.select-dropdown").remove();
        $("svg.caret").remove();

        $("select.custom-select").attr("disabled", "disabled");

        $("#wrapper-advancedSearch").hide();
    }
});
function abc() {
    if (!flag) {
        $("input.inputEdit").removeAttr("disabled");
        $("td.td-edit").attr("contenteditable", "true");
        $("select.sl-edit").removeAttr("disabled");             
        $("select.custom-select").removeAttr("disabled");
        $("#pencil").remove();
        $("#pencilandsave").html("<a id='save' class='float modal-trigger' href='#updateBrief'><i class='material-icons my-float'>save</i></a>");
        flag = true;
    } else {
        $("input.inputEdit").attr("disabled", "disabled");
        $("td.td-edit").attr("contenteditable", "false");
        $("select.sl-edit").attr("disabled", "disabled");
        $("select.custom-select").attr("disabled", "disabled");
        $("#save").remove();
        $("#pencilandsave").html("<a id='pencil' class='float' href='#' onclick='abc()'><i class='material-icons my-float'>create</i></a>");
        flag = false;
    }
}

