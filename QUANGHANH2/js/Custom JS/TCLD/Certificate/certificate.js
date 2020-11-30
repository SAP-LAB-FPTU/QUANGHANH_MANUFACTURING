$('input.autocomplete_MS').autocomplete({
    data: {
        "SA1320	": null,
        "SB1321	": null,
        "SC1322	": null,
        "SA1323	": null,
        "SB1324	": null,
        "SC1325	": null,
        "SC1326	": null,        
    },
});
$('input.autocomplete_Name').autocomplete({
    data: {
        "Nguyễn Văn Long-SA1320": null,
        "Nguyễn Văn Sơn-SB1321": null,
        "Nguyễn Văn Tuấn-SC1322": null,
        "Nguyễn Văn Duy-SA1323": null,
        "Vũ Văn Đức-SB132": null,
        "Vũ Văn Hoàng-SC1325": null,
        "Nguyễn Văn Hải-SC1326": null,
    },
});
function getFocus() {
    document.getElementById("myText").focus();
}

function loseFocus() {
    document.getElementById("myText").blur();
}