// ============================================================== 
    // Visitors
    // ============================================================== 
    var chart = c3.generate({
        bindto: '#visitor',
        data: {
            columns: [
                ['Bơm nước hầm lò', 2805204],
                ['Bơm nước lộ thiên', 551319]
            ],

            type: 'donut',
            onclick: function(d, i) { console.log("onclick", d, i); },
            onmouseover: function(d, i) { console.log("onmouseover", d, i); },
            onmouseout: function(d, i) { console.log("onmouseout", d, i); }
        },
        donut: {
            label: {
                show: false
            },

            width: 25,

        },

        legend: {
            hide: true
            //or hide: 'data1'
            //or hide: ['data1', 'data2']
        },
        color: {
            pattern: ['#40c4ff',  '#ff821c']
        }
    });