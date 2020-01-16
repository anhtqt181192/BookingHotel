"use strict";

const reducer = (accumulator, currentValue) => accumulator + currentValue;

function drawPieChart(idTarget, data) {

    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: data,
                backgroundColor: [
                    "#34bfa3",
                    "#ffb822",
                    "#adb1c7"
                ]
            }],
            labels: ['Chấm công', 'Chấm công trễ', 'Chưa chấm công']
        },
        options: {
            cutoutPercentage: 75,
            responsive: true,
            maintainAspectRatio: false,
            legend: {
                display: false,
                position: 'top',
            },
            title: {
                display: false,
                text: 'Technology'
            },
            animation: {
                animateScale: true,
                animateRotate: true
            },
            tooltips: {
                enabled: true,
                intersect: false,
                mode: 'nearest',
                bodySpacing: 5,
                yPadding: 10,
                xPadding: 10,
                caretPadding: 0,
                displayColors: false,
                backgroundColor: KTApp.getStateColor('brand'),
                titleFontColor: '#ffffff',
                cornerRadius: 4,
                footerSpacing: 0,
                titleSpacing: 0
            }
        }
    };

    var ctx = KTUtil.getByID(idTarget).getContext('2d');
    var myDoughnut = new Chart(ctx, config);
};

function dailySales() {
    var chartContainer = KTUtil.getByID('kt_chart_daily_sales');

    if (!chartContainer) {
        return;
    }

    var chartData = {
        labels: ["Ngày 1/7", "Ngày 2/7", "Ngày 3/7", "Ngày 4/7", "Ngày 5/7", "Ngày 6/7", "Ngày 7/7", "Ngày 8/7" ],
        datasets: [{
            //label: 'Dataset 1',
            backgroundColor: KTApp.getStateColor('success'),
            data: [
                20, 21, 21, 21, 18, 21, 12, 12
            ]
        }, {
            //label: 'Dataset 2',
            backgroundColor: '#ffb822',
            data: [
                1, 0, 0, 0, 2, 0, 7, 6
            ]
        }, {
            //label: 'Dataset 2',
            backgroundColor: '#f3f3fb',
            data: [
                0, 0, 0, 0, 1, 0, 2, 3
            ]
        }]
    };

    var chart = new Chart(chartContainer, {
        type: 'bar',
        data: chartData,
        options: {
            title: {
                display: true,
            },
            tooltips: {
                intersect: false,
                mode: 'nearest',
                xPadding: 10,
                yPadding: 10,
                caretPadding: 10
            },
            legend: {
                display: false
            },
            responsive: true,
            maintainAspectRatio: false,
            barRadius: 4,
            scales: {
                xAxes: [{
                    display: false,
                    gridLines: false,
                    stacked: true,
                }],
                yAxes: [{
                    display: true,
                    stacked: true,
                    gridLines: false
                }]
            },
            layout: {
                padding: {
                    left: 0,
                    right: 0,
                    top: 0,
                    bottom: 0
                }
            }
        }
    });
}

var KTDashboard = function () {
    return {
        init: function () {
            var loading = new KTDialog({ 'type': 'loader', 'placement': 'top center', 'message': 'Loading ...' });
            loading.show();

            setTimeout(function () {
                loading.hide();
            }, 3000);
        }
    };
}();


jQuery(document).ready(function () {
    KTDashboard.init();
    drawPieChart("kt_chart_1", [7, 2, 1]);
    drawPieChart("kt_chart_2", [6, 3, 2]);
    dailySales();
});
