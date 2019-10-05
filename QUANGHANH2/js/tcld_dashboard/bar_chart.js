$(function () {
    "use strict";
    // ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance

    var donvi = [];
    for (var i = 0; i < listNhanLuc.length; i++) {
        donvi.push(listNhanLuc[i].MaDonVi);
    }
    var soluong = [];
    for (var i = 0; i < listNhanLuc.length; i++) {
        soluong.push(listNhanLuc[i].SoLuong);
    }
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
                data: soluong,
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