$(function () {
    "use strict";
    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var barbasicChart1 = echarts.init(document.getElementById('PowerUsage1'));

    var option1 = {

        // Setup grid
        grid: {
            x: 130,
            x2: 40,
            y: 45,
            y2: 25
        },

        // Add tooltip
        tooltip: {
            trigger: 'axis',
            formatter: "{b}: {c} %",
            align: 'center'
        },

        // Add custom colors
        color: ['#4fc3f7'],

        // Horizontal axis
        xAxis: [{
            type: 'value',
            boundaryGap: [0, 0.01]
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ["Bơm nước hầm lò", "Bơm nước lộ thiên", "Thông gió", "Đào lò chuẩn bị sx", "Khai thác than lò chợ", "Chống xén", "Sàng tuyển", "Vận băng tải", "Vận tầu điện", "Trục tải", "Khí nén", "Phục vụ", "Khác"]
        }],

        // Add series
        series: [
            {
                type: 'bar',
                data: [59.74, 38.79, 50.08, 52.28, 47.28, 32.22, 36.05, 47.18, 53.59, 54.43, 51.09, 49.05, 29.47]
            }
        ]
    };
    // use configuration item and data specified to show chart
    barbasicChart1.setOption(option1);
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
                barbasicChart1.resize();
            }, 200);
        }
    });
});

function ResizeChart() {
    var barbasicChart1 = echarts.init(document.getElementById('PowerUsage1'));
    setTimeout(function () {
        // Resize chart
        barbasicChart1.resize();
    }, 200);
}