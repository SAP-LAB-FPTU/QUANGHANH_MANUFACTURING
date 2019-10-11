$(function () {
    "use strict";
    var donvi = ["ĐL3", "ĐL5", "ĐL7", "ĐL8", "KT1", "KT2", "KT3", "KT4", "KT5", "KT6", "KT7", "KT8", "KT9", "KT10", "KT11", "VTL1", "VTL2"];
    var dilam = ["141","174","170","177","176","146","147","173","151","154","143","142","164","157","161","156","178"];
    var nghilam = ["11", "4", "11", "10", "11", "12", "7", "8", "9", "13", "12", "14", "9", "14", "11", "1", "11"];

    //***************************
    // CHI TIẾT KHAI THÁC
    //***************************
    // try{
    //     var stackedChart_ChiTietKhaiThac = echarts.init(document.getElementById('chart_chi_tiet_khai_thac'));
    //     var option = {
    
    //         grid: {
    //             left: '1%',
    //             right: '2%',
    //             bottom: '3%',
    //             containLabel: true
    //         },
    //         tooltip: {
    //             trigger: 'axis'
    //         },
    //         // Add legend
    //         legend: {
    //             data: ['KT', 'CĐ', 'HSTT']
    //         },
    
    //         // Add custom colors
    //         color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],
    
    //         // Enable drag recalculate
    //         calculable: true,
    
    //         // Hirozontal axis
    //         xAxis: [{
    //             type: 'category',
    //             boundaryGap: false,
    //             data: [
    //                 'Ca 1', 'Ca 2', 'Ca 3'
    //             ]
    //         }],
    
    //         // Vertical axis
    //         yAxis: [{
    //             type: 'value'
    //         }],
    
    //         // Add series
    //         series: [
    //             {
    //                 name: 'KT',
    //                 type: 'line',
    //                 stack: 'Total',
    //                 data: [120, 132, 101, 134, 90, 230, 210]
    //             },
    //             {
    //                 name: 'CĐ',
    //                 type: 'line',
    //                 stack: 'Total',
    //                 data: [220, 182, 191, 234, 290, 330, 310]
    //             },
    //             {
    //                 name: 'HSTT',
    //                 type: 'line',
    //                 stack: 'Total',
    //                 data: [150, 232, 201, 154, 190, 330, 410]
    //             },
    
    //         ]
    //         // Add series
    
    //     };
    //     stackedChart_ChiTietKhaiThac.setOption(option);
    // }catch{
    //     console.log("loi roi");
    // }
     //************************************************************************************************************** */




    //***************************
    // CHI TIẾT KHAI ĐÀO LÒ
    ////***************************
    //var bareaChart = echarts.init(document.getElementById('basic-area'));
    //var option = {
    //    // Setup grid
    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },

    //    // Add Tooltip
    //    tooltip: {
    //        trigger: 'axis'
    //    },

    //    // Add Legend
    //    legend: {
    //        data: ['Max temp', 'Min temp']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#4fc3f7'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Horizontal Axiz
    //    xAxis: [
    //        {
    //            type: 'category',
    //            boundaryGap: false,
    //            data: ['Ca 1','Ca 2','Ca 3']
    //        }
    //    ],

    //    // Vertical Axis
    //    yAxis: [
    //        {
    //            type: 'value',
    //            axisLabel: {
    //                formatter: '{value} Mét'
    //            }
    //        }
    //    ],

    //    // Add Series
    //    series: [
    //        {
    //            name: 'Mét lò',
    //            type: 'line',
    //            areaStyle: {},
    //            data: [1,3,6],
    //            markPoint: {
    //                data: [
    //                    { type: 'max', name: 'Max' },
    //                    { type: 'min', name: 'Min' }
    //                ]
    //            },
    //            markLine: {
    //                data: [
    //                    { type: 'average', name: 'Average' }
    //                ]
    //            }
    //        },
    //        // {
    //        //     name: 'Min temp',
    //        //     type: 'line',
    //        //     areaStyle: {},
    //        //     data: [1,2,4],
    //        //     markPoint: {
    //        //         data: [
    //        //             { name: 'Week low', value: -2, xAxis: 1, yAxis: -1.5 }
    //        //         ]
    //        //     },
    //        //     markLine: {
    //        //         data: [
    //        //             { type: 'average', name: 'Average' }
    //        //         ]
    //        //     }
    //        // }
    //    ]
    //};
    //bareaChart.setOption(option);
    //************************************************************************************************************** */




    //***************************
    // CHI TIẾT THAN NHẬP
    //***************************
    //var stackedChart_ChiTietThanNhap = echarts.init(document.getElementById('chart_than_nhap'));
    //var option2 = {

    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },
    //    tooltip: {
    //        trigger: 'axis'
    //    },
    //    // Add legend
    //    legend: {
    //        data: ['KT', 'CĐ', 'HSTT']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Hirozontal axis
    //    xAxis: [{
    //        type: 'category',
    //        boundaryGap: false,
    //        data: [
    //            'Ca 1', 'Ca 2', 'Ca 3'
    //        ]
    //    }],

    //    // Vertical axis
    //    yAxis: [{
    //        type: 'value'
    //    }],

    //    // Add series
    //    series: [
    //        {
    //            name: 'KT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [120, 132, 101, 134, 90, 230, 210]
    //        },
    //        {
    //            name: 'CĐ',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [220, 182, 191, 234, 290, 330, 310]
    //        },
    //        {
    //            name: 'HSTT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [150, 232, 201, 154, 190, 330, 410]
    //        },

    //    ]
    //    // Add series

    //};
    //stackedChart_ChiTietThanNhap.setOption(option2);
    //************************************************************************************************************** */



    //***************************
    // CHI TIẾT THAN TIÊU THỤ
    //***************************
    //var stackedChart_ChiTietThanTieuThu = echarts.init(document.getElementById('chart_than_tieu_thu'));
    //var option3 = {

    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },
    //    tooltip: {
    //        trigger: 'axis'
    //    },
    //    // Add legend
    //    legend: {
    //        data: ['KT', 'CĐ', 'HSTT']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Hirozontal axis
    //    xAxis: [{
    //        type: 'category',
    //        boundaryGap: false,
    //        data: [
    //            'Ca 1', 'Ca 2', 'Ca 3'
    //        ]
    //    }],

    //    // Vertical axis
    //    yAxis: [{
    //        type: 'value'
    //    }],

    //    // Add series
    //    series: [
    //        {
    //            name: 'KT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [120, 132, 101, 134, 90, 230, 210]
    //        },
    //        {
    //            name: 'CĐ',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [220, 182, 191, 234, 290, 330, 310]
    //        },
    //        {
    //            name: 'HSTT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [150, 232, 201, 154, 190, 330, 410]
    //        },

    //    ]
    //    // Add series

    //};
    //stackedChart_ChiTietThanTieuThu.setOption(option3);
    //************************************************************************************************************** */




    //***************************
    // CHI TIẾT THAN SÀNG TUYỂN
    //***************************
    //var stackedChart_ChiTietThanSangTuyen = echarts.init(document.getElementById('chart_than_sang_tuyen'));
    //var option4 = {

    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },
    //    tooltip: {
    //        trigger: 'axis'
    //    },
    //    // Add legend
    //    legend: {
    //        data: ['KT', 'CĐ', 'HSTT']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Hirozontal axis
    //    xAxis: [{
    //        type: 'category',
    //        boundaryGap: false,
    //        data: [
    //            'Ca 1', 'Ca 2', 'Ca 3'
    //        ]
    //    }],

    //    // Vertical axis
    //    yAxis: [{
    //        type: 'value'
    //    }],

    //    // Add series
    //    series: [
    //        {
    //            name: 'KT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [120, 132, 101, 134, 90, 230, 210]
    //        },
    //        {
    //            name: 'CĐ',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [220, 182, 191, 234, 290, 330, 310]
    //        },
    //        {
    //            name: 'HSTT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [150, 232, 201, 154, 190, 330, 410]
    //        },

    //    ]
    //    // Add series

    //};
    //stackedChart_ChiTietThanSangTuyen.setOption(option4);
    //************************************************************************************************************** */\





    //***************************
    // CHI TIẾT ĐÁ XÍT XUẤT KHO
    //***************************
    //var stackedChart_ChiTietDaXitXuatKho = echarts.init(document.getElementById('chart_than_da_xit_xuat_kho'));
    //var option5 = {

    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },
    //    tooltip: {
    //        trigger: 'axis'
    //    },
    //    // Add legend
    //    legend: {
    //        data: ['KT', 'CĐ', 'HSTT']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Hirozontal axis
    //    xAxis: [{
    //        type: 'category',
    //        boundaryGap: false,
    //        data: [
    //            'Ca 1', 'Ca 2', 'Ca 3'
    //        ]
    //    }],

    //    // Vertical axis
    //    yAxis: [{
    //        type: 'value'
    //    }],

    //    // Add series
    //    series: [
    //        {
    //            name: 'KT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [120, 132, 101, 134, 90, 230, 210]
    //        },
    //        {
    //            name: 'CĐ',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [220, 182, 191, 234, 290, 330, 310]
    //        },
    //        {
    //            name: 'HSTT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [150, 232, 201, 154, 190, 330, 410]
    //        },

    //    ]
    //    // Add series

    //};
    //stackedChart_ChiTietDaXitXuatKho.setOption(option5);
    //************************************************************************************************************** */\





    //***************************
    // CHI TIẾT ĐẤT ĐÁ BÓC
    //***************************
    //var stackedChart_DatDaBoc = echarts.init(document.getElementById('chart_dat_da_boc'));
    //var option6 = {

    //    grid: {
    //        left: '1%',
    //        right: '2%',
    //        bottom: '3%',
    //        containLabel: true
    //    },
    //    tooltip: {
    //        trigger: 'axis'
    //    },
    //    // Add legend
    //    legend: {
    //        data: ['KT', 'CĐ', 'HSTT']
    //    },

    //    // Add custom colors
    //    color: ['#2962FF', '#7460ee', '#f62d51', '#36bea6', '#212529'],

    //    // Enable drag recalculate
    //    calculable: true,

    //    // Hirozontal axis
    //    xAxis: [{
    //        type: 'category',
    //        boundaryGap: false,
    //        data: [
    //            'Ca 1', 'Ca 2', 'Ca 3'
    //        ]
    //    }],

    //    // Vertical axis
    //    yAxis: [{
    //        type: 'value'
    //    }],

    //    // Add series
    //    series: [
    //        {
    //            name: 'KT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [120, 132, 101, 134, 90, 230, 210]
    //        },
    //        {
    //            name: 'CĐ',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [220, 182, 191, 234, 290, 330, 310]
    //        },
    //        {
    //            name: 'HSTT',
    //            type: 'line',
    //            stack: 'Total',
    //            data: [150, 232, 201, 154, 190, 330, 410]
    //        },

    //    ]
    //    // Add series

    //};
    //stackedChart_DatDaBoc.setOption(option6);
    //************************************************************************************************************** */\


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