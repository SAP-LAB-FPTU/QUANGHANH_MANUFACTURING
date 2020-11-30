$(function() {
    "use strict";
    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
        var barbasicChart = echarts.init(document.getElementById('bar-basic'));

        var option = {

             // Setup grid
                grid: {
                    x: 40,
                    x2: 10,
                    y: 70,
                    y2: 25
                },

                // Add tooltip
                tooltip: {
                    trigger: 'axis',
                    align: 'center'
                },

                // Add legend
                legend: {
                    data: ['Tổng NLPX', 'Tổng CNTT','Tổng CNĐL']
                },

                // Add custom colors
            color: ['#aeddf3', '#4fc3f7','#2962FF'],

                // Horizontal axis
                xAxis: [{
                    type: 'value',
                    boundaryGap: [0, 0.2]
                }],

                // Vertical axis
                yAxis: [{
                    type: 'category',
                    data: ['ĐL 3', 'ĐL 5', 'ĐL 7', 'ĐL 8', 'KT 1', 'KT 2', 'KT 3'
                        , 'KT 4', 'KT 5', 'KT 6', 'KT 7', 'KT 8', 'KT 9',
                        'KT 10', 'KT 11', 'VT 1', 'VT 2']
                }],

                // Add series
                series : [
                    {
                        name:'Tổng NLPX',
                        type:'bar',
                        data:[116, 103, 118, 101,105, 111, 134,116,116,100,100,124,98,72,75,182,127]
                    },
                    {
                        name:'Tổng CNTT',
                        type:'bar',
                        data:[109, 96, 111, 94, 98, 103,127,109,109,93,93,117,91,65,68,175,120]
                    },
                    {
                        name: 'Tổng CNĐL',
                        type: 'bar',
                        data: [102, 87, 105, 88, 92, 102,122,107,101,80,88,107,84,61,62,172,118]
                    }
                ]
        };
        // use configuration item and data specified to show chart
        barbasicChart.setOption(option);
    
    /* var barbasicChart1 = echarts.init(document.getElementById('bar-basic1'));

    var option = {

        // Setup grid
        grid: {
            x: 60,
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
            data: ['Tuần 1', 'Tuần 2', 'Tuần 3', 'Tuần 4','TB Tháng']
        },

        // Add custom colors
        
        color: ['#5bff97', '#08a968', '#4fc3f7', '#2962FF','#fe2121'],

        // Horizontal axis
        xAxis: [{
            type: 'value',
            boundaryGap: [0, 1]
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ['ĐL 3', 'ĐL 5', 'ĐL 7', 'ĐL 8', 'KT 1', 'KT 2', 'KT 3'
                , 'KT 4', 'KT 5', 'KT 6', 'KT 7', 'KT 8', 'KT 9',
                'KT 10', 'KT 11', 'VT 1', 'VT 2']
        }],
      
        // Add series
        series: [
            {
                name: 'Tuần 1',
                type: 'bar',
                data: [88.6, 82.1, 87.6, 81.6, 88.8, 95.2, 82.0, 84.7, 81.7, 82.4, 78.8, 83.7, 79.1, 81.1, 88.8, 88.3, 89.2]
            },
            {
                name: 'Tuần 2',
                type: 'bar',
                data: [88.0, 83.4, 87.0, 83.9, 85.3, 92.0, 86.2, 81.9, 80.7, 81.7, 86.0, 83.8, 85.9, 82.2, 84.9, 85.6, 86.1]
            },
            {
                name: 'Tuần 3',
                type: 'bar',
                data: [85.0, 87.4, 85.0, 83.0, 85.5, 94.4, 81.0, 83.2, 80.7, 86.5, 82.4, 79.4, 81.3, 83.5, 86.5, 85.8, 86.5]
            },
            {
                name: 'Tuần 4',
                type: 'bar',
                data: [86.3, 83.0, 83.2, 81.3, 82.6, 90.7, 82.5, 84.2, 82.1, 80.7, 79.9, 82.6, 74.1, 81.4, 76.0, 84.5, 85.6]
            },
            {
                name: 'TB Tháng',
                type: 'bar',
                data: [87.0, 84.0, 85.7, 82.4, 85.6, 93.1, 82.9, 83.5, 81.3, 82.8, 81.8, 82.4, 80.1, 82.1, 84.0, 86.1, 86.9]
            }
        ]
    };
    // use configuration item and data specified to show chart
    barbasicChart1.setOption(option);

       //------------------------------------------------------
       // Resize chart on menu width change and window resize
       //------------------------------------------------------
*/
    // based on prepared DOM, initialize echarts instance
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
        color: ["#4fc3f7"],
        calculable: true,
        xAxis: [
            {
                type: 'category',
                data: ['ĐL3', 'ĐL5', 'ĐL7', 'ĐL8', 'KT1', 'KT2', 'KT3', 'KT4', 'KT5', 'KT6', 'KT7', 'KT8', 'KT9', 'KT10','KT11','VT1','VT2']
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: 'Site A',
                type: 'bar',
                data: [7, 9, 6, 6, 6, 1, 5, 2, 8, 13, 5, 10,7,4,6,3,2],
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
            }
        ]
    };
    // use configuration item and data specified to show chart
    myChart.setOption(option);
    //--------------------------------------------------------------
    var myChart1 = echarts.init(document.getElementById('basic-bar1'));

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
        color: ["#4fc3f7"],
        calculable: true,
        xAxis: [
            {
                type: 'category',
                data: ['ĐL3', 'ĐL5', 'ĐL7', 'ĐL8', 'KT1', 'KT2', 'KT3', 'KT4', 'KT5', 'KT6', 'KT7', 'KT8', 'KT9', 'KT10', 'KT11', 'VT1', 'VT2']
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: 'Site A',
                type: 'bar',
                data: [87, 84, 85.7, 82.4, 85.6, 93.1, 82.9, 83.5, 81.3, 82.8, 81.8, 82.4, 80.1, 82.1, 84, 86.1, 86.9],
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
            }
        ]
    };
    // use configuration item and data specified to show chart
    myChart1.setOption(option);

        $(function () {

                // Resize chart on menu width change and window resize
                $(window).on('resize', resize);
                $(".sidebartoggler").on('click', resize);

                // Resize function
                function resize() {
                    setTimeout(function() {
                        // Resize chart
                        barbasicChart.resize();
                        myChart.resize();
                        myChart1.resize();
                    }, 200);
                }
            });
});