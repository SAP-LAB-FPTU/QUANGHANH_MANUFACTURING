
$(document).ready(function () {
    //
    $('.parent').click(function () {
        if ($(this).siblings(".child-" + this.id).is(':visible')) {
            $(this).css('background-color', '');
            $(this).css('color', 'black');

        }
        else {
            $(this).css('background-color', '#3fe7ac');
            $(this).css('color', 'white');

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
    $('.parent').hover(function () {
        $(this).css('background-color', '#0190f3');
    }, function () {
        if ($(this).siblings(".child-" + this.id).is(':visible')) {
            $(this).css('background-color', '#3fe7ac');
        }
        else {
            $(this).css('background-color', '');
        }
    });
});

$(document).ready(function () {

    //$('tr[@class^=child-]').hide().children('td');
});
