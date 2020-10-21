
$(function () {
    var basicpieChart = echarts.init(document.getElementById('basic-pie'));
    var option;
    option = {
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} ({d}%)",
                align:'center'
            },  
            // Add legend
            legend: {
                orient: 'vertical',
                x: '5%',
                y: '88%',
                data: ['Huy động dưới 82%', 'Huy động trên 82%']
            },
            // Add custom colors
            color: ['#f62d51', '#2962FF'],

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
                        show: false,
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
                                x: '35%',
                                y: '20%',
                                width: '50%',
                                height: '70%',
                                funnelAlign: 'left',
                                max: 1548
                            }
                        }
                    },
                    restore: {
                        show: false,
                        title: 'Restore'
                    },
                    saveAsImage: {
                        show: false,
                        title: 'Same as image',
                        lang: ['Save']
                    }
                }
            },

            // Enable drag recalculate
            calculable: true,

            // Add series
            series: [{
                name: 'Các phòng ban',
                type: 'pie',
                radius: '60%',
                center: ['50%', '45.5%'],
                label: {
                    formatter: "{d}%",
                    show:true,
                },
            data: [{
                value: duoi82,
                name: 'Huy động dưới 82%'

            },
            {
                value: tren82,
                name: 'Huy động trên 82%'
            }
            ]
        }]
    };
    basicpieChart.setOption(option);
$(function () {
    // Resize chart on menu width change and window resize
    $(window).on('resize', resize);
    $(".sidebartoggler").on('click', resize);
    // Resize function
    function resize() {
        setTimeout(function () {
            basicpieChart.resize();
           
        }, 200);
    }
});
});