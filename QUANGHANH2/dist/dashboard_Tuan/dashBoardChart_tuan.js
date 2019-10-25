$(function () {
    "use strict";
    //var dilam = ["141","174","170","177","176","146","147","173","151","154","143","142","164","157","161","156","178"];
    //var nghilam = ["11", "4", "11", "10", "11", "12", "7", "8", "9", "13", "12", "14", "9", "14", "11", "1", "11"];

   

    //***************************
    // NHÂN LỰC ĐI LÀM
    //***************************
    var NhanLucDiLam = echarts.init(document.getElementById('basic-bar2'));
    var option7 = {
        // Setup grid
        grid: {
            left: '1%',
            right: '2%',
            bottom: '3%',
            containLabel: true
        },

        // Add Tooltip
        tooltip: {
            trigger: 'axis',
            align: 'center'
        },

        legend: {
            data: ['Tỉ lệ huy động']
        },
        toolbox: {
            show: false,
            feature: {
                magicType: { show: true, type: ['line', 'bar'] },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        color: ["#4fc3f7"],
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
                name: 'Tỉ lệ',
                type: 'bar',
                data: dilam,
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
    NhanLucDiLam.setOption(option7);
    //************************************************************************************************************** */\




    //***************************
    // NHÂN LỰC ĐI NGHỈ
    //***************************
    var NhanLucNghi = echarts.init(document.getElementById('basic-bar3'));
    var option8 = {
        // Setup grid
        grid: {
            left: '1%',
            right: '2%',
            bottom: '3%',
            containLabel: true
        },

        // Add Tooltip
        tooltip: {
            trigger: 'axis',
            align: 'center'
        },

        legend: {
            data: ['Số lao động nghỉ dài theo từng đơn vị']
        },
        toolbox: {
            show: false,
            feature: {
                magicType: { show: true, type: ['line', 'bar'] },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        color: ["#4fc3f7"],
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
                name: 'Số lượng',
                type: 'bar',
                data: nghilam,
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
    NhanLucNghi.setOption(option8);
    //************************************************************************************************************** */\



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
                stackedChart_ChiTietDaXitXuatKho.resize();
                // stackedChart_ChiTietKhaiThac.resize();

                //stackedChart_ChiTietThanSangTuyen.resize();
                //stackedChart_ChiTietThanTieuThu.resize();
                //stackedChart_DatDaBoc.resize();
                NhanLucDiLam.resize();
                NhanLucNghi.resize();
                // stackedareaChart.resize();
                // gradiantChart.resize();
                // myChart.resize();
            }, 200);
        }
    });
});