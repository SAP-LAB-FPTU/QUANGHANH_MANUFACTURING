$(function() {
    "use strict";
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var nestedChart1 = echarts.init(document.getElementById('water'));
    var option1 = {
        
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b}: {c} m<sup>3</sup> ({d}%)",
            align: 'center'
        },

        // Add legend
        legend: {
            type: 'scroll',
            bottom: 0,
            data: ['Bơm nước hầm lò','Trạm bơm thoát nước chính','Trạm bơm thoát nước chuyển tiếp','Trạm bơm thoát nước khu vực','Bơm nước lộ thiên']
        },

        // Add custom colors
        color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51', '#2962FF'],

        // Display toolbox
        toolbox: {
            left: 0,
            show: true,
            feature: {
                mark: {
                    show: true,
                    title: {
                        mark: 'Markline switch',
                        markUndo: 'Undo markline',
                        markClear: 'Clear markline'
                    }
                },
                dataView: {
                    show: true,
                    readOnly: false,
                    title: 'Xem số liệu',
                    lang: ['View chart data', 'Close', 'Update']
                },
                magicType: {
                    show: true,
                    title: {
                        pie: 'Switch to pies',
                        funnel: 'Switch to funnel',
                    },
                    type: ['pie', 'funnel']
                },
                restore: {
                    show: true,
                    title: 'Tải lại'
                },
                saveAsImage: {
                    show: true,
                    title: 'Tải về',
                    lang: ['Save']
                }
            }
        },
        // Enable drag recalculate
        calculable: false,

        // Add series
        series: [

            // Inner
            {
                name: 'Khâu bơm nước',
                type: 'pie',
                radius: [0, '40%'],

                // for funnel
                x: '15%',
                y: '7.5%',
                width: '40%',
                height: '85%',
                center: ['50%', '45%'],
                funnelAlign: 'right',
                max: 2805204,

                itemStyle: {
                    normal: {
                        label: {
                            position: 'inner'
                        },
                        labelLine: {
                            show: false
                        }
                    },
                    emphasis: {
                        label: {
                            show: true
                        }
                    }
                },

                data: [
                    {value: 2805204, name: 'Bơm nước hầm lò'},
                    {value: 551319, name: 'Bơm nước lộ thiên'}
                ]
            },

            // Outer
            {
                name: 'Trạm bơm',
                type: 'pie',
                radius: ['55%', '75%'],

                // for funnel
                x: '55%',
                y: '7.5%',
                width: '35%',
                height: '85%',
                center: ['50%', '45%'],
                funnelAlign: 'left',
                max: 2615874,

                data: [
                    {value: 2615874, name: 'Trạm bơm thoát nước chính'},
                    {value: 36750, name: 'Trạm bơm thoát nước khu vực'},
                    {value: 152580, name: 'Trạm bơm thoát nước chuyển tiếp'},
                    {value: 551319, name: 'Bơm nước lộ thiên'}
                ]
            }
        ]
    };    
       
    
    nestedChart1.setOption(option1);
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var nestedChart2 = echarts.init(document.getElementById('electric'));
    var option2 = {

        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b}: {c} kWh ({d}%)",
            align: 'center'
        },

        // Add legend
        legend: {
            type: 'scroll',
            bottom: 0,
            data: ['Bơm nước hầm lò', 'Trạm bơm thoát nước chính', 'Trạm bơm thoát nước chuyển tiếp', 'Trạm bơm thoát nước khu vực', 'Máy chính phục vụ bơm CT', 'Bơm nước lộ thiên']
        },

        // Add custom colors
        color: ['#ffbc34', '#4fc3f7', '#2962FF', '#f62d51', '#212529', '#827703'],

        // Display toolbox
        toolbox: {
            left: 0,
            show: true,
            feature: {
                mark: {
                    show: true,
                    title: {
                        mark: 'Markline switch',
                        markUndo: 'Undo markline',
                        markClear: 'Clear markline'
                    }
                },
                dataView: {
                    show: true,
                    readOnly: false,
                    title: 'Xem số liệu',
                    lang: ['View chart data', 'Close', 'Update']
                },
                magicType: {
                    show: true,
                    title: {
                        pie: 'Switch to pies',
                        funnel: 'Switch to funnel',
                    },
                    type: ['pie', 'funnel']
                },
                restore: {
                    show: true,
                    title: 'Tải lại'
                },
                saveAsImage: {
                    show: true,
                    title: 'Tải về',
                    lang: ['Save']
                }
            }
        },

        // Enable drag recalculate
        calculable: false,

        // Add series
        series: [

            // Inner
            {
                name: 'Khâu bơm nước',
                type: 'pie',
                radius: [0, '40%'],

                // for funnel
                x: '15%',
                y: '7.5%',
                width: '40%',
                height: '85%',
                funnelAlign: 'right',
                center: ['50%', '45%'],
                max: 3627688,

                itemStyle: {
                    normal: {
                        label: {
                            position: 'inner'
                        },
                        labelLine: {
                            show: false
                        }
                    },
                    emphasis: {
                        label: {
                            show: true
                        }
                    }
                },

                data: [
                    { value: 3627688, name: 'Bơm nước hầm lò' },
                    { value: 383460, name: 'Bơm nước lộ thiên' }
                ]
            },

            // Outer
            {
                name: 'Trạm bơm',
                type: 'pie',
                radius: ['55%', '75%'],

                // for funnel
                x: '55%',
                y: '7.5%',
                width: '35%',
                height: '85%',
                funnelAlign: 'left',
                center: ['50%', '45%'],
                max: 1822878,

                data: [
                    { value: 67375, name: 'Trạm bơm thoát nước chuyển tiếp' },
                    { value: 176295, name: 'Trạm bơm thoát nước khu vực' },
                    { value: 1822878, name: 'Trạm bơm thoát nước chính' },
                    { value: 1561140, name: 'Máy chính phục vụ bơm CT'},
                    { value: 383460, name: 'Bơm nước lộ thiên' }
                ]
            }
        ]
    };


    nestedChart2.setOption(option2);
    //------------------------------------------------------
    // Resize chart on menu width change and window resize
    //------------------------------------------------------
    $(function () {

        // Resize chart on menu width change and window resize
        $(window).on('resize', resize);
        $(".sidebartoggler").on('click', resize);

        // Resize function
        function resize() {
            if ($(document).width() < 1460) {
                nestedChart1.setOption({
                    series: {
                        label: {
                            show: false,
                        },
                        labelLine: {
                            show: false
                        }
                    }
                });
                nestedChart2.setOption({
                    series: {
                        label: {
                            show: false,
                        },
                        labelLine: {
                            show: false
                        }
                    }
                });
            } else {
                nestedChart1.setOption({
                    series: {
                        label: {
                            show: true,
                        },
                        labelLine: {
                            show: true
                        }
                    }
                });
                nestedChart2.setOption({
                    series: {
                        label: {
                            show: true,
                        },
                        labelLine: {
                            show: true
                        }
                    }
                });
            }
            setTimeout(function () {
                
                // Resize chart
                nestedChart1.resize();
                nestedChart2.resize();
            }, 200);
        }
    });
});

function ResizeChart() {
    var barbasicChart1 = echarts.init(document.getElementById('water'));
    var barbasicChart1 = echarts.init(document.getElementById('electric'));
    if ($(document).width() < 1460) {
        barbasicChart1.setOption({
            series: {
                label: {
                    show: false,
                },
                labelLine: {
                    show: false
                }
            }
        });
    } else {
        barbasicChart1.setOption({
            series: {
                label: {
                    show: true,
                },
                labelLine: {
                    show: true
                }
            }
        });
    }
    setTimeout(function () {

        // Resize chart
        barbasicChart1.resize();
    }, 200);
}