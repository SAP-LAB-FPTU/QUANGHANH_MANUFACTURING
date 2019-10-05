$(function () {
    "use strict";
    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var myChart = echarts.init(document.getElementById('basic-line'));

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

        // Add Legend
        legend: {
            data: ['Max temp', 'Min temp']
        },

        // Add custom colors
        color: ['#2962FF', '#f62d51', '#ec73f5'],

        // Enable drag recalculate
        calculable: true,

        // Horizontal Axiz
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                data: ['0', 'K1', 'K2', 'K3']
            }
        ],

        // Vertical Axis
        yAxis: [
            {
                type: 'value',
                max: 100,
                axisLabel: {
                    formatter: '{value} %'
                }
            }
        ],

        // Add Series
        series: [
            {
                name: 'K1',
                type: 'line',
                data: [0, 6, 1, 1],
                markLine: {
                    data: [
                        { type: 'max', name: 'Max' }
                    ]
                },
                lineStyle: {
                    normal: {
                        width: 3,
                        shadowColor: 'rgba(0,0,0,0.1)',
                        shadowBlur: 10,
                        shadowOffsetY: 10
                    }
                },
            },
            {
                name: 'K2',
                type: 'line',
                data: [0, 6, 5, 5],
                markLine: {
                    data: [
                        { type: 'max', name: 'Max' }
                    ]
                },
                lineStyle: {
                    normal: {
                        width: 3,
                        shadowColor: 'rgba(0,0,0,0.1)',
                        shadowBlur: 10,
                        shadowOffsetY: 10
                    }
                },
            },
            {
                name: 'K3',
                type: 'line',
                data: [0, 26, 22, 19],
                markLine: {
                    data: [
                        { type: 'max', name: 'Max' }
                    ]
                },
                lineStyle: {
                    normal: {
                        width: 3,
                        shadowColor: 'rgba(0,0,0,0.1)',
                        shadowBlur: 10,
                        shadowOffsetY: 10
                    }
                },
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