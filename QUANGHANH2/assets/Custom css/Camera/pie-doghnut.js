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
        $("#type").val(params.name);
        $("#Fbut").click();
        
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