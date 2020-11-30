$(function () {
            "use strict";
            // ------------------------------
            // Basic pie chart
            // ------------------------------
            // based on prepared DOM, initialize echarts instance
            var basicpieChart = echarts.init(document.getElementById('basic-pie2'));
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
                    formatter: "{a} <br/>{b}: {c} kWh ({d}%)"
                },

                // Add legend
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    data: ['Bơm nước hầm lò', 'Bơm nước lộ thiên']
                },

                // Add custom colors
                color: ['#ffbc34', '#4fc3f7', '#212529', '#f62d51', '#2962FF', '#afc6d8', '#518de1', '#a2d22e', '#573dd4', '#241ede', '#742037', '#02e73f', '#414590'],

                // Display toolbox
                toolbox: {
                    show: false,
                    orient: 'vertical',
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
                            title: 'View data',
                            lang: ['View chart data', 'Close', 'Update']
                        },
                        magicType: {
                            show: true,
                            title: {
                                pie: 'Switch to pies',
                                funnel: 'Switch to funnel',
                            },
                            type: ['pie', 'funnel'],
                            option: {
                                funnel: {
                                    x: '25%',
                                    y: '20%',
                                    width: '50%',
                                    height: '70%',
                                    funnelAlign: 'left',
                                    max: 1548
                                }
                            }
                        },
                        restore: {
                            show: true,
                            title: 'Restore'
                        },
                        saveAsImage: {
                            show: true,
                            title: 'Same as image',
                            lang: ['Save']
                        }
                    }
                },

                // Enable drag recalculate
                calculable: true,

                // Add series
                series: [{
                    type: 'pie',
                    radius: '60%',
                    center: ['55%', '57.5%'],
                    data: [
                        { value: 3627688, name: 'Bơm nước hầm lò' },
                        { value: 383460, name: 'Bơm nước lộ thiên' }
                    ]
                }]
            };

            basicpieChart.setOption(option);
            // ------------------------------
            // Basic pie chart
            $(function () {

                // Resize chart on menu width change and window resize
                $(window).on('resize', resize);
                $(".sidebartoggler").on('click', resize);

                // Resize function
                function resize() {
                    setTimeout(function () {

                        // Resize chart
                        basicpieChart.resize();
                        // basicdoughnutChart.resize();
                        // customizedChart.resize();
                        // nestedChart.resize();
                        // poleChart.resize();
                    }, 200);
                }
            });
        });