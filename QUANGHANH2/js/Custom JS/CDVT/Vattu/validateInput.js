accept_Keycode_table = [96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 8, 9, 37, 40, 39, 38, 190]
function inputNumber(id) {
    $(document).on('keydown', id, function (e) {
        //alert('e')
        if (!accept_Keycode_table.includes(e.keyCode)) {
            e.preventDefault()
        }
    })
}