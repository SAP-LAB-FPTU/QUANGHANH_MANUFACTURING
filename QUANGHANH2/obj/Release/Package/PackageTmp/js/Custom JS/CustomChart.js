$(function () {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance

    // ------------------------------
    // Stacked bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var stackedChartBaoCaoSuCo = echarts.init(document.getElementById('baocaosuco'));

    // specify chart configuration item and data
    var option1 = {
        // Setup grid
        grid: {
            x: 40,
            x2: 40,
            y: 45,
            y2: 80
        },

        // Add tooltip
        tooltip: {
            trigger: 'axis',
            axisPointer: {            // Axis indicator axis trigger effective
                type: 'shadow'        // The default is a straight line, optionally: 'line' | 'shadow'
            },
            align: 'center'
        },

        // Add legend
        legend: {
            data: ['Xử lý xong', 'Chưa xử lý', 'Xử lý tạm thời']
        },

        // Add custom colors
        color: ['#4CAF50', '#F44336', '#ffeb3b'],

        // Horizontal axis
        xAxis: [{
            type: 'value',
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ['KT1', 'KT2', 'KT3', 'KT4', 'KT6', 'KT7', 'KT8', 'KT11', 'CĐM', 'Sàng Tuyển', 'VT1']
        }],

        // Add series
        series: [
            {
                name: 'Xử lý xong',
                type: 'bar',
                stack: 'Total',
                itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
                data: [2, 2, 1, 1, 1, 1, 9, 2, 1, 2, 4]
            },
            {
                name: 'Chưa xử lý',
                type: 'bar',
                stack: 'Total',
                itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
                data: ["", 1, "", "", "", "", 1, "", "", "", ""]
            },
            {
                name: 'Xử lý tạm thời',
                type: 'bar',
                stack: 'Total',
                itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
                data: ["", "", "", "", "", "", 1, "", "", "", ""]
            }
        ]
    };
    // use configuration item and data specified to show chart
    stackedChartBaoCaoSuCo.setOption(option1);

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
                // stackedChart chart
                stackedChartBaoCaoSuCo.resize();
            }, 200);
        }
    });
});