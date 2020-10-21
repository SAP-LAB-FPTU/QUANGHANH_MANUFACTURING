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