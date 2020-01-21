$(document).ready(function () {
    resize();
})

$(window).bind("load", function () {
    setTimeout(function () { resize();}, 500)
})

$(window).resize(function () {
    resize();
})

function resize() {
    var w = $(".slide-show").innerWidth();
    var h = $(".slide-show").innerHeight();
    var iw = $(".title-welcome").innerWidth();
    var ih = $(".title-welcome").innerHeight() / 2;

    $(".title-welcome").css("left", ((w - iw) / 2));
    $(".title-welcome").css("top", ((h - ih) / 2));
}

function bookingRoom() {
    var data = {};
    data.email = $("#fastBookingEmail").val();
    data.fromDate = $("#fastBookingFromDate").val();
    data.toDate = $("#fastBookingToDate").val();
    data.typeRoom = $("#fastBookingTypeRoom > option:selected").text();
    data.unitCustomer = $("#fastBookingUnit > option:selected").val();

    $.post("/Services/BookingRoom", data, function (d) {
        if (d) {
            $("#modal-booking").modal();
        }
    });
}
