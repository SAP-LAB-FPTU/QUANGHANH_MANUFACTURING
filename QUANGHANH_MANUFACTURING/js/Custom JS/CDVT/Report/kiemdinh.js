$(function () {
    "use strict";
    // ------------------------------
    // Nested chart
    // ------------------------------
    // based on prepared DOM, initialize echarts instance
    var nestedChart1 = echarts.init(document.getElementById('kiemdinh1'));
    if ($(document).width >= 1460) {
        var option1 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ chi phí kiểm định',
            //    y: 'bottom'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} thiết bị ({d}%)"
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
                data: ['Phân xưởng đào lò', 'Phân xưởng vận tải', 'Phân xưởng phục vụ', 'Phân xưởng lộ thiên']
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
                center: ['55%', '45.5%'],
                data: [
                    { value: 1700000, name: 'Phân xưởng đào lò' },
                    { value: 1200000, name: 'Phân xưởng vận tải' },
                    { value: 3000000, name: 'Phân xưởng phục vụ' },
                    { value: 2300000, name: 'Phân xưởng lộ thiên' }
                ]
            }]
        };
    } else {
        var option1 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ chi phí kiểm định',
            //    y: 'bottom'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} thiết bị ({d}%)"
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
                data: ['Phân xưởng đào lò', 'Phân xưởng vận tải', 'Phân xưởng phục vụ', 'Phân xưởng lộ thiên']
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
                center: ['55%', '45.5%'],
                data: [
                    { value: 1700000, name: 'Phân xưởng đào lò' },
                    { value: 1200000, name: 'Phân xưởng vận tải' },
                    { value: 3000000, name: 'Phân xưởng phục vụ' },
                    { value: 2300000, name: 'Phân xưởng lộ thiên' }
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
    var nestedChart2 = echarts.init(document.getElementById('kiemdinh2'));
    if ($(document).width >= 1460) {
        var option2 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ phân bố thiết bị thu hồi các phân xưởng',
            //    y: 'bottom'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} thiết bị ({d}%)"
            },

            // Add legend
            legend: {
                orient: 'horizontal',
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['Đào lò', 'Vận tải', 'Phục vụ', 'Lộ thiên']
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
            // Add custom colors
            color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '60%',
                center: ['55%', '45.5%'],
                data: [
                    { value: 12, name: 'Đào lò' },
                    { value: 8, name: 'Vận tải' },
                    { value: 4, name: 'Phục vụ' },
                    { value: 6, name: 'Lộ thiên' }
                ]
            }]
        };
    } else {
        var option2 = {
            // Add title

            //title: {
            //    text: 'Biểu đồ phân bố thiết bị thu hồi các phân xưởng',
            //    y: 'bottom'
            //},
            // Add tooltip
            tooltip: {
                trigger: 'item',
                align: 'center',
                formatter: "{a} <br/>{b}: {c} thiết bị ({d}%)"
            },

            // Add legend
            legend: {
                orient: 'horizontal',
                x: 'center',
                type: 'scroll',
                bottom: 0,
                data: ['Đào lò', 'Vận tải', 'Phục vụ', 'Lộ thiên']
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
                center: ['55%', '45.5%'],
                data: [
                    { value: 12, name: 'Đào lò' },
                    { value: 8, name: 'Vận tải' },
                    { value: 4, name: 'Phục vụ' },
                    { value: 6, name: 'Lộ thiên' }
                ]
            }]
        };
    }
  

    // Enable drag recalculate




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
    var barbasicChart1 = echarts.init(document.getElementById('kiemdinh1'));
    var barbasicChart2 = echarts.init(document.getElementById('kiemdinh2'));
    setTimeout(function () {
        // Resize chart
        barbasicChart1.resize();
    }, 200);
}