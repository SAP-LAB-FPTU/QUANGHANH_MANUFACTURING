$(function () {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var donvi = ["ĐL3", "ĐL5", "ĐL7", "ĐL8", "KT1", "KT2", "KT3", "KT4", "KT5", "KT6", "KT7", "KT8", "KT9", "KT10", "KT11", "VTL1", "VTL2"];
    var myChart = echarts.init(document.getElementById('basic-bar'));

    // specify chart configuration item and data
    var option = {
        // Setup grid
        grid: {
            left: '1%',
            right: '2%',
            bottom: '3%',
            containLabel: true
        },

        // Add Tooltip
        tooltip: {
            trigger: 'axis'
        },

             
        color: ["#2962FF", "#4fc3f7"],
        calculable: true,
        xAxis: [
            {
                type: 'category',
                data: donvi
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: 'Tổng',
                type: 'bar',
                data: [86,77,92,78,74,103,96,86,83,78,84,71,80,90,67,154,119],
                markPoint: {
                    data: [
                        { type: 'max', name: 'Max' },
                        { type: 'min', name: 'Min' }
                    ]
                },
                markLine: {
                    data: [
                        { type: 'average', name: 'Average' }
                    ]
                }
            },            
        ]
    };
    // use configuration item and data specified to show chart
    myChart.setOption(option);


    $(function () {

        // Resize chart on menu width change and window resize
        $(window).on('resize', resize);
        $(".sidebartoggler").on('click', resize);

        // Resize function
        function resize() {
            setTimeout(function () {

                // Resize chart
                myChart.resize();
            }, 200);
        }
    });
});