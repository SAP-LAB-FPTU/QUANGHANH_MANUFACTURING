$(document).ready(function () {
    new SlimSelect({
        select: '#demo',
        placeholder: 'Chọn chứng chỉ',
        searchText: 'Sorry couldnt find anything',
    })
    new SlimSelect({
        select: '#demo2',
        placeholder: 'Chọn chứng chỉ',
        searchText: 'Sorry couldnt find anything',
    })

});
$(function () {
    $("#add").click(function () {
        $("input[type=text]").focusout(function () {
            var text = $(this).val();
            var id = $(this).id;
            if (text === "" || text === null) {
                $(this).css("cssText", "border-color: red !important;");
            }

        });
        $("input[type=text]").focusin(function () {
            $(this).css("cssText", "border-color: green !important;");
        })

    });
});  