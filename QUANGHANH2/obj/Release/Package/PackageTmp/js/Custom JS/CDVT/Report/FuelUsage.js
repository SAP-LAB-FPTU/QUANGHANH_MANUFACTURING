$(function() {
    "use strict";
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var nestedChart1 = echarts.init(document.getElementById('fuel'));
    if ($(document).width() >= 1460) {
        var option1 = {

            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} Lít ({d}%)",
                align: 'center'
            },

            // Add legend
            legend: {
                type: 'scroll',
                bottom: 0,
                data: ['Xăng', 'Dầu nhũ hóa', 'Dầu mỡ']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7', '#212529'],

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
                    name: 'Loại nhiên liệu',
                    type: 'pie',
                    radius: [0, '75%'],

                    // for funnel
                    x: '15%',
                    y: '7.5%',
                    width: '40%',
                    height: '85%',
                    center: ['50%', '45%'],
                    funnelAlign: 'right',
                    max: 1668000,

                    data: [
                        { value: 1140000, name: 'Xăng' },
                        { value: 1668000, name: 'Dầu nhũ hóa' },
                        { value: 156000, name: 'Dầu mỡ' }
                    ]
                }
            ]
        };
    } else {
        var option1 = {

            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} Lít ({d}%)",
                align: 'center'
            },

            // Add legend
            legend: {
                type: 'scroll',
                bottom: 0,
                data: ['Xăng', 'Dầu nhũ hóa', 'Dầu mỡ']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7', '#212529'],

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
                    name: 'Loại nhiên liệu',
                    type: 'pie',
                    radius: [0, '75%'],

                    label: {
                        show: false
                    },

                    // for funnel
                    x: '15%',
                    y: '7.5%',
                    width: '40%',
                    height: '85%',
                    center: ['50%', '45%'],
                    funnelAlign: 'right',
                    max: 1668000,

                    data: [
                        { value: 1140000, name: 'Xăng' },
                        { value: 1668000, name: 'Dầu nhũ hóa' },
                        { value: 156000, name: 'Dầu mỡ' }
                    ]
                }
            ]
        };    
    }
    
       
    
    nestedChart1.setOption(option1);
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
            }
            setTimeout(function() {

                // Resize chart
                nestedChart1.resize();
            }, 200);
        }
    });
});

function ResizeChart() {

    var barbasicChart1 = echarts.init(document.getElementById('fuel'));
    setTimeout(function () {
        // Resize chart
        barbasicChart1.resize();
    }, 200);
}