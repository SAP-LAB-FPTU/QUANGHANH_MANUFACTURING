$(function() {
    "use strict";
    // ------------------------------
    // Basic line chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var barbasicChart = echarts.init(document.getElementById('bar-basic'));
    var ldtt_list=[];
    var ldtt_nghi_dai=[];
    var ldbq=[];
    var ld_sanxuat=[];
    var tile_huydong=[];
    var donvi=["ĐL3", "ĐL5", "ĐL7", "ĐL8", "KT1", "KT2", "KT3", "KT4", "KT5", "KT6", "KT7", "KT8", "KT9", "KT10", "KT11", "VTL1", "VTL2"];
    var i=0;
    $('.table_container').find('.total_ldtt').each(function () {
        ldtt_list[i] = $(this).text();
        i++;
    });
    i = 0;
    $('.table_container').find('.total_ldtt_nghi_dai').each(function () {
        ldtt_nghi_dai[i] = $(this).text();
        i++;
    });
    i = 0;
    $('.table_container').find('.ldbq_di_lam').each(function () {
        ldbq[i] = $(this).text();
        i++;
    });
    i = 0;
    $('.table_container').find('.ld_sanxuat').each(function () {
        ld_sanxuat[i] = $(this).text();
        i++;
    });
    i = 0;
    $('.table_container').find('.tilehuydong').each(function () {
        tile_huydong[i] = $(this).text();
        i++;
    });
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
                trigger: 'axis',
                align:'center'
            },

            // Add legend
            legend: {
                data: ['LĐTT Theo danh sách', 'Lao động tham gia SX']
            },

            // Add custom colors
            color: ['#2962FF', '#4fc3f7'],

            // Horizontal axis
            xAxis: [{
                type: 'value',
                boundaryGap: [0, 0.01]
            }],

            // Vertical axis
            yAxis: [{
                type: 'category',
                data: myArray
            }],

            // Add series
            series : [
                {
                    name:'LĐTT Theo danh sách',
                    type:'bar',
                    data:ldtt_list
                },
                {
                    name:'Lao động tham gia SX',
                    type:'bar',
                    data:ld_sanxuat
                },
            ]
    };
    // use configuration item and data specified to show chart
    barbasicChart.setOption(option);


    // ------------------------------
    // Basic bar chart
    // ------------------------------
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
            tooltip : {
                trigger: 'axis',
                align:'center'
            },

            legend: {
                data:['Lao động BQ']
            },
            toolbox: {
                show : false,
                feature : {
                    magicType : {show: true, type: ['line', 'bar']},
                    restore : {show: true},
                    saveAsImage : {show: true}
                }
            },
            color: ["#4fc3f7"],
            calculable : true,
            xAxis : [
                {
                    type : 'category',
                    data: myArray
                }
            ],
            yAxis : [
                {
                    type : 'value'
                }
            ],
            series : [
                {
                    name:'Lao động BQ đi làm',
                    type:'bar',
                    data:ldbq,
                    markPoint : {
                        data : [
                            {type : 'max', name: 'Max'},
                            {type : 'min', name: 'Min'}
                        ]
                    },
                    markLine : {
                        data : [
                            {type : 'average', name: 'Average'}
                        ]
                    }
                },      
            ]
        };
    // use configuration item and data specified to show chart
    myChart.setOption(option);
   //------------------------------------------------------
   // Resize chart on menu width change and window resize
   //------------------------------------------------------



   ////////////////////////////////////////////////////////////////////////////
// ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var myChart2 = echarts.init(document.getElementById('basic-bar2'));
        var option2 = {
            // Setup grid
            grid: {
                left: '1%',
                right: '2%',
                bottom: '3%',
                containLabel: true
            },

            // Add Tooltip
            tooltip : {
                trigger: 'axis',
                align:'center'
            },

            legend: {
                data:['Tỉ lệ huy động']
            },
            toolbox: {
                show : false,
                feature : {
                    magicType : {show: true, type: ['line', 'bar']},
                    restore : {show: true},
                    saveAsImage : {show: true}
                }
            },
            color: ["#4fc3f7"],
            calculable : true,
            xAxis : [
                {
                    type : 'category',
                    data: myArray
                }
            ],
            yAxis : [
                {
                    type : 'value'
                }
            ],
            series : [
                {
                    name:'Tỉ lệ',
                    type:'bar',
                    data:tile_huydong,
                    markPoint : {
                        data : [
                            {type : 'max', name: 'Max'},
                            {type : 'min', name: 'Min'}
                        ]
                    },
                    markLine : {
                        data : [
                            {type : 'average', name: 'Average'}
                        ]
                    }
                },      
            ]
        };
    // use configuration item and data specified to show chart
    myChart2.setOption(option2);
   //------------------------------------------------------
   // Resize chart on menu width change and window resize
   //------------------------------------------------------
   ////////////////////////////////////////////////////////////////////////////

  ////////////////////////////////////////////////////////////////////////////
// ------------------------------
    // Basic bar chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var myChart3 = echarts.init(document.getElementById('basic-bar3'));
        var option3 = {
            // Setup grid
            grid: {
                left: '1%',
                right: '2%',
                bottom: '3%',
                containLabel: true
            },

            // Add Tooltip
            tooltip : {
                trigger: 'axis',
                align:'center'
            },

            legend: {
                data:['Số lao động nghỉ dài theo từng đơn vị']
            },
            toolbox: {
                show : false,
                feature : {
                    magicType : {show: true, type: ['line', 'bar']},
                    restore : {show: true},
                    saveAsImage : {show: true}
                }
            },
            color: ["#4fc3f7"],
            calculable : true,
            xAxis : [
                {
                    type : 'category',
                    data: myArray
                }
            ],
            yAxis : [
                {
                    type : 'value'
                }
            ],
            series : [
                {
                    name:'Số lượng',
                    type:'bar',
                    data:ldtt_nghi_dai,
                    markPoint : {
                        data : [
                            {type : 'max', name: 'Max'},
                            {type : 'min', name: 'Min'}
                        ]
                    },
                    markLine : {
                        data : [
                            {type : 'average', name: 'Average'}
                        ]
                    }
                },      
            ]
        };
    // use configuration item and data specified to show chart
    myChart3.setOption(option3);
   //------------------------------------------------------
   // Resize chart on menu width change and window resize
   //------------------------------------------------------
   ////////////////////////////////////////////////////////////////////////////



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
                    myChart2.resize();
                    myChart3.resize();
                    stackedChart.resize();
                    stackedbarcolumnChart.resize();
                    
                }, 200);
            }
        });
    
    
});