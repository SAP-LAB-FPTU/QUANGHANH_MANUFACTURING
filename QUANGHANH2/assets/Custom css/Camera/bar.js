function chartYear() {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var myChart = echarts.init(document.getElementById('basic-bar'));

    // specify chart configuration item and data
    var option = {
        // Add title
        title: {
            text: 'Thống kê sự cố',
            x: 'center'
        },

        // Setup grid
        grid: {
            left: '1%',
            right: '15%',
            bottom: '3%',
            containLabel: true
        },

        // Add Tooltip
        tooltip: {
            trigger: 'axis'
        },

        legend: {
            orient: 'vertical',
            x: 'right',
            data: ['Chưa xử lý', 'Đã xử lý']
        },
        color: ['#58bbff', '#fcb051'],
        calculable: true,
        xAxis: [
            {
                name: '',
                type: 'category',
                data: ['']
            }
        ],
        yAxis: [
            {
                name: 'Số lượng',
                type: 'value'
            }
        ],
        series: [
            {
                name: 'Đã xử lý',
                type: 'bar',
                data: done,
                
            },
            {
                name: 'Chưa xử lý',
                type: 'bar',
                data: notdone,
                
            }
        ]
    };
    // use configuration item and data specified to show chart
    myChart.setOption(option);
    myChart.on('click', function (params) {
        $("#hiddenmonth").val(params.name);
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
                myChart.resize();
                stackedChart.resize();
                stackedbarcolumnChart.resize();
                barbasicChart.resize();
            }, 200);
        }
    });
    //alert("bac");

}