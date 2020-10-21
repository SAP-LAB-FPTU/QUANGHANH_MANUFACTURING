

$(function () {
    
            "use strict";
            // ------------------------------
            // Basic pie chart
            // ------------------------------
            // based on prepared DOM, initialize echarts instance
    var basicpieChart = echarts.init(document.getElementById('basic-pie4'));
    var width = $(document).width();
    //alert($(document).width() / width);
    var option;
    if ($(document).width()>1460) {
        option = {
            // Add title
            // title: {
            //     text: 'Mức sử dụng điện năng (Thực tế)',
            //     subtext: 'Open source information',
            //     x: 'center'
            // },

            // Add tooltip
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)",
                align: 'center'
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
                data: ['Đang hoạt động', 'Sửa chữa', 'Bảo dưỡng', 'Kiểm định', 'Thanh lí', 'Thu hồi']
            },

            // Add custom colors
            color: ['#7A03FF', '#4FC3F7', '#FF7171', '#F2BC39', '#E7F921', '#6EFF4C'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '70%',
                center: ['50%', '40%'],
                label: {
                    show: true
                },
                data: [
                    { value: total, name: 'Đang hoạt động' },
                    { value: total_repair, name: 'Sửa chữa' },
                    { value: total_main, name: 'Bảo dưỡng' },
                    { value: total_KD, name: 'Kiểm định' },
                    { value: total_TL, name: 'Thanh lí' },
                    { value: total_TH, name: 'Thu hồi' }
                ]
            }]
        }
    } else {
        option = {

            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} chiếc ({d}%)",
                align: 'center'
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
                data: ['Đang hoạt động', 'Sửa chữa', 'Bảo dưỡng', 'Kiểm định', 'Thanh lí', 'Thu hồi']
            },

            // Add custom colors
            color: ['#7A03FF', '#4FC3F7', '#FF7171', '#F2BC39', '#E7F921', '#6EFF4C'],

            // Display toolbox


            // Enable drag recalculate
            calculable: false,

            // Add series
            series: [{
                type: 'pie',
                radius: '70%',
                center: ['50%', '40%'],
                label: {
                    show: false
                },
                data: [
                    { value: 7000, name: 'Đang hoạt động' },
                    { value: 1000, name: 'Sửa chữa' },
                    { value: 1000, name: 'Bảo dưỡng' },
                    { value: 1000, name: 'Kiểm định' },
                    { value: 1000, name: 'Thanh lí' },
                    { value: 1000, name: 'Thu hồi' }
                ]
            }]
        }
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