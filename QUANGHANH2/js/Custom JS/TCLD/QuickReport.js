$(function () {
    var sparklineLogin = function () {  
        $("#sparklinedash5").sparkline([0, 23, 43, 35, 44, 45, 56, 37, 40, 45, 56, 7, 10], {
            type: 'line',
            width: '67',
            height: '30',
            lineColor: '#fb6d9d',
            fillColor: 'transparent',
            spotColor: '#fb6d9d',
            minSpotColor: undefined,
            maxSpotColor: undefined,
            highlightSpotColor: undefined,
            highlightLineColor: undefined
        });
        $("#sparklinedash6").sparkline([0, 23, 43, 35, 44, 45, 56, 37, 40, 45, 56, 7, 10], {
            type: 'line',
            width: '67',
            height: '30',
            lineColor: '#f5cf5d',
            fillColor: 'transparent',
            spotColor: '#f5cf5d',
            minSpotColor: undefined,
            maxSpotColor: undefined,
            highlightSpotColor: undefined,
            highlightLineColor: undefined
        });
        $("#sparklinedash7").sparkline([0, 2, 8, 6, 8, 5, 6, 4, 8, 6, 4, 2], {
            type: 'line',
            width: '67',
            height: '30',
            lineColor: '#ffca4a',
            fillColor: '#ffca4a',
            highlightLineColor: 'rgba(0, 0, 0, 0.2)',
            highlightSpotColor: '#4f4f4f'
        });
        $("#sparklinedash8").sparkline([0, 2, 8, 6, 8, 5, 6, 4, 8, 6, 4, 2], {
            type: 'line',
            width: '67',
            height: '30',
            lineColor: '#89dff5',
            fillColor: '#89dff5',
            minSpotColor: '#0db9bf',
            spotColor: '#0db9bf',
            maxSpotColor: '#0db9bf',
            highlightLineColor: 'rgba(0, 0, 0, 0.2)',
            highlightSpotColor: '#89dff5'
        });
        $('#sparklinedash9').sparkline([15, 23, 55, 35, 54, 45, 66, 47, 30], {
            type: 'line',
            width: '67',
            height: '30',
            chartRangeMax: 50,
            resize: true,
            minSpotColor: '#rgba(0,0,0,.1)',
            spotColor: '#rgba(0,0,0,.1)',
            maxSpotColor: '#rgba(0,0,0,.1)',
            lineColor: '#13dafe',
            fillColor: 'rgba(19, 218, 254, 0.3)',
            highlightLineColor: 'rgba(0,0,0,.1)',
            highlightSpotColor: 'rgba(0,0,0,.2)',
        });

        $('#sparklinedash9').sparkline([0, 13, 10, 14, 15, 10, 18, 20, 0], {
            type: 'line',
            width: '67',
            height: '30',
            chartRangeMax: 40,
            minSpotColor: '#rgba(0,0,0,.1)',
            spotColor: '#rgba(0,0,0,.1)',
            maxSpotColor: '#rgba(0,0,0,.1)',
            lineColor: '#6164c1',
            fillColor: 'rgba(97, 100, 193, 0.3)',
            composite: true,
            resize: true,
            highlightLineColor: 'rgba(0,0,0,.1)',
            highlightSpotColor: 'rgba(0,0,0,.2)',
        });      
    }
    var sparkResize;

    $(window).resize(function (e) {
        clearTimeout(sparkResize);
        sparkResize = setTimeout(sparklineLogin, 500);
    });
    sparklineLogin();

});