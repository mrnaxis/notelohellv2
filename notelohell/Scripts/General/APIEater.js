//The API Eater for OWAPI, This will be used for consuming the api and putting 
//the data in the screen. All data should be already treated within the limits 
//that JSON allow, the purpose in this file is the generic data that is returned
//Minify it before deploying in production.

function GetDataGeneral(gameTag, urlData) {
        $.ajax({
            type: "POST",
            url: urlData,
            data: JSON.stringify({ tag: gameTag }),
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            if (data !== null) {
                var returnData = JSON.parse(data);
                google.charts.load('current', { packages: ['corechart'] });
                google.charts.setOnLoadCallback(function () { GeneralGraphCall(); });
            }

            function GeneralGraphCall() {
                ConstructTheGraphsTimeHeroes(returnData);
            }
        },
        error: function () {
            alert("Deu Ruim!");
        }
    });
}

function ConstructTheGraphsTimeHeroes(d) {
    //copiei na cara dura msm, e vou adaptar
    // Create the data table.
       
    var dt = [['Heroes', 'Time']];
    var lin = d.us.heroes.playtime.quickplay;
    if (typeof lin !== 'undefined') {
        for (var i in lin) {
            if (lin.hasOwnProperty(i)) {
                dt.push([i,lin[i]]);
            }
        }
    }
    var data = new google.visualization.arrayToDataTable(dt);

    // Set chart options
    var options = {
        'title': 'Quanto Tempo foi Gasto em Cada Heroi?',
        'width': 500,
        'height': 600
    };

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.BarChart(document.getElementById('chart-time'));
    chart.draw(data, options);

    $("#chart-time").removeClass("hidden");
}