function piechart() {
    "use strict";
    // ------------------------------
    // Basic pie chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var basicpieChart = echarts.init(document.getElementById('basic-pie'));
    var option = {
        // Add title
        title: {
            text: 'Thống kê hệ thống',
            x: 'center'
        },

        // Add tooltip
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b}: {c} ({d}%)"
        },

        // Add legend
        legend: {
            orient: 'vertical',
            x: 'left',
            data: ['Hoạt động không đầy đủ', 'Hoạt động đầy đủ', 'Không hoạt động']
        },

        // Add custom colors
        color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51', '#2962FF'],


        // Enable drag recalculate
        calculable: true,

        // Add series
        series: [{
            name: 'Hệ thống',
            type: 'pie',
            radius: '70%',
            center: ['50%', '57.5%'],
            data: [
                { value: kodaydu, name: 'Hoạt động không đầy đủ' },
                { value: daydu, name: 'Hoạt động đầy đủ' },
                { value: ko, name: 'Không hoạt động' }
            ]
        }]
    };

    basicpieChart.setOption(option);
    // use configuration item and data specified to show chart
    basicpieChart.on('click', function (params) {
        $('#pre-load').show();
        $.ajax({
            url: "/camera/getList",
            method: 'post',
            data: {
                type: params.name
            },
            success: function (data) {
                $('#thongke h3').text(params.name);
                $('#thongke tbody').empty();
                if (data.success) {
                    for (var j in data.listDB) {
                        let i = data.listDB[j];
                        let $tr = $('<tr><td>' + i.room_name + '</td><td>' + i.department_name + '</td><td>' + i.camera_available + '/' + i.camera_quantity + '</td></tr>');
                        $('#thongke tbody').append($tr);
                    }
                } else {
                    errorAlert("Có lỗi xảy ra");
                }
                $('#thongke').modal('open');
                $('#pre-load').hide();
            },
            cache: false
        })
    });
    //------------------------------------------------------
    // Resize chart on menu width change and window resize
    //------------------------------------------------------
    $(function () {

        // Resize chart on menu width change and window resize
        $(window).on('resize', resize);
        $(".sidebartoggler").on('click', resize);

        // Resize function
        function resize() {
            setTimeout(function () {

                // Resize chart
                basicpieChart.resize();
                basicdoughnutChart.resize();
                customizedChart.resize();
                nestedChart.resize();
                poleChart.resize();
            }, 200);
        }
    });
}