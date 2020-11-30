$(function () {
    "use strict";
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var nestedChart1 = echarts.init(document.getElementById('thuhoi'));
    if ($(document).width) {
        var option1 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ phân bố thiết bị thu hồi các phân xưởng',
            //    y: 'top'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)"
            },
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
            // Add legend
            legend: {
                orient: 'horizontal',
                type: 'scroll',
                bottom: 0,
                x: 'center',
                data: ['Đào lò', 'Vận tải', 'Phục vụ', 'Lộ thiên']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '60%',
                center: ['50%', '45.5%'],
                data: [
                    { value: 11, name: 'Đào lò' },
                    { value: 13, name: 'Vận tải' },
                    { value: 5, name: 'Phục vụ' },
                    { value: 21, name: 'Lộ thiên' }
                ]
            }]
        };
    } else {
        var option1 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ phân bố thiết bị thu hồi các phân xưởng',
            //    y: 'top'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)"
            },
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
            // Add legend
            legend: {
                orient: 'horizontal',
                type: 'scroll',
                bottom: 0,
                x: 'center',
                data: ['Đào lò', 'Vận tải', 'Phục vụ', 'Lộ thiên']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '60%',
                label: {
                    show: false
                },
                center: ['50%', '45.5%'],
                data: [
                    { value: 11, name: 'Đào lò' },
                    { value: 13, name: 'Vận tải' },
                    { value: 5, name: 'Phục vụ' },
                    { value: 21, name: 'Lộ thiên' }
                ]
            }]
        };
    }
   

        // Enable drag recalculate
        



    nestedChart1.setOption(option1);
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    
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
            setTimeout(function () {

                // Resize chart
                nestedChart1.resize();
            }, 200);
        }
    });
});

function ResizeChart() {
    var barbasicChart1 = echarts.init(document.getElementById('thuhoi'));
    setTimeout(function () {
        // Resize chart
        barbasicChart1.resize();
    }, 200);
}