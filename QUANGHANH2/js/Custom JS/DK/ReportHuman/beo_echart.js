$(function () {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance

    // ------------------------------
    // Stacked bar chart
    // ------------------------------




    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var barbasicChart = echarts.init(document.getElementById('bar-basic'));

    var option = {

        // Setup grid
        grid: {
            x: 40,
            x2: 40,
            y: 80,
            y2: 20
        },

        // Add tooltip
        tooltip: {
            trigger: 'axis',
            align: 'center'
        },

        // Add legend
        legend: {
            data: ['TổngLĐ PX trừ nghỉ dài', 'Tổng LĐ TT DS', 'Tổng LĐ PX báo']
        },

        // Add custom colors
        color: ['#aeddf3', '#4fc3f7', '#2962FF'],

        // Horizontal axis
        xAxis: [{
            type: 'value',
            boundaryGap: [0, 0.2]
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ['Đlò3', 'Đlò5', 'Đlò7', 'Đlò8', 'KT 1', 'KT 2', 'KT 3'
                , 'KT 4', 'KT 5', 'KT 6', 'KT 7', 'KT 8', 'KT 9',
                'KT 10', 'KT 11', 'VT 1', 'VT 2']
        }],

        // Add series
        series: [
            {
                name: 'TổngLĐ PX trừ nghỉ dài',
                type: 'bar',
                data: [112, 90, 113, 98, 84, 121, 116, 95, 106, 91, 94, 99, 90, 107, 77, 179, 126]
            },
            {
                name: 'Tổng LĐ TT DS',
                type: 'bar',
                data: [105, 83, 106, 91, 77, 113, 109, 88, 99, 84, 87, 92, 83, 100, 70, 172, 119]
            },
            {
                name: 'Tổng LĐ PX báo',
                type: 'bar',
                data: [105, 84, 112, 101, 81, 118, 113, 95, 102, 83, 93, 100, 90, 109, 75, 176, 129]
            }
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