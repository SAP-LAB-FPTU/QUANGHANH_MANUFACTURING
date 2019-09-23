$(function () {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    // specify chart configuration item and data
    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var barbasicChart = echarts.init(document.getElementById('bar-basic'));

    var option = {

        // Setup grid
        grid: {
            x: 160,
            x2: 40,
            y: 45,
            y2: 25
        },

        // Add tooltip
        tooltip: {
            trigger: 'axis'
        },

        // Add legend
        legend: {
            data: ['Tiến độ thực hiện ngày 19/10']
        },

        // Add custom colors
        color: ['#2962FF'],

        // Horizontal axis
        xAxis: [{
            type: 'value',
            boundaryGap: [0, 0.01]
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ['Than Sản Xuất', 'Than Hầm Lò', 'Than Lộ Thiên', ' Mét Lò Đào', 'Mét Lò Neo', 'Mét Lò Xén', 'Than Nhập Dương Huy','Than Tiêu Thụ', 'Doanh Thu', 'Than Sàng Tuyển', 'Đá Xít Xuất Kho']
        }],

        //,'Than Nhập Dương Huy','Doanh Thu','Than Sàng Tuyển','Đá Xít Xuất Kho'

        // Add series
        series: [{
                name: '2017',
                type: 'bar',
                data: [21, 30, 21, 38, 29, 30,34,35,33,35,38]
            },
        ]
    };
    // use configuration item and data specified to show chart
    barbasicChart.setOption(option);
            $(function () {

                // Resize chart on menu width change and window resize
                $(window).on('resize', resize);
                $(".sidebartoggler").on('click', resize);

                // Resize function
                function resize() {
                    setTimeout(function () {

                        // Resize chart
                        barbasicChart.resize();
                    }, 200);
                }
            });
});