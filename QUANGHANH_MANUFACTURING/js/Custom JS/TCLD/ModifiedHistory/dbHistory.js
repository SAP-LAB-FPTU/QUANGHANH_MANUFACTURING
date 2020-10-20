(function () {


    var db = {
        insertItem: function (insertingClient) {
            this.clients.push(insertingClient);
        },

        updateItem: function (updatingClient) { },

        deleteItem: function (deletingClient) {
            var clientIndex = $.inArray(deletingClient, this.clients);
            this.clients.splice(clientIndex, 1);
        }

    };

    window.db = db;

    db.thanTest = [
        {
            "STT": 1,
            "Mã NV": "ABC123",
            "Tên NV": "Long",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Thêm 200 hồ sơ mới"

        },
        {
            "STT": 2,
            "Mã NV": "ABC123",
            "Tên NV": "Thúy",
            "Thời gian sửa chữa": "02/02/2019",
            "Nội dung sửa chữa": "Thay đổi thông tin 1 số hồ sơ"

        },
        {
            "STT": 3,
            "Mã NV": "ABC123",
            "Tên NV": "Học",
            "Thời gian sửa chữa": "03/02/2019",
            "Nội dung sửa chữa": "Thêm chứng chỉ"

        },
        {
            "STT": 4,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ đi học"

        },
        {
            "STT": 5,
            "Mã NV": "ABC123",
            "Tên NV": "Trà",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Thêm chi tiết bảo hiểm"

        },
        {
            "STT": 6,
            "Mã NV": "ABC123",
            "Tên NV": "Thành",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Thanh lý 20 hồ sơ"

        },
        {
            "STT": 7,
            "Mã NV": "ABC123",
            "Tên NV": "Long",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Thêm 100 hồ sơ mới"

        },
        {
            "STT": 8,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 9,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 10,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 11,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 12,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 13,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 14,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 15,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 16,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 17,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 18,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 19,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 20,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 21,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 22,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 23,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 24,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
        {
            "STT": 25,
            "Mã NV": "ABC123",
            "Tên NV": "Vương",
            "Thời gian sửa chữa": "01/01/2019",
            "Nội dung sửa chữa": "Cập nhật chứng chỉ"

        },
    ];
   
}());