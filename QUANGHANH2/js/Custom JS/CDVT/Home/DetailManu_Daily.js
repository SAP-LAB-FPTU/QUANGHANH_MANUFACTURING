
$(document).ready(function () {
    //
    $('.parent').click(function () {
        if ($(this).siblings(".child-" + this.id).is(':visible')) {
            $(this).css('background-color', '');
            $(this).css('color', 'black');

            $(this).siblings(".child-" + this.id).css('background-color', '');
            $(this).siblings(".child-" + this.id).css('color', 'black');

            $(this).siblings('.child-child-' + this.id).css('background-color', '');
            $(this).siblings('.child-child-' + this.id).css('color', 'black');

            $(this).siblings('.grand-' + this.id).css('background-color', '');
            $(this).siblings('.grand-' + this.id).css('color', 'black');

            $(this).siblings('.grand-grand-' + this.id).css('background-color', '');
            $(this).siblings('.grand-grand-' + this.id).css('color', 'black');

            $(this).siblings('.master-' + this.id).css('background-color', '');
            $(this).siblings('.master-' + this.id).css('color', 'black');
        }
        else {
            $(this).css('background-color', '#ddd');
            $(this).css('color', 'black');

        }
    });
    //
    $('tr.parent')
        .css("cursor", "pointer")
        .attr("title", "Ấn để mở rộng/thu vào")
        .click(function () {
            $(this).siblings('.child-' + this.id).toggle();
            $(this).siblings('.child-child-' + this.id).hide();
            $(this).siblings('.child-child-' + this.id).css('font-style', 'italic');
            $(this).siblings('.grand-' + this.id).hide();
            $(this).siblings('.grand-grand-' + this.id).hide();
            $(this).siblings('.master-' + this.id).hide();
        });
});

$(function () {
    $('.largest').hover(function () {
        $(this).css('color', 'blue');
    }, function () {
        $(this).css('color', 'black');
    });
});

$(function () {
    $('tr').hover(function () {
        $(this).css('background-color', '#A4A4A4');
    }, function () {
        if ($(this).siblings(".child-" + this.id).is(':visible')) {
            $(this).css('background-color', '#ddd');
        }
        else {
            $(this).css('background-color', '');
        }
    });
});

$('#edit').click(function () {
    $('td').attr('contenteditable', 'true');
    $("#save").show();
    $("#edit").hide();
});
$('#ok').click(function () {
    $('td').attr('contenteditable', 'false');
    $("#edit").show();
    $("#save").hide();
});
$('#export').click(function () {
    window.location.href = "/excel/chi-tiet-san-xuat.xls";
});
