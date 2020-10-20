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

    db.nghidai = [
        {
            "STT":1,
            "Họ và tên": "Nguyễn Văn Lãm",
            "Số thẻ": "4710",
            "Từ ngày": "01/5/19"
        },
        {
            "STT":2,
            "Họ và tên": "Lưu Đình Chung",
            "Số thẻ": "8744",
            "Từ ngày": "01/7/19"
        },
        {
            "STT":3,
            "Họ và tên": "Vũ Quý Nghiêm",
            "Số thẻ": "5310",
            "Từ ngày": "14/2/17"
        },
        {
            "STT":4,
            "Họ và tên": "Nguyễn Văn Anh",
            "Số thẻ": "8192",
            "Từ ngày": "31/5/18"
        },
        {
            "STT":5,
            "Họ và tên": "Trần Hữu Quang",
            "Số thẻ": "2487",
            "Từ ngày": "18/9/18"
        },
        {
            "STT": 6,
            "Họ và tên": "Nguyễn Đăng Quân",
            "Số thẻ": "1103",
            "Từ ngày": "13/2/19"
        },
        {
            "STT": 7,
            "Họ và tên": "Lê Hồng Khá",
            "Số thẻ": "1099",
            "Từ ngày": "08/5/19"
        }
        ,
        {
            "STT": 8,
            "Họ và tên": "Nguyễn Duy Khánh",
            "Số thẻ": "5123",
            "Từ ngày": "3/3/19"
        }
        ,
        {
            "STT": 9,
            "Họ và tên": "Lương Thế Hưng",
            "Số thẻ": "4563",
            "Từ ngày": "13/2/18"
        }
        ,
        {
            "STT": 10,
            "Họ và tên": "Phạm Hải Hà",
            "Số thẻ": "2231",
            "Từ ngày": "13/6/18"
        }
    ];    

    db.sanluong = [
        {
            "STT": 'A',
            "Danh mục": "Kế hoạch năm 2019",            
        },
        {
            "STT": 1,
            "Danh mục": "Tấn than",
            "DVT": "Tấn",
            "Kế hoạch": "28.000",
            "Thực hiện": "9.057",
            "Chênh lệch": "32"
        },
        {
            "STT": 2,
            "Danh mục": "Mét lò",
            "DVT": "m",
            "Kế hoạch": "3.100",
            "Thực hiện": "853",
            "Chênh lệch": "28"
        },
        {
            "STT": 'B',
            "Danh mục": "Kế hoạch quý 3/2019",            
        },
        {
            "STT": 1,
            "Danh mục": "Tấn than",
            "DVT": "Tấn",
            "Kế hoạch": "2.375",
            "Thực hiện": "630",
            "Chênh lệch": "12"
        },
        {
            "STT": 2,
            "Danh mục": "Mét lò",
            "DVT": "m",
            "Kế hoạch": "275",
            "Thực hiện": "71",
            "Chênh lệch": "6"
        }
    ];
}());