$(function () {
    "use strict";
    // ------------------------------
    // Basic pie chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var basicpieChart = echarts.init(document.getElementById('maintain-type'));
    if ($(document).width) {
        var option = {
            // Add title
            // title: {
            //     text: 'Mức sử dụng điện năng (Thực tế)',
            //     subtext: 'Open source information',
            //     x: 'center'
            // },
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
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)"
            },

            // Add legend
            legend: {
                orient: 'horizontal',
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['Bảo dưỡng 100h', 'Bảo dưỡng 200h', 'Bảo dưỡng 500h', 'Bảo dưỡng 1000h', 'Bảo dưỡng 2000h', 'Tiểu tu']
            },

            // Add custom colors
            color: ['#ffbc34', '#43cbff', '#4fc3f7', '#FF7777', '#FC7A41', '#62FF5A'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '80%',
                center: ['50%', '40%'],
                data: [
                    { value: bd100, name: 'Bảo dưỡng 100h' },
                    { value: bd200, name: 'Bảo dưỡng 200h' },
                    { value: bd500, name: 'Bảo dưỡng 500h' },
                    { value: bd1000, name: 'Bảo dưỡng 1000h' },
                    { value: bd2000, name: 'Bảo dưỡng 2000h' },
                    { value: tt, name: 'Tiểu tu' }
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
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)"
            },

            // Add legend
            legend: {
                orient: 'horizontal',
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['Bảo dưỡng 100h', 'Bảo dưỡng 200h', 'Bảo dưỡng 500h', 'Bảo dưỡng 1000h', 'Bảo dưỡng 2000h', 'Tiểu tu']
            },

            // Add custom colors
            color: ['#ffbc34', '#43cbff', '#4fc3f7', '#FF7777', '#FC7A41', '#62FF5A'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '80%',
                label: {
                    show: false
                },
                center: ['50%', '40%'],
                data: [
                    { value: 150, name: 'Bảo dưỡng 100h' },
                    { value: 150, name: 'Bảo dưỡng 200h' },
                    { value: 150, name: 'Bảo dưỡng 500h' },
                    { value: 150, name: 'Bảo dưỡng 1000h' },
                    { value: 250, name: 'Bảo dưỡng 2000h' },
                    { value: 200, name: 'Tiểu tu' }
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