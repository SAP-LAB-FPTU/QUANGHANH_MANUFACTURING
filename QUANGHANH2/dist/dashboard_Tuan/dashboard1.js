/*
Template Name: Admin Pro Admin
Author: Wrappixel
Email: niravjoshi87@gmail.com
File: js
*/
$(function() {
    "use strict";

    // ============================================================== 
    // sales ratio
    // ============================================================== 
    var chart = new Chartist.Line('#sales', {
        labels: ['K1', 'K2', 'K3'],
        series: [
            [5,10,8],
            // [5,4,7]
        ]
    }, {
        high: 10,
        low: 0,
        showArea: true,
        fullWidth: true,
        plugins: [
            Chartist.plugins.tooltip()
        ], // As this is axis specific we need to tell Chartist to use whole numbers only on the concerned axis
        axisY: {
            onlyInteger: true,
            offset: 20,
            labelInterpolationFnc: function(value) {
                return (value / 1) + 'T';
            }
        }
    });

    // Offset x1 a tiny amount so that the straight stroke gets a bounding box
    // Straight lines don't get a bounding box 
    // Last remark on -> http://www.w3.org/TR/SVG11/coords.html#ObjectBoundingBox
    chart.on('draw', function(ctx) {
        if (ctx.type === 'area') {
            ctx.element.attr({
                x1: ctx.x1 + 0.001
            });
        }
    });

    // Create the gradient definition on created event (always after chart re-render)
    chart.on('created', function(ctx) {
        var defs = ctx.svg.elem('defs');
        defs.elem('linearGradient', {
            id: 'gradient',
            x1: 0,
            y1: 1,
            x2: 0,
            y2: 0
        }).elem('stop', {
            offset: 0,
            'stop-color': '#2ddeff'
        }).parent().elem('stop', {
            offset: 1,
            'stop-color': '#7f9bff'
        });
    });


    var chart = [chart];

    var sparklineLogin = function() {
        $('.spark-count').sparkline([4, 5, 0, 10, 9, 12, 4, 9, 4, 5, 3, 10, 9, 12, 10, 9], {
            type: 'bar',
            width: '100%',
            height: '70',
            barWidth: '2',
            resize: true,
            barSpacing: '6',
            barColor: '#a880fa'
        });

        $('.spark-count2').sparkline([20, 40, 30], {
            type: 'pie',
            height: '80',
            resize: true,
            sliceColors: ['#f370b0', '#a77ff9', '#f6d22f']
        });
    }
    var sparkResize;

    sparklineLogin();
});