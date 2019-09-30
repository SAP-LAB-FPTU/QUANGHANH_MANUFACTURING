$(function () {
    "use strict";
    // ------------------------------
    // Basic pie chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var basicpieChart = echarts.init(document.getElementById('repair-num-pie'));
    if ($(document).width) {
        var option = {
            // Add title
            // title: {
            //     text: 'Mức sử dụng điện năng (Thực tế)',
            //     subtext: 'Open source information',
            //     x: 'center'
            // },

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
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['SC Lớn', 'SCTX']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '75%',
                center: ['50%', '40%'],
                data: [
                    { value: scl, name: 'SC Lớn' },
                    { value: sctx, name: 'SCTX' }
                ]
            }]
        };
    } else {
        var option = {
            // Add title
            // title: {
            //     text: 'Mức sử dụng điện năng (Thực tế)',
            //     subtext: 'Open source information',
            //     x: 'center'
            // },

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
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['SC Lớn', 'SCTX']
            },

            // Add custom colors
            color: ['#ffbc34', '#4fc3f7'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '75%',
                label: {
                    show: false
                },
                center: ['50%', '40%'],
                data: [
                    { value: scl, name: 'SC Lớn' },
                    { value: sctx, name: 'SCTX' }
                ]
            }]
        };
    }
 

    basicpieChart.setOption(option);
    // ------------------------------
    // Basic pie chart
    $(function () {

        // Resize chart on menu width change and window resize
        $(window).on('resize', resize);
        $(".sidebartoggler").on('click', resize);

        // Resize function
        function resize() {
            if ($(document).width() < 1460) {
                basicpieChart.setOption({
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
                basicpieChart.setOption({
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
                basicpieChart.resize();
            }, 200);
        }
    });
});